// See https://aka.ms/new-console-template for more information
using System;
using Linq_proyecto;
using Linq_proyecto.Entidades;
class Program
{
    public static void Main (string[] args){


        LinqQueries queries = new LinqQueries();

        //ImprimirValores(queries.TodaLaColeccion());

        //System.Console.WriteLine($"la coleccion tiene algun libro del año 2005 -{queries.Coleccionen2005()}");

       // System.Console.WriteLine($"todos los libros tienen el estado PUBLISH -{queries.Estatusdeloslibros()}");

        //ImprimirValores(queries.Coleccion250InAction());

        //ImprimirValores(queries.CategoriaPython());

        

        //libros de java ordenados por nombre
        //ImprimirValores(queries.LibrosJavaPorOrdenAsendente());

        //libros de 450 paginas ordenados de manera decendente
        //ImprimirValores(queries.Librosde450PorOrdenDesendente());

        //3 primeros libros publicados
        //ImprimirValores(queries.TresPrimerosLibrosJavaOrdenadosPorfecha());

        //Una lista de los 4 libros con mas paginas saltandome el primero y el segundo
        ImprimirValores(queries.Librosde400PorOrdenDesendente());

        void ImprimirValores(IEnumerable<Book> listdelibros){
            System.Console.WriteLine("{0, -60} {1, 15} {2, 11} {3, 17}\n", "Titulo", "N. Paginas", "Fecha publicacion", "Categoria"); //los valores de entre {} nos permiten decir le al sistema que queremos que se impriman de una parte hasta otra
            System.Console.WriteLine(new string('-', 90));
            foreach (var item in listdelibros)
            {   
                string categoria = string.Join(", ", item.Categories);
                System.Console.WriteLine("{0, -60} {1, 15} {2, 11} {3, 24} ", item.Title, item.PageCount, item.PublishedDate.ToShortDateString(), categoria);
                
            }
        }
    }
    
}

