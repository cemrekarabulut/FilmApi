using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Domain.Enumeration
{
    public class Gender : Enumeration<Gender>
    {
        public static readonly Gender Male = new Gender(1, "Male");
        public static readonly Gender Female = new Gender(2, "Female");

        private Gender(int id, string name) : base(id, name) { }

        public static Gender FromName(string name)
{
    if (name == Male.Name) return Male;
    if (name == Female.Name) return Female;
    throw new ArgumentException("Invalid gender name");
}

    }
}
