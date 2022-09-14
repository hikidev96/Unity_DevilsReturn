using UnityEngine;

namespace DevilsReturn
{
    public interface ICardData
    {
        public LocalizedString CardName { get; }
        public LocalizedString CardDescription { get; }
        public ETier CardTier { get; }
    }
}
