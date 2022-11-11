namespace _003_TaskFactorySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variante 1 .NET 4.0
            //Variante 1:
            Task task1 = new Task(MacheEtwasInEinemThread);
            task1.Start();
            task1.Wait();
           

            //Variante 2
            Task task2 = Task.Factory.StartNew(MacheEtwasInEinemThread); //Task startet sofort 
            task2.Wait();
            #endregion



            #region Variante 3 - .NET 4.5
            Task task3 = Task.Run(MacheEtwasInEinemThread);  //Task startet sofort 
            task3.Wait();
            #endregion
        }

        private static void MacheEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("*");
            }
        }
    }
}