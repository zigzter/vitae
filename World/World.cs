public class World
{
    private readonly int width;
    private readonly int height;
    private readonly List<Entity> entities;
    private readonly GridCell[,] grid;
    private readonly Random random;

    public World(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.grid = new GridCell[width, height];
        this.entities = new List<Entity>();
        this.random = new Random();
    }

    public void Initialize()
    {
        var noise = new Simplex.Noise();
        noise.Seed = random.Next();
        var scale = 0.10f;
        var peakThreshold = 235f;
        var mountainThreshold = 200f;
        var earthThreshold = 50f;
        float[,] noiseValues = noise.Calc2D(height, width, scale);
        for (int x = 0; x < noiseValues.GetLength(0); x++)
        {
            for (int y = 0; y < noiseValues.GetLength(0); y++)
            {
                var noiseVal = noiseValues[x, y];
                Terrain terrain;
                switch (noiseVal)
                {
                    case var value when value > peakThreshold:
                        terrain = new Terrain(TerrainType.Peak, x, y);
                        break;
                    case var value when value > mountainThreshold:
                        terrain = new Terrain(TerrainType.Mountain, x, y);
                        break;
                    case var value when value > earthThreshold:
                        terrain = new Terrain(TerrainType.Earth, x, y);
                        break;
                    default:
                        terrain = new Terrain(TerrainType.Water, x, y);
                        break;
                }
                grid[x, y] = new GridCell(x, y, terrain);
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
        foreach (var entity in entities) entity.Draw(renderer);
    }
}
