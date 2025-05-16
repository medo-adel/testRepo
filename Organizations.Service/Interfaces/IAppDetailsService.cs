using System.Threading.Tasks;
using Organizations.Service.Dto;

namespace Organizations.Service.Interfaces
{
    public interface IAppDetailsService
    {
        Task<AppDetailsDto> GetLatestVersionAsync(string code);
        Task<AppDetailsDto> AddVersionAsync(AppDetailsDto dto);
    }
}