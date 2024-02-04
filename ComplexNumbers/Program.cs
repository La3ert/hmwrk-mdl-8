namespace ComplexNumbers;

class Program
{
    static void Main(string[] args)
    {
        Complex c = new Complex(1, 1);
        Complex c1 = new Complex(1, 2);

        Complex result = c.Plus(c1);
        Console.WriteLine($"Result:\nReal {result.Real}\nImaginary {result.Imaginary}");
    }
}   