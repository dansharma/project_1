namespace DurakCardGame
{
    public class Game
    {
        public List<Player> Players { get; }
        public Deck Deck { get; }
        public Card TrumpCard { get; private set; }
        public List<Card> Table { get; }
        public List<Card> DiscardPile { get; }
        public int CurrentAttacker { get; private set; }
        public int CurrentDefender { get; private set; }
        public int CurrentTurn { get; private set; }

        private MainForm _mainForm;

        public Game(MainForm mainForm)
        {
            _mainForm = mainForm;

            Players = new List<Player>();
            for (int i = 0; i < 2; i++)
            {
                Players.Add(i == 0 ? new Player() : new AIPlayer());
            }

            Deck = new Deck();
            Deck.CardDrawn += OnCardDrawn; // Subscribe to the event

            Table = new List<Card>();
            DiscardPile = new List<Card>();

            StartNewGame();
        }

        public void StartNewGame()
        {
            foreach (var player in Players)
            {
                player.Hand.Clear();
            }
            Deck.Shuffle();
            Table.Clear();
            DiscardPile.Clear();
            //AttacksThisTurn = 0;

            for (int i = 0; i < 6; i++)
            {
                foreach (var player in Players)
                {
                    player.DrawCard(Deck);
                }
            }

            TrumpCard = Deck.Draw();

            // Insert Trump Card to the end of the deck
            Deck.Add(TrumpCard);

            _mainForm.DisplayTrumpCard(TrumpCard);
            _mainForm.FillPlayerHand(Players[0].Hand);
            _mainForm.FillAIHand(Players[1].Hand);

            AIPlayer aIPlayer = Players[1] as AIPlayer;
            aIPlayer.EndAttack += EndAttack;
            aIPlayer.PickCards += EndDefence;
            aIPlayer.PerformMove += PerformMove;

            CurrentAttacker = DetermineFirstAttacker();
            CurrentDefender = (CurrentAttacker + 1) % Players.Count;
            CurrentTurn = CurrentAttacker;

            if (CurrentAttacker == 1) {
                aIPlayer.MakeMove(TrumpCard, Table, CurrentAttacker == 1);
            }
            UpdatePlayerRole_UI();
        }

        private void UpdatePlayerRole_UI()
        {
            bool isPlayerAttacking = CurrentAttacker == 0;
            _mainForm.PlayerRole_TEXT.Text = isPlayerAttacking ? "Player 1: Attacking" : "Player 1: Defending";
            _mainForm.AIRole_TEXT.Text = isPlayerAttacking ? "AI: Defending" : "AI: Attacking";
        }

        private int DetermineFirstAttacker()
        {
            int lowestTrumpValue = int.MaxValue;
            int attackerIndex = -1;

            for (int i = 0; i < Players.Count; i++)
            {
                foreach (var card in Players[i].Hand)
                {
                    if (card.Suit == TrumpCard.Suit && (int)card.Rank < lowestTrumpValue)
                    {
                        lowestTrumpValue = (int)card.Rank;
                        attackerIndex = i;
                    }
                }
            }

            return attackerIndex;
        }

        public void RemoveCardFromPlayerHand(Card card, int playerIndex)
        {
            Players[playerIndex].Hand.Remove(card);
            _mainForm.RemoveCardFromPlayerHand(card, playerIndex);
        }

        public void AddCardToPlayerHand(Card card, int playerIndex)
        {
            Players[playerIndex].Hand.Add(card);
            _mainForm.AddCardToPlayerHand(card, playerIndex);
        }

        public void GameWon(int winnerIndex) { 
            _mainForm.GameWon(winnerIndex);
        }
        public void ChangePlayerTurn() {
            if (Players[CurrentTurn].Hand.Count == 0) { 
                GameWon(CurrentTurn);
                return;
            }
            CurrentTurn = (CurrentTurn + 1) % Players.Count;
            if (CurrentTurn == 1)
            {
                AIPlayer aIPlayer = Players[1] as AIPlayer;
                aIPlayer.MakeMove(TrumpCard, Table, CurrentAttacker == 1);
            }
        }
        public void PerformMove(Card card, int Instigator)
        {
            // Perform Move if called by Current Turn Move
            if (Instigator == CurrentTurn)
            {
                // Check if its an First Attack 
                if (Table.Count == 0)
                {   // 1st Attack
                    Table.Add(card);
                    RemoveCardFromPlayerHand(card, Instigator);
                    _mainForm.PlayCardOnTable(card);
                    ChangePlayerTurn();
                }
                // Check if its an Attack 
                else if (CurrentTurn == CurrentAttacker)
                {   // Subsequent Attacks
                    foreach (var playedCard in Table)
                    {
                        if (playedCard.Rank == card.Rank)
                        {
                            Table.Add(card);
                            RemoveCardFromPlayerHand(card, Instigator);
                            _mainForm.PlayCardOnTable(card);

                            ChangePlayerTurn();
                            break;
                        }
                    }
                }
                // Check if its an Defence
                else if (CurrentTurn == CurrentDefender)
                {
                    // Defending
                    Card attackingCard = Table.Last();
                    if (attackingCard.Suit == card.Suit && card.Rank > attackingCard.Rank)
                    {
                        Table.Add(card);
                        RemoveCardFromPlayerHand(card, Instigator);
                        _mainForm.PlayCardOnTable(card);

                        ChangePlayerTurn();
                    }
                    else if (card.Suit == TrumpCard.Suit)
                    {
                        Table.Add(card);
                        RemoveCardFromPlayerHand(card, Instigator);
                        _mainForm.PlayCardOnTable(card);

                        ChangePlayerTurn();
                    }
                }
            }
        }

        public void EndDefence(int playerIndex) {
            //Player player = Players[playerIndex];
            if (CurrentTurn != playerIndex || playerIndex != CurrentDefender)
                return;
            foreach (var playedCard in Table){
                _mainForm.RemoveCardFromTable(playedCard);
                AddCardToPlayerHand(playedCard,playerIndex);
            }
            
            Table.Clear();
            ChangePlayerTurn();
            
            RefillPlayerHands();
        }

        public void EndAttack(int playerIndex) {
            if (CurrentTurn != playerIndex || playerIndex != CurrentAttacker)
                return;
            _mainForm.ClearCardFromTable();
            Table.Clear();

            CurrentAttacker = (CurrentTurn + 1) % Players.Count;
            CurrentDefender = (CurrentAttacker + 1) % Players.Count;

            ChangePlayerTurn();

            UpdatePlayerRole_UI();
            RefillPlayerHands();
        }

        public void RefillPlayerHands()
        {
            int i = 0;
            foreach (var player in Players)
            {
                while (player.Hand.Count < 6 && Deck.Count > 0)
                {
                    Card card = Deck.Draw();
                    player.Hand.Add(card);
                    _mainForm.AddCardToPlayerHand(card, i);
                }
                i++;
            }
        }

        public bool IsGameOver()
        {
            return Players.Any(player => player.Hand.Count == 0) || Deck.Count == 0;
        }

        public string GetWinner()
        {
            var losers = Players.Where(player => player.Hand.Count > 0).ToList();
            if (losers.Count == 1)
            {
                return Players.IndexOf(losers.First()) == 0 ? "Human" : "AI";
            }
            return null;
        }

        private void OnCardDrawn(int count) {
            _mainForm.UpdateDeckCardCount(count);
        }
    }
}
