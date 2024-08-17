using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Models
{
    public class Endereco
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Endereço")]
        [StringLength(120, ErrorMessage = "O endereço deve conter até 120 caracteres")]
        [MinLength(10, ErrorMessage = "O endereço deve conter pelo menos 10 caracteres")]
        [DisplayName("Endereço")]
        public string Logradouro { get; set; } = string.Empty;

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "Cliente inválido")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

    }
}