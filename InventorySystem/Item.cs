namespace Atelier_jeu
{
    public abstract class Item
    {
        protected string m_Name = "";
        protected int m_Price = 0;
        protected EQuality m_Quality = EQuality.Poor;

        public int Price { get => m_Price; }
        public string Name { get => m_Name; }
        public EQuality Quality { get => m_Quality; }


        public Item(int a_Price, string a_Name, EQuality a_Quality)
        {
            m_Price = a_Price;
            m_Name = a_Name;
            m_Quality = a_Quality;
        }

        public abstract void DrawItem();
    }
}