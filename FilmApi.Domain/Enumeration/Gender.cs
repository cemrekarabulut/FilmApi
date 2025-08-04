using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Domain.Enumeration
{
    public class Gender
    {
        public string Name { get; private set; }

        // Statik hazır Gender nesneleri
        public static readonly Gender Male = new Gender("Male");
        public static readonly Gender Female = new Gender("Female");
        public static readonly Gender Unknown = new Gender("Unknown");

        // Private constructor
        private Gender(string name)
        {
            Name = name;
        }

        // FromName metodu burada
        public static Gender FromName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Gender name cannot be empty.");

            var normalized = name.Trim().ToLowerInvariant();

            if (normalized == "male") return Male;
            if (normalized == "female") return Female;

            throw new ArgumentException($"Invalid gender name: {name}");
        }

        // İstersen Equals, GetHashCode override edebilirsin
    }
}

