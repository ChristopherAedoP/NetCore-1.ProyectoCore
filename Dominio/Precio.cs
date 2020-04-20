namespace Dominio
{
	public class Precio
	{
		//campos tabla -->
		public int PrecioId { get; set; }
		public decimal PrecioActual { get; set; }
		public decimal Promocion { get; set; }
		public int CursoId { get; set; }
		//referencia a nivel de objetos -->
		public Curso Curso { get; set; }
	}
}