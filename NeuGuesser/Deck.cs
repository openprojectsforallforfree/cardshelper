using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuGuesser
{

    public class Deck
    {
        public List<Card> Cards = new List<Card>();
        public Deck()
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    Cards.Add(new Card { Value = j, Symbol = (Symbol)i, Deck = this });
                }
            }

        }
         

        public Card GetTip(Card card)
        {
            return Cards.Where(c => c.Symbol == card.Symbol & c.Value == card.GetPreviousValue()).First();
        }
        public Card GetPop(Card card)
        {
            return Cards.Where(c => c.Symbol == card.Symbol & c.Value == card.GetNextValue()).First();
        }

        public List<Card> GetSameValueCards(Card card)
        {
            var v= Cards.Where(c => c.Value == card.Value).ToList();
            return v;
        }

        public void CardIsThrownorNotPicked(Card card)
        {
            card.TipProbability = card.TipProbability - 100;
            card.PopProbability = card.PopProbability - 100;
            var samevalueCards = GetSameValueCards(card);
            foreach (var item in samevalueCards)
            {
                item.JockerProbability = item.JockerProbability - 500;
            }
            var pop = GetPop(card);
            pop.PopProbability = pop.PopProbability - 100;
            pop.JockerProbability = pop.JockerProbability - 100;

            var tip = GetTip(card);
            tip.TipProbability = tip.TipProbability -100;
            tip.JockerProbability = tip.JockerProbability - 100;
        }

        public void CardIsPicked(Card card)
        {
            card.TipProbability = card.TipProbability + 50;
            card.PopProbability = card.PopProbability + 50;
            foreach (var item in GetSameValueCards(card))
            {
                item.JockerProbability = item.JockerProbability + 50;
            }
            var pop = GetPop(card);
            pop.PopProbability = pop.PopProbability + 50;

            foreach (var item in GetSameValueCards(pop))
            {
                item.JockerProbability = item.JockerProbability + 50;
               
            }

            var tip = GetTip(card);
            tip.TipProbability = tip.TipProbability + 50;
            foreach (var item in GetSameValueCards(tip))
            {
                item.JockerProbability = item.JockerProbability + 50;
            }

            var popop = GetPop(pop);
            popop.PopProbability = popop.PopProbability + 50;

            var tiptip = GetTip(tip);
            tiptip.TipProbability = tiptip.TipProbability + 50;
        }
    }
}
