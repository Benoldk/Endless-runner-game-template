using System;

namespace game.package.ui
{
    public static class HUDEvents
    {
        public static Action<int> OnUIAddToScore;
        public static Action<int> OnUIAddToCurrency;
        public static Action<int> OnUIAddToScoreMultipler;
        public static Action<int> OnUpdateHP;
        public static Action<bool> OnGamePaused;
    }
}