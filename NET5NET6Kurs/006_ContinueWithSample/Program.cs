namespace _006_ContinueWithSample
{
    internal class Program
    {
        private static int[] lottozahlen = new int[7];
        static void Main(string[] args)
        {
            //Anonyme Methode (ja man könnte auch diese Methode auslagern und aufrufen ;-) 
            Task t1 = new Task(() =>
            {
                Console.WriteLine("Task1 - Lottozahlen werden ermittelt");

                lottozahlen[0] = 2;
                lottozahlen[1] = 12;
                lottozahlen[2] = 23;
                lottozahlen[3] = 35;
                lottozahlen[4] = 43;
                lottozahlen[5] = 50;
                lottozahlen[6] = 51;

                //throw new Exception();
            });

            t1.Start();


            #region So kann man einen Task nach dem Anderen starten
            //Allgemeiner Folgetask wird immer gestartet
            Task t2 = t1.ContinueWith(t => AllgemeinerFolgetask());

            Task t3 = t2.ContinueWith(t => AllgemeinerFolgetask2());
            t3.Wait();

            #endregion

            //Dieser Task wird nur ausgeführt, wenn der vorige Task (von t1) einen Fehler geworfen hat 
            t1.ContinueWith(t => FolgetaskBeiFehler(), TaskContinuationOptions.OnlyOnFaulted);

            //Folgetask, wenn voriger Methode ohne Fehler durchgelaufen ist
            t1.ContinueWith(t => FolgetaskBeiErfolg(), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        private static void AllgemeinerFolgetask()
            => Console.WriteLine("Werde immer aufgerufen....vielleicht für Logging");

        private static void AllgemeinerFolgetask2()
             => Console.WriteLine("Werde auch immer aufgerufen");


        private static void FolgetaskBeiFehler()
            => Console.WriteLine("Werde Aufgerufen, wenn die Lottoziehung einen Fehler erfährt -> für Aufräumarbeiten");

        private static void FolgetaskBeiErfolg()
            => Console.WriteLine("Werde im Erfolgsfall aufgerufen");
    }
}