using System.Linq;
using System.Reflection.PortableExecutable;
using Linq_proyecto.Entidades;

namespace Linq_proyecto
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();

        public  LinqQueries()
        {
            using(StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive= true});
            }

        }            
            public bool Coleccionen2005()
            {
                return librosCollection.Any(p=>p.PublishedDate.Year == 2005);
            }

            public bool Estatusdeloslibros()
            {
                return librosCollection.All(p=>p.Status.Contains("PUBLISH"));
            }

            public IEnumerable<Book> TodaLaColeccion()
            {
                return librosCollection;
            }

            public IEnumerable<Book> Coleccion250InAction()
            {
                return librosCollection.Where(p=>p.PageCount >= 250 && p.Title.Contains("in Action"));
            }

            public IEnumerable<Book> CategoriaPython()
            {   //expresion method
                //return librosCollection.Where(p=>p.Categories.Contains("Python"))

                //query expression
                 var resultado = from l in librosCollection where l.Categories.Contains("Python") select l;

                 return resultado;
            }

            public IEnumerable<Book> LibrosJavaPorOrdenAsendente()
            {
                return librosCollection.Where(p=>p.Categories.Contains("Java")).OrderBy(p=>p.Title); //orderby ordena los elementos de manera ascendente
            }

            public IEnumerable<Book> Librosde450PorOrdenDesendente()
            {
                return librosCollection.Where(p=>p.PageCount > 450).OrderByDescending(p=>p.PageCount); //orderbydescending ordena los elementos de manera decendente 
            }

            public IEnumerable<Book> TresPrimerosLibrosJavaOrdenadosPorfecha()
            {
                return librosCollection.Where(p=>p.Categories.Contains("Java")).OrderBy(p=>p.PublishedDate).TakeLast(3); //takelast permite tomar una cantidad deceada de los ultimos elementos de la coleccion
        }

            public IEnumerable<Book> Librosde400PorOrdenDesendente()
            {
                return librosCollection.Where(p=>p.PageCount > 400).Take(4).Skip(2);  //take permite tomar una cantidad deceada de los primeros elementos de la coleccion, 
                                                                                       // skip, permite volar una cantidad de elementos de la lista
            }

            public int LibrosCount()
            {
            librosCollection.LongCount(p => p.PageCount >= 200 && p.PageCount <= 500); //otra forma en que se puede hacer, aunque deberia ser un long la funcion
                return librosCollection.Where(p => p.PageCount >= 200 && p.PageCount <= 500).Count(); //count me dice la cantidad de elementos que cumple con lo que se le pide, longcount es una variable la cual funciona cuando hay muchso valores, estos 2 devuelven enteros count devuelve un int mientras que longcount retorna un long
            }
        
         public DateTime LibrosMin()
        {
            return librosCollection.Min(p => p.PublishedDate); //min lo que hace es dar el valor minimo de una lista de valores
        }

        public int Maximodepaginas()
        {
            return librosCollection.Max(p => p.PageCount); // devuelve el valor maximo de una lista
        }

    }

    
}