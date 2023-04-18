namespace asteroid_fever.Domain.Enums
{
    public enum Material
    {
        Unknown = 0,
        Ice = 1,
        Rock = 2,
        Iron = 3
    }

    public static class MaterialExtensions
    {
        public static double Strength(this Material material)
        {
            switch (material)
            {
                case Material.Ice:
                    return 0.5;
                case Material.Rock:
                    return 1.0;
                case Material.Iron:
                    return 2.0;
                default:
                    return 1.0;
            }
        }
    }
}
