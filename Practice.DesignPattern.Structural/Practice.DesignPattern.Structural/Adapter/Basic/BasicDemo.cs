namespace Practice.DesignPattern.Structural.Adapter.Basic
{
    public class BasicDemo
    {
        // ======= Logger mới (mong muốn chuẩn mới) =======
        public interface INewLogger
        {
            string LogInfo(string message);
            string LogError(string message);
        }

        // ======= Logger cũ (legacy, không tương thích) =======
        public class OldLogger
        {
            public string WriteLog(string message)
            {
                return $"[OldLogger] {DateTime.Now}: {message}";
            }
        }

        // ======= Logger mới giả lập =======
        public class NewLogger : INewLogger
        {
            public string LogInfo(string message)
            {
                return $"[NewLogger] INFO: {message}";
            }

            public string LogError(string message)
            {
                return $"[NewLogger] ERROR: {message}";
            }
        }
    }
}
