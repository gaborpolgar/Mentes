namespace restapi3
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bekertIdTextBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.felhasznalonevTextBox = new System.Windows.Forms.TextBox();
            this.jelszoTextBox = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 69);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "GET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.getToys_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(47, 130);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "GET + id";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.getToyWithId);
            // 
            // bekertIdTextBox
            // 
            this.bekertIdTextBox.Location = new System.Drawing.Point(191, 130);
            this.bekertIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.bekertIdTextBox.Name = "bekertIdTextBox";
            this.bekertIdTextBox.Size = new System.Drawing.Size(132, 22);
            this.bekertIdTextBox.TabIndex = 3;
            this.bekertIdTextBox.Text = "Ide írd az id-t!";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(521, 15);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1200, 596);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(47, 187);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 5;
            this.button3.Text = "POST (ADD)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.toyAddClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(47, 246);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 6;
            this.button4.Text = "DELETE";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.deleteByIdClick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(47, 305);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 33);
            this.button5.TabIndex = 7;
            this.button5.Text = "Módosít (PUT)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.updateToyClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(191, 250);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Mit töröljek (id)?";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(191, 191);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 22);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "id";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(345, 176);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(132, 22);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "jatek neve";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // felhasznalonevTextBox
            // 
            this.felhasznalonevTextBox.Location = new System.Drawing.Point(345, 208);
            this.felhasznalonevTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.felhasznalonevTextBox.Name = "felhasznalonevTextBox";
            this.felhasznalonevTextBox.Size = new System.Drawing.Size(132, 22);
            this.felhasznalonevTextBox.TabIndex = 11;
            this.felhasznalonevTextBox.Text = "Felhasználónév";
            // 
            // jelszoTextBox
            // 
            this.jelszoTextBox.Location = new System.Drawing.Point(345, 240);
            this.jelszoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.jelszoTextBox.Name = "jelszoTextBox";
            this.jelszoTextBox.Size = new System.Drawing.Size(132, 22);
            this.jelszoTextBox.TabIndex = 12;
            this.jelszoTextBox.Text = "jelszó";
            this.jelszoTextBox.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(345, 288);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(132, 28);
            this.button6.TabIndex = 13;
            this.button6.Text = "BEJELENTKEZÉS";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.bejelentkezesClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 489);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.jelszoTextBox);
            this.Controls.Add(this.felhasznalonevTextBox);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.bekertIdTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "REST client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox bekertIdTextBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox felhasznalonevTextBox;
        private System.Windows.Forms.TextBox jelszoTextBox;
        private System.Windows.Forms.Button button6;
    }
}

