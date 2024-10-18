namespace DurakCardGame
{
    public class AIPlayer : Player
    {
        public delegate void EndAttackEventHandler(int playerIndex);
        public event EndAttackEventHandler EndAttack;
        
        public delegate void PickCardsEventHandler(int playerIndex);
        public event PickCardsEventHandler PickCards;

        public delegate void PerformMoveEventHandler(Card card,int playerIndex);
        public event PerformMoveEventHandler PerformMove;

        public void MakeMove(Card trumpCard, List<Card> table,bool isAttacker)
        {
            //bool hasPerformedMove = false;

            foreach (var card in Hand){
                
                if (table.Count == 0)
                { // 1st Move
                    PerformMove?.Invoke(card,1);
                    //hasPerformedMove = true;
                    return;
                }
                Card attackingCard = table.Last();
                if (isAttacker)
                {
                    foreach (var playedCard in table)
                    {
                        if (playedCard.Rank == card.Rank)
                        {
                            PerformMove?.Invoke(card,1);
                            //hasPerformedMove = true;
                            return;
                        }
                    }
                }
                else if (!isAttacker && attackingCard.Rank < card.Rank && attackingCard.Suit == card.Suit)
                {
                    PerformMove?.Invoke(card,1);
                    //hasPerformedMove = true;
                    return;
                }
                else {
                    if (card.Suit == trumpCard.Suit) {
                        PerformMove?.Invoke(card,1);
                        //hasPerformedMove = true;
                        return;
                    }
                }
            }

            if (isAttacker)
            {
                // AI can't Attack so End Attack
                EndAttack?.Invoke(1);
                return;
            }else{
                // AI can't defend so Pick Cards
                PickCards?.Invoke(1);
                return;
            }
        }
    }
}
