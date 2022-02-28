namespace Jeu_1
{
    public abstract class Item
    {
        protected string p_Name = "";
        protected int p_Price = 0;
        protected EQuality p_Quality = EQuality.Poor;

        protected ConsoleColor p_QualityColor;

        public int Price { get => p_Price; }
        public string Name { get => p_Name; }
        public EQuality Quality { get => p_Quality; }

        public ConsoleColor QualityColor { get => p_QualityColor; }


        public Item(int a_Price, string a_Name, EQuality a_Quality)
        {
            p_Price = a_Price;
            p_Name = a_Name;
            p_Quality = a_Quality;

            switch(p_Quality)
            {
                case EQuality.Poor: p_QualityColor = ConsoleColor.DarkGray; break;
                case EQuality.Common: p_QualityColor = ConsoleColor.White; break;
                case EQuality.Uncommon: p_QualityColor = ConsoleColor.Green; break;
                case EQuality.Rare: p_QualityColor = ConsoleColor.DarkBlue; break;
                case EQuality.Epic: p_QualityColor = ConsoleColor.Cyan; break;
                case EQuality.Legendary: p_QualityColor = ConsoleColor.DarkRed; break;
            }
        }

        public abstract void DrawItem();
    }
}