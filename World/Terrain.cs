using SFML.System;

public enum TerrainType { Water, Earth, Mountain, Peak }

public class Terrain
{
    public Vector2i Position { get; }
    public TerrainType Type { get; set; }
    public Terrain(TerrainType type, int x, int y)
    {
        this.Type = type;
        this.Position = new Vector2i(x, y);
    }
    public bool IsTraversable => Type == TerrainType.Earth;
}
