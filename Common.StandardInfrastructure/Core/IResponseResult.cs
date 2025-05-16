using Common.StandardInfrastructure.CommonDto;

namespace Common.StandardInfrastructure.Core {
    public interface IResponseResult : IResult {
        IResult PostResult(object data = null);
    }
}