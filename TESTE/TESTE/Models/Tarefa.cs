using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TESTE.Models
{
    public class Tarefa
    {
        public long TarefaId { get; set; }
        public string Titulo { get; set; }
        public int Status { get; set; }
        public string Descricao { get; set; }

    }
}