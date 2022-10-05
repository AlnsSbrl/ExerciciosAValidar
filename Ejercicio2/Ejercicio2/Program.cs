#define FRASE

class Ejer2
{
    public static void Main()
    {
        

        Console.WriteLine("Escriba unha frase");
        string frase1=Console.ReadLine();
        Console.WriteLine("Escriba outra frase");
        string frase2=Console.ReadLine();
        //Console.WriteLine(frase1 + "\t" + frase2 + "\n" + frase1 + "\n"+frase2);
#if FRASE
        Console.WriteLine("\"{0}\"\t\\{1}\\",frase1,frase2);
#else
        Console.WriteLine( "{0} \t {1} \n {0}\n{1} ",frase1,frase2);
#endif
        
    }
}
