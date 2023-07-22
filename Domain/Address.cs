using System;
using Domain.SeedWork;
using Domain.Validations.UserValidation;

namespace Domain;

public sealed class Address : Entity
{
    private Address(string street, string district, string city, string state, string country, bool isDefault)
    {
        Street = street;
        District = district;
        City = city;
        State = state;
        Country = country;
        IsDefault = isDefault;
    }

    public string Street { get; private set; }
    public string District { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public bool IsDefault { get; private set; }
    public string UserId { get; private set; }
    public User User { get; private set; }

    public static Address Create(
        string street,
        string district,
        string city,
        string state,
        string country,
        bool isDefault)
    {
        return new(street, district, city, state, country, isDefault);
    }

    internal void CheckAddressDefault()
    {
        IsDefault = true;
    }

    public bool IsValidCreate()
    {
        ValidationResult = new CreateAddressValidator().Validate(this);
        return ValidationResult.IsValid;
    }

    internal void UnCheckAddressDefault()
    {
        IsDefault = false;
    }
}
