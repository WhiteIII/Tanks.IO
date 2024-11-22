namespace TanksIO.Common.Services
{
    public interface IEntityHealthValue
    {
        public int MaxHealth { get; }
        public int HealthValue { get; }
    }
}