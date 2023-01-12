using Microsoft.VisualBasic;

namespace TryCatchFinnalyEx;
internal class TryCatchFinnalyEx
{
    class CustomException : DivideByZeroException
    {
    }

    static void Main(string[] args)
    {
        try
        {
            Calc();
        }
        catch (CustomException e)
        {
            Console.WriteLine("Catch CustomException in Main");
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("Catch DivideByZeroException in Main");
        }

        Console.ReadLine();
    }

    private static void Calc()
    {
        try
        {
            throw new DivideByZeroException();
        }
        catch (CustomException e)
        {
            Console.WriteLine("Catch CustomException");
        }
        catch (Exception e)
        {
            Console.WriteLine("Catch Exception");
            throw;
        }
        finally
        {
            throw new CustomException();
        }
    }
}