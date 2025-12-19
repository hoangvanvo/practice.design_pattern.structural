namespace Practice.DesignPattern.Structural.Adapter
{
    public interface IReportData //Giả lập interface nằm trên thư viện bên thứ 3
    {
        Task<PostData[]> GetData(); //bao gồm query solr, elastic, restsharp, logic công thức phức tạp, ...
    }
}

