using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Models
{
    public class PaginateRestModel
    {

        public IEnumerable<SortingParams> SortingParams { set; get; }
        public IEnumerable<FilterParams> FilterParam { get; set; }

        int pageNumber = 1;
        public int PageNumber { get { return pageNumber; } set { if (value > 1) pageNumber = value; } }

        int pageSize = 4;
        public int PageSize { get { return pageSize; } set { if (value > 1) pageSize = value; } }
    }

    public enum SortOrders
    {
        Asc,
        Desc
    }
    

public class SortingParams
{
    public string SortOrder { get; set; }
    public string ColumnName { get; set; }
}

    public enum FilterOptions
    {
        Contains
    }

public class FilterParams
{
    public string ColumnName { get; set; } = string.Empty;
    public string FilterValue { get; set; } = string.Empty;
    public FilterOptions FilterOption { get; set; } = FilterOptions.Contains;
}
}