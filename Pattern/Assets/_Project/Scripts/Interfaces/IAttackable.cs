public interface IAttackable : IBodyAttackable
{
    public int Damage { get; }
    public float AttackSpeed { get; }
    public float BulletSpeed { get; }
    public int BulletPenetration { get; }
}
