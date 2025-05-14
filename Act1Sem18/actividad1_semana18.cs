class Program
{
    static void Main(string [] args){
        Cursos curso= new Cursos();
        curso.DatosEstudiantes();

        bool salirPrograma=false;
        while (!salirPrograma)
        {
            Console.WriteLine("Menú de Opciones");
            Console.WriteLine("1) Mostrar notas aprobadas por alumno");
            Console.WriteLine("2) Mosstrar notas no aprobadas por alumno");
            Console.WriteLine("3) Mostrar promedio de notas del grupo");
            Console.WriteLine("4) Salir");
            Console.Write("Seleccione una opción (1-4): ");
            
            string opcionPersona = Console.ReadLine();
            Console.WriteLine();

            switch (opcionPersona)
            {
                case "1":
                    curso.MostrarNotasAprobadas();
                    break;
                case "2":
                    curso.MostrarNotasReprobadas();
                    break;
                case "3":
                    double promedioEstudiantes = curso.PromedioGrupo();
                    Console.WriteLine($"El promedio general del grupo es: {promedioEstudiantes:F2}");
                    Console.WriteLine();
                    break;
                case "4":
                    salirPrograma=true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
public class EstudiantesDatos{
    public string NombreEstudiante {get; set;}
    public double [] NotasEstudiante {get; set;}

    public EstudiantesDatos(int notasGrado){
        NotasEstudiante= new double [notasGrado];
    }
    public double[] NotasAprobadas(double notaAprobada)
    {
        int contadorNotas=0;
        for (int i = 0; i < NotasEstudiante.Length; i++)
        {
            if (NotasEstudiante[i] >= notaAprobada)
            {
                contadorNotas++;
            }
        }
        double [] aprobadasNotas = new double [contadorNotas];
        int aprobadasIndex = 0;
        for (int i = 0; i < NotasEstudiante.Length; i++)
        {
            if (NotasEstudiante[i] >= notaAprobada)
            {
                aprobadasNotas[aprobadasIndex] = NotasEstudiante[i];
                aprobadasIndex++;
            }
        }

            return aprobadasNotas;
    }
    public double[] NotasReprobadas(double notaAprobada)
    {
        int contadorNotas=0;
        for (int i = 0; i < NotasEstudiante.Length; i++)
        {
            if (NotasEstudiante[i] < notaAprobada)
            {
                contadorNotas++;
            }
        }
        double [] reprobadasNotas = new double [contadorNotas];
        int reprobadasIndex = 0;
        for (int i = 0; i < NotasEstudiante.Length; i++)
        {
            if (NotasEstudiante[i] < notaAprobada)
            {
                reprobadasNotas[reprobadasIndex] = NotasEstudiante[i];
                reprobadasIndex++;
            }
        }

            return reprobadasNotas;
    }
}
public class Cursos{
        private const int ConteoEstudiantes=10;
        private const int ConteoNotasPorEstudiante=10;
        private const double NotaParaPasar=65.0;

        public EstudiantesDatos[] Estudiantes {get; private set;}

        public Cursos(){
            Estudiantes= new EstudiantesDatos[ConteoEstudiantes];
            for (int i = 0; i < ConteoEstudiantes; i++)
            {
                Estudiantes[i]= new EstudiantesDatos(ConteoNotasPorEstudiante);
            }
        }
        public void DatosEstudiantes(){
            Console.WriteLine("Ingreso de los Datos de cada uno de los Estudiantes");
            for (int i = 0; i < Estudiantes.Length; i++)
            {
                string nombreEstudiante;
                do
                {
                    Console.Write($"Ingrese el nombre del estudiante #{i + 1}: ");
                    nombreEstudiante= Console.ReadLine().Trim();
                } while (string.IsNullOrEmpty(nombreEstudiante));
                Estudiantes[i].NombreEstudiante= nombreEstudiante;
                for (int j = 0; j < ConteoNotasPorEstudiante; j++)
                {
                    double notasEstudiante;
                    while (true)
                    {
                        Console.Write($"Ingrese la nota #{j + 1} para {nombreEstudiante} (0-100): ");
                        string ingresoNota= Console.ReadLine();
                        if (double.TryParse(ingresoNota, out notasEstudiante)&& notasEstudiante >= 0 && notasEstudiante <= 100)
                        {
                            Estudiantes[i].NotasEstudiante[j]= notasEstudiante;
                            break;
                        }
                        Console.WriteLine("Ingresa un dato válido para la nota del Estudiante");
                    }
                }
                Console.WriteLine();
            }
        }
        public void MostrarNotasAprobadas(){
            Console.WriteLine("Notas Aprobadas");
            foreach (var estudiante in Estudiantes)
            {
                var aprobadasNotas= estudiante.NotasAprobadas(NotaParaPasar);
                Console.WriteLine($"Estudiante: {estudiante.NombreEstudiante}");
                string resultado = "";
                if (aprobadasNotas.Length > 0)
                {
                    for (int i = 0; i < aprobadasNotas.Length; i++)
                    {
                        resultado += aprobadasNotas[i];
                        if (i < aprobadasNotas.Length - 1)
                            {
                                resultado += ", ";
                            }
                    }
                    Console.WriteLine(resultado);
                }
                else
                {
                    Console.WriteLine("No tiene notas aprobadas");
                }
            }
        }
            public void MostrarNotasReprobadas(){
            Console.WriteLine("Notas Reprobadas");
            foreach (var estudiante in Estudiantes)
            {
                var reprobadasNotas= estudiante.NotasReprobadas(NotaParaPasar);
                Console.WriteLine($"Estudiante: {estudiante.NombreEstudiante}");
                string resultado = "";
                if (reprobadasNotas.Length > 0)
                {
                    for (int i = 0; i < reprobadasNotas.Length; i++)
                    {
                        resultado += reprobadasNotas[i];
                        if (i < reprobadasNotas.Length - 1)
                            {
                                resultado += ", ";
                            }
                    }
                    Console.WriteLine(resultado);
                }
                else
                {
                    Console.WriteLine("No tiene notas reprobadas");
                }
            }
        }
        public double PromedioGrupo()
        {
            double total = 0;
            int contador = 0;

            for (int i = 0; i < Estudiantes.Length; i++)
            {
                for (int j = 0; j < Estudiantes[i].NotasEstudiante.Length; j++)
                {
                    total += Estudiantes[i].NotasEstudiante[j];
                    contador++;
                }
            }
            if (contador > 0)
            {
                return total / contador;
            }
            else
            {
                return 0;
            }
        }  
}