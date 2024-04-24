using System;

namespace NoobKnight.Utils
{
    public static class ConvertService
    {
        public static ItemType GetItemTypeByID(int ID)
        {
            string IDStr = ID.ToString();
            string signal = IDStr.Substring(0, 1);
            return Enum.TryParse<ItemType>(signal, out ItemType result) ? result : default;
        }

        public static AppearanceSubType GetSubTypeAppearanceFromID(int ID)
        {
            string IDStr = ID.ToString();
            string signal = IDStr.Substring(2, 2);
            return Enum.TryParse<AppearanceSubType>(signal, out AppearanceSubType result) ? result : default;
        }


    }
}
