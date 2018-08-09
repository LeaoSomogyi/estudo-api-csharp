using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Cliente.WebApi.Models
{
    [Table("TAB_CLIENTES")]
    public class Cliente
    {
        [Column("CLICODIGO")]
        public int ClienteId { get; set; }

        [Column("CLINOME")]
        public String Nome { get; set; }

        [Column("CLIEMAIL")]
        public String Email { get; set; }

        [Column("CLIDTNASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("CLIATIVO")]
        public bool IsAtivo { get; set; }

        //Relacionamento Um para Muitos
        public List<Endereco> Enderecos { get; set; }
    }
}