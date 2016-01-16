//Camilo Chacón Sartori
//http://blog.camilochacon.com
//16-01-2016
using System;
using System.Collections.Generic;

class Program
{
    const int NUM_ELEMENT = 5;
    class ToqueFama
    {
        public uint CountToque { get; set; }
        public uint CountFama { get; set; }
        public void Start(List<uint> sequenceRandom, List<uint> sequenceInput)
        {
            string printSequence = String.Empty;
            sequenceInput.ForEach(n => printSequence += n.ToString() + ", ");
            printSequence = printSequence.Remove(printSequence.Length - 2, 2);
            Console.WriteLine("tu ingresaste [" + printSequence + "]");
            int i = 0;
            while (i < NUM_ELEMENT)
            {
                if (sequenceInput[i] == sequenceRandom[i]) CountFama++;
                if (sequenceInput.Contains(sequenceRandom[i])) CountToque++;
                i++;
            }
            Console.WriteLine("resultado: {0} Toques {1} Famas", CountToque, CountFama);
        }
    }
    private static List<uint> RandomSequence()
    {
        var nList = new List<uint>();
        var digits = new List<uint>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var random = new Random();
        while(nList.Count < NUM_ELEMENT)
        {
            int ri = random.Next(digits.Count);
            nList.Add(digits[ri]);
            digits.RemoveAt(ri);
        }
        return nList;
    }
    private static List<uint> ValidationList(uint number)
    {
        var nList = new List<uint>();
        if (number <= 0) return nList;
        while(number > 0)
        {
            uint n = number % 10;
            number = number / 10;
            if (nList.Contains(n)) break;
            nList.Add(n);
        }
        if (nList.Count < NUM_ELEMENT) nList.Clear();
        nList.Reverse();
        return nList;
    }
    private static void InitGame()
    {
        Console.WriteLine(@"
Bienvenido a Toque y Fama.
==========================

En este juego debes tratar de adivinar una secuencia de 5 dígitos generadas por el programa.
Para esto ingresas 5 dígitos distintos con el fin de adivinar la secuencia.
Si has adivinado correctamente la posición de un dígito se produce una Fama.
Si has adivinado uno de los dígitos de la secuencia, pero en una posición distinta se trata de un Toque.
");
        Console.WriteLine("Ingresa una secuencia de 5 dígitos distintos (o escribe salir):");
        string cnumber = Console.ReadLine();
        int number = 0;
        bool check = Int32.TryParse(cnumber, out number);
        if (check)
        {
            var sequence = ValidationList((uint)number);
            if (sequence.Count == 0)
            {
                Console.WriteLine("error!");
            }
            else
            {
                new ToqueFama().Start(RandomSequence(), sequence);
            }
        }
        InitGame();
        Console.ReadLine();
    }
    static void Main()
    {
        InitGame();
    }
}
