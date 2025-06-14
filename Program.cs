using DZ_modul_4_part_2;
using System.Linq.Expressions;

namespace DZ_modul_part_2
{
    internal class Program
    {
        /// <summary>
        /// Метод для вывода меню калькулятора
        /// </summary>
        static void PrintMenuCalculator()
        {
            Console.WriteLine("Выберите направление перевода числа:");
            Console.WriteLine("1. Десятичная в Двоичная");
            Console.WriteLine("2. Десятичная в Восьмеричная");
            Console.WriteLine("3. Десятичная в Шестнадцатеричная");
            Console.WriteLine("4. Выход");
        }

        static void ConvertDecimalToBinary(int number)
        {
            string res = "";
            try
            {
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException("Число должно быть неотрицательным.");
                }
                else if (number == 0)
                {
                    throw new ArgumentOutOfRangeException("Число должно быть не ноль.");
                }
                else if (number > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Число должно быть в пределах диапазона типа int.");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            while (number > 0)
            {
                res = Convert.ToString(number % 2) + res;
                number /= 2;

            }
            Console.WriteLine("Двоичная система: " + res);
        }

        static void ConvertDecimalToOctal(int number)
        {
            string res = "";
            try
            {
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException("Число должно быть неотрицательным.");
                }
                else if (number == 0)
                {
                    throw new ArgumentOutOfRangeException("Число должно быть не ноль.");
                }
                else if (number > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Число должно быть в пределах диапазона типа int.");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            while (number > 0)
            {
                res = Convert.ToString(number % 8) + res;
                number /= 8;
            }
            Console.WriteLine("Восьмеричная система: " + res);
        }

        static void ConvertDecimalToHexadecimal(int number)
        {
            string res = "";
            try
            {
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException("Число должно быть неотрицательным.");
                }
                else if (number == 0)
                {
                    throw new ArgumentOutOfRangeException("Число должно быть не ноль.");
                }
                else if (number > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Число должно быть в пределах диапазона типа int.");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            while (number > 0)
            {
                int remainder = number % 16;
                res = (remainder < 10 ? remainder.ToString() : ((char)(remainder - 10 + 'A')).ToString()) + res;
                number /= 16;
            }
            Console.WriteLine("Шестнадцатеричная система: " + res);
        }

        static void Calculator()
        {
            PrintMenuCalculator();
            try
            {

                int choice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите число для конвертации ");
                int num = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ConvertDecimalToBinary(num);
                        break;

                    case 2:
                        ConvertDecimalToOctal(num);
                        break;

                    case 3:
                        ConvertDecimalToHexadecimal(num);
                        break;

                    default:
                        Console.WriteLine("Не верный ввод выбора 1 - 3");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        
        }


        /// <summary>
        /// // Метод для перевода слова в число от 0 до 9
        /// </summary>

        static void PrintStrToNum(string str)
        {
            switch (str.ToLower())
            {
                case "zero":
                    Console.WriteLine(0);
                    break;
                case "one":
                    Console.WriteLine(1);
                    break;
                case "two":
                    Console.WriteLine(2);
                    break;
                case "three":
                    Console.WriteLine(3);
                    break;
                case "four":
                    Console.WriteLine(4);
                    break;
                case "five":
                    Console.WriteLine(5);
                    break;
                case "six":
                    Console.WriteLine(6);
                    break;
                case "seven":
                    Console.WriteLine(7);
                    break;
                case "eight":
                    Console.WriteLine(8);
                    break;
                case "nine":
                    Console.WriteLine(9);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        static void LogicResult(string input)
        {
            try
            {
                char[] operators = { '<', '>', '=', '!' };
                string[] parts = input.Split(operators, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                {
                    throw new FormatException("Неверный формат логического выражения.");
                }
                int leftOperand = int.Parse(parts[0].Trim());
                int rightOperand = int.Parse(parts[1].Trim());
                char operatorChar = input.First(c => operators.Contains(c));

                bool result = false;

                switch (operatorChar)
                {
                    case '<':
                        if (input.Contains("<="))
                        {
                            result = leftOperand <= rightOperand;
                        }
                        else
                        {
                            result = leftOperand < rightOperand;
                        }
                        break;

                    case '>':
                        if (input.Contains(">="))
                        {
                            result = leftOperand >= rightOperand;
                        }
                        else
                        {
                            result = leftOperand > rightOperand;
                        }
                        break;

                    case '=':
                        if (input.Contains("=="))
                        {
                            result = leftOperand == rightOperand;
                        }
                        else
                        {
                            throw new FormatException("Неверный оператор сравнения.");
                        }
                        break;

                    case '!':
                        if (input.Contains("!="))
                        {
                            result = leftOperand != rightOperand;
                        }
                        else
                        {
                            throw new FormatException("Неверный оператор сравнения.");
                        }
                        break;

                    default:
                        throw new FormatException("Неверный оператор сравнения.");
                }
                Console.WriteLine($"Результат выражения '{input}': {result}");

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ошибка формата: " + ex.Message);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: число выходит за пределы диапазона типа int.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);

            }

            
        }

        static void Main(string[] args)
        {
            //Задание 1
            //Создайте приложение калькулятор для перевода числа
            //из одной системы исчисления в другую. Пользователь с помощью меню выбирает направление перевода.Например, 
            //из десятичной в двоичную. После выбора направления, 
            //пользователь вводит число в исходной системе исчисления.
            //Приложение должно перевести число в требуемую систему.Предусмотреть случай выхода за границы диапазона,
            //определяемого типом int, неправильный ввод.

            Console.WriteLine("Калькулятор для перевода числа из одной системы исчисления в другую");

            Calculator();
            


            //Задание 2
            //Пользователь вводит словами цифру от 0 до 9.Приложение должно перевести слово в цифру. Например, если
            //пользователь ввёл five, приложение должно вывести на
            //экран 5.

            string s;
            Console.WriteLine("Введите цифру от 0 до 9 словами (например, 'five'):");
            try
            {
                s = Console.ReadLine();
                PrintStrToNum(s);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка ввода: " + ex.Message);
                
            }


            //Задание 3
            //Создайте класс «Заграничный паспорт». Вам необходимо
            //хранить информацию о номере паспорта, ФИО владельца,
            //дате выдачи и т.д.Предусмотреть механизмы для инициализации полей класса.Если значение для инициализации
            //неверное, генерируйте исключение. 

            try
            {
                Console.WriteLine("Введите ФИО владельца паспорта:");
                string name = Console.ReadLine();

                Console.WriteLine("Введите дату выдачи паспорта (в формате ГГГГ-ММ-ДД):");
                DateOnly datePassport = DateOnly.Parse(Console.ReadLine());

                Console.WriteLine("Введите номер паспорта (должен состоять из 9 символов):");
                string passportNumber = Console.ReadLine();

                Passport passport = new Passport(name, datePassport, passportNumber);

                Console.WriteLine($"Паспорт успешно создан:\nФИО: {passport.Name}\nДата выдачи: {passport.DatePassport}\nНомер паспорта: {passport.PassportNumber}");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: неверный формат даты. Используйте формат ГГГГ-ММ-ДД.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            //Задание 4
            //Пользователь вводит в строку с клавиатуры логическое
            //выражение.Например, 3 > 2 или 7 < 3.Программа должна
            //посчитать результат введенного выражения и дать результат true или false.В строке могут быть только целые числа
            //и операторы: <, >, <=, >=, ==, !=.Для обработки ошибок
            //ввода используйте механизм исключений.


            Console.WriteLine("Введите логическое выражение (например, 3 > 2):");
            string input = Console.ReadLine();
            LogicResult(input);

        }
    }
}
