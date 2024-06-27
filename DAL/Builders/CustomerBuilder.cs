using DAL.Models;

namespace DAL.Builders;

public class CustomerBuilder
{
    private Customer _customer;

    public CustomerBuilder()
    {
        _customer = new Customer();
    }
    public CustomerBuilder WithCustomerId(int customerId)
    {
        _customer.Id = customerId;
        return this;
    }
    public CustomerBuilder WithCustomerFullName(string fullName)
    {
        _customer.FullName = fullName;
        return this;
    }
    public CustomerBuilder WithTelephone(string telephone)
    {
        _customer.Telephone = telephone;
        return this;
    }
    public CustomerBuilder WithEmailAddress(string email)
    {
        _customer.Email = email;
        return this;
    }
    public CustomerBuilder WithCustomerBirthday(DateTime birthday)
    {
        _customer.Birthday = birthday;
        return this;
    }
    public CustomerBuilder WithCustomerStatus(bool status)
    {
        _customer.Status = status;
        return this;
    }
    public CustomerBuilder WithPassword(string password)
    {
        _customer.Password = password;
        return this;
    }
    public CustomerBuilder WithBookingReservations(List<Booking> bookings)
    {
        _customer.Bookings = bookings;
        return this;
    }
    public Customer Build()
    {
        return _customer;
    }
}