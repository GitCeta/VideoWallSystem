using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoWall_Client
{
    public class FileItem
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }

        // ListBox'ta sadece dosya adı gösterilecek
        public override string ToString()
        {
            return FileName;
        }
    }
}
