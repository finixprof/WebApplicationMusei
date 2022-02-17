using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMusei.Models.Entities;

namespace WebApplicationMusei.Models.Dtos
{

    public class NazioneDto : Nazione
    {
        public IFormFile FileFlag { get; set; }
    }
}
