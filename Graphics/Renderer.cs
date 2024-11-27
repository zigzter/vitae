using SFML.Graphics;
using SFML.System;

public class Renderer
{
    private readonly RenderWindow window;
    public Renderer(RenderWindow window) { this.window = window; }

    public void DrawTerrain(Terrain[,] grid)
    {
        foreach (var tile in grid)
        {
            var rectangle = new RectangleShape(new Vector2f(10, 10))
            {
                Position = new Vector2f(tile.Position.X * 10, tile.Position.Y * 10),
                FillColor = tile.Type == TerrainType.Earth ? Color.Green : Color.Blue,
                // Outline is only for dev
                /* OutlineColor = Color.Red, */
                /* OutlineThickness = 1.0f */
            };
            window.Draw(rectangle);
        }
    }
    public void DrawEntity(Entity entity) { /* TODO: render */ }
    public void DrawRectangle(Vector2i position, Color color)
    {
        var rectangle = new RectangleShape(new Vector2f(10, 10))
        {
            Position = new Vector2f(position.X * 10, position.Y * 10),
            FillColor = color
        };
        window.Draw(rectangle);
    }
}
