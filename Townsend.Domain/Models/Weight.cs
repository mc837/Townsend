using System;

namespace Townsend.Domain.Models
{
    public class Weight
    {
        private readonly double _ounces;
        private const double OuncesPerPound = 16.0;

        public double Pounds
        {
            get { return _ounces / OuncesPerPound; }
        }

        public double Ounces
        {
            get { return _ounces; }
        }

        public Weight(double pounds)
        {
            _ounces = pounds * OuncesPerPound;
        }

        public Weight(int pounds, double ounces)
        {
            _ounces = pounds * OuncesPerPound + ounces;
        }

        // An example operator, probably want to implement addition
        // and perhaps multiplication/division as well
        public static Weight operator -(Weight w1, Weight w2)
        {
            return new Weight((w1._ounces - w2._ounces) / OuncesPerPound);
        }

        public static Weight operator +(Weight w1, Weight w2)
        {
            return new Weight((w1._ounces + w2._ounces) / OuncesPerPound);
        }

        public override string ToString()
        {
            return String.Format("{0} pounds, {1} ounces", (int)Pounds, Math.Round(Ounces % OuncesPerPound, 4));
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Weight)) return false;
            var weight = obj as Weight;
            return (_ounces.Equals(weight._ounces));
        }
    }
}