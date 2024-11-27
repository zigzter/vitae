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
        var scale = 0.02f;
        var random = new Random();
        var seed = random.Next(1000);
        var threshold = 0.38f; // Increae number for more water
        var offsetX = 50;
        var offsetY = 30;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < width; y++)
            {
                var scaledX = (int)((x + seed + offsetX) * scale * 100);
                var scaledY = (int)((y + seed + offsetY) * scale * 100);
                var noiseValue = (float)noise.CalcPixel2D(scaledX, scaledY, 1) / 255.0f;
                grid[x, y] = new Terrain(noiseValue < threshold ? TerrainType.Water : TerrainType.Earth, x, y);
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
