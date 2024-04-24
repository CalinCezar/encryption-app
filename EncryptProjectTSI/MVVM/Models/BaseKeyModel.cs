using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptProjectTSI.MVVM.Models
{
    class BaseKeyModel
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public int KeySize { get; set; }
        public BaseKeyModel() 
        {
            KeySize = 128;
            PrivateKey = "";
            PublicKey = "";
        }
    }
}
