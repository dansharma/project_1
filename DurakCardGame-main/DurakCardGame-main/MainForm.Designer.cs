namespace DurakCardGame
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PlayerHand = new FlowLayoutPanel();
            AIHand = new FlowLayoutPanel();
            Deck = new Button();
            PlayerRole_TEXT = new Label();
            AIRole_TEXT = new Label();
            Deck_Label = new Label();
            CardsInPlay = new FlowLayoutPanel();
            TrumpSuit_Picture = new PictureBox();
            TrumpSuit_TEXT = new Label();
            TakeCards_Btn = new Button();
            EndAttack_Btn = new Button();
            DeckCardCount_Text = new Label();
            UserMessage_Text = new Label();
            ((System.ComponentModel.ISupportInitialize)TrumpSuit_Picture).BeginInit();
            SuspendLayout();
            // 
            // PlayerHand
            // 
            PlayerHand.Anchor = AnchorStyles.Bottom;
            PlayerHand.BackColor = Color.Transparent;
            PlayerHand.Location = new Point(257, 533);
            PlayerHand.Margin = new Padding(3, 4, 3, 4);
            PlayerHand.Name = "PlayerHand";
            PlayerHand.Size = new Size(577, 100);
            PlayerHand.TabIndex = 0;
            // 
            // AIHand
            // 
            AIHand.Anchor = AnchorStyles.Top;
            AIHand.BackColor = Color.Transparent;
            AIHand.Location = new Point(257, 33);
            AIHand.Margin = new Padding(3, 4, 3, 4);
            AIHand.Name = "AIHand";
            AIHand.Size = new Size(577, 100);
            AIHand.TabIndex = 2;
            // 
            // Deck
            // 
            Deck.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Deck.BackColor = Color.Black;
            Deck.BackgroundImage = Properties.Resources.Back;
            Deck.BackgroundImageLayout = ImageLayout.Stretch;
            Deck.Location = new Point(57, 533);
            Deck.Margin = new Padding(3, 4, 3, 4);
            Deck.Name = "Deck";
            Deck.Size = new Size(57, 93);
            Deck.TabIndex = 3;
            Deck.UseVisualStyleBackColor = false;
            // 
            // PlayerRole_TEXT
            // 
            PlayerRole_TEXT.AutoSize = true;
            PlayerRole_TEXT.BackColor = Color.Transparent;
            PlayerRole_TEXT.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PlayerRole_TEXT.ForeColor = Color.White;
            PlayerRole_TEXT.Location = new Point(181, 504);
            PlayerRole_TEXT.Name = "PlayerRole_TEXT";
            PlayerRole_TEXT.Size = new Size(77, 20);
            PlayerRole_TEXT.TabIndex = 4;
            PlayerRole_TEXT.Text = "Attacking";
            PlayerRole_TEXT.TextAlign = ContentAlignment.MiddleCenter;
            PlayerRole_TEXT.Click += label1_Click;
            // 
            // AIRole_TEXT
            // 
            AIRole_TEXT.AutoSize = true;
            AIRole_TEXT.BackColor = Color.Transparent;
            AIRole_TEXT.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AIRole_TEXT.ForeColor = Color.White;
            AIRole_TEXT.Location = new Point(181, 12);
            AIRole_TEXT.Name = "AIRole_TEXT";
            AIRole_TEXT.Size = new Size(82, 20);
            AIRole_TEXT.TabIndex = 5;
            AIRole_TEXT.Text = "Defending";
            AIRole_TEXT.TextAlign = ContentAlignment.MiddleCenter;
            AIRole_TEXT.Click += label1_Click_1;
            // 
            // Deck_Label
            // 
            Deck_Label.AutoSize = true;
            Deck_Label.BackColor = Color.Transparent;
            Deck_Label.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Deck_Label.ForeColor = Color.White;
            Deck_Label.Location = new Point(65, 492);
            Deck_Label.Name = "Deck_Label";
            Deck_Label.Size = new Size(43, 20);
            Deck_Label.TabIndex = 6;
            Deck_Label.Text = "Deck";
            Deck_Label.TextAlign = ContentAlignment.MiddleCenter;
            Deck_Label.Click += label1_Click_2;
            // 
            // CardsInPlay
            // 
            CardsInPlay.Anchor = AnchorStyles.Bottom;
            CardsInPlay.BackColor = Color.Transparent;
            CardsInPlay.Location = new Point(304, 231);
            CardsInPlay.Margin = new Padding(3, 4, 3, 4);
            CardsInPlay.Name = "CardsInPlay";
            CardsInPlay.Size = new Size(472, 212);
            CardsInPlay.TabIndex = 1;
            // 
            // TrumpSuit_Picture
            // 
            TrumpSuit_Picture.BackgroundImage = Properties.Resources.Ace_C;
            TrumpSuit_Picture.BackgroundImageLayout = ImageLayout.Stretch;
            TrumpSuit_Picture.Location = new Point(57, 283);
            TrumpSuit_Picture.Margin = new Padding(3, 4, 3, 4);
            TrumpSuit_Picture.Name = "TrumpSuit_Picture";
            TrumpSuit_Picture.Size = new Size(57, 93);
            TrumpSuit_Picture.TabIndex = 7;
            TrumpSuit_Picture.TabStop = false;
            // 
            // TrumpSuit_TEXT
            // 
            TrumpSuit_TEXT.AutoSize = true;
            TrumpSuit_TEXT.BackColor = Color.Transparent;
            TrumpSuit_TEXT.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TrumpSuit_TEXT.ForeColor = Color.White;
            TrumpSuit_TEXT.Location = new Point(46, 231);
            TrumpSuit_TEXT.Name = "TrumpSuit_TEXT";
            TrumpSuit_TEXT.Size = new Size(86, 20);
            TrumpSuit_TEXT.TabIndex = 8;
            TrumpSuit_TEXT.Text = "Trump Suit";
            TrumpSuit_TEXT.TextAlign = ContentAlignment.MiddleCenter;
            TrumpSuit_TEXT.Click += TrumpSuit_TEXT_Click;
            // 
            // TakeCards_Btn
            // 
            TakeCards_Btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TakeCards_Btn.Location = new Point(841, 533);
            TakeCards_Btn.Margin = new Padding(3, 4, 3, 4);
            TakeCards_Btn.Name = "TakeCards_Btn";
            TakeCards_Btn.Size = new Size(86, 31);
            TakeCards_Btn.TabIndex = 9;
            TakeCards_Btn.Text = "Take Cards";
            TakeCards_Btn.UseVisualStyleBackColor = true;
            // 
            // EndAttack_Btn
            // 
            EndAttack_Btn.BackColor = SystemColors.Control;
            EndAttack_Btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EndAttack_Btn.Location = new Point(841, 603);
            EndAttack_Btn.Margin = new Padding(3, 4, 3, 4);
            EndAttack_Btn.Name = "EndAttack_Btn";
            EndAttack_Btn.Size = new Size(86, 31);
            EndAttack_Btn.TabIndex = 10;
            EndAttack_Btn.Text = "End Attack";
            EndAttack_Btn.UseVisualStyleBackColor = false;
            // 
            // DeckCardCount_Text
            // 
            DeckCardCount_Text.AutoSize = true;
            DeckCardCount_Text.BackColor = Color.Transparent;
            DeckCardCount_Text.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeckCardCount_Text.ForeColor = Color.White;
            DeckCardCount_Text.Location = new Point(78, 633);
            DeckCardCount_Text.Name = "DeckCardCount_Text";
            DeckCardCount_Text.Size = new Size(18, 20);
            DeckCardCount_Text.TabIndex = 11;
            DeckCardCount_Text.Text = "0";
            DeckCardCount_Text.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserMessage_Text
            // 
            UserMessage_Text.AutoSize = true;
            UserMessage_Text.BackColor = Color.Transparent;
            UserMessage_Text.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserMessage_Text.ForeColor = Color.Crimson;
            UserMessage_Text.Location = new Point(395, 182);
            UserMessage_Text.Name = "UserMessage_Text";
            UserMessage_Text.Size = new Size(0, 41);
            UserMessage_Text.TabIndex = 12;
            UserMessage_Text.TextAlign = ContentAlignment.MiddleCenter;
            UserMessage_Text.Click += label1_Click_3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.poker_background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1079, 668);
            Controls.Add(UserMessage_Text);
            Controls.Add(DeckCardCount_Text);
            Controls.Add(EndAttack_Btn);
            Controls.Add(TakeCards_Btn);
            Controls.Add(TrumpSuit_TEXT);
            Controls.Add(TrumpSuit_Picture);
            Controls.Add(CardsInPlay);
            Controls.Add(Deck_Label);
            Controls.Add(AIRole_TEXT);
            Controls.Add(PlayerRole_TEXT);
            Controls.Add(Deck);
            Controls.Add(PlayerHand);
            Controls.Add(AIHand);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "DurakCardGame";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)TrumpSuit_Picture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel PlayerHand;
        private FlowLayoutPanel AIHand;
        public Button Deck;
        public Label PlayerRole_TEXT;
        public Label AIRole_TEXT;
        private Label Deck_Label;
        private FlowLayoutPanel CardsInPlay;
        private PictureBox TrumpSuit_Picture;
        private Label TrumpSuit_TEXT;
        private Button TakeCards_Btn;
        private Button EndAttack_Btn;
        private Label DeckCardCount_Text;
        private Label UserMessage_Text;
    }
}
