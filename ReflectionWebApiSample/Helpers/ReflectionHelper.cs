using ReflectionWebApiSample.Entities;
using System.Reflection;

namespace ReflectionWebApiSample.Helpers;

public class ReflectionHelper
{

    public static object Project(object obj, string? fields)
    {
        var dict = new Dictionary<string, object>();
        if (fields is null)
            return obj;

        var selectedFields = fields?.Split(',') ?? Array.Empty<string>();
        foreach (var field in selectedFields)
        {
            var value = GetPropertyValue(obj, field);
            dict[field] = value;
        }

        return dict;
    }


    public static List<object> Filter(IEnumerable<object> list, string filters)
    {
        var results = new List<object>();
        results.AddRange(list);
        var selectedFilteres = filters?.Split(",") ?? Array.Empty<string>();
        foreach (var filter in selectedFilteres)
        {
            foreach (var item in list)
            {
                var selectedFilter = filter?.Split(":") ?? Array.Empty<string>();
                var field = selectedFilter[0];
                var filterValue = selectedFilter[1];
                var value = GetPropertyValue(item, field);

                if (!value.ToString().ToUpper().Contains(filterValue.ToString().ToUpper()))
                {
                    results.Remove(item);
                }
            }
        }


        return results;
    }


    public static object GetPropertyValue(object obj, string propertyName)
    {
        var propInfo = obj.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        return propInfo != null ? propInfo.GetValue(obj) : null;
    }
}
