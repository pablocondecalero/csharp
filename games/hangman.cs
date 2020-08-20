// Pablo Conde

using System;
using System.Text;

public class Ahorcado
{
    public static void Main()
    {
        const int MAX = 9;
        string[] palabras = {"ford", "opel", "citroen", "volvo", "saab", 
            "peugeot", "dacia", "honda", "ferrari", "fiat", "bugatti",
            "infiniti", "jaguar", "jeep", "kia", "lamborghini", "maserati",
            "lexus", "nissan", "renault"};
         
        //Escogemos una marca al azar
        Random r = new Random();
        int dato = r.Next(0,20);
        string marca = palabras[dato];

        /*Creamos la palabra oculta con líneas que será modificable
        utilizando StringBuilder*/
        string palabraLineas = new String('_', marca.Length);
        StringBuilder palabraOculta = new StringBuilder(palabraLineas);


        Console.WriteLine("Este ahorcado va sobre marcas de coches " +
            "¿adivinas la marca?");
        Console.WriteLine();

        //Dibujamos el número de letras de la palabra oculta
        for (int i = 0; i < palabraOculta.Length; i++)
        {
            if (i == palabraOculta.Length -1)
                Console.WriteLine(palabraOculta[i]);
            else
                Console.Write(palabraOculta[i] + " ");
        }
        Console.WriteLine();


        bool contieneEspacios;
        bool acierto;
        int contadorFallos = 0;
       
        do
        {
            contieneEspacios = false;
            acierto = false;
            
            Console.Write("Escribe una letra: ");
            char letra = Convert.ToChar(Console.ReadLine());

            for (int i = 0; i < marca.Length; i++)
            {
                if(marca[i] == letra)
                {
                   palabraOculta[i] = letra;
                    acierto = true; 
                }
            }
            
            //Mostramos la palabra con las letras adivinadas
            for (int i = 0; i < palabraOculta.Length; i++)
            {
                if (i == palabraOculta.Length -1)
                    Console.WriteLine(palabraOculta[i]);
                else
                    Console.Write(palabraOculta[i] + " ");
            }
            Console.WriteLine();

            
            //Comprobamos si quedan espacios en la palabraOculta
            for (int i = 0; i < palabraOculta.Length; i++)
            {
                if(palabraOculta[i] == '_')
                    contieneEspacios = true;
            }
            
            if(!acierto)
                contadorFallos++;

            //Dibujamos el ahorcado
            if (contadorFallos == 1)
                Console.WriteLine(" | \n | \n | \n | \n |_________");
            else if (contadorFallos == 2)
                Console.WriteLine("  _________  \n | \n | \n | \n | \n |_________");
            else if (contadorFallos == 3)
                Console.WriteLine("  _________  \n |    | \n | \n | \n | \n |_________");
            
            else if (contadorFallos == 4)
                Console.WriteLine("  _________  \n |    | \n |    O\n | \n | \n |_________");
            
            else if (contadorFallos == 5)
                Console.WriteLine("  _________  \n |    | \n |    O\n |    |\n | \n |_________");

            else if (contadorFallos == 6)
                Console.WriteLine("  _________  \n |    | \n |    O\n |   /|\n | \n |_________");
            
            else if (contadorFallos == 7)
                Console.WriteLine("  _________  \n |    | \n |    O\n |   /|\\ \n | \n |_________");
            
            else if (contadorFallos == 8)
                Console.WriteLine("  _________  \n |    | \n |    O\n |   /|\\ \n |   / \n |_________");
            
            else if (contadorFallos == 9)
                Console.WriteLine("  _________  \n |    | \n |    O\n |   /|\\ \n |   / \\ \n |_________");
            
            Console.WriteLine();
        }
        while(contieneEspacios && contadorFallos < MAX );
       
        if (!contieneEspacios)
        Console.WriteLine("¡Enhorabuena, has adivinado la marca!");

        else
        Console.WriteLine("Lo siento. Has perdido la partida");
    }
}
