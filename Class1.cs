using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_modul_4_part_2
{
    class Passport
    { 
        public string Name { get; set; }
        public DateOnly DatePassport { get; set; }
        public string PassportNumber { get; set; }

        public Passport(string name, DateOnly datePassport, string passportNumber)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя не может быть пустым или состоять только из пробелов. Поле: ", nameof(name));
            }
            if (datePassport == default)
            {
                throw new ArgumentException("Дата паспорта не может быть пустой. Поле: ", nameof(datePassport));
            }
            if (string.IsNullOrWhiteSpace(passportNumber) || passportNumber.Length != 9)
            {
                throw new ArgumentException("Номер паспорта должен состоять из 9 символов. Поле: ", nameof(passportNumber));
            }

            Name = name;
            DatePassport = datePassport;
            PassportNumber = passportNumber;
        }

    }
}
