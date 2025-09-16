namespace Application.Data
{
    public class ResourceBonusData
    {
        public float CachedBonus { get; set; }
        public bool IsDirty { get; set; } = true;
        public int Tier { get; set; } = 0;
        public float[] BonusByTier { get; set; }

        public ResourceBonusData(float[] bonusByTier)
        {
            BonusByTier = bonusByTier;
        }
    }
}