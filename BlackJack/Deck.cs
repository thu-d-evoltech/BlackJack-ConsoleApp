using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        private List<Card> deck = new List<Card>(52);
        public Deck()
        {
            DeckMethod();
        }

        //Tạo bộ bài từ 4 tính chất và 13 lá
        public void DeckMethod()
        {
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    deck.Add(new Card((CardSuit)i, (CardFace)j));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            int n = deck.Count;

            //Mỗi vòng lặp tìm một thẻ ngẫu nhiên để chèn vào đối tượng danh sách thẻ mới.

        }
    }
}
