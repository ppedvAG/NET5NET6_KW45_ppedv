namespace _001_Task_starten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(MachEtwasInEinemTask); //Funktionzeiger übergeben (Adresse der Methode) 

            task.Start(); //Aufgabe wird gestartet 
            task.Wait(); //Callback bedeutet -> Wir warten bis die Methode 'MachEtwasInEinemTask' fertig ist 
            
            for (int i = 0; i < 5000; i++)
            {
                Console.WriteLine("*");
            }

            Console.ReadLine();
        }

        private static void MachEtwasInEinemTask()
        {
            for(int i = 0; i < 5000; i++)
            {
                Console.WriteLine($"{i} #");
            }
        }
    }
}