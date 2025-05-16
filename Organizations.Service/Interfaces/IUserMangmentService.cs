using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.StandardInfrastructure;
using Organizations.Service.Dto;
using Organizations.Service.FilterDto;

namespace Organizations.Service.Interfaces
{
    public interface IUserManagementService
    {
        Task<IEnumerable<UserMangmentDto>> GetAll();
        Task<IEnumerable<DropdownDto>> GetAllRoles();
        Task<string> Add(UserMangmentDto UserManagementDto);
        Task Delete(Guid id);
        Task<UserMangmentDto> Get(Guid id);
        Task<PagedListDto<UserMangmentDto>> GetAllUserManagementPaged(UserMangmentFilterDto filteringDto, PagingSortingDto pagingSortingDto);
        Task Update(UserMangmentDto userManagementDto);
        Guid ReturenUserIdToken();
    }
}