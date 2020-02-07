using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadastro_De_Usuarios.viewmodels
{
    public class autenticacaoViewModel
    {
        public string IP { get; set; }
        public int cdUsuario { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public bool btn_Novo { get; set; }
       // public bool valido { get; set; }
        public bool autenticado { get; set; }
        public string seleciona { get; set; }
        public string strcon { get; set; }
        public object table { get; set; }
        public string procura { get; set; }
        public string idUsuario { get; set; }
        public bool editar_campo { get; set; }
        

    }
}