using System;

namespace Domain.ValueObjects
{
    [Flags]
    public enum Categories
    {
        CONSOLES = 1,
        COMPUTERS = 2,
        VIDEOGAMES = 4,
        ACCESORIES = 8,
        RETRO = 16
    }

    public class Category
    {
        public Categories Value { get; set; }
    }
}