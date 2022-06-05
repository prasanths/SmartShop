using Microsoft.EntityFrameworkCore;
using SmartShop.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SmartShop.Helpers
{
    public static class PaginationHelper
    {
        public static async Task<Pagination<T>> GetPagination<T>(IQueryable<T> query, int page, int pageSize, string orderBy, bool orderByDesc) where T : class
        {
            Pagination<T> pagination = new Pagination<T>
            {
                TotalItems = query.Count(),
                PageSize = pageSize,
                CurrentPage = page,
                OrderBy = orderBy,
                OrderByDesc = orderByDesc
            };
            if (query.Count() > 0)
            {

                int skip = (page - 1) * pageSize;
                var props = typeof(T).GetProperties();
                var orderByProperty = props.FirstOrDefault(n => n.GetCustomAttribute<SortableAttribute>()?.OrderBy == orderBy);
                if (orderByProperty == null)
                {
                    throw new Exception($"Field: '{orderBy}' is not sortable");
                }
                IOrderedQueryable<T> orderedList = null;
                if (orderByDesc)
                {
                    orderedList = query
                        .OrderByDescending(x => orderByProperty.Name);// (x => orderByProperty.GetValue(x, null));
                }
                else
                {
                    orderedList = query
                        .OrderBy(x => orderByProperty.Name); //(x => orderByProperty.GetValue(x, null));
                }
                pagination.Result = await orderedList
                    .Skip(skip)
                    .Take(pageSize)
                    .ToListAsync();
            }

            return pagination;
        }
    }
}
