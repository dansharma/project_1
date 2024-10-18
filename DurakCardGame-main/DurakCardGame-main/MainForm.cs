using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DurakCardGame
{
    public partial class MainForm : Form
    {
        public Game game;
        public MainForm()
        {
            InitializeComponent();
            game = new Game(this);
            TakeCards_Btn.Click += (object? sender, EventArgs e) => game.EndDefence(0);
            EndAttack_Btn.Click += (object? sender, EventArgs e) => game.EndAttack(0);
        }

        public void FillPlayerHand(List<Card> cards)
        {

            foreach (var card in cards)
            {
                // Get the resource stream for the card image
                string resourceName = card.GetSpritePath();
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        Button cardButton = new Button
                        {
                            Size = new Size(50, 70),
                            BackgroundImageLayout = ImageLayout.Stretch,
                            FlatStyle = FlatStyle.Flat,
                            BackColor = Color.Black,
                            BackgroundImage = Image.FromStream(stream)
                        };

                        cardButton.Click += (object? sender, EventArgs e) => CardButton_MouseClick(card, 0);
                        PlayerHand.Controls.Add(cardButton);
                        card.AssignedButton = cardButton;
                    }
                    else
                    {
                        MessageBox.Show($"Resource not found: {resourceName}");
                    }
                }
            }
        }

        public void RemoveCardFromPlayerHand(Card card, int playerIndex)
        {
            FlowLayoutPanel target = playerIndex == 0 ? PlayerHand : AIHand;
            target.Controls.Remove(card.AssignedButton);
            card.AssignedButton.Dispose();
        }

        public void AddCardToPlayerHand(Card card, int playerIndex)
        {
            FlowLayoutPanel target = playerIndex == 0 ? PlayerHand : AIHand;
            string resourceName = card.GetSpritePath();
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    Button cardButton = new Button
                    {
                        Size = new Size(50, 70),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Black,
                        BackgroundImage = Image.FromStream(stream)
                    };

                    cardButton.Click += (object? sender, EventArgs e) => CardButton_MouseClick(card, playerIndex);
                    target.Controls.Add(cardButton);
                    card.AssignedButton = cardButton;
                }
                else
                {
                    MessageBox.Show($"Resource not found: {resourceName}");
                }
            }
        }
        private void CardButton_MouseClick(Card card, int OwnerIndex)
        {
            game.PerformMove(card, OwnerIndex);
        }

        public void FillAIHand(List<Card> cards)
        {

            foreach (var card in cards)
            {
                // Get the resource stream for the card image
                string resourceName = card.GetSpritePath();
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        Button cardButton = new Button
                        {
                            Size = new Size(50, 70),
                            BackgroundImageLayout = ImageLayout.Stretch,
                            FlatStyle = FlatStyle.Flat,
                            BackColor = Color.Black,
                            BackgroundImage = Image.FromStream(stream)
                        };

                        AIHand.Controls.Add(cardButton);
                        cardButton.Click += (object? sender, EventArgs e) => CardButton_MouseClick(card, 1);
                        card.AssignedButton = cardButton;
                    }
                    else
                    {
                        MessageBox.Show($"Resource not found: {resourceName}");
                    }
                }
            }
        }

        public void DisplayTrumpCard(Card card)
        {
            string resourceName = card.GetSpritePath();
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    TrumpSuit_Picture.BackgroundImage = Image.FromStream(stream);
                    TrumpSuit_TEXT.Text = $"Trump Suit\n{card.ToString()}";
                }
                else
                {
                    MessageBox.Show($"Resource not found: {resourceName}");
                }
            }
        }


        public void PlayCardOnTable(Card card)
        {
            string resourceName = card.GetSpritePath();
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    Button cardButton = new Button
                    {
                        Size = new Size(50, 70),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Black,
                        BackgroundImage = Image.FromStream(stream)
                    };

                    CardsInPlay.Controls.Add(cardButton);
                    card.AssignedButton = cardButton;
                }
                else
                {
                    MessageBox.Show($"Resource not found: {resourceName}");
                }
            }
        }

        public void RemoveCardFromTable(Card card)
        {
            CardsInPlay.Controls.Remove(card.AssignedButton);
            card.AssignedButton.Dispose();
        }

        public void ClearCardFromTable()
        {
            // Remove all buttons from the FlowLayoutPanel
            foreach (Control control in CardsInPlay.Controls.OfType<Button>().ToList())
            {
                CardsInPlay.Controls.Remove(control);
                control.Dispose();
            }
        }

        public void UpdateDeckCardCount(int count)
        {
            DeckCardCount_Text.Text = $"{count}";
        }

        public void GameWon(int winnerIndex)
        {
            String winner = winnerIndex == 0 ? "Player" : "AI";
            UserMessage_Text.Text = $"{winner} Won the Game";
            winner = winnerIndex == 0 ? "Won" : "Lost";
            DialogResult result = MessageBox.Show($"You {winner} the Game", "Game End");
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void TrumpSuit_TEXT_Click(object sender, EventArgs e)
        {

        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SampleCard_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }
    }
}
