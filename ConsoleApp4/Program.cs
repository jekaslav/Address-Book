using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var contacts = new List<Contact>();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить контакт");
                Console.WriteLine("2. Просмотреть контакты");
                Console.WriteLine("3. Удалить контакт");
                Console.WriteLine("4. Выход");

                int action = Convert.ToInt32(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        AddContact(contacts);
                        break;

                    case 2:
                        ViewContacts(contacts);
                        break;

                    case 3:
                        RemoveContact(contacts);
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Неверное действие");
                        break;
                }
            }
        }

        static void AddContact(List<Contact> contacts)
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            try
            {
                if (name.Contains(" ") || (Regex.IsMatch(name, @"\d")))
                {
                    throw new ArgumentException("Недопустимое имя");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Произошло исключение: {0}", ex);
                return;
            }

            string path = @"C:\Users\Delor\Documents\Visual Studio 2022\ConsoleApp4\ConsoleApp4\Names.txt";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(name);
            }

            Console.Write("Введите номер телефона: ");
            string phoneNumber = Console.ReadLine();

            Regex regex = new Regex(@"^[0-9]+$");

            try
            {
                if (regex.IsMatch(phoneNumber))
                {

                }

                else
                {
                    throw new ArgumentException("Недопустимый номер телефона");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Произошло исключение: {0}", ex);
                return;
            }

            string path1 = @"C:\Users\Delor\Documents\Visual Studio 2022\ConsoleApp4\ConsoleApp4\Numbers.txt";

            using (StreamWriter sw = new StreamWriter(path1, true))
            {
                sw.WriteLine(phoneNumber);
            }

            Console.Write("Введите почту: ");
            string mail = Console.ReadLine();
            try
            {
                if (mail.Contains('@'))
                {

                }

                else
                {
                    throw new ArgumentException("Недопустимый ввод");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Произошло исключение: {0}", ex);
                return;
            }

            string path2 = @"C:\Users\Delor\Documents\Visual Studio 2022\ConsoleApp4\ConsoleApp4\Mail.txt";

            using (StreamWriter sw = new StreamWriter(path2, true))
            {
                sw.WriteLine(mail);
            }

            contacts.Add(new Contact { Name = name, PhoneNumber = phoneNumber, Mail = mail });

            string path3 = @"C:\Users\Delor\Documents\Visual Studio 2022\ConsoleApp4\ConsoleApp4\Contacts.txt";

            using (StreamWriter sw = new StreamWriter(path3, true))
            {
                foreach (var contact in contacts)
                {
                    sw.WriteLine($"{contact.Name}\t {contact.PhoneNumber}\t {contact.Mail}\t ");
                }
            }

            Console.WriteLine("Контакт добавлен");


        }

        static void ViewContacts(List<Contact> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("В адресной книге пусто, ой");
            }
            else
            {
                string path4 = @"C:\Users\Delor\Documents\Visual Studio 2022\ConsoleApp4\ConsoleApp4\Contacts.txt";
                string data = "\t \t \t";

                using (StreamReader sr = new StreamReader(path4))
                {
                    data = sr.ReadToEnd();
                    Console.WriteLine("Имя:\t Номер телефона:\t Почта:\t");
                    Console.WriteLine(data);                                                                                                                                                 
                }
            }
        }
        static void RemoveContact(List<Contact> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("В адресной книге пусто, ой");

                return;
            }
            //string name = Console.ReadLine();

            //for (int i = 0; i < contacts.Count; i++)
            //{
            //    if (contacts[i].Name == name)
            //    {
            //        contacts.RemoveAt(i);

            //        Console.WriteLine("Контакт удалён");

            //        return;
            //    }
            //    Console.WriteLine("Контакт не найден");
            //}

            string path5 = @"C:\Users\Delor\Documents\Visual Studio 2022\ConsoleApp4\ConsoleApp4\Contacts.txt";
            Console.Write("Введите данные контакта через пробел:  ");

            string lineToDelete = Console.ReadLine();

            string[] lines = File.ReadAllLines(path5);

            using (StreamWriter writer = new StreamWriter(path5))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = string.Empty;
                    if (line != lineToDelete)
                    {
                        writer.WriteLine(line);
                        return;
                    }
                }
            }
        }

        class Contact
        {
            public string Name { get; set; }

            public string PhoneNumber { get; set; }

            public string Mail { get; set; }
        }

    }
}