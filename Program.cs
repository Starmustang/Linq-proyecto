// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.Serialization.Json;
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
        //ImprimirValores(queries.Librosde400PorOrdenDesendente());


        //muestra la cantidad de libros que tienen entre 200 y 500 paginas
        //Console.WriteLine("cantidad de libros con entre 200 y 500 paginas " +queries.LibrosCount());

        //muestra el valor minimo de fecha
        //Console.WriteLine($"fecha minima {queries.LibrosMin()}");

        //muestra el maximo de paginas que tiene un libro
        //Console.WriteLine($"lo maximo de paginas que hay es este {queries.Maximodepaginas()}");

        //muestra toda la informacion del elemento minimo
        /*var librosMenorpag = queries.MinBydepaginas();
        Console.WriteLine($"{librosMenorpag.Title} - {librosMenorpag.PageCount}");
        Console.ReadKey();*/

        /*var librosFechaReciente = queries.MaxByDeFecha();
        Console.WriteLine($"{librosFechaReciente.Title} - {librosFechaReciente.PageCount} - {librosFechaReciente.PublishedDate}");*/

        //suma de paginas entre 0 y 500
        // Console.WriteLine($"suma total de paginas {queries.SumPagecountEntre0y500()}");

        //libros publicados despues del 2015
        //Console.WriteLine($"los libros del 2015 en adelante {queries.titulosDespuesDel2015Concatenados()}");

        //promedio de caracteres del titulo de los libros
        // Console.WriteLine($"Este es el promedio de caracteres de los titulos \n {queries.promedioDeLibros()}");

        //promedio de paginas en libros mayores a 0
        // Console.WriteLine($"Este es el promedio {queries.PromedioTarea()}");


        //libros publicados a partir del 2000 agrupados por año
        //ImprimirGrupo(queries.GrupodeLibrosDespuesDel2000());

        //Diccionario de libros por primera letra del titulo
        //var diccionarioLookup = queries.DiccionarioDelibrosConILookup();
        //Console.WriteLine("ingrese la primera letra del libro que quiere ver");
        //string input = Console.ReadLine().ToUpper();

        //if (!string.IsNullOrEmpty(input))
        //{
        //    char valor = input[0];
        //    ImprimirDiccionario(diccionarioLookup, valor);
        //}
        //else
        //{
        //    Console.WriteLine("No se ingreso ningun caracter");
        //}

        // libros filtrados con la clausula join
        ImprimirValores(queries.Librosconmasde500Pagydespues2005());


        void ImprimirDiccionario(ILookup<char, Book> listadeLibros, char letra)
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N.Paginas", "Fecha publicacion");
            foreach (var item in listadeLibros[letra])
            {
                Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
            }
        }

        void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
        {
            foreach (var grupo in ListadeLibros)
            {
                Console.WriteLine("");
                Console.WriteLine($"Grupo: {grupo.Key}");
                Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
                foreach (var item in grupo)
                {
                    Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
                }
            }
        }

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

