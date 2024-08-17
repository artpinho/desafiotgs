using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cadastro.Models
{
    public class Cliente
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
        [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres")]
        [DisplayName("Nome Completo")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o E-mail")]
        [EmailAddress(ErrorMessage = "Informe inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Logotipo")]
        public byte[]? Logotipo { get; set; }

        public List<Endereco> Enderecos { get; set; } = new();
    }
}