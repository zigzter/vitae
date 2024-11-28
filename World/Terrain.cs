public enum TerrainType { Water, Earth, Mountain, Peak }

public class Terrain
{
    public TerrainType Type { get; set; }
    public Terrain(TerrainType type, int x, int y)
    {
        this.Type = type;
    }
}
