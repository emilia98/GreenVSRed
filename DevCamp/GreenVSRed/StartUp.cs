namespace GreenVSRed
{
    public class StartUp
    {
        static void Main()
        {
            var game = new Game();
            // User Input
            game.Input();

            // Calcualtions over the grid with the data the user has entered
            game.Play();

            // The result from the calculations
            game.Output();
        }
    }
}
