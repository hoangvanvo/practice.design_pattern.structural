using Microsoft.AspNetCore.Mvc;
using Practice.DesignPattern.Structural.Adapter.DesignPattern;

namespace Practice.DesignPattern.Structural.Adapter
{
    [Route("api/structural/v1/adapter")]
    [ApiController]
    public class AdapterController : ControllerBase
    {
        private readonly PatternDemo.LoggerFactory loggerFactory;

        public AdapterController(PatternDemo.LoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        [HttpPost("basic")]
        public string BasicDemo([FromBody] AdapterRequest request)
        {
            switch (request.version)
            {
                case 1:
                    var oldLogger = new Basic.BasicDemo.OldLogger();
                    switch (request.type)
                    {
                        case 1:
                            return oldLogger.WriteLog($"INFO: {request.message}");
                        case 2:
                            return oldLogger.WriteLog($"ERROR: {request.message}");
                        default:
                            return "[ERROR] Loại log không hợp lệ.";
                    }
                case 2:
                    var newLogger = new Basic.BasicDemo.NewLogger();
                    switch (request.type)
                    {
                        case 1:
                            return newLogger.LogInfo(request.message);
                        case 2:
                            return newLogger.LogError(request.message);
                        default:
                            return "[ERROR] Loại log không hợp lệ.";
                    }
                default:
                    return "[ERROR] Phiên bản logger không hợp lệ.";
            }
        }

        [HttpPost("pattern")]
        public string PatternDemo([FromBody] AdapterRequest request)
        {
            var payment = loggerFactory.GetLogger(version: request.version);
            switch (request.type)
            {
                case 1:
                    return payment.LogInfo(request.message);
                case 2:
                    return payment.LogError(request.message);
                default:
                    return "[ERROR] Loại log không hợp lệ.";
            }
        }
    }
}
