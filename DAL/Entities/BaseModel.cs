namespace DAL.Entities;

public abstract class BaseModel
{
    /*public int Id { get; set; }*/
}

public class ModelFactory
{
    public BaseModel CreateModel(string modelType)
    {
        if (modelType.Equals("Customer", StringComparison.InvariantCultureIgnoreCase))
        {
            return new CustomerFactory().CreateCustomer();
        }
        else
        {
            throw new ArgumentException("Invalid model type");
        }
    }
}

public class CustomerFactory
{
    public Customer CreateCustomer() => new();
}