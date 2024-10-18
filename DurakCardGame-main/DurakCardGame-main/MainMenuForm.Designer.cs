namespace DurakCardGame
{
    partial class MainMenuForm
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
            MainMenu_Label = new Label();
            Play_Btn = new Button();
            SuspendLayout();
            // 
            // MainMenu_Label
            // 
            MainMenu_Label.AutoSize = true;
            MainMenu_Label.BackColor = Color.Transparent;
            MainMenu_Label.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MainMenu_Label.ForeColor = Color.White;
            MainMenu_Label.Location = new Point(150, 58);
            MainMenu_Label.Name = "MainMenu_Label";
            MainMenu_Label.Size = new Size(512, 81);
            MainMenu_Label.TabIndex = 0;
            MainMenu_Label.Text = "Durak Card Game";
            MainMenu_Label.Click += label1_Click;
            // 
            // Play_Btn
            // 
            Play_Btn.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Play_Btn.Location = new Point(316, 214);
            Play_Btn.Name = "Play_Btn";
            Play_Btn.Size = new Size(146, 60);
            Play_Btn.TabIndex = 1;
            Play_Btn.Text = "Play";
            Play_Btn.UseVisualStyleBackColor = true;
            Play_Btn.Click += Play_Btn_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.MainMenu_Background;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(800, 450);
            Controls.Add(Play_Btn);
            Controls.Add(MainMenu_Label);
            Name = "MainMenuForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MainMenu_Label;
        private Button Play_Btn;
    }
}