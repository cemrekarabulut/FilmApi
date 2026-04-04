namespace FilmApi.Domain.Enumeration
{
    public class Gender : IEquatable<Gender>
    {
        public string Name { get; }

        public static readonly Gender Male = new("Male");
        public static readonly Gender Female = new("Female");
        public static readonly Gender Unknown = new("Unknown");

        private Gender(string name) => Name = name;

        public static Gender FromName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Unknown;

            return name.Trim().ToLowerInvariant() switch
            {
                "male" => Male,
                "female" => Female,
                "unknown" => Unknown,
                _ => throw new ArgumentException($"Geçersiz cinsiyet değeri: '{name}'. Geçerli değerler: Male, Female, Unknown.")
            };
        }

        public bool Equals(Gender? other)
        {
            if (other is null) return false;
            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object? obj) => obj is Gender other && Equals(other);

        public override int GetHashCode() => Name.ToLowerInvariant().GetHashCode();

        public override string ToString() => Name;
    }
}
