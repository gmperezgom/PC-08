using System;
using System.Runtime.CompilerServices;
public class Program
{
    public static void Main(){
        string nombreEstudiante, carreraEstudiante;
        int edadEstudiante, carnetEstudiante, notaAdmision;

        Console.WriteLine("Ingrese su nombre");
        nombreEstudiante= Console.ReadLine();
        
        do{
            Console.WriteLine("Ingrese su edad");
            
            if (int.TryParse(Console.ReadLine() , out edadEstudiante)&& edadEstudiante > 0){
                break;
            }
            else
            {
                Console.WriteLine("Ingrese la edad valida");
            }
        }while (true);

        Console.WriteLine("Ingrese su carrera");
        carreraEstudiante= Console.ReadLine();
        
        Console.WriteLine("Ingrese su carnet");
        carnetEstudiante= Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese su nota de admision");
        notaAdmision= Convert.ToInt32(Console.ReadLine());

        Estudiante objEstudiante= new Estudiante(nombreEstudiante,edadEstudiante,carreraEstudiante,carnetEstudiante,notaAdmision);
        objEstudiante.mostrarResumen();
        objEstudiante.puedeMatricular();
    }

}
public class Estudiante{
    public string nombreEstudiante, carreraEstudiante;
    public int edadEstudiante, carnetEstudiante, notaAdmision;
    public Estudiante(string NombreEstudiante, int EdadEstudiante, string CarreraEstudiante, int CarnetEstudiante, int NotaAdmision){
        this.nombreEstudiante= NombreEstudiante;
        this.edadEstudiante=EdadEstudiante;
        this.carreraEstudiante=CarreraEstudiante;
        this.carnetEstudiante=CarnetEstudiante;
        this.notaAdmision=NotaAdmision;
    }
    public void mostrarResumen(){
        Console.WriteLine($"La informacion del estudiante es: {nombreEstudiante}, con {edadEstudiante} años, para la carrera de {carreraEstudiante}, con el carnet {carnetEstudiante}, y el resultado de {notaAdmision} puntos");
    }

    public bool puedeMatricular(){
        bool notaValida = notaAdmision >= 75;
        bool carnetValido = carnetEstudiante.ToString().EndsWith("2025");

        if (notaValida && carnetValido)
        {
            Console.WriteLine("Puede Matricularse");
            return true;
        }
        else 
        {
            Console.WriteLine("No puede matricularse");
            return false;
        }
    }
}