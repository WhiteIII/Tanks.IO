public interface ITank : IAttackable, IMovable, IUpgradable
{
    public int CountOfPoints { get; }
    public int Heal { get; }
}
