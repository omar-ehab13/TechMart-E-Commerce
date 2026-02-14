namespace TechMart.Domain.ValueObjects;

public sealed class AddressValue : IEquatable<AddressValue>
{
    public string Line1 { get; }
    public string? Line2 { get; }
    public string City { get; }
    public string State { get; }
    public string PostalCode { get; }
    public string Country { get; }

    public AddressValue(string line1, string city, string state, string postalCode, string country, string? line2 = null)
    {
        Line1 = string.IsNullOrWhiteSpace(line1) ? throw new ArgumentException("Address line 1 is required.", nameof(line1)) : line1.Trim();
        Line2 = line2?.Trim();
        City = string.IsNullOrWhiteSpace(city) ? throw new ArgumentException("City is required.", nameof(city)) : city.Trim();
        State = string.IsNullOrWhiteSpace(state) ? throw new ArgumentException("State is required.", nameof(state)) : state.Trim();
        PostalCode = string.IsNullOrWhiteSpace(postalCode) ? throw new ArgumentException("Postal code is required.", nameof(postalCode)) : postalCode.Trim();
        Country = string.IsNullOrWhiteSpace(country) ? throw new ArgumentException("Country is required.", nameof(country)) : country.Trim();
    }

    public bool Equals(AddressValue? other) => other is not null &&
        Line1 == other.Line1 && Line2 == other.Line2 && City == other.City &&
        State == other.State && PostalCode == other.PostalCode && Country == other.Country;

    public override bool Equals(object? obj) => Equals(obj as AddressValue);

    public override int GetHashCode() => HashCode.Combine(Line1, Line2, City, State, PostalCode, Country);

    public override string ToString() => string.Join(", ", new[] { Line1, Line2, City, State, PostalCode, Country }.Where(s => !string.IsNullOrEmpty(s)));
}
