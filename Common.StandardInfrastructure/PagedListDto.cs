using System.Collections.Generic;

namespace Common.StandardInfrastructure {
    public class PagedListDto<T> where T : class {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
    
    public class PagedListDtoWithConstractor<T> where T : class {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        
        public PagedListDtoWithConstractor(IEnumerable<T> list, int count, int pageSize = 10, int pageNumber = 1) {
            List = list;
            Count = count;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
