namespace Atelier_jeu
{
    public class NPC
    {
        private string m_Name = "";
        private List<Product> m_Products = new List<Product>();

        public NPC(string a_Name, Product[] a_Products)
        {
            m_Products = new List<Product>();
            m_Name = a_Name;
            // Init market items
            if (a_Products.Length > 0)
            {
                foreach(Product p in a_Products)
                    m_Products.Add(p);
            }
        }

        public Product? GetProduct(int a_Index)
        {
            if (a_Index < 0 || a_Index > m_Products.Count)
                return null;
            return m_Products[a_Index];
        }

        public void DrawMarket()
        {
            Console.WriteLine("¤═════════════════════════════¤\n" +
                              $"         ¤ {m_Name} ¤         \n");

            for (int i = 0; i < m_Products.Count; i++)
            {
                ConsoleColor qualityColor = ConsoleColor.Black;
                switch (m_Products[i].Item.Quality)
                {
                    case EQuality.Poor: qualityColor = ConsoleColor.Gray; break;
                    case EQuality.Common: qualityColor = ConsoleColor.White; break;
                    case EQuality.Uncommon: qualityColor = ConsoleColor.Green; break;
                    case EQuality.Rare: qualityColor = ConsoleColor.DarkBlue; break;
                    case EQuality.Epic: qualityColor = ConsoleColor.Cyan; break;
                    case EQuality.Legendary: qualityColor = ConsoleColor.Red; break;
                }
                Console.ForegroundColor = qualityColor;
                Console.Write($"{i + 1}: {m_Products[i].Item.Name} -> {m_Products[i].Price} gold\n");
            }
            Console.ResetColor();
            //Console.Write($"{m_Products.Count + 1}: Sell Item\n");
            Console.Write($"{m_Products.Count + 1}: Leave\n");

            Console.WriteLine("\n¤═════════════════════════════¤");
        }
    }
}