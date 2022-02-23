namespace Atelier_jeu
{
    public abstract class Item
    {
        protected string p_Name = "";
        protected int p_Price = 0;
        protected EQuality p_Quality = EQuality.Poor;

        public int Price { get => p_Price; }
        public string Name { get => p_Name; }
        public EQuality Quality { get => p_Quality; }


        public Item(int a_Price, string a_Name, EQuality a_Quality)
        {
            p_Price = a_Price;
            p_Name = a_Name;
            p_Quality = a_Quality;
        }

        public abstract void DrawItem();
    }
}