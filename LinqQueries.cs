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
        
        public Book MinBydepaginas()
        {
            return librosCollection.Where(p => p.PageCount>0).MinBy(p => p.PageCount); //en este caso se devuelve toda la informacion del elemento que cumple con las condiciones

        }

        public Book MaxByDeFecha()
        {
            return librosCollection.MaxBy(p => p.PublishedDate);
        }

        public int SumPagecountEntre0y500()
        {
            return librosCollection.Where(p => p.PageCount >=0 && p.PageCount <= 500).Sum(p =>p.PageCount);
        }

        public string titulosDespuesDel2015Concatenados()
        {
            return librosCollection.Where(p => p.PublishedDate.Year > 2015).Aggregate("", (TitulosLibros, next) => //aggregate va agregando elementos a un grupo
            {
                if (TitulosLibros != string.Empty)
                {
                    TitulosLibros += " - " + next.Title;
                }
                else
                {
                    TitulosLibros += next.Title;
                }

                return TitulosLibros;
            });
        }

        public double promedioDeLibros()
        {
            return librosCollection.Average(p => p.Title.Length);
        }

        public double PromedioTarea()
        {
            return librosCollection.Where(p => p.PageCount > 0).Average(p => p.PageCount); //average calcula el promedio de lo que se busca devuelve double
        }

        public IEnumerable<IGrouping<int, Book>> GrupodeLibrosDespuesDel2000()
        {
            return librosCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year); //Group by agrupa datos en base a lo que se solicite, tiene una estructura diferente como la que se puede ver en la funcion 
        }

        public ILookup<char, Book> DiccionarioDelibrosConILookup()
        {
            return librosCollection.ToLookup(p => p.Title[0], p => p);
        }

        public IEnumerable<Book> Librosconmasde500Pagydespues2005()
        {
            var librosDespuesdel2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);

            var librosConMasde500pag = librosCollection.Where(p => p.PageCount > 500);

            return librosDespuesdel2005.Join(librosConMasde500pag, p => p.Title, x=> x.Title, (p, x) => p);
        }

    }    
}