using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMusei.Models.Entities
{
    public class Museo
    {
        public int Id { get; set; }
        public string Denominazione { get; set; }
        public int CittaId { get; set; }
    }
}
