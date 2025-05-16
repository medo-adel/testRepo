using Common.StandardInfrastructure.CommonDto;

namespace Common.StandardInfrastructure.Core {
    public class ResponseResult : Result, IResponseResult {
        public ResponseResult(object result = null) {
            Data = result;
        }
        public IResult PostResult(object result = null) {
            return new ResponseResult(result: result);
        }
    }
}