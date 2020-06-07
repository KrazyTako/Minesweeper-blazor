using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MineSweeperWeb.FormModels
{
    public class CreateScore
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
