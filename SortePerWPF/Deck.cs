using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerWPF
{
    class Deck
    {
        List<Card> cards = new List<Card>();
        internal List<Card> Cards { get => cards; set => cards = value; }

        public Deck(List<Card> cards)
        {
            this.cards = cards; 
        }

    }
}
