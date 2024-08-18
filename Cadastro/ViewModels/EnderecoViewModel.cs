using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.ViewModels
{
    public class EnderecoViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public int ClienteId { get; set; }
    }
}