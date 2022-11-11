namespace _002_Task_beenden
{
    internal class Program
    {


        //Mit welcher Klassen kann man einen Task beenden?
        //CancelationTokenSource -> Gibt bekannt, dass der Task beendet werden soll
        //CancelationToken -> Ist der Empfänger und bekommt mit, wenn ein Task zu beenden freigegeben wurde


        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task task = new Task(MeineMethodeMitAbbrechen, cts.Token);
            task.Start();

            //Nach drei Sekunden wollen wir den Task abbrechen.

            Task.Delay(3000).Wait();

            cts.Cancel(); //Signal zum Abbrechen des Tasks

            Console.ReadLine();
        }


        private static void MeineMethodeMitAbbrechen(object param)
        {
            if (param is CancellationToken cancellationToken)
            {
                Task task2 = new Task(SubMethodeInEinemTaskMitAbbrechen, cancellationToken);
                task2.Start();

                try
                {
                    while (true)
                    {
                        Console.WriteLine("sleep.......");

                        Task.Delay(50).Wait(); //Thread


                        if (cancellationToken.IsCancellationRequested)
                            cancellationToken.ThrowIfCancellationRequested(); //Wir werden eine Exception und lassen Methode beenden
                    }
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //Aufräumarbeiten :-) (ist wichtig) 
                }

                
            }
            
        }


        private static void SubMethodeInEinemTaskMitAbbrechen(object param)
        {
            if (param is CancellationToken cancellationToken)
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine("schrachhhhhh.......");

                        Task.Delay(50).Wait(); //Thread

                        if (cancellationToken.IsCancellationRequested)
                            cancellationToken.ThrowIfCancellationRequested();
                    }
                }
                catch(OperationCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally 
                { 
                }

                
            }
            
        }
    }
}