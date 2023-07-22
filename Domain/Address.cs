using System;
using Domain.SeedWork;
using Domain.Validations.UserValidation;

namespace Domain;

public sealed class Address : Entity
{
    [Obsolete("Construtor criado apenas para o funcionamento do ef")]
    public Address()
    {
    }

    private Address(string userId, string street, string district, string city, string state, string country, bool isDefault)
    {
        Id = Guid.NewGuid().ToString();
        UserId = userId;
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
        string userId,
        string street,
        string district,
        string city,
        string state,
        string country,
        bool isDefault)
    {
        return new(userId, street, district, city, state, country, isDefault);
    }

    public bool IsValidCreate()
    {
        ValidationResult = new CreateAddressValidator().Validate(this);
        return ValidationResult.IsValid;
    }

    internal void CheckAddressDefault()
    {
        IsDefault = true;
    }

    internal void UnCheckAddressDefault()
    {
        IsDefault = false;
    }
}
