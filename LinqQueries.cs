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
                return librosCollection.Where(p=>p.Categories.Contains("Java")).OrderBy(p=>p.Title);
            }

            public IEnumerable<Book> Librosde450PorOrdenDesendente()
            {
                return librosCollection.Where(p=>p.PageCount > 450).OrderByDescending(p=>p.PageCount);
            }

            public IEnumerable<Book> TresPrimerosLibrosJavaOrdenadosPorfecha()
            {
                return librosCollection.Where(p=>p.Categories.Contains("Java")).OrderBy(p=>p.PublishedDate).TakeLast(3);
            }

            public IEnumerable<Book> Librosde400PorOrdenDesendente()
            {
                return librosCollection.Where(p=>p.PageCount > 400).Take(4).Skip(2);
            }
    }

    
}