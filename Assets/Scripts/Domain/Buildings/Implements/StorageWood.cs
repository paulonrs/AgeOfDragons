using UnityEngine;

namespace Domain.Buildings.Implements
{
    public class StorageWood : MonoBehaviour
    {
        [SerializeField] private string buildingName = "Storage of wood";
        [SerializeField] private string buildingType = "Storage";
        [SerializeField] private string buildingIcon = "wood_storage_icon";
        [SerializeField] private int life = 100;
        [SerializeField] private int damage = 0;
        [SerializeField] private int armor = 5;
        [SerializeField] private int costOfGold = 50;
        [SerializeField] private int costOfWood = 100;
        [SerializeField] private int costOfFood = 0;
        [SerializeField] private int costOfStone = 25;
        [SerializeField] private double woodCollectionSpeedBonus = 0;

        public string Name => buildingName;
        public string Type => buildingType;
        public string Icon => buildingIcon;
        public int Life => life;
        public int Health => Life;
        public int Damage => damage;
        public int Armor => armor;
        public int CostOfGold => costOfGold;
        public int CostOfWood => costOfWood;
        public int CostOfFood => costOfFood;
        public int CostOfStone => costOfStone;
        public double WoodCollectionSpeedBonus => woodCollectionSpeedBonus;
        
        void Start()
        {

        }

        void Update()
        {
            
        }
    }
}
