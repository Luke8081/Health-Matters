
namespace Health_Matters
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.Username_textBox = new System.Windows.Forms.TextBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.create_account_label = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.user_message = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(105, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Health Advice Group";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Username_textBox
            // 
            this.Username_textBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Username_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Username_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_textBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.Username_textBox.Location = new System.Drawing.Point(136, 300);
            this.Username_textBox.Name = "Username_textBox";
            this.Username_textBox.Size = new System.Drawing.Size(204, 28);
            this.Username_textBox.TabIndex = 6;
            this.Username_textBox.Text = "Username";
            this.Username_textBox.Click += new System.EventHandler(this.Username_textBox_click);
            // 
            // Password_textBox
            // 
            this.Password_textBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Password_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_textBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.Password_textBox.Location = new System.Drawing.Point(138, 393);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.Size = new System.Drawing.Size(204, 28);
            this.Password_textBox.TabIndex = 7;
            this.Password_textBox.Text = "Password";
            this.Password_textBox.Click += new System.EventHandler(this.Password_textBox_click);
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.Color.SteelBlue;
            this.login_button.BackgroundImage = global::Health_Matters.Properties.Resources.dark_blue;
            this.login_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.login_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.login_button.Location = new System.Drawing.Point(178, 490);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(125, 42);
            this.login_button.TabIndex = 8;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = false;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(108, 570);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Don\'t have an account?";
            // 
            // create_account_label
            // 
            this.create_account_label.AutoSize = true;
            this.create_account_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.create_account_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_account_label.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.create_account_label.Location = new System.Drawing.Point(277, 570);
            this.create_account_label.Name = "create_account_label";
            this.create_account_label.Size = new System.Drawing.Size(110, 18);
            this.create_account_label.TabIndex = 10;
            this.create_account_label.Text = "Create Account";
            this.create_account_label.Click += new System.EventHandler(this.load_create_form);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Health_Matters.Properties.Resources._lock;
            this.pictureBox5.Location = new System.Drawing.Point(78, 368);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(52, 53);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Health_Matters.Properties.Resources.user;
            this.pictureBox4.Location = new System.Drawing.Point(78, 285);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(52, 43);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Health_Matters.Properties.Resources.dark_blue;
            this.pictureBox3.Location = new System.Drawing.Point(78, 427);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(342, 10);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Health_Matters.Properties.Resources.dark_blue;
            this.pictureBox2.Location = new System.Drawing.Point(78, 334);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(342, 10);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Health_Matters.Properties.Resources.cross;
            this.pictureBox1.Location = new System.Drawing.Point(151, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // user_message
            // 
            this.user_message.BackColor = System.Drawing.Color.Red;
            this.user_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.user_message.Cursor = System.Windows.Forms.Cursors.Default;
            this.user_message.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.user_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_message.ForeColor = System.Drawing.Color.Silver;
            this.user_message.Location = new System.Drawing.Point(78, 215);
            this.user_message.Name = "user_message";
            this.user_message.Padding = new System.Windows.Forms.Padding(5);
            this.user_message.Size = new System.Drawing.Size(342, 37);
            this.user_message.TabIndex = 25;
            this.user_message.Text = "user_message";
            this.user_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(494, 617);
            this.Controls.Add(this.user_message);
            this.Controls.Add(this.create_account_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Username_textBox);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox Username_textBox;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label create_account_label;
        private System.Windows.Forms.Label user_message;
    }
}

