using System;

namespace Balloons_Pops_game
{
    public class Chart : IComparable<Chart>
    {
        public int Value;
        public string Name;

        public Chart(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int CompareTo(Chart other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}