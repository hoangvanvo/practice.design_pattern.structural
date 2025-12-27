using Practice.DesignPattern.Structural.Proxy.Normal;

namespace Practice.DesignPattern.Structural.Proxy.Pattern
{
    public class ServiceProxy : IService
    {
        private readonly RealService _realService;

        public ServiceProxy(RealService realService)
        {
            _realService = realService;
        }

        public void GapGiamDoc(string name)
        {
            if (name != "Hứa Văn Duy")
                return;

            _realService.GapGiamDoc(name);
        }
    }
}
