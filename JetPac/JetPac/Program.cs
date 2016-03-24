using System;

namespace JetPac
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MainGameLoop game = new MainGameLoop())
            {
                game.Run();
            }
        }
    }
#endif
}

