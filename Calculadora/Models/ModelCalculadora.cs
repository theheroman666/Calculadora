using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calculadora.Models
{
    public class ModelCalculadora
    {
        [DisplayName("Ingresa un numero")]
		[Required(ErrorMessage = "El Valor es requerido")]
        public int Valor1 { get; set; }

        [DisplayName("Ingresa un numero")]
		[Required(ErrorMessage = "El Valor es requerido")]
        public int Valor2 { get; set; }

        [DisplayName("Tipo De operacion")]
        public string Operacion { get; set; }
        public int Resultado { get; set; }
    }
}
