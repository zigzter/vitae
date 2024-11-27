public abstract class LivingEntity : Entity
{
    public int Health { get; set; }
    public int Hunger { get; set; }
    public int Thirst { get; set; }

    public abstract void Reproduce();
}
