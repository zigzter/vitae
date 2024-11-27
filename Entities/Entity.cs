using SFML.System;

public abstract class Entity
{
    public Vector2i Position { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public abstract void Update(World world, float deltaTime);
    public abstract void Draw(Renderer renderer);
}
