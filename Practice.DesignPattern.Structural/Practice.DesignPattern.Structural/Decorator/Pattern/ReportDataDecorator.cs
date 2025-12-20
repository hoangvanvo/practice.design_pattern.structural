namespace Practice.DesignPattern.Structural.Decorator.Pattern
{
    public abstract class ReportDataDecorator : IReportData
    {
        private readonly IReportData _reportData;

        public ReportDataDecorator(IReportData reportData)
        {
            _reportData = reportData;
        }

        public virtual async Task<PostData[]> GetData()
        {
            return await _reportData.GetData();
        }
    }
}
