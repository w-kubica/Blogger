﻿using Blogger.API.Helpers;

namespace Blogger.API.Filters
{
    public class SortingFilter
    {
        public string SortField { get; set; }
        public bool Ascending { get; set; } = true;

        public SortingFilter()
        {
            SortField = "Id";
        }

        public SortingFilter(string sortField, bool ascending)
        {
            var sortFields = SortingHelper.GetSortFilds();
            sortField = sortField.ToLower();

            if (sortFields.Select(x => x.Key).Contains(sortField.ToLower()))
            {
                sortField = sortFields.Where(x => x.Key == sortField).Select(x => x.Value).SingleOrDefault();
            }
            else
            {
                sortField = "Id";
            }

            SortField = sortField;
            Ascending = ascending;
        }
    }

}
