namespace Practice.DesignPattern.Structural.Decorator.Pattern
{
    public class ReportDataRetryDecorator : ReportDataDecorator
    {
        private readonly int _maxRetries;
        public ReportDataRetryDecorator(IReportData reportData, int maxRetries = 3) : base(reportData)
        {
            _maxRetries = maxRetries;
        }
        public override async Task<PostData[]> GetData()
        {
            int attempt = 0;
            while (true)
            {
                try
                {
                    return await base.GetData();
                }
                catch (Exception ex)
                {
                    attempt++;
                    if (attempt >= _maxRetries)
                    {
                        throw; // Rethrow the exception after max retries
                    }
                    // Optionally, add a delay before retrying
                    await Task.Delay(1000);
                }
            }
        }
    }
}
