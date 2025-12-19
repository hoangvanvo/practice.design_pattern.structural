
namespace Practice.DesignPattern.Structural.Adapter
{
    public class ReportDataService : IReportData //Class thực thi IReportData trong thư viện bên thứ 3
    {
        public async Task<PostData[]> GetData()
        {
            var result = new List<PostData>();
            //Gọi solr
            //Gọi elastic
            //Gọi sql server
            //Gọi service khác
            //Xử lý logic phức tạp
            return result.ToArray();
        }
    }
}
