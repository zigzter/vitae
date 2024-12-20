using SFML.Graphics;
using SFML.System;

public class Renderer
{
    private readonly RenderWindow window;
    public Renderer(RenderWindow window) { this.window = window; }

    public void DrawTerrain(GridCell[,] grid)
    {
        foreach (var cell in grid)
        {
            Color color;
            switch (cell.terrain.Type)
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
                Position = new Vector2f(cell.Position.X * 10, cell.Position.Y * 10),
                FillColor = color,
            };
            window.Draw(rectangle);
        }
    }
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
