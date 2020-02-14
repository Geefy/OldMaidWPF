using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SortePerWPF
{
    public class Player
    {

        private List<Card> hand = new List<Card>();
        public string playerName;

        public List<Card> Hand { get => hand; set => hand = value; }

        public Player(string name)
        {
            playerName = name;
        }

        
    }
}
