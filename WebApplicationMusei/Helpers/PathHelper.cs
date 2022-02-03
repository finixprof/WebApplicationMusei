using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMusei.Helpers
{
    public static class PathHelper
    {
        public static string WebRootPath { get; set; }


        public static string GetPathNazione(int id)
        {
            return $"{WebRootPath}\\wwwroot\\uploads\\nazioni\\{id}";
        }

    }
}
