using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Vitae
{
    class Program
    {
        static void Main()
        {
            var window = new RenderWindow(new VideoMode(800, 600), "Simulation");
            window.Closed += (sender, e) => window.Close();
            var world = new World(50, 50);
            world.Initialize();

            var renderer = new Renderer(window);

            var clock = new Clock();
            while (window.IsOpen)
            {
                window.DispatchEvents();
                var deltaTime = clock.Restart();
                world.Update(deltaTime.AsSeconds());
                window.Clear(Color.Black);
                world.Draw(renderer);
                window.Display();
            }

        }
    }
}
