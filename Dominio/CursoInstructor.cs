namespace Dominio
{
	public class CursoInstructor
	{
		//campos tabla -->
		public int InstructorId { get; set; }
		public int CursoId { get; set; }

		//referencia a nivel de objetos -->
		public Curso Curso { get; set; }

		public Instructor Instructor { get; set; }
        
	}
}