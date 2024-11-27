public class World
{
    private readonly int width;
    private readonly int height;
    private readonly List<Entity> entities;
    private readonly Terrain[,] grid;
    private readonly Random random;

    public World(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.grid = new Terrain[width, height];
        this.entities = new List<Entity>();
        this.random = new Random();
    }

    public void Initialize()
    {
        var noise = new Simplex.Noise();
        var scale = 0.10f;
        var waterThreshold = 90f;
        float[,] noiseValues = noise.Calc2D(height, width, scale);
        for (int x = 0; x < noiseValues.GetLength(0); x++)
        {

            for (int y = 0; y < noiseValues.GetLength(0); y++)
            {
                var noiseVal = noiseValues[x, y];
                switch (noiseVal)
                {
                    case var value when value < waterThreshold:
                        grid[x, y] = new Terrain(TerrainType.Water, x, y);
                        break;
                    default:
                        grid[x, y] = new Terrain(TerrainType.Earth, x, y);
                        break;
                }
            }
        }
    }

    public void Update(float deltaTime)
    {
        foreach (var entity in entities) entity.Update(this, deltaTime);
    }
    public void Draw(Renderer renderer)
    {
        renderer.DrawTerrain(grid);
        foreach (var entity in entities) renderer.DrawEntity(entity);
    }
}
