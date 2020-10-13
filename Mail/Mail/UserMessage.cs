using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Mail
{
    public class UserMessage
    {
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Subj { get; set; }
        public string Text { get; set; }
    }
}
