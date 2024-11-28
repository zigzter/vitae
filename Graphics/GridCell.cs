using SFML.System;

public class GridCell
{
    public Vector2i Position { get; }
    public Terrain terrain { get; set; }
    public Entity? entity { get; set; }

    public GridCell(int x, int y, Terrain terrain)
    {
        Position = new Vector2i(x, y);
        this.terrain = terrain;
        entity = null;
    }
}
