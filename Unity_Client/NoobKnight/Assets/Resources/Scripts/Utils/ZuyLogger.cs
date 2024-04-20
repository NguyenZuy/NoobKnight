using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoobKnight.Tools
{
    public static class ZuyLogger
    {
        public static void Log(string prefix, string message)
        {
            Debug.LogFormat("{0}{1}", prefix, message);
        }
        public static void LogWarning(string prefix, string message)
        {
            Debug.LogWarningFormat("{0}{1}", prefix, message);
        }
        public static void LogError(string prefix, string message)
        {
            Debug.LogErrorFormat("{0}{1}", prefix, message);
        }
    }
}
