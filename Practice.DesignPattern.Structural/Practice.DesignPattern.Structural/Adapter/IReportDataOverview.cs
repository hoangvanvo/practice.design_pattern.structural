namespace Practice.DesignPattern.Structural.Adapter
{
    public interface IReportDataOverview //interface mới thay thế cho IReportData
    {
        Task<FeedData[]> GetDataOverview();
    }
}
