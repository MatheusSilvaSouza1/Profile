using System;
using Domain.SeedWork;
using Domain.Validations.UserValidation;

namespace Domain;

public class Address : Entity
{
    [Obsolete("Construtor criado apenas para o funcionamento do ef")]
    public Address()
    {
    }

    private Address(Guid userId, string street, string district, string city, string state, string country, bool isDefault)
    {
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
    public virtual Guid UserId { get; private set; }

    public static Address Create(
        Guid userId,
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
