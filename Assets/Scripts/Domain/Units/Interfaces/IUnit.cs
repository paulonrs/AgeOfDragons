namespace Domain.Units.Interfaces
{
    public interface IUnit
    {
        public string Name { get; }
        public string Type { get; }
        public string Icon { get; }

        public int Life { get; }
        public int Speed { get; }
        public int MaxHealth { get; }
        public int CurrentHealth { get; }
        public int Armor { get; }
        public int Damage { get; }
        public int AttackRange { get; }
        public int AttackSpeed { get; }
        public int VisionRange { get; }
        public bool IsDead => CurrentHealth <= 0;
        public bool InDamage => false;
    }
}