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
        for (int x = 0; x < width; x++)
        {

            for (int y = 0; y < width; y++)
            {
                var type = random.NextDouble() < 0.7 ? TerrainType.Earth : TerrainType.Water;
                grid[x, y] = new Terrain(type, x, y);
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
