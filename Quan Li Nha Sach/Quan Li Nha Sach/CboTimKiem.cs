using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Li_Nha_Sach
{
    class CboTimKiem
    {
        public string Text { get; set; }
        public string Name { get; set; }

        public CboTimKiem(string text, string name)
            {
                Text = text;
                Name = name;
            }
    }
}
