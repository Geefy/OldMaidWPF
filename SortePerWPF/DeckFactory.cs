using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePerWPF
{
    static class DeckFactory
    {
        public static Deck CreateSortePerDeck()
        {
            List<Card> cards = new List<Card>
            {
                new Card("bear"),
                new Card("bear"),
                new Card("bear"),
                new Card("bull"),
                new Card("bull"),
                new Card("bee"),
                new Card("bee"),
                new Card("camel"),
                new Card("camel"),
                new Card("cat"),



            };
            return new Deck(cards);


        }
    }
}
