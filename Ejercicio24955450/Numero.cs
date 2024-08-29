using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace Ejercicio24955450
{
    [Table("numero")]
    public class Numero
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("valor")]
        public int Valor { get; set; }

        [Column("signo")]
        public string? Signo { get; set; }
    }
}

