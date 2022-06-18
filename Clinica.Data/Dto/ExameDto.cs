using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Data.Dto
{
    public class ExameDto
    {
        public int Id { get; set; }

        public string Cpf { get; set; }

        public string NomePaciente { get; set; }

        public string resultado { get; set; }

        public DateTime dataExame { get; set; }

    }
}
