using AutoMapper;
using Microsoft.Extensions.Localization;
using Organizations.DataAccess;

namespace Organizations.Service.Services.Base
{
    public  class BaseServices
    {

        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly IStringLocalizer<Resources.Organizations> OrganizationLocalize;
        protected readonly IStringLocalizer<Common.StandardInfrastructure.Resources.Common> CommonLocalize;
        public BaseServices(IMapper mapper,
                            IUnitOfWork unitOfWork,
                            IStringLocalizer<Resources.Organizations> organizationLocalize,
                            IStringLocalizer<Common.StandardInfrastructure.Resources.Common> commonLocalize)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            OrganizationLocalize = organizationLocalize;
            CommonLocalize = commonLocalize;
        }
    }
}

