using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SortePerWPF
{
    public class SortePerGameController
    {
        private static SortePerGameController instance;
        public static SortePerGameController Instance
        {
            get
            {
                if (instance == null)
                    instance = new SortePerGameController();

                return instance;
            }
        }
        private Deck deck;
        public Card chosenCards;

        private List<Player> players = new List<Player>();
        public List<Player> Players { get => players; set => players = value; }

        internal Deck Deck { get => deck; set => deck = value; }

        private SortePerGameController()
        {
            Players.Add(new Player("Geef"));
            Players.Add(new Player("Polak"));
            deck = DeckFactory.CreateSortePerDeck();
            GiveCards();
        }

        public void GiveCards()
        {
            while (deck.Cards.Count != 0)
            {
                foreach (Player player in players)
                {
                    if (deck.Cards.Count == 0)
                    {
                        return;
                    }
                    player.Hand.Add(deck.Cards.First());
                    deck.Cards.RemoveAt(0);

                }
            }
        }

        public void MatchCards(object sender, MouseEventArgs e)
        {
            ImageCard control = (ImageCard)sender;
            if (control == null)
                return;
                
            if (chosenCards == null)
            {
                chosenCards = control.card;
                return;
            }
            
            if (chosenCards.CardValue != control.card.CardValue)
                return;

            MatchPlayerCard(control);
        }

        private void MatchPlayerCard(ImageCard control)
        {
            foreach (Card card in players[0].Hand.ToList())
            {
                if (card.CardValue == control.card.CardValue)
                {
                    players[0].Hand.Remove(card);
                    players[0].Hand.Remove(control.card);
                }
            }
            control.MouseUp -= MatchCards;
        }
    }
}
