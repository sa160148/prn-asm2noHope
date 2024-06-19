using System.Linq.Expressions;
using System.Reflection;
using DAL.Entities;

namespace DAL.Builders;

public class BaseBuilder<T> where T : new()
{
    private T _instance = new T();
    
    /*public BaseBuilder<T> With(Action<T> action)
    {
        action(_instance);
        return this;
    }*/
    public BaseBuilder<T> With(string propertyName, object value)
    {
        var property = typeof(T).GetProperty(propertyName, BindingFlags.Public 
                                                           | BindingFlags.Instance /*| BindingFlags.IgnoreCase*/);
        /*property?.SetValue(_instance, value);*/
        if (property != null) property.SetValue(_instance, value);
        else throw new MissingMemberException($"Property {propertyName} not found in {typeof(T).Name}");
        return this;
    }   
    public T Build() => _instance;

    /*public BaseBuilder<T> With(Func<T, bool> propertyName, IQueryable<RoomInformation> value)
    {
        throw new NotImplementedException();
    }*/
}
public static class BaseBuilderX
{
    public static BaseBuilder<T> With<T, TProperty>(this BaseBuilder<T> builder,
        Expression<Func<T, TProperty>> expression, TProperty value) where T : new()
    {
        if (expression.Body is MemberExpression memberExpression && memberExpression.Member is PropertyInfo propertyInfo)
            return builder.With(propertyInfo.Name, value??default(TProperty));
        throw new ArgumentException("Expression is not a property");
    }
    public static T Build<T>(this BaseBuilder<T> builder) where T : new() => builder.Build();
}

/*// su dung buider extentsion, X
var customerBuilder = new GenericBuilder<Customer>()
    .With(c => c.CustomerId, 1)
    .With(c => c.CustomerFullName, "John Doe")
    .With(c => c.EmailAddress, "john.doe@example.com")
    .With(c => c.Telephone, "123456789")
    .With(c => c.CustomerBirthday, new DateOnly(1990, 1, 1))
    .With(c => c.CustomerStatus, true)
    .With(c => c.Password, "securepassword");

var customer = customerBuilder.Build();
*/