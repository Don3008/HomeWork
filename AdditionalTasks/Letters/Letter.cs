using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letters
{
    enum Addresses
    {
        Igor = 1,
        Ivan,
        Michael,
        Dmitriy,
        Pavel,
        Alex
    }
    class Letter
    {
        private string textOfLetter;

        Random rnd = new Random();

        public string AddressedTo { get; private set; }
        public bool Closed { get; private set; }

        public Letter()
        {
            textOfLetter = CreateText();
            var values = Enum.GetValues(typeof(Addresses));
            Addresses addr = (Addresses)values.GetValue(rnd.Next(values.Length));
            AddressedTo = addr.ToString();
            Closed = true;
        }

        private string CreateText()
        {
            int number;
            int length = rnd.Next(5, 50);
            for (int i = 0; i < length; i++)
            {
                number = rnd.Next(0, 10);
                textOfLetter += number;
            }
            return textOfLetter;
        }

        public string Read()
        {
            if (Closed == false)
            {
                return textOfLetter;
            }
            else
            {
                return "Письмо не открыто";
            }
        }

        public bool Open()
        {
            Closed = false;
            return Closed;
        }
    }
}
