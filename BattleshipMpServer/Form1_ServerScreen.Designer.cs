namespace BattleshipMp
{
    partial class Form1_ServerScreen
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIpAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPort = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelServerState = new System.Windows.Forms.Label();
            this.buttonServerStart = new Guna.UI2.WinForms.Guna2GradientButton();
            this.buttonGoToBoard = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.Controls.Add(this.guna2PictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.buttonGoToBoard);
            this.guna2GradientPanel1.Controls.Add(this.buttonServerStart);
            this.guna2GradientPanel1.Controls.Add(this.labelServerState);
            this.guna2GradientPanel1.Controls.Add(this.textBoxPort);
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.Controls.Add(this.textBoxIpAddress);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.LightGray;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.Black;
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(851, 507);
            this.guna2GradientPanel1.TabIndex = 6;
            this.guna2GradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(105, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address:";
            // 
            // textBoxIpAddress
            // 
            this.textBoxIpAddress.BackColor = System.Drawing.Color.Transparent;
            this.textBoxIpAddress.BorderRadius = 15;
            this.textBoxIpAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxIpAddress.DefaultText = "";
            this.textBoxIpAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxIpAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxIpAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxIpAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxIpAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxIpAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxIpAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxIpAddress.Location = new System.Drawing.Point(252, 168);
            this.textBoxIpAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxIpAddress.Name = "textBoxIpAddress";
            this.textBoxIpAddress.PasswordChar = '\0';
            this.textBoxIpAddress.PlaceholderText = "";
            this.textBoxIpAddress.SelectedText = "";
            this.textBoxIpAddress.Size = new System.Drawing.Size(442, 36);
            this.textBoxIpAddress.TabIndex = 7;
            this.textBoxIpAddress.TextChanged += new System.EventHandler(this.textBoxIpAddress_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(164, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.BackColor = System.Drawing.Color.Transparent;
            this.textBoxPort.BorderRadius = 15;
            this.textBoxPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPort.DefaultText = "";
            this.textBoxPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxPort.Location = new System.Drawing.Point(252, 229);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.PasswordChar = '\0';
            this.textBoxPort.PlaceholderText = "";
            this.textBoxPort.SelectedText = "";
            this.textBoxPort.Size = new System.Drawing.Size(442, 36);
            this.textBoxPort.TabIndex = 7;
            this.textBoxPort.TextChanged += new System.EventHandler(this.textBoxPort_TextChanged);
            // 
            // labelServerState
            // 
            this.labelServerState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelServerState.AutoSize = true;
            this.labelServerState.BackColor = System.Drawing.Color.Transparent;
            this.labelServerState.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelServerState.Location = new System.Drawing.Point(286, 457);
            this.labelServerState.Name = "labelServerState";
            this.labelServerState.Size = new System.Drawing.Size(310, 29);
            this.labelServerState.TabIndex = 10;
            this.labelServerState.Text = "Waiting for the server to start.";
            // 
            // buttonServerStart
            // 
            this.buttonServerStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonServerStart.BorderRadius = 15;
            this.buttonServerStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonServerStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonServerStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonServerStart.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonServerStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonServerStart.FillColor = System.Drawing.Color.Black;
            this.buttonServerStart.FillColor2 = System.Drawing.Color.Red;
            this.buttonServerStart.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonServerStart.ForeColor = System.Drawing.Color.White;
            this.buttonServerStart.Location = new System.Drawing.Point(202, 300);
            this.buttonServerStart.Name = "buttonServerStart";
            this.buttonServerStart.Size = new System.Drawing.Size(492, 48);
            this.buttonServerStart.TabIndex = 11;
            this.buttonServerStart.Text = "Start Server";
            this.buttonServerStart.Click += new System.EventHandler(this.buttonServerStart_Click);
            // 
            // buttonGoToBoard
            // 
            this.buttonGoToBoard.BackColor = System.Drawing.Color.Transparent;
            this.buttonGoToBoard.BorderRadius = 15;
            this.buttonGoToBoard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonGoToBoard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonGoToBoard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonGoToBoard.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonGoToBoard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonGoToBoard.FillColor = System.Drawing.Color.Black;
            this.buttonGoToBoard.FillColor2 = System.Drawing.Color.Red;
            this.buttonGoToBoard.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGoToBoard.ForeColor = System.Drawing.Color.White;
            this.buttonGoToBoard.Location = new System.Drawing.Point(202, 369);
            this.buttonGoToBoard.Name = "buttonGoToBoard";
            this.buttonGoToBoard.Size = new System.Drawing.Size(492, 48);
            this.buttonGoToBoard.TabIndex = 12;
            this.buttonGoToBoard.Text = "Continue";
            this.buttonGoToBoard.Click += new System.EventHandler(this.buttonGoToBoard_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::BattleshipMp.Properties.Resources.kisspng_battleship_board_game_the_game_of_life_logo_game_logo_5ad240b56c37a3_0610637215237285654433;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(238, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(386, 71);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 13;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // Form1_ServerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(851, 507);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1_ServerScreen";
            this.Text = "Server Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_ServerScreen_FormClosed);
            this.Load += new System.EventHandler(this.Form1_ServerScreen_Load);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label labelServerState;
        private Guna.UI2.WinForms.Guna2TextBox textBoxPort;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox textBoxIpAddress;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton buttonGoToBoard;
        private Guna.UI2.WinForms.Guna2GradientButton buttonServerStart;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}

