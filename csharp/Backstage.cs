namespace csharp
{
    public class Backstage : IGood
    {
        public int SellIn { get; set; }

        public void Update(Quality quality)
        {
            quality.Increase();
        }

        public static IGood Build(int sellIn)
        {
            switch (sellIn)
            {
                case < 0: return new Expired();
                case < 5: return new LessThan5Days();
                case < 10: return new LessThan10Days();
                default: return new Backstage();
            }
        }

        public class Expired : IGood
        {
            public int SellIn { get; set; }

            public void Update(Quality quality)
            {
                quality.Reset();
            }
        }

        public class LessThan5Days : IGood
        {
            public int SellIn { get; set; }

            public void Update(Quality quality)
            {
                quality.Increase();
                quality.Increase();
                quality.Increase();
            }
        }

        public class LessThan10Days : IGood
        {
            public int SellIn { get; set; }

            public void Update(Quality quality)
            {
                quality.Increase();
                quality.Increase();
            }
        }
    }
}