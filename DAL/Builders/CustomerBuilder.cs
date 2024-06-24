using DAL.Entities;

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
        _customer.CustomerId = customerId;
        return this;
    }
    public CustomerBuilder WithCustomerFullName(string customerFullName)
    {
        _customer.CustomerFullName = customerFullName;
        return this;
    }
    public CustomerBuilder WithTelephone(string telephone)
    {
        _customer.Telephone = telephone;
        return this;
    }
    public CustomerBuilder WithEmailAddress(string emailAddress)
    {
        _customer.EmailAddress = emailAddress;
        return this;
    }
    public CustomerBuilder WithCustomerBirthday(DateOnly customerBirthday)
    {
        _customer.CustomerBirthday = customerBirthday;
        return this;
    }
    public CustomerBuilder WithCustomerStatus(bool customerStatus)
    {
        _customer.CustomerStatus = customerStatus;
        return this;
    }
    public CustomerBuilder WithPassword(string password)
    {
        _customer.Password = password;
        return this;
    }
    public CustomerBuilder WithBookingReservations(List<BookingReservation> bookingReservations)
    {
        _customer.BookingReservations = bookingReservations;
        return this;
    }
    public Customer Build()
    {
        return _customer;
    }
}