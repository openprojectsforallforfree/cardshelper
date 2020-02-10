using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuGuesser
{
    public enum Symbol
    {
        Spade,
        Club,
        Diamond,
       
        Heart
    }

    public class Card
    {
        public Deck Deck { get; set; }
        public int Value;
        public Symbol Symbol;

        public double TipProbability { get; set; }
        public double PopProbability { get; set; }
        public double JockerProbability { get; set; }

        public double ThrownOrNotPicked { get; set; }
        public double Picked { get; set; }


        public double UnSafeToThrowIndex
        {
            get
            {
                return TipProbability + PopProbability + JockerProbability;
            }
        }

        public string GetName()
        {
            var sym = "❤";
            switch (Symbol)
            {
                case Symbol.Spade:
                    sym = "♠";
                    break;
                case Symbol.Club:
                    sym = "♣";
                    break;
                case Symbol.Diamond:
                    sym = "♦";
                    break;
                case Symbol.Heart:
                    sym = "❤";
                    break;
                
               
                default:
                    break;
            }
            string val = Value.ToString();
            if (Value == 11)
            {
                val = "J";
            }
            else
                if (Value == 12)
            { val = "Q"; }
            else
                if (Value == 13)
            { val = "K"; }
            else
                if (Value == 1)
            { val = "A"; }
            return sym + val;
        }

        public string GetProbability()
        {
            return TipProbability.ToString() + "(" + JockerProbability.ToString() + ")" + PopProbability.ToString();
        }

    }

    public static class MyExtensions
    {
        public static int GetNextValue(this Card card)
        {
            return card.Value == 13 ? 1 : card.Value + 1;
        }


        public static int GetPreviousValue(this Card card)
        {
            return card.Value == 1 ? 13 : card.Value - 1;
        }
    }



}
