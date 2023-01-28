using System.ComponentModel.DataAnnotations;

namespace EstefaniaVinueza_EjercicioCF.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }//Es importante definir un ID
        [Required]//el DA se coloca antes del atributo 
        public string? Name { get; set; }//Se usa el '?' para que no sea null
        public bool WithCheese { get; set; }
        public bool WithTomatoes { get; set; }




        [VerificarRango]
        public decimal Price { get; set; }
    }

    public class VerificarRango : ValidationAttribute
    {
        public override bool IsValid(object? valor)
        {
            decimal valor1 = (decimal)valor;
            if (valor1 < 2)
            {
                return false;

            }
            else
            {
                return true;
            }

        }
    }
}


