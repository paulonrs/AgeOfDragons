using Application;
using Domain.Units.Interfaces;
using Enums;
using UnityEngine;

namespace Domain.Units.Implements
{
    public class Worker : MonoBehaviour, IUnit
    {
        [SerializeField] private string unitName = "Worker";
        [SerializeField] private string unitType = "Unit";
        [SerializeField] private string unitIcon = "worker_icon";
        [SerializeField] private int life = 50;
        [SerializeField] private int speed = 3;
        [SerializeField] private int maxHealth = 50;
        [SerializeField] private int currentHealth = 50;
        [SerializeField] private int armor = 0;
        [SerializeField] private int damage = 5;
        [SerializeField] private int attackRange = 1;
        [SerializeField] private int attackSpeed = 2;
        [SerializeField] private int visionRange = 4;
        
        // Speed base
        [SerializeField] private float baseWoodCollectionSpeed = 1;
        [SerializeField] private float baseFoodCollectionSpeed = 1;
        [SerializeField] private float baseStoneCollectionSpeed = 1;
        [SerializeField] private float baseGoldCollectionSpeed = 1;
        
        // Working
        [SerializeField] private bool collectingWood = false;
        [SerializeField] private bool collectingFood = false;
        [SerializeField] private bool collectingStone = false;
        [SerializeField] private bool collectingGold = false;
        [SerializeField] private bool building = false;
        private bool IsWorking => collectingWood || collectingFood || collectingStone || collectingGold || building;
        
        public string Name => unitName;
        public string Type => unitType;
        public string Icon => unitIcon;
        public int Life => life;
        public int Speed => speed;
        public int MaxHealth => maxHealth;
        public int CurrentHealth => currentHealth;
        public int Armor => armor;
        public int Damage => damage;
        public int AttackRange => attackRange;
        public int AttackSpeed => attackSpeed;
        public int VisionRange => visionRange;

        [SerializeField] private float woodCollectionSpeed;
        [SerializeField] private float foodCollectionSpeed;
        [SerializeField] private float stoneCollectionSpeed;
        [SerializeField] private float goldCollectionSpeed;

        public float WoodCollectionSpeed => woodCollectionSpeed;
        public float FoodCollectionSpeed => foodCollectionSpeed;
        public float StoneCollectionSpeed => stoneCollectionSpeed;
        public float GoldCollectionSpeed => goldCollectionSpeed;

        
        private void OnEnable()
        {
            var manager = FindFirstObjectByType<UnitUpdatesManager>();
            if (manager != null)
            {
                manager.OnBonusesUpdated += UpdateBonuses;
                UpdateBonuses(manager);
            }
        }

        private void OnDisable()
        {
            var manager = FindFirstObjectByType<UnitUpdatesManager>();
            if (manager != null)
            {
                manager.OnBonusesUpdated -= UpdateBonuses;
            }
        }
        
        public float CalculateTotalBonus(ResourcesTypesEnum resourceType)
        {
            var manager = FindFirstObjectByType<UnitUpdatesManager>();
            
            if (manager == null) return 0f;

            return manager.GetBonusCollectionSpeed(resourceType);
        }
        
        private void UpdateBonuses(UnitUpdatesManager manager)
        {
            woodCollectionSpeed = baseWoodCollectionSpeed + CalculateTotalBonus(ResourcesTypesEnum.Wood);
            foodCollectionSpeed = baseFoodCollectionSpeed + CalculateTotalBonus(ResourcesTypesEnum.Food);
            stoneCollectionSpeed = baseStoneCollectionSpeed + CalculateTotalBonus(ResourcesTypesEnum.Stone);
            goldCollectionSpeed = baseGoldCollectionSpeed + CalculateTotalBonus(ResourcesTypesEnum.Gold);
        }
    }
}
