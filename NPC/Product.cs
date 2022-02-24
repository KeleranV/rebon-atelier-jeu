namespace Jeu_1
{
    public class Product
    {
        private int m_Price = 0;
        private Item m_Item;

        public int Price { get => m_Price; }
        public Item Item { get => m_Item; }

        public Product(int a_Price, Item a_Item)
        {
            m_Price = a_Price;
            m_Item = a_Item;
        }
    }
}