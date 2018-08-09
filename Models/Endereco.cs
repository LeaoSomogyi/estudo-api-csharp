using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Cliente.WebApi.Models
{
    [DataContract(IsReference = true)]
    [Table("TAB_ENDERECOS")]
    public class Endereco
    {
        [Column("ENDCODIGO")]
        public int EnderecoId { get; set; }

        [DataMember]
        [Column("ENDLOGRADOURO")]
        public String Logradouro { get; set; }

        [DataMember]
        [Column("ENDCOMPLEMENTO")]
        public String Complemento { get; set; }

        [DataMember]
        [Column("ENDNUMERO")]
        public int Numero { get; set; }

        [DataMember]
        [Column("ENDATIVO")]
        public bool IsAtivo { get; set; }

        //[DataMember]
        //Relacionamento Muitos para um
        public Cliente Cliente { get; set; }

        [DataMember]
        [ForeignKey("Cliente")]
        [Column("CLICODIGO")]
        public int ClienteId { get; set; }
    }
}