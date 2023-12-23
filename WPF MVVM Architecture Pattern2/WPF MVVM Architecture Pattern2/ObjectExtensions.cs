using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ObjectExtensions.cs
using System;


/*
 *  You can use reflection to automatically match the properties of two objects without explicitly listing each property. 
 *  Here's a generic method that uses reflection to copy properties from one object to another:
 *  
 */
// carViewModel.CopyPropertiesFrom(_carViewModel);

public static class ObjectExtensions
{
    public static void CopyPropertiesFrom<T>(this T destination, T source)
    {
        if (destination == null || source == null)
            throw new ArgumentNullException();

        var type = typeof(T);
        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            if (property.CanWrite)
            {
                var value = property.GetValue(source);
                property.SetValue(destination, value);
            }
        }
    }
}