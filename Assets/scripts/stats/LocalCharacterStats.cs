namespace game.package.fsm.stats
{
    public class LocalCharacterStats
    {
        public int Health;
        public float Speed;
        public float MaxSpeed;
        public float Acceleration;
        public float IdleDuration;

        public LocalCharacterStats(CharacterStats stats)
        {
            CopyStats(stats);
        }


        protected virtual void CopyStats(CharacterStats stats)
        {
            Health = stats.Health;
            Speed = stats.Speed;
            MaxSpeed = stats.MaxSpeed;
            Acceleration = stats.Acceleration;
            IdleDuration = stats.IdleDuration;
        }
    }
}