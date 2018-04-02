using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace addMenuElem
{
    public partial class Form1 : Form
    {
        ToolStripMenuItem item;
        public Form1()
        {
            InitializeComponent();
            item = new ToolStripMenuItem();
        }

        private void btnMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem temp = new ToolStripMenuItem(txtTopLevelMenu.Text);
            item = temp;
            menuStrip1.Items.Add(item);
            txtTopLevelMenu.Clear();
        }

        private void btnSubItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Items.Remove(item);
            item.DropDownItems.Add(new ToolStripMenuItem(txtSubItem.Text));
            menuStrip1.Items.Add(item);
            txtSubItem.Clear();
        }
    }
}
