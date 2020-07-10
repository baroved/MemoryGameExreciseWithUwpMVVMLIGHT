using MemoryGameExrecise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGameExrecise.Infra
{
    public interface IServiceMemoryGame
    {
        List<Card> GetIconList(out bool[] buttons);
        void NewGame();
        bool[] IsMatch(int indexSrc1, int IndexSrc2);
        string GetSrcByIndex(int index);
        bool[] ChangeStatusBeforeChecking(int index);
        bool CheckFinish();
    }
}

