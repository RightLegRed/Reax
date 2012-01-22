using System;

namespace Reax {
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Reax game = new Reax())
            {
                game.Run();
            }
        }
    }
#endif
}

