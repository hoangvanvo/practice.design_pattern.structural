namespace Practice.DesignPattern.Structural.Decorator
{
    public interface IReportData //Giả lập interface nằm trên thư viện bên thứ 3
    {
        Task<PostData[]> GetData(); //bao gồm query solr, elastic, restsharp, logic công thức phức tạp, ...
    }
}

