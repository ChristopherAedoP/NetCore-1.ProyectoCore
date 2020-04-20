namespace Dominio
{
	public class Comentario
	{
		//campos tabla -->
		public int ComentarioId { get; set; }
		public string Alumno { get; set; }
		public int Puntaje { get; set; }
		public string ComentarioTexto { get; set; }
		public int CursoId { get; set; }
		//referencia a nivel de objetos -->
		public Curso Curso { get; set; }
	}
}