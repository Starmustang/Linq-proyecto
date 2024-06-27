// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    public static void Main (string[] args){
        

        var frutas = new string[]{"Sandia", "Fresa","Mango","Mango de azucar","Mango Tomy"};

        var mangoList = frutas.Where(fruit=>fruit.StartsWith("Mango")).ToList();

        mangoList.ForEach(mango =>Console.WriteLine(mango));

        //Console.WriteLine("Hello, World!");
    }
    
}

