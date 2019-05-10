using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RCZProjectorApp
{
    public partial class Form1 : Form
    {

        SQLiteConnection rczConnection = new SQLiteConnection("Data Source=rcz.db;Version=3;");
        DataTable dt;
        DataTable bdt;
        //DataTable qvs;
        string bibleBook;
        string bibleBhuku;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.WindowState = FormWindowState.Maximized;

            txtSearchChapter.Enabled = false;
            txtSearchVerse.Enabled = false;
            gridChapter.Enabled = false;
            gridVerse.Enabled = false;
            btnAddBibleToList.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //load the hymns
            loadHymns();

            //load the bible books
            loadBibleBooks();
            gridQuickVerses.Columns[1].Visible = false;
            gridQuickVerses.Columns[0].Width = 250;
            gridQuickVerses.Columns[2].Width = 65;

            if (Screen.AllScreens.Length > 1)
            {
                ProjectorForm frm = new ProjectorForm();
                frm.StartPosition = FormStartPosition.Manual;
                Screen screen = GetSecondaryScreen();
                frm.Location = screen.WorkingArea.Location;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            else
            {
                ProjectorForm frm = new ProjectorForm();
                frm.Show();
            }
        }

        private void loadHymns()
        {
            rczConnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = rczConnection;
            cmd.CommandText = "select hymn, title,derivation, favourite from hymns";

            using (SQLiteDataReader sdr = cmd.ExecuteReader())
            {
                dt = new DataTable();
                dt.Load(sdr);
                sdr.Close();
                rczConnection.Close();
                grid1.DataSource = dt;
            }
            grid1.Columns[1].Visible = false;
            grid1.Columns[4].Visible = false;
            grid1.Columns[5].Visible = false;
            grid1.Columns[2].Width = 30; 
            grid1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid1.ColumnHeadersVisible = false;
            grid1.RowHeadersVisible = false;

            grid1.Columns[2].DisplayIndex = 0;
            grid1.Columns[3].DisplayIndex = 1;
            grid1.Columns[0].DisplayIndex = 2;

        }

        private void loadBibleBooks()
        {
            rczConnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = rczConnection;
            cmd.CommandText = "select id, testament, bhuku, book from books";

            using (SQLiteDataReader sdr = cmd.ExecuteReader())
            {
                bdt = new DataTable();
                bdt.Load(sdr);
                sdr.Close();
                rczConnection.Close();
                bibleGrid.DataSource = bdt;
            }

            bibleGrid.Columns[0].Visible = false;
            bibleGrid.Columns[2].DisplayIndex = 0;
            bibleGrid.Columns[3].DisplayIndex = 1;
            bibleGrid.Columns[1].DisplayIndex = 2;
            bibleGrid.RowHeadersVisible = false;
            bibleGrid.ColumnHeadersVisible = false;
            bibleGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }


        public Screen GetSecondaryScreen()
        {
            if (Screen.AllScreens.Length == 1)
            {
                return null;
            }
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary == false)
                {
                    return screen;
                }
            }
            return null;
        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid1.Columns[e.ColumnIndex].Name == "addToList")
            {
                int i = grid1.SelectedCells[0].RowIndex;
                string sno = grid1.Rows[i].Cells[5].Value.ToString();
                string msg = "This id the Hymn: " + sno;
                MessageBox.Show(msg);
            }
            else if (grid1.Columns[e.ColumnIndex].Name == "viewInProjector")
            {
                int i = grid1.SelectedCells[0].RowIndex;
                string hymnId = grid1.Rows[i].Cells[2].Value.ToString();
                string title = grid1.Rows[i].Cells[3].Value.ToString();
                string derivation = grid1.Rows[i].Cells[4].Value.ToString();
                string msg = "Projector This id the Hymn: " + hymnId;
                if (CheckOpened("ProjectorForm"))
                {    
                    ProjectorForm frm = (ProjectorForm) GetForm("ProjectorForm");
                    string hymn = getHymn(hymnId);

                    string fullTitle = hymnId + ": " + title;
                    Debug.WriteLine(hymn);
                    frm.DisplayHtml(fullTitle, derivation, hymn);
                }
                else
                    MessageBox.Show("Testing 123");
            }
        }

        private string getHymn(string hymnIdString)
        {
            rczConnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = rczConnection;
            cmd.CommandText = "select * from lyrics where hymn = @hymnId order by stanza, sequence";
            cmd.Parameters.AddWithValue("@hymnId",hymnIdString);
            SQLiteDataReader sdr = cmd.ExecuteReader();
            string songData = "";

            long curStanza = 0;
            long oldStanza = 0;

            using (sdr)
            {
                while (sdr.Read())
                {
                    long hymn = (long)sdr["hymn"];
                    long stanza = (long)sdr["stanza"];
                    string subtitle = (string)sdr["subtitle"];
                    long sequence = (long)sdr["sequence"];
                    string words = (string)sdr["words"];

                    curStanza = stanza;
                    
                    if (curStanza != oldStanza)
                    {
                        if (oldStanza != 0)
                            songData = songData + "</p>";
                        oldStanza = curStanza;
                        songData = songData + "<h2>" + subtitle + "</h2><p class=\"bodyText\">" + words + " <br>";
                    }
                    else
                    {
                        songData = songData + words + "<br>";
                    }
                }
                songData = songData + "</p>";
            }
            rczConnection.Close();
            return songData;
        }
        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private Form GetForm(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return frm;
                }
            }
            return null;
        }

        private void SearchHymnText_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("CONVERT(hymn, System.String) like '%{0}%' Or title like '%{0}%'", searchHymnText.Text);
            if (searchHymnText.Text != defaultText)
            {
                grid1.DataSource = dv;
            }
        }

        private const string defaultText = "Search Hymn";

        private void SearchHymnText_GotFocus(object sender, EventArgs e)
        {
            searchHymnText.Text = searchHymnText.Text == defaultText ? string.Empty : searchHymnText.Text;
        }

        private void SearchHymnText_LostFocus(object sender, EventArgs e)
        {
            searchHymnText.Text = searchHymnText.Text == string.Empty ? defaultText : searchHymnText.Text;
        }

        private void TxtBibleSearch_TextChanged(object sender, EventArgs e)
        {
            DataView bdv = new DataView(bdt);
            bdv.RowFilter = string.Format(" bhuku like '%{0}%' Or book like '%{0}%'", txtBibleSearch.Text);
            if (txtBibleSearch.Text != defaultBibleText)
            {
                bibleGrid.DataSource = bdv;
            }
        }

        private const string defaultBibleText = "Search Book";

        private void TxtBibleSearch_GotFocus(object sender, EventArgs e)
        {
            txtBibleSearch.Text = txtBibleSearch.Text == defaultBibleText ? string.Empty : txtBibleSearch.Text;
        }

        private void TxtBibleSearch_LostFocus(object sender, EventArgs e)
        {
            txtBibleSearch.Text = txtBibleSearch.Text == string.Empty ? defaultBibleText : txtBibleSearch.Text;
        }

        private void BibleGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = bibleGrid.SelectedCells[0].RowIndex;
            gridChapter.Enabled = true;
            txtSearchChapter.Enabled = true;

            string bookId = bibleGrid.Rows[i].Cells[0].Value.ToString();
            bibleBook = bibleGrid.Rows[i].Cells[3].Value.ToString();
            bibleBhuku = bibleGrid.Rows[i].Cells[2].Value.ToString();

            loadChapters(bookId);

            gridVerse.DataSource = null;
            gridVerse.Enabled = false;
            btnAddBibleToList.Enabled = false;
            startingRow = 0;
            endingRow = 0;
            cntSelected = 0;
            selectedRowsPresent = false;
        }

        private const string defaultChapterText = "Chapter";
        private void TxtSearchChapter_TextChanged(object sender, EventArgs e)
        {
            DataView bdv = new DataView(cdt);
            bdv.RowFilter = string.Format(" CONVERT(chNum, System.String) like '%{0}%'", txtSearchChapter.Text);
            if (txtSearchChapter.Text != defaultChapterText)
            {
                gridChapter.DataSource = bdv;
            }
        }

        private void TxtSearchChapter_GotFocus(object sender, EventArgs e)
        {
            txtSearchChapter.Text = txtSearchChapter.Text == defaultChapterText ? string.Empty : txtSearchChapter.Text;
        }

        private void TxtSearchChapter_LostFocus(object sender, EventArgs e)
        {
            txtSearchChapter.Text = txtSearchChapter.Text == string.Empty ? defaultChapterText : txtSearchChapter.Text;
        }

        private const string defaultVerseText = "Verse";
        private void TxtSearchVerse_TextChanged(object sender, EventArgs e)
        {
            DataView bdv = new DataView(vdt);
            bdv.RowFilter = string.Format(" CONVERT(verseNum, System.String) like '%{0}%'", txtSearchVerse.Text);
            if (txtBibleSearch.Text != defaultVerseText)
            {
                gridVerse.DataSource = bdv;
            }
        }

        private void TxtSearchVerse_GotFocus(object sender, EventArgs e)
        {
            txtSearchVerse.Text = txtSearchVerse.Text == defaultVerseText ? string.Empty : txtSearchVerse.Text;
        }

        private void TxtSearchVerse_LostFocus(object sender, EventArgs e)
        {
            txtSearchVerse.Text = txtSearchVerse.Text == string.Empty ? defaultVerseText : txtSearchVerse.Text;
        }

        DataTable cdt;
        DataTable vdt;
        private void loadChapters(string bookId)
        {
            rczConnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = rczConnection;
            cmd.CommandText = "select distinct chNum, bookNum from bible where bookNum = @bookId";
            cmd.Parameters.AddWithValue("@bookId", bookId);

            using (SQLiteDataReader csdr = cmd.ExecuteReader())
            {
                cdt = new DataTable();
                cdt.Load(csdr);
                csdr.Close();
                rczConnection.Close();
                gridChapter.DataSource = cdt;
            }

            gridChapter.Columns[1].Visible = false;
            gridChapter.Columns[0].Width = 75;
            gridChapter.RowHeadersVisible = false;
            gridChapter.ColumnHeadersVisible = false;
            gridChapter.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void loadVerses(string bookId, string chapterId)
        {
            rczConnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = rczConnection;
            cmd.CommandText = "select wordId, bookNum, chNum, verseNum, word, izwi from bible where bookNum = @bookId and chNum = @chapterId";
            cmd.Parameters.AddWithValue("@bookId", bookId);
            cmd.Parameters.AddWithValue("@chapterId", chapterId);

            using (SQLiteDataReader sdr = cmd.ExecuteReader())
            {
                vdt = new DataTable();
                vdt.Load(sdr);
                sdr.Close();
                rczConnection.Close();
                gridVerse.DataSource = vdt;
            }

            gridVerse.Columns[0].Width = 41;
            gridVerse.Columns[1].Width = 85;
            gridVerse.Columns[2].Visible = false;
            gridVerse.Columns[3].Visible = false;
            gridVerse.Columns[4].Visible = false;
            gridVerse.Columns[5].Width = 41;
            gridVerse.Columns[6].Visible = false;
            gridVerse.Columns[7].Visible = false;
            gridVerse.Columns[0].DisplayIndex = 1;
            gridVerse.Columns[1].DisplayIndex = 2;
            gridVerse.Columns[5].DisplayIndex = 0;
            gridVerse.RowHeadersVisible = false;
            gridVerse.ColumnHeadersVisible = false;
            gridVerse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void GridChapter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = gridChapter.SelectedCells[0].RowIndex;
            gridVerse.Enabled = true;
            txtSearchVerse.Enabled = true;
            string bookId = gridChapter.Rows[i].Cells[1].Value.ToString();
            string chapterId = gridChapter.Rows[i].Cells[0].Value.ToString();

            loadVerses(bookId, chapterId);

            cntSelected = 0;
            startingRow = 0;
            endingRow = 0;
            selectedRowsPresent = false;
        }

        int cntSelected = 0;
        int startingRow = 0;
        int endingRow = 0;
        bool selectedRowsPresent = false;

        private void GridVerse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = gridVerse.SelectedCells[0].RowIndex;
            string bookId = gridVerse.Rows[i].Cells[3].Value.ToString();
            string chapterId = gridVerse.Rows[i].Cells[4].Value.ToString();
            string verseId = gridVerse.Rows[i].Cells[5].Value.ToString();
            string word = gridVerse.Rows[i].Cells[6].Value.ToString();
            string izwi = gridVerse.Rows[i].Cells[7].Value.ToString();
            btnAddBibleToList.Enabled = true;
            if (gridVerse.Columns[e.ColumnIndex].Name == "btnViewVerse")
            {
                string fullTitle = bibleBhuku + "/" + bibleBook + ": Chapter " + chapterId + ", Verse " + verseId;
                string reading = "<p class=\"bodyText\">" + izwi + "<br><br>" + word + "</p>";
                addQuickVerse(fullTitle, reading);
                showInProjector(fullTitle, reading);
                /*if (CheckOpened("ProjectorForm"))
                {
                    ProjectorForm frm = (ProjectorForm)GetForm("ProjectorForm");

                    string fullTitle = bibleBhuku + "/" + bibleBook + ": Chapter " + chapterId + ", Verse " + verseId;
                    string reading = "<p class=\"bodyText\">" + izwi + "<br><br>" + word + "</p>";
                    addQuickVerse(fullTitle, reading);
                    frm.DisplayHtml(fullTitle, "", reading);
                }
                else
                    MessageBox.Show(izwi);*/
            } else if (gridVerse.Columns[e.ColumnIndex].Name == "cbSelectedVs")
            {
                DataGridViewRow row = gridVerse.Rows[i];
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells["cbSelectedVs"];
                bool currentVal = Convert.ToBoolean(cell.Value);
                if (cntSelected > 0)
                {
                    selectedRowsPresent = true;
                }

                if (!currentVal)
                {
                    cntSelected = cntSelected + 1;
                }
                else
                {
                    cntSelected = cntSelected - 1;
                }
                    
                if (cntSelected > 2)
                {
                    MessageBox.Show("Select a maximum of 2 rows. One for Starting Verse and the Other for Last Verse.");
                    cntSelected = 2;
                }
                else
                {
                    gridVerse.Rows[i].Cells[e.ColumnIndex].Value = !currentVal;
                    if (cntSelected == 0)
                    {
                        startingRow = 0;
                        endingRow = 0;
                        selectedRowsPresent = false;
                    }
                    if (cntSelected == 1)
                    {
                        if (selectedRowsPresent)
                        {
                            foreach (DataGridViewRow grow in gridVerse.Rows)
                            {
                                if ((grow.Index >= startingRow) && (grow.Index <= endingRow))
                                {
                                    gridVerse.Rows[grow.Index].DefaultCellStyle.BackColor = Color.White;
                                }
                            }
                            endingRow = 0;
                        }
                        else
                            startingRow = i;
                    }
                    if (cntSelected == 2)
                    {
                        if (startingRow < i)
                        {
                            endingRow = i;
                        }
                        else
                        {
                            endingRow = startingRow;
                            startingRow = i;
                        }
                        
                        //highlight range of rows:
                        foreach (DataGridViewRow grow in gridVerse.Rows)
                        {
                            if ((grow.Index >= startingRow) && (grow.Index <= endingRow))
                            {
                                gridVerse.Rows[grow.Index].DefaultCellStyle.BackColor = Color.Blue;
                            }
                        }
                        btnAddBibleToList.Enabled = true;
                    }
                    else
                    {
                        btnAddBibleToList.Enabled = false;
                    }
                    
                }
            }
        }

        private void BtnAddBibleToList_Click(object sender, EventArgs e)
        {
            string words = "";
            string mazwi = "";
            string fullTitle = bibleBhuku + "/" + bibleBook;

            foreach (DataGridViewRow grow in gridVerse.Rows)
            {
                if ((grow.Index >= startingRow) && (grow.Index <= endingRow))
                {
                    string bookId = grow.Cells[3].Value.ToString();
                    string chapterId = grow.Cells[4].Value.ToString();
                    string verseId = grow.Cells[5].Value.ToString();
                    string word = grow.Cells[6].Value.ToString();
                    string izwi = grow.Cells[7].Value.ToString();

                    if (grow.Index == startingRow)
                    {
                        fullTitle = fullTitle + ": Chapter " + chapterId + ", Verses " + verseId + " to ";
                        mazwi = mazwi + "<ol start=\"" + verseId + "\">";
                        words = words + "<ol start=\"" + verseId + "\">";
                    }
                    mazwi = mazwi + "<li>" + izwi + "</li>";
                    words = words + "<li>" + word + "</li>";
                    if (grow.Index == endingRow)
                    {
                        fullTitle = fullTitle + verseId;
                        mazwi = mazwi + "</ol>";
                        words = words + "</ol>";
                    }
                }
            }

            string fullBody = "<p class=\"verseText\">" + mazwi + "<br>" + words + "</p>";
            addQuickVerse(fullTitle, fullBody);
        }

        private void addQuickVerse(string titleText, string bodyText)
        {
            DataGridViewRow row = new DataGridViewRow(); 
            DataGridViewTextBoxCell title = new DataGridViewTextBoxCell();

            title.Value = titleText;
            row.Cells.Add(title);
            DataGridViewTextBoxCell body = new DataGridViewTextBoxCell();
            body.Value = bodyText;
            row.Cells.Add(body);
            gridQuickVerses.Rows.Add(row);
        }

        private void addNotification(string titleText, string bodyText)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell title = new DataGridViewTextBoxCell();

            title.Value = titleText;
            row.Cells.Add(title);
            DataGridViewTextBoxCell body = new DataGridViewTextBoxCell();
            body.Value = bodyText;
            row.Cells.Add(body);
            gridNotifications.Rows.Add(row);
        }

        private void GridQuickVerses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = gridQuickVerses.SelectedCells[0].RowIndex;
            string title = gridQuickVerses.Rows[i].Cells[0].Value.ToString();
            string body = gridQuickVerses.Rows[i].Cells[1].Value.ToString();
            //btnAddBibleToList.Enabled = true;
            if (gridQuickVerses.Columns[e.ColumnIndex].Name == "btnViewVerses")
            {
                showInProjector(title, body);
                /*if (CheckOpened("ProjectorForm"))
                {
                    ProjectorForm frm = (ProjectorForm)GetForm("ProjectorForm");
                    frm.DisplayHtml(title, "", body);
                }
                else
                    MessageBox.Show(title);*/
            }
        }

        private void GridQuickVerses__CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.gridQuickVerses.Rows[e.RowIndex].Selected = true;
                this.qvRowIndex = e.RowIndex;
                this.gridQuickVerses.CurrentCell = this.gridQuickVerses.Rows[e.RowIndex].Cells[0];
                this.cmsBibleDelete.Show(this.gridQuickVerses, e.Location);
                cmsBibleDelete.Show(Cursor.Position);
            }
        }

        private void BtnNotificationAdd_Click(object sender, EventArgs e)
        {
            string title = txtNotificationTitle.Text.Trim();
            string body = txtNotificationBody.Text.Trim();

            if ((title == "Title") || (title == ""))
            {
                MessageBox.Show("Please enter a Title!");
                return;
            }

            if ((body == "Ziviso") || (body == ""))
            {
                MessageBox.Show("Please enter some Ziviso Text!");
                return;
            }

            addNotification(title, body);

            txtNotificationBody.Text = "Ziviso";
            txtNotificationTitle.Text = "Title";
            btnShowAllNotifications.Enabled = true;
        }

        private void GridNotifications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = gridNotifications.SelectedCells[0].RowIndex;
            string title = gridNotifications.Rows[i].Cells[0].Value.ToString();
            string body = gridNotifications.Rows[i].Cells[1].Value.ToString();
            //btnAddBibleToList.Enabled = true;
            if (gridNotifications.Columns[e.ColumnIndex].Name == "btnShowNotification")
            {
                body = "<p class=\"bodyText\">" + body + "</p>";
                title = "Ziviso: " + title;
                showInProjector(title, body);
            }

        }

        private void BtnShowAllNotifications_Click(object sender, EventArgs e)
        {
            string fullTitle = "Ziviso";
            string fullBody = "";
            foreach (DataGridViewRow grow in gridNotifications.Rows)
            {
                string title = grow.Cells[0].Value.ToString();
                string body = grow.Cells[1].Value.ToString();

                fullBody = fullBody + "<h2>" + title + "</h2><p class=\"bodyText\">" + body + " </p>";

            }

            showInProjector(fullTitle, fullBody);

        }

        private void showInProjector(string title, string body)
        {
            if (CheckOpened("ProjectorForm"))
            {
                ProjectorForm frm = (ProjectorForm)GetForm("ProjectorForm");
                frm.DisplayHtml(title, "", body);
            }
            else
                MessageBox.Show("No Projector Connection");  
        }

        private void GridNotifications__CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.gridNotifications.Rows[e.RowIndex].Selected = true;
                this.nRowIndex = e.RowIndex;
                this.gridNotifications.CurrentCell = this.gridNotifications.Rows[e.RowIndex].Cells[0];
                this.cmsNotificationDelete.Show(this.gridNotifications, e.Location);
                cmsNotificationDelete.Show(Cursor.Position);
            }
        }

        private int qvRowIndex = 0;
        private int nRowIndex = 0;
        private void CmsBibleDelete_Click(object sender, EventArgs e)
        {
            if (!this.gridQuickVerses.Rows[this.qvRowIndex].IsNewRow)
            {
                this.gridQuickVerses.Rows.RemoveAt(this.qvRowIndex);
            }
        }

        private void CmsNotificationDelete_Click(object sender, EventArgs e)
        {
            if (!this.gridNotifications.Rows[this.nRowIndex].IsNewRow)
            {
                this.gridNotifications.Rows.RemoveAt(this.nRowIndex);
            }
        }

        private const string defaultNotificationTitleText = "Title";
        private void TxtNotificationTitle_TextChanged(object sender, EventArgs e)
        {

        }     

        private void TxtNotificationTitle_GotFocus(object sender, EventArgs e)
        {
            txtNotificationTitle.Text = txtNotificationTitle.Text == defaultNotificationTitleText ? string.Empty : txtNotificationTitle.Text;
        }

        private void TxtNotificationTitle_LostFocus(object sender, EventArgs e)
        {
            txtNotificationTitle.Text = txtNotificationTitle.Text == string.Empty ? defaultNotificationTitleText : txtNotificationTitle.Text;
        }

        private const string defaultNotificationBodyText = "Ziviso";

        private void TxtNotificationBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNotificationBody_GotFocus(object sender, EventArgs e)
        {
            txtNotificationBody.Text = txtNotificationBody.Text == defaultNotificationBodyText ? string.Empty : txtNotificationBody.Text;
        }

        private void TxtNotificationBody_LostFocus(object sender, EventArgs e)
        {
            txtNotificationBody.Text = txtNotificationBody.Text == string.Empty ? defaultNotificationBodyText : txtNotificationBody.Text;
        }

        private void BibleGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
