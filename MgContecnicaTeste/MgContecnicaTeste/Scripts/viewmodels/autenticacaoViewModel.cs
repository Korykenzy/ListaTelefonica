using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monitoramento_De_Servicos.viewmodels
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
        public string nomeservicomonitora { get; set; }
        public int quantidadeservicos { get; set; }
        public string servicoselecionado { get; set; }
        public int TempoDoAlert { get; set; }
        public DateTime DataTime_UltimoAlert { get; set; }
        public int FiltroAlert { get; set; }
     
    }
}