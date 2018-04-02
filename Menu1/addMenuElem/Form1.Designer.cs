namespace addMenuElem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTopLevelMenu = new System.Windows.Forms.TextBox();
            this.txtSubItem = new System.Windows.Forms.TextBox();
            this.btnMenuItem = new System.Windows.Forms.Button();
            this.btnSubItem = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // txtTopLevelMenu
            // 
            this.txtTopLevelMenu.Location = new System.Drawing.Point(41, 70);
            this.txtTopLevelMenu.Name = "txtTopLevelMenu";
            this.txtTopLevelMenu.Size = new System.Drawing.Size(178, 20);
            this.txtTopLevelMenu.TabIndex = 0;
            // 
            // txtSubItem
            // 
            this.txtSubItem.Location = new System.Drawing.Point(41, 153);
            this.txtSubItem.Name = "txtSubItem";
            this.txtSubItem.Size = new System.Drawing.Size(178, 20);
            this.txtSubItem.TabIndex = 1;
            // 
            // btnMenuItem
            // 
            this.btnMenuItem.Location = new System.Drawing.Point(272, 67);
            this.btnMenuItem.Name = "btnMenuItem";
            this.btnMenuItem.Size = new System.Drawing.Size(152, 23);
            this.btnMenuItem.TabIndex = 2;
            this.btnMenuItem.Text = "Добавить пункт меню";
            this.btnMenuItem.UseVisualStyleBackColor = true;
            this.btnMenuItem.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnSubItem
            // 
            this.btnSubItem.Location = new System.Drawing.Point(272, 150);
            this.btnSubItem.Name = "btnSubItem";
            this.btnSubItem.Size = new System.Drawing.Size(152, 23);
            this.btnSubItem.TabIndex = 3;
            this.btnSubItem.Text = "Добавить пункт подменю";
            this.btnSubItem.UseVisualStyleBackColor = true;
            this.btnSubItem.Click += new System.EventHandler(this.btnSubItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(464, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 227);
            this.Controls.Add(this.btnSubItem);
            this.Controls.Add(this.btnMenuItem);
            this.Controls.Add(this.txtSubItem);
            this.Controls.Add(this.txtTopLevelMenu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTopLevelMenu;
        private System.Windows.Forms.TextBox txtSubItem;
        private System.Windows.Forms.Button btnMenuItem;
        private System.Windows.Forms.Button btnSubItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

