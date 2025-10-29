using Practice.DesignPattern.Structural.Bridge.DesignPattern;

namespace Practice.DesignPattern.Structural.Adapter.DesignPattern
{
    public class PatternDemo
    {
        // ===== TARGET INTERFACE (mới) =====
        public interface INewLogger
        {
            string LogInfo(string message);
            string LogError(string message);
        }

        // ===== ADAPTEE (hệ thống cũ) =====
        public class OldLogger
        {
            public string WriteLog(string message)
            {
                return $"[OldLogger] {DateTime.Now}: {message}";
            }
        }

        // ===== ADAPTER =====
        public class OldLoggerAdapter : INewLogger
        {
            private readonly OldLogger _oldLogger;

            public OldLoggerAdapter(OldLogger oldLogger)
            {
                _oldLogger = oldLogger;
            }

            public string LogInfo(string message)
            {
                return _oldLogger.WriteLog($"INFO: {message}");
            }

            public string LogError(string message)
            {
                return _oldLogger.WriteLog($"ERROR: {message}");
            }
        }

        public class NewLogger : INewLogger
        {
            public string LogInfo(string message)
            {
                return $"[NewLogger - INFO] {DateTime.Now}: {message}";
            }
            public string LogError(string message)
            {
                return $"[NewLogger - ERROR] {DateTime.Now}: {message}";
            }
        }

        // ===== FACTORY =====
        public class LoggerFactory
        {
            public INewLogger GetLogger(int version)
            {
                switch (version)
                {
                    case 1: // Old logger
                        return new OldLoggerAdapter(new OldLogger());
                    case 2: // New Logger
                        return new NewLogger();
                    default:
                        throw new Exception("[ERROR] version logger không hợp lệ");
                }
            }
        }
    }
}
