using ConsoleWithEFCoreSample.Data;
using ConsoleWithEFCoreSample.Entities;

namespace ConsoleWithEFCoreSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SchoolContext context= new SchoolContext())
            {
                //EF Core (read/insert/update/delete) 

                IList<Student> allStudents = context.Students.ToList(); 
            }
        }
    }
}