using System;
using System.Collections.Generic;
using Application.Data;
using Enums;
using UnityEngine;

namespace Application
{
    public class UnitUpdatesManager : MonoBehaviour
    {
        public event Action<UnitUpdatesManager> OnBonusesUpdated;

        private Dictionary<ResourcesTypesEnum, ResourceBonusData> _resourceBonuses;

        private void InitializeResourceBonuses()
        {
            if (_resourceBonuses != null) return;

            _resourceBonuses = new Dictionary<ResourcesTypesEnum, ResourceBonusData>
            {
                { ResourcesTypesEnum.Wood,  new ResourceBonusData(new[] { 0, 0.25f, 0.40f, 0.60f, 1.0f }) },
                { ResourcesTypesEnum.Food,  new ResourceBonusData(new[] { 0, 0.20f, 0.35f, 0.55f, 0.90f }) },
                { ResourcesTypesEnum.Stone, new ResourceBonusData(new[] { 0, 0.15f, 0.30f, 0.50f, 0.80f }) },
                { ResourcesTypesEnum.Gold,  new ResourceBonusData(new[] { 0, 0.10f, 0.25f, 0.45f, 0.70f }) }
            };
        }

        public float GetBonusCollectionSpeed(ResourcesTypesEnum resourceType)
        {
            InitializeResourceBonuses();
        
            var resourceData = _resourceBonuses[resourceType];

            if (!resourceData.IsDirty)
                return resourceData.CachedBonus;

            resourceData.CachedBonus = resourceData.BonusByTier[resourceData.Tier];
            resourceData.IsDirty = false;

            OnBonusesUpdated?.Invoke(this);

            return resourceData.CachedBonus;
        }

        public void UpdatedSpeedBonusTier(ResourcesTypesEnum resource, int tier)
        {
            InitializeResourceBonuses();
            _resourceBonuses[resource].Tier = tier;
            InvalidateBonusCache(resource);
        }

        public void InvalidateBonusCache(ResourcesTypesEnum resource)
        {
            InitializeResourceBonuses();
            _resourceBonuses[resource].IsDirty = true;
        }
    }
}