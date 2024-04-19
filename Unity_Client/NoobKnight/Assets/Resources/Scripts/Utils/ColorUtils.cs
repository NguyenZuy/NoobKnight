using UnityEngine;

public static class ColorUtils
{
    // Phương thức chuyển đổi từ Color32 sang integer
    public static int Color32ToInt(Color32 color)
    {
        return color.r << 24 | color.g << 16 | color.b << 8 | color.a;
    }

    // Phương thức chuyển đổi từ integer sang Color32
    public static Color32 IntToColor32(int intColor)
    {
        return new Color32(
            (byte)((intColor >> 24) & 0xFF),
            (byte)((intColor >> 16) & 0xFF),
            (byte)((intColor >> 8) & 0xFF),
            (byte)(intColor & 0xFF)
        );
    }
}
