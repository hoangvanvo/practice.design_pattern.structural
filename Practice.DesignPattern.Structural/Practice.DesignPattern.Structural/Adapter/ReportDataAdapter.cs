namespace Practice.DesignPattern.Structural.Adapter
{
    public class ReportDataAdapter : IReportDataOverview
    {
        private readonly IReportData _reportData;
        public ReportDataAdapter(IReportData reportData)
        {
            _reportData = reportData;
        }

        public async Task<FeedData[]> GetDataOverview()
        {
            var postDatas = await _reportData.GetData();
            return ConvertToFeedData(postDatas);
        }

        private FeedData[] ConvertToFeedData(PostData[] postData)
        {
            var result = Array.Empty<FeedData>();
            //CODE CHUYỂN ĐỔI từ PostData[] sang FeedData[] Ở ĐÂY (300 dòng code)
            return result;
        }
    }
}
