using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu1
{
    public partial class Form1 : Form
    {
        bool isNewFile = true;
        string fileName;
        ToolBar toolBar;
        ImageList imageList;
        ToolBarButton newFile;
        ToolBarButton open;
        ToolBarButton save;
        ToolBarButton copy;
        ToolBarButton cut;
        ToolBarButton paste;
        ToolBarButton undo;
        ToolBarButton paint;
        ToolBarButton separator;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            this.Text = fileName;
            richTextBox1.SelectionChanged += richTextBox1_SelectionChanged;
            copyToolStripMenuItem1.Click += copyToolStripMenuItem_Click;
            cutToolStripMenuItem1.Click += cutToolStripMenuItem_Click;
            pasteToolStripMenuItem1.Click += pasteToolStripMenuItem_Click;
            cancelToolStripMenuItem1.Click += cancelToolStripMenuItem_Click;
            imageList = new ImageList();
            imageList.ImageSize = new Size(24, 24);
            imageList.Images.Add(Image.FromFile("new.png"));
            imageList.Images.Add(Image.FromFile("open.png"));
            imageList.Images.Add(Image.FromFile("save.png"));
            imageList.Images.Add(Image.FromFile("copy.png"));
            imageList.Images.Add(Image.FromFile("cut.png"));
            imageList.Images.Add(Image.FromFile("paste.png"));
            imageList.Images.Add(Image.FromFile("undo.png"));
            imageList.Images.Add(Image.FromFile("Paint.png"));
            toolBar = new ToolBar();
            toolBar.ImageList = imageList;
            newFile = new ToolBarButton();
            open = new ToolBarButton();
            save = new ToolBarButton();
            copy = new ToolBarButton();
            cut = new ToolBarButton();
            paste = new ToolBarButton();
            undo = new ToolBarButton();
            paint = new ToolBarButton();
            separator = new ToolBarButton();
            separator.Style = ToolBarButtonStyle.Separator;
            newFile.ImageIndex = 0;
            open.ImageIndex = 1;
            save.ImageIndex = 2;
            copy.ImageIndex = 3;
            cut.ImageIndex = 4;
            paste.ImageIndex = 5;
            undo.ImageIndex = 6;
            paint.ImageIndex = 7;
            toolBar.Buttons.AddRange(new ToolBarButton[]{newFile,separator,open,separator,save,separator,
                                                        copy,separator,cut,separator,paste,separator,undo,separator,paint});
            toolBar.Appearance = ToolBarAppearance.Flat;
            toolBar.BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(toolBar);
            toolBar.BringToFront();
            toolBar.ShowToolTips = true;
            newFile.ToolTipText = "Новый файл";
            open.ToolTipText = "Открыть";
            save.ToolTipText = "Сохранить";
            copy.ToolTipText = "Копировать";
            cut.ToolTipText = "Вырезать";
            paste.ToolTipText = "Вставить";
            undo.ToolTipText = "Отменить";
            paint.ToolTipText = "Цвет фона";
            save.Enabled = false;
            copy.Enabled = false;
            cut.Enabled = false;
            paste.Enabled = false;
            paint.Enabled = false;
            toolBar.ButtonClick += toolBar_ButtonClick;
        }

        void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            OpenFileDialog open;
            switch (e.Button.ImageIndex)
            {
                case 0:
                    enabledMenu();
                    isNewFile = true;
                    fileName = "";
                    this.Text = fileName;
                    backgroundToolStripMenuItem.Enabled = true;
                    paint.Enabled = true;
                    break;
                case 1:
                    enabledMenu();
                    open = new OpenFileDialog();
                    open.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                    if (open.ShowDialog() == DialogResult.Cancel)
                        return;
                    fileName = open.FileName;
                    richTextBox1.Text = System.IO.File.ReadAllText(fileName);
                    isNewFile = false;
                    this.Text = fileName;
                    backgroundToolStripMenuItem.Enabled = true;
                    paint.Enabled = true;
                    break;
                case 2:
                    System.IO.File.WriteAllText(fileName, richTextBox1.Text);
                    this.Text = fileName;
                    break;
                case 3:
                    pasteToolStripMenuItem.Enabled = true;
                    pasteToolStripMenuItem1.Enabled = true;
                    paste.Enabled = true;
                    richTextBox1.Copy();
                    break;
                case 4:
                    pasteToolStripMenuItem.Enabled = true;
                    pasteToolStripMenuItem1.Enabled = true;
                    paste.Enabled = true;
                    richTextBox1.Cut();
                    break;
                case 5:
                    richTextBox1.Paste();
                    break;
                case 6:
                    richTextBox1.Undo();
                    break;
                case 7:
                    ColorDialog colorDialog1 = new ColorDialog();
                    if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    richTextBox1.BackColor = colorDialog1.Color;
                    break;
                default:
                    break;
            }
        }

        void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                copyToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                colorToolStripMenuItem.Enabled = true;
                fontToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem1.Enabled = true;
                cutToolStripMenuItem1.Enabled = true;
                copy.Enabled = true;
                cut.Enabled = true;
            }
            else
            {
                copyToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                colorToolStripMenuItem.Enabled = false;
                fontToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem1.Enabled = false;
                cutToolStripMenuItem1.Enabled = false;
                copy.Enabled = false;
                cut.Enabled = false;
            }
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enabledMenu();
            isNewFile = true;
            fileName = "";
            this.Text = fileName;
            backgroundToolStripMenuItem.Enabled = true;
            paint.Enabled = true;
        }
        void enabledMenu()
        {
            richTextBox1.Visible = true;
            richTextBox1.Clear();
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            if (!isNewFile)
            {
                saveToolStripMenuItem.Enabled = true;
                save.Enabled = true;
            }
            else
            {
                saveToolStripMenuItem.Enabled = false;
                save.Enabled = false;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enabledMenu();
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (open.ShowDialog() == DialogResult.Cancel)
                return;
            fileName = open.FileName;
            richTextBox1.Text = System.IO.File.ReadAllText(fileName);
            isNewFile = false;
            this.Text = fileName;
            backgroundToolStripMenuItem.Enabled = true;
            paint.Enabled = true;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.Cancel)
                return;
            fileName = save.FileName;
            System.IO.File.WriteAllText(save.FileName, richTextBox1.Text);
            isNewFile = false;
            this.Text = fileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(fileName, richTextBox1.Text);
            this.Text = fileName;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
                return;
            richTextBox1.SelectAll();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.Enabled = true;
            pasteToolStripMenuItem1.Enabled = true;
            paste.Enabled = true;
            richTextBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.Enabled = true;
            pasteToolStripMenuItem1.Enabled = true;
            paste.Enabled = true;
            richTextBox1.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            richTextBox1.BackColor = colorDialog1.Color;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            richTextBox1.SelectionFont = fontDialog1.Font;
        }
    }
}
