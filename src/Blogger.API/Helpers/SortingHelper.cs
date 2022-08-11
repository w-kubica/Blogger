namespace Blogger.API.Helpers
{
    public class SortingHelper
    {
        public static KeyValuePair<string, string>[] GetSortFilds()
        {
            return new[] {SortFields.Title, SortFields.CreationDate};
        }
    }

    public class SortFields
    {
        public static KeyValuePair<string, string> Title { get; set; } =
            new KeyValuePair<string, string>("title", "Title");

        public static KeyValuePair<string, string> CreationDate { get; set; } =
            new KeyValuePair<string, string>("creationdate", "Created");

    }
}
