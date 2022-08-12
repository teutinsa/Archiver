namespace Archiver
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            //TODO: Do update checking
            switch(new UpdateDialog().ShowDialog())
            {
                case DialogResult.Yes: //New update available
                    Application.Restart();
                    break;

                case DialogResult.Abort: //Abort start
                    Environment.Exit(0);
                    break;

                case DialogResult.None: //No update available
                default:
                    break;
            }

            Application.Run(new Form());
        }
    }
}