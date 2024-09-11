namespace ApiClase.Models
{
    public class Moneda
    {
        public string Nombre { get; set; }

        public decimal Valor { get; set; }

        public Moneda(string nombre, decimal valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
