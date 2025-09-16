namespace Domain.Buildings.Interfaces
{
    public interface IBuilding
    {
        public string Name { get; }
        public string Type { get; }
        public string Icon { get; }
    
        public int Life { get;  }
        public int Health { get; }
        public int Damage { get; }
        public int Armor { get; }
    
        public bool IsBroken => Life <= 0;
    
        public int CostOfGold { get; }
        public int CostOfWood { get; }
        public int CostOfFood { get; }
        public int CostOfStone { get; }
    
    
        /* Upgrades */
        public virtual double WoodCollectionSpeedBonus => 0;
        public double FoodCollectionSpeedBonus => 0;
        public double StoneCollectionSpeedBonus => 0;
        public double GoldCollectionSpeedBonus => 0;
    }
}

