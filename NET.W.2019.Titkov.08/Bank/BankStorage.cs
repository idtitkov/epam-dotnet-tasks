using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._08
{
    public class BankStorage
    {
        private readonly string filePath = @"D:\Downloads\accounts.dat";
        private List<BankAccount> allAccounts = new List<BankAccount>();

        /// <summary>
        /// Ctor.
        /// </summary>
        public BankStorage()
        {
            ReadFromFile();
        }

        /// <summary>
        /// List of accounts returned from storage.
        /// </summary>
        public List<BankAccount> AllAccounts { get => allAccounts; set => allAccounts = value; }

        /// <summary>
        /// Saves changes to storage.
        /// </summary>
        public void Synchronize()
        {
            WriteToFile();
        }

        private void ReadFromFile()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.OpenOrCreate)))
                {
                    //// пока не достигнут конец файла
                    //// считываем каждое значение из файла
                    while (reader.PeekChar() > -1)
                    {
                        var account = new BankAccount
                        {
                            Id = reader.ReadInt32(),
                            FirstName = reader.ReadString(),
                            Surname = reader.ReadString(),
                            Balance = reader.ReadDouble(),
                            Bonus = reader.ReadInt32(),
                            Grade = (Grades)Enum.Parse(typeof(Grades), reader.ReadString()),
                        };

                        AllAccounts.Add(account);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void WriteToFile()
        {
            try
            {
                //// создаем объект BinaryWriter
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    foreach (var account in AllAccounts)
                    {
                        //// записываем в файл значение каждого поля структуры
                        writer.Write(account.Id);
                        writer.Write(account.FirstName);
                        writer.Write(account.Surname);
                        writer.Write(account.Balance);
                        writer.Write(account.Bonus);
                        writer.Write(account.Grade.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
