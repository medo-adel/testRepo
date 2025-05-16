using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Organizations.Data;
using Organizations.Data.Entities;
using Organizations.Service.Dto;
using Organizations.Service.Interfaces;

namespace Organizations.Service.Services {
    public class AppDetailsService : IAppDetailsService {
        private readonly OrganizationsContext _context;

        public AppDetailsService(OrganizationsContext context) {
            _context = context;
        }

        public async Task<AppDetailsDto> GetLatestVersionAsync(string code) {
            var latestVersion = await _context.AppDetails
                .Where(v => v.Code == code)
                .OrderByDescending(v => v.DateVersion)
                .FirstOrDefaultAsync();
            
            return latestVersion != null ? new AppDetailsDto
            {
                Code = latestVersion.Code,
                Version = latestVersion.Version,
                DateVersion = latestVersion.DateVersion
            } : null;
        }

        public async Task<AppDetailsDto> AddVersionAsync(AppDetailsDto dto) {
            var newVersion = new AppDetails
            {
                Code = dto.Code,
                Version = dto.Version,
                DateVersion = dto.DateVersion
            };

            _context.AppDetails.Add(newVersion);
            await _context.SaveChangesAsync();

            return dto;
        }
    }
}