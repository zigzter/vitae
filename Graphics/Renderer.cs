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
            Color color;
            switch (tile.Type)
            {
                case TerrainType.Earth:
                    // TODO: Break these colors out into vars
                    color = new Color(34, 139, 34);
                    break;
                case TerrainType.Water:
                    color = new Color(100, 181, 246);
                    break;
                case TerrainType.Mountain:
                    color = new Color(101, 67, 33);
                    break;
                case TerrainType.Peak:
                    color = Color.White;
                    break;
                default:
                    color = Color.Black;
                    break;
            }
            var rectangle = new RectangleShape(new Vector2f(10, 10))
            {
                Position = new Vector2f(tile.Position.X * 10, tile.Position.Y * 10),
                FillColor = color,
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
