using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
    }
}
