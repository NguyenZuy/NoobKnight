using UnityEngine;

namespace NoobKnight.Utils
{
    public static class ColorUtils
    {
        public static int Color32ToInt(Color32 color)
        {
            return (color.a << 24) | (color.r << 16) | (color.g << 8) | color.b;
        }

        public static Color32 IntToColor32(int colorInt)
        {
            byte a = (byte)((colorInt >> 24) & 0xFF);
            byte r = (byte)((colorInt >> 16) & 0xFF);
            byte g = (byte)((colorInt >> 8) & 0xFF);
            byte b = (byte)(colorInt & 0xFF);
            return new Color32(r, g, b, a);
        }
    }
}
