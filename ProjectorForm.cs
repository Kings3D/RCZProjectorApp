using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCZProjectorApp
{
    public partial class ProjectorForm : Form
    {
        TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlPanel;
        public ProjectorForm()
        {
            InitializeComponent();
        }

        private void ProjectorForm_Load(object sender, EventArgs e)
        {

        }

        private void DisplayImage()
        {
            PictureBox imageControl = new PictureBox();
            imageControl.Width = 400;
            imageControl.Height = 400;
            Bitmap image = new Bitmap("screenPic.jpg");
            imageControl.Dock = DockStyle.Fill;
            imageControl.Image = (Image)image;
            imageControl.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(imageControl);
        }

        public void DisplayHtml(string title, string derivation, string txt)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name == "ShowHtml")
                {
                    // check ctrl.Name
                    ctrl.Dispose();
                }
            }
            htmlPanel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            htmlPanel.Name = "ShowHtml";
            htmlPanel.UseGdiPlusTextRendering = true;

            /*htmlPanel.Dock = DockStyle.Fill;
            htmlPanel.Location = new Point(0, 0);
            //groupBox1.Controls.Add(htmlPanel);
            Controls.Add(htmlPanel);*/
            htmlPanel.AutoScroll = true;
            htmlPanel.AutoScrollMinSize = new Size(278, 20);
            htmlPanel.BackColor = Color.Transparent;
            htmlPanel.BaseStylesheet = null;
            htmlPanel.Cursor = Cursors.IBeam;
            htmlPanel.Location = new Point(8, 25);
            //htmlPanel.Name = "htmlBody";
            //htmlPanel.Size = new System.Drawing.Size(278, 96);
            htmlPanel.TabIndex = 2;
            //htmlPanel.Text = "<!doctype html><html><head><meta charset=\"UTF-8\"><style>html,body{width:100%;height:100%;margin:0;padding:0;}body{margin:0 5px;font-size:14px;border:1px;}h1{font-size:16px;font-weight:normal;margin:0;padding:0 0 4px 0;}</style></head><body>" + txt + "</body></html>";
            /*htmlPanel.AutoScroll = false;
            htmlPanel.IsSelectionEnabled = false;*/
            htmlPanel.Dock = DockStyle.Fill;
            //htmlPanel.Text = "";

            htmlPanel.Text = "<!doctype html> <html> <head> <meta charset=\"UTF-8\"> <style> #banner { background-color: #88ADE9; height: 200px; text-align: center; padding-top: 100px; } #copyright { width: 100%; text-align: center; } html { width:100%; height:100%; margin:0; padding:0; align-content: center; align-items: center; } body { width:100%; height:100%; margin:20px 40px; background-color: #BCD2CE; opacity: 30; align-self: center; text-align: center; } h1 { font-weight:bolder; color: #276B27; margin: 0px; line-height: 100px; font-size: 4.0em; } h2 { padding-left: 5px; font-weight:bold; color: #276B27; font-size: 3.0em; } .bodyText { color: #080847; padding-left: 20px; padding-right: 20px; font-weight: 700; font-size: 2.5em; } .verseText { text-align: left; color: #080847; padding-left: 20px; padding-right: 20px; font-weight: 700; font-size: 2.5em; } [class=\"bodyText\"]  {font-size: 100px; } </style> </head> <body> <div id=\"banner\"> <h1>" + title + "</h1> <h2></h2> </div> " + txt + " <div id=\"copyright\">RCZ Kambuzuma &copy;</div> </body> </html>";
            Controls.Add(htmlPanel);
        }

        public void DisplayText(string txt, int fsize)
        {

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name == "ShowText")
                {
                    // check ctrl.Name
                    ctrl.Dispose();
                }
            }

            TextBox txtLabel = new TextBox();
            txtLabel.Name = "ShowText";
            txtLabel.Text = txt;// Regex.Replace(txt, "(.{20})", "$1\n");
            txtLabel.Dock = DockStyle.Fill;
            txtLabel.ScrollBars = ScrollBars.Vertical;
            txtLabel.TextAlign = HorizontalAlignment.Center;
            txtLabel.AcceptsReturn = true;
            txtLabel.Multiline = true;
            txtLabel.AcceptsTab = true;
            txtLabel.ReadOnly = true;
            txtLabel.WordWrap = true;
            txtLabel.Font = new Font("Georgia", fsize);
            txtLabel.ForeColor = Color.Black;

            Controls.Add(txtLabel);
        }

    }
}
