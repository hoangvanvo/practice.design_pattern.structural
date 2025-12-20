namespace Practice.DesignPattern.Structural.Decorator.Normal
{
    public class ReportDataV2 : IReportDataV2
    {
        private readonly IReportData _reportData;
        public ReportDataV2(IReportData reportData)
        {
            _reportData = reportData;
        }

        public async Task<PostData[]> GetDataV2()
        {
            try
            {
                return await _reportData.GetData();
            } 
            catch(Exception ex)
            {
                return Array.Empty<PostData>();
            }
        }
    }
}
