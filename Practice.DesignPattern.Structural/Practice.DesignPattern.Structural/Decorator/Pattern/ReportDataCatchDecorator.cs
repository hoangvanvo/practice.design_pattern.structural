namespace Practice.DesignPattern.Structural.Decorator.Pattern
{
    public class ReportDataCatchDecorator : ReportDataDecorator
    {
        public ReportDataCatchDecorator(IReportData reportData) : base(reportData)
        {
        }
        public override async Task<PostData[]> GetData()
        {
            try
            {
                return await base.GetData();
            }
            catch (Exception ex)
            {
                return Array.Empty<PostData>();
            }
        }
    }
}
