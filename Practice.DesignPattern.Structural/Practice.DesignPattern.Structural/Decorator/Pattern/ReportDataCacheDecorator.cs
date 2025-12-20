namespace Practice.DesignPattern.Structural.Decorator.Pattern
{
    public class ReportDataCacheDecorator : ReportDataDecorator
    {
        public ReportDataCacheDecorator(IReportData reportData) : base(reportData)
        {
        }

        public override async Task<PostData[]> GetData()
        {
            //Check cache
            var isCacheAvailable = false; //Giả sử không có cache
            if (isCacheAvailable)
            {
                //Lấy dữ liệu từ cache
                return Array.Empty<PostData>(); //Giả sử trả về dữ liệu cache
            }
            else
            {
                var data = await base.GetData();
                //Lưu dữ liệu vào cache
                return data;
            }
        }
    }
}
