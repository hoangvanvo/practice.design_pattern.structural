namespace Practice.DesignPattern.Structural.Adapter
{
    public class AdapterRequest
    {
        /// <summary>
        /// Message cần log
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// version logger (1 - old logger, 2 - new logger)
        /// </summary>
        public int version { get; set; }
        /// <summary>
        /// loại log (1 - info, 2 - error)
        /// </summary>
        public int type { get; set; }
    }
}
