using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7C_
{
    internal class Money
    {
        private int bill;
        private int coins;

        public int Bill
        {
            get { return bill; }
            set { bill = value; }
        }

        public int Coins
        {
            get { return coins; }
            set { coins = value; }
        }

        public Money(int bill, int coins)
        {
            if (bill < 0 || coins < 0)
            {
                throw new ArgumentOutOfRangeException("Значення не може бути менше 0");
            }
            this.bill = bill;
            this.coins = coins;
        }

        public static Money operator +(Money a, Money b)
        {
            int c = a.bill + b.bill;
            int d = a.coins + b.coins;
            if (d >= 100)
            {
                c = c + d / 100;
                d = d % 100;
            }
            return new Money(c, d);
        }

        public static Money operator -(Money a, Money b)
        {
            int c = a.bill - b.bill;
            int d = a.coins - b.coins;
            if (d < 0)
            {
                c--;
                d = a.coins + 100 - b.coins;
            }
            if (c < 0 || d < 0)
            {
                throw new ArgumentOutOfRangeException("Від більшого значення потрібно віднімати менше");
            }
            return new Money(c, d);
        }

        public static Money operator /(Money a, int b)
        {
            int c = ((a.bill * 100) + a.coins) / b;
            a.bill = c / 100;
            a.coins = c % 100;
            return a;
        }

        public static Money operator *(Money a, int b)
        {
            int c = ((a.bill * 100) + a.coins) * b;
            a.bill = c / 100;
            a.coins = c % 100;
            return a;
        }

        public static Money operator ++(Money a)
        {
            return new Money(a.bill, a.coins + 1);
        }

        public static Money operator --(Money a)
        {
            return new Money(a.bill, a.coins - 1);
        }

        public static bool operator <(Money a, Money b)
        {
            bool c = a.bill < b.bill;
            return c;
        }

        public static bool operator >(Money a, Money b)
        {
            return !(a < b);
        }

        public static bool operator ==(Money a, Money b)
        {
            if (a.bill == b.bill && a.coins == b.coins) { return true; }
            else return false;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return $"\nAfter operation: {bill}.{coins}";
        }
    }
}
