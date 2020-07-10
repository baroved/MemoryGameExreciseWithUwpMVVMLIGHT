using MemoryGameExrecise.Infra;
using MemoryGameExrecise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MemoryGameExrecise.Service
{
    public class SevriceMemoryGame : IServiceMemoryGame
    {
        public List<Card> Icons { get; set; }
        public bool[] Buttons { get; set; }
        public Random Rnd { get; set; }
        public int Count { get; set; }
        public SevriceMemoryGame()
        {
            Count = 0;
            Rnd = new Random();
            Icons = new List<Card>()
            {
                new Card(){Id=1,SrcStart="/Images/1.png",SrcAfterClick="/Images/2.jpg",UserMatched=false},
                new Card(){Id=2,SrcStart="/Images/1.png",SrcAfterClick="/Images/2.jpg",UserMatched=false},
                new Card(){Id=3,SrcStart="/Images/1.png",SrcAfterClick="/Images/3.jpg",UserMatched=false},
                new Card(){Id=4,SrcStart="/Images/1.png",SrcAfterClick="/Images/3.jpg",UserMatched=false},
                new Card(){Id=5,SrcStart="/Images/1.png",SrcAfterClick="/Images/4.jpg",UserMatched=false},
                new Card(){Id=6,SrcStart="/Images/1.png",SrcAfterClick="/Images/4.jpg",UserMatched=false},
                new Card(){Id=7,SrcStart="/Images/1.png",SrcAfterClick="/Images/5.jpg",UserMatched=false},
                new Card(){Id=8,SrcStart="/Images/1.png",SrcAfterClick="/Images/5.jpg",UserMatched=false},
                new Card(){Id=9,SrcStart="/Images/1.png",SrcAfterClick="/Images/6.jpg",UserMatched=false},
                new Card(){Id=10,SrcStart="/Images/1.png",SrcAfterClick="/Images/6.jpg",UserMatched=false},
                new Card(){Id=11,SrcStart="/Images/1.png",SrcAfterClick="/Images/7.jpg",UserMatched=false},
                new Card(){Id=12,SrcStart="/Images/1.png",SrcAfterClick="/Images/7.jpg",UserMatched=false},
                new Card(){Id=13,SrcStart="/Images/1.png",SrcAfterClick="/Images/8.jpg",UserMatched=false},
                new Card(){Id=14,SrcStart="/Images/1.png",SrcAfterClick="/Images/8.jpg",UserMatched=false},
                new Card(){Id=15,SrcStart="/Images/1.png",SrcAfterClick="/Images/9.jpg",UserMatched=false},
                new Card(){Id=16,SrcStart="/Images/1.png",SrcAfterClick="/Images/9.jpg",UserMatched=false}
            };
            Buttons = new bool[Icons.Count];
            for (int i = 0; i < Icons.Count; i++)
            {
                Buttons[i] = true;
            }
            NewGame();

        }
        public List<Card> GetIconList(out bool[] buttons)
        {
            buttons = Buttons;
            return Icons;
        }
        public void NewGame()
        {
            Card[] listOfIcons = new Card[Icons.Count];
            for (int i = 0; i < Icons.Count; i++)
            {
                int random = Rnd.Next(Icons.Count);
                while (Icons[random] == null)
                    random = Rnd.Next(Icons.Count);
                listOfIcons[i] = new Card { Id = i, SrcStart = Icons[random].SrcStart, SrcAfterClick = Icons[random].SrcAfterClick, UserMatched = false };
                Icons[random] = null;
            }



            Icons = listOfIcons.ToList();
        }
        public bool[] IsMatch(int indexSrc1, int IndexSrc2)
        {
            if (Icons[indexSrc1].SrcAfterClick == Icons[IndexSrc2].SrcAfterClick)
            {
                Icons[indexSrc1].UserMatched = true;
                Icons[IndexSrc2].UserMatched = true;
                return Buttons;
            }
            else
            {
                Icons[indexSrc1].UserMatched = false;
                Icons[IndexSrc2].UserMatched = false;
                Buttons[indexSrc1] = true;
                Buttons[IndexSrc2] = true;
            }
            return Buttons;
        }
        public string GetSrcByIndex(int index)
        {
            return Icons[index].SrcAfterClick;
        }
        public bool[] ChangeStatusBeforeChecking(int index)
        {

            Icons[index].UserMatched = true;
            Buttons[index] = false;
            if (Count == 0)
                Count++;
            else
            {
                Count = 0;
                return new bool[Icons.Count];
            }
            return Buttons;
        }
        public bool CheckFinish()
        {
            for (int i = 0; i < Icons.Count; i++)
            {
                if (!Icons[i].UserMatched)
                    return false;
            }
            return true;
        }
    }
}
