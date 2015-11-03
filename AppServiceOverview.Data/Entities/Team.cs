using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServiceOverview.Data.Entities
{
    public class Team : IIdEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Rank { get; set; }

        public string Name { get; set; }

        public DateTimeOffset NextMatch { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
