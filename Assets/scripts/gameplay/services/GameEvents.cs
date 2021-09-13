using System;

namespace game.package.gameplay.services
{
    public static class GameEvents
    {
        public static Action<int> OnUIAddToScore;
        public static Action<int> OnUIAddToCurrency;
        public static Action<int> OnUIAddToScoreMultipler;
    }
}