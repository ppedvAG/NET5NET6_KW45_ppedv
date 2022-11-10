namespace ExtentionMethodeSample
{
    using ExtentionMethodeSample.Extentions;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Person p = new Person() { Id = 123, Name = "Otto Walkes" };
            p.MehrGehalt(500);

        }
    }


    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }    
    }
}

namespace ExtentionMethodeSample.Extentions
{
    public static class PersonExtentions
    {
        public static void MehrGehalt(this Person person, int offSetGehalt)
        {
            //......
        }
    }
}