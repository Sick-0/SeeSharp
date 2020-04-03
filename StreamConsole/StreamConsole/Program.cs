
/*
    C# IS A OBJECT ORIENTATED LANGUAGE (Very similar to Java)
    C# IS VERY CASE SENSITIVE (Don't tell the upper case it's "big")
   
    ALWAYS END LINES WITH ;
    COMMENTS ARE WITH // (Duh)
    WE ALSO HAVE COMMENT BLOCKS (this)
    
    Declaring Variables: 
    DATATYPE varName = value;
    
    Declaring functions:
    PUBLIC/PRIVATE RETURNTYPE NAME(VAR PARAMETER) 
    { 
        return RETURNTYPE;
    }
    
    Wanna Learn? DotNet has great Documentation and Tutorials -> dotnet.microsoft.com/learn/dotnet/
*/


using System;

namespace StreamConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Intro intro = new Intro();
            
            intro.getCoachInfo();
            intro.checkCoachInfo();
            intro.LoopsBaby();
            
            CookieCutter cutter = new CookieCutter("Vegan Sour Dough", "(Vegan)Chocolate chip", 10);
            Console.WriteLine(cutter.CutCookie());

            Console.WriteLine(cutter.RemindMeToCutCookieOn(2));
            
        }
    }
}