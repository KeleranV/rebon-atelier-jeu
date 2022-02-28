namespace Jeu_1
{
    public class EquipableItem : Item
    {
        private EEquipableType m_EquipableType;

        private int m_Armor = 0;
        private int m_Vitality = 0;
        private int m_Strength = 0;
        private int m_Agility = 0;
        private int m_Magic = 0;
        private int m_MinDamage = 1;
        private int m_MaxDamage = 1;

        public int Armor { get => m_Armor; }
        public int Vitality { get => m_Vitality; }
        public int Strength { get => m_Strength; }
        public int Agility { get => m_Agility; }
        public int Magic { get => m_Magic; }
        public int MinDamage { get => m_MinDamage; }
        public int MaxDamage { get => m_MaxDamage; }

        public EEquipableType EquipableType { get => m_EquipableType; }
    
        public EquipableItem(int a_Price, string a_Name, EQuality a_Quality, EEquipableType a_EquipableType, int[] a_Stats)
            : base (a_Price, a_Name, a_Quality)
        {
            m_EquipableType = a_EquipableType;
            m_Armor = a_Stats[0];
            m_Vitality = a_Stats[1];
            m_Strength = a_Stats[2];
            m_Agility = a_Stats[3];
            m_Magic = a_Stats[4];
            m_MinDamage = a_Stats[5];
            m_MaxDamage = a_Stats[6];
        }

        public override void DrawItem()
        {
            Console.WriteLine("¤════════════════════¤");
            Console.ForegroundColor = p_QualityColor;
            Console.Write($"{p_Name}\n");
            Console.Write($"{p_Quality}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{m_EquipableType}\n");
            if (m_Armor > 0)
                Console.Write($"+{m_Armor} Armor\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (m_MinDamage > 0 && m_MaxDamage > 0)
                Console.Write($"Damage: {m_MinDamage} - {m_MaxDamage}\n");
            if (m_Strength > 0)
                Console.Write($"+{m_Strength} Strength\n");
            if (m_Agility > 0)
                Console.Write($"+{m_Agility} Agility\n");
            if (m_Vitality > 0)
                Console.Write($"+{m_Vitality} Vitality\n");
            if (m_Magic > 0)
                Console.Write($"+{m_Magic} Mana\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"\nValue: {p_Price} Gold\n");
            Console.ResetColor();
            Console.WriteLine("¤════════════════════¤");
        }
    }
}