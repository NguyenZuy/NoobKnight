using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoobKnight.Utils
{
    public static class ZuyLogger
    {
        private static bool _isUseDebug = true;

        private static Dictionary<LogType, LogColor> _logColorMap = new Dictionary<LogType, LogColor>()
        {
            {LogType.Nakama, LogColor.yellow },
            {LogType.Authentication, LogColor.blue },
        };

        public static void Log(LogType qLogType, string message)
        {
            if (!_isUseDebug)
                return;

            if (_logColorMap.TryGetValue(qLogType, out LogColor logColor))
            {
                Debug.Log($"<color={logColor}><b>[{qLogType}]</b>: </color>{message}");
            }
        }

        public static void LogWarning(LogType qLogType, string message)
        {
            if (!_isUseDebug)
                return;

            if (_logColorMap.TryGetValue(qLogType, out LogColor logColor))
            {
                Debug.LogWarning($"<color={logColor}><b>[{qLogType}]</b>: </color>{message}");
            }
        }

        public static void LogError(LogType qLogType, string message)
        {
            if (!_isUseDebug)
                return;

            if (_logColorMap.TryGetValue(qLogType, out LogColor logColor))
            {
                Debug.LogError($"<color={logColor}><b>[{qLogType}]</b>: </color>{message}");
            }
        }

        public enum LogType
        {
            Nakama,
            Authentication,
        }

        public enum LogColor
        {
            white,
            red,
            blue,
            green,
            yellow,
            cyan,
            magenta,
            pink,
            purple
        }
    }
}
