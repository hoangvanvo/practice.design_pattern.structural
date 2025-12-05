namespace Practice.DesignPattern.Structural.BigDemo.Infrastructure
{
    // Very small demo rate limiter - not production ready
    public class RateLimiter
    {
        private int _counter = 0;
        public bool Allow()
        {
            _counter++;
            // allow 4 in a row then block 1 (simple demo)
            return _counter % 5 != 0;
        }
    }
}
