using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class UpgradeUIController : MonoBehaviour
    {
        [SerializeField] private UIDocument uiDocument;
        [SerializeField] private BuildingManager buildingManager;
        [SerializeField] private UnitUpdatesManager unitUpdatesManager;

        private Dictionary<ResourcesTypesEnum, List<Button>> _resourceButtons;
        private Dictionary<ResourcesTypesEnum, int> _currentTier;

        private void Start()
        {
            var root = uiDocument.rootVisualElement;

            _resourceButtons = new Dictionary<ResourcesTypesEnum, List<Button>>
            {
                {
                    ResourcesTypesEnum.Wood, new List<Button>
                    {
                        root.Q<Button>("upgrade-wood-tier-one-button"),
                        root.Q<Button>("upgrade-wood-tier-two-button"),
                        root.Q<Button>("upgrade-wood-tier-three-button"),
                        root.Q<Button>("upgrade-wood-tier-four-button")
                    }
                },
                {
                    ResourcesTypesEnum.Gold, new List<Button>
                    {
                        root.Q<Button>("upgrade-gold-tier-one-button"),
                        root.Q<Button>("upgrade-gold-tier-two-button"),
                        root.Q<Button>("upgrade-gold-tier-three-button"),
                        root.Q<Button>("upgrade-gold-tier-four-button")
                    }
                },
                {
                    ResourcesTypesEnum.Stone, new List<Button>
                    {
                        root.Q<Button>("upgrade-stone-tier-one-button"),
                        root.Q<Button>("upgrade-stone-tier-two-button"),
                        root.Q<Button>("upgrade-stone-tier-three-button"),
                        root.Q<Button>("upgrade-stone-tier-four-button")
                    }
                },
                {
                    ResourcesTypesEnum.Food, new List<Button>
                    {
                        root.Q<Button>("upgrade-food-tier-one-button"),
                        root.Q<Button>("upgrade-food-tier-two-button"),
                        root.Q<Button>("upgrade-food-tier-three-button"),
                        root.Q<Button>("upgrade-food-tier-four-button")
                    }
                }
            };

            _currentTier = new Dictionary<ResourcesTypesEnum, int>
            {
                { ResourcesTypesEnum.Wood, 0 },
                { ResourcesTypesEnum.Gold, 0 },
                { ResourcesTypesEnum.Stone, 0 },
                { ResourcesTypesEnum.Food, 0 }
            };

            foreach (var kvp in _resourceButtons)
            {
                var resource = kvp.Key;
                var buttons = kvp.Value;

                for (var i = 0; i < buttons.Count; i++)
                {
                    buttons[i].style.display = DisplayStyle.None;

                    var tierIndex = i + 1;
                    buttons[i].clicked += () => { OnTierUpgraded(resource, tierIndex); };
                }
            }

            foreach (var resource in _resourceButtons.Keys)
            {
                UpdateVisibleTier(resource);
            }
        }

        private void OnTierUpgraded(ResourcesTypesEnum resource, int tierIndex)
        {
            unitUpdatesManager.UpdatedSpeedBonusTier(resource, tierIndex);
            
            unitUpdatesManager.InvalidateBonusCache(resource);

            _currentTier[resource] = tierIndex;
            UpdateVisibleTier(resource);
        }

        private void UpdateVisibleTier(ResourcesTypesEnum resource)
        {
            var buttons = _resourceButtons[resource];

            foreach (var btn in buttons)
                btn.style.display = DisplayStyle.None;

            int currentTier = _currentTier[resource];
            if (currentTier < buttons.Count)
            {
                buttons[currentTier].style.display = DisplayStyle.Flex;
            }
        }
    }
}