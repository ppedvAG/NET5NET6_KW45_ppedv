namespace AsyncAwaitSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task1 = MachAusgabeNach10Sek();
            Task task2 = MachAusgabeNach15Sek();
            Task task3 = MachAusgabeNach20Sek();

            Console.WriteLine("Main-Methode ist fertig");


            Task.WaitAll(task1, task2, task3);
        }


        #region Asynchron mit Task 
        public static async Task MachAusgabeNach10Sek()
        {
            await Task.Delay(10000);
            Console.WriteLine("Text nach 10 Sekunden");

            //return Task.CompletedTask; -> wird bei async/await nicht mehr benötigt
        }

        public static async Task MachAusgabeNach15Sek()
        {
            //Task.Delay(15000).Wait();
            //Console.WriteLine("Text nach 15 Sekunden");

            //return Task.CompletedTask;


            await Task.Delay(15000);
            Console.WriteLine("Text nach 15 Sekunden");

            //return Task.CompletedTask;
        }

        public static async Task MachAusgabeNach20Sek()
        {
            await Task.Delay(20000);
            Console.WriteLine("Text nach 15 Sekunden");
        }
        #endregion


    }


}