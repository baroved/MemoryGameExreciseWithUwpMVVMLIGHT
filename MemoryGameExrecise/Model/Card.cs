using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGameExrecise.Model
{
    public class Card
    {
        public int Id { get; set; }
        public string SrcStart { get; set; }
        public string SrcAfterClick { get; set; }
        public bool UserMatched { get; set; }

    }
}
