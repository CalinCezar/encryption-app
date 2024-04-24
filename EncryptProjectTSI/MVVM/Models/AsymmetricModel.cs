using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptProjectTSI.MVVM.Models
{
    class AsymmetricModel: BaseKeyModel
    {
        public string modulus { get; set; }
        public AsymmetricModel(): base()
        {
            modulus = string.Empty;
        }
    }
}
