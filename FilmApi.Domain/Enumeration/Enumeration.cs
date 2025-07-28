using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmApi.Domain.Enumeration
{
    public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>> where TEnum : Enumeration<TEnum>
    {
        public int Id { get; }
        public string Name { get; }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        public bool Equals(Enumeration<TEnum> other)
        {
            if (other is null) return false;
            return Id == other.Id && GetType() == other.GetType();
        }

        public override bool Equals(object obj)
        {
            return obj is Enumeration<TEnum> other && Equals(other);
        }

        public override int GetHashCode() => Id.GetHashCode();

        // Tüm Enumeration değerlerini döndürür
        public static IEnumerable<TEnum> GetAll()
        {
            return typeof(TEnum)
                .GetFields(System.Reflection.BindingFlags.Public |
                           System.Reflection.BindingFlags.Static |
                           System.Reflection.BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<TEnum>();
        }
    }
}
