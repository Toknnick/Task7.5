using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.Work();
        }
    }

    class Shop
    {
        private List<CanOfStew> _cansOfStew = new List<CanOfStew>();

        public Shop()
        {
            AddCansOfStew();
        }

        public void Work()
        {
            int currectYear = 2022; 
            ShowAllCansOfStew();
            IEnumerable<CanOfStew> expiredCansOfStew = _cansOfStew.Where(canOfStew => canOfStew.ExpirationDate < (currectYear - canOfStew.ProductionYear));
            ShowExpiredCansOfStew(expiredCansOfStew);
            IEnumerable<CanOfStew> notExpiredCansOfStew = _cansOfStew.Except(expiredCansOfStew);
            Console.WriteLine($"Количество непросроченной тушенки: {notExpiredCansOfStew.Count()}.");
        }

        private void ShowAllCansOfStew()
        {
            Console.WriteLine("Банки тушенки на складе магазина:");

            foreach (CanOfStew canOfStew in _cansOfStew)
            {
                canOfStew.ShowInfo();
            }
        }

        private void ShowExpiredCansOfStew(IEnumerable<CanOfStew> expiredCansOfStew)
        {
            Console.WriteLine("Просроченные банки тушенки:");

            foreach (CanOfStew canOfStew in expiredCansOfStew)
            {
                canOfStew.ShowInfo();
            }

            Console.WriteLine();
        }

        private void AddCansOfStew()
        {
            Random random = new Random();
            int minCountOfCansOfStew = 10;
            int maxCountOfCansOfStew = 20;
            int minProductionYear = 1980;
            int maxProductionYear = 2022;
            int expirationDate = 30;
            int countOfPlayers = random.Next(minCountOfCansOfStew, maxCountOfCansOfStew);

            for (int i = 0; i < countOfPlayers; i++)
            {
                int productionYear = random.Next(minProductionYear, maxProductionYear);
                _cansOfStew.Add(new CanOfStew("Банка тушеники", productionYear, expirationDate));
            }
        }
    }

    class CanOfStew
    {
        private string _name;

        public int ProductionYear { get; private set; }
        public int ExpirationDate { get; private set; }

        public CanOfStew(string name, int productionYear, int expirationDate)
        {
            _name = name;
            ProductionYear = productionYear;
            ExpirationDate = expirationDate;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name}. Дата производства: {ProductionYear} год. Срок годности: {ExpirationDate} лет.");
        }
    }
}
