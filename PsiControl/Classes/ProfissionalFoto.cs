using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsiControl.Classes;

class ProfissionalFoto
{
    //public string CaminhoFoto { get; set; }
    public byte[] Foto { get; set; }

    public ProfissionalFoto(byte[] foto)
    {
        this.Foto = foto;
    }
}
