using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SortePerWPF
{
    public class Card
    {

        string value;

        public string CardValue { set { this.value = value; } get { return this.value; } }

        public Card(string value)
        {

            this.CardValue = value;

        }
    }

}