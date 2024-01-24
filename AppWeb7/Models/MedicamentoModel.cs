namespace AppWeb7.Models
{
    public class MedicamentoModel
    {
        public int IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
