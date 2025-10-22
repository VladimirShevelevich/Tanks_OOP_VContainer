namespace Game.Analytics
{
    public class AnalyticsContext
    {
        public int Level;
        public int Score;

        public override string ToString()
        {
            return $"Level: {Level}, Score: {Score}";
        }
    }
}