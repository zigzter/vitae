using SFML.Graphics;

public class Plant : Entity
{
    public override void Update(World world, float deltaTime) { }
    public override void Draw(Renderer renderer)
    {
        renderer.DrawRectangle(Position, Color.Yellow);
    }
}
