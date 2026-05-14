using System;
using System.Collections.Generic;
using N4;

namespace N4
{
    class Airport
    {
        private string code;
        private string name;
        private string city;
        private string country;

        public Airport(
            string code,
            string name,
            string city,
            string country
        )
        {
            this.code = code;
            this.name = name;
            this.city = city;
            this.country = country;
        }

        public string Code
        {
            get { return code; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
    }


    class Flight
    {
        private string flightNumber;
        private string airline;
        private string originCode;
        private string destinationCode;
        private int capacity;
        private string status;

        public Flight(
            string flightNumber,
            string airline,
            string originCode,
            string destinationCode,
            int capacity,
            string status
        )
        {
            this.flightNumber = flightNumber;
            this.airline = airline;
            this.originCode = originCode;
            this.destinationCode = destinationCode;
            this.capacity = capacity;
            this.status = status;
        }

        public string FlightNumber
        {
            get { return flightNumber; }
        }

        public string Airline
        {
            get { return airline; }
            set { airline = value; }
        }

        public string OriginCode
        {
            get { return originCode; }
            set { originCode = value; }
        }

        public string DestinationCode
        {
            get { return destinationCode; }
            set { destinationCode = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }


    class Departure
    {
        private Flight flight;
        private Airport airport;
        private DateTime departureTime;
        private string gate;

        public Departure(
            Flight flight,
            Airport airport,
            DateTime departureTime,
            string gate
        )
        {
            this.flight = flight;
            this.airport = airport;
            this.departureTime = departureTime;
            this.gate = gate;
        }

        public Flight Flight
        {
            get { return flight; }
        }

        public Airport Airport
        {
            get { return airport; }
        }

        public DateTime DepartureTime
        {
            get { return departureTime; }
            set { departureTime = value; }
        }

        public string Gate
        {
            get { return gate; }
            set { gate = value; }
        }
    }


    class Arrival
    {
        private Flight flight;
        private Airport airport;
        private DateTime? arrivalTime;
        private string terminal;

        public Arrival(
            Flight flight,
            Airport airport,
            string terminal
        )
        {
            this.flight = flight;
            this.airport = airport;
            this.arrivalTime = null;
            this.terminal = terminal;
        }

        public Flight Flight
        {
            get { return flight; }
        }

        public Airport Airport
        {
            get { return airport; }
        }

        public DateTime? ArrivalTime
        {
            get { return arrivalTime; }
            set { arrivalTime = value; }
        }

        public string Terminal
        {
            get { return terminal; }
            set { terminal = value; }
        }
    }


    class AirTransportation
    {
        static Dictionary<string, Airport> airports;
        static Dictionary<string, Flight> flights;
        static List<Departure> departures;
        static List<Arrival> arrivals;

        static AirTransportation()
        {
            airports = new Dictionary<string, Airport>();
            flights = new Dictionary<string, Flight>();
            departures = new List<Departure>();
            arrivals = new List<Arrival>();
        }

        public static void AddAirport()
        {
            Console.Write("Код аэропорта: ");
            string code = Console.ReadLine();

            Console.Write("Название аэропорта: ");
            string name = Console.ReadLine();

            Console.Write("Город: ");
            string city = Console.ReadLine();

            Console.Write("Страна: ");
            string country = Console.ReadLine();

            airports.Add(code, new Airport(code, name, city, country));
            Console.WriteLine("Аэропорт " + code + " добавлен.");
        }

        public static void EditAirport()
        {
            Console.Write("Код аэропорта для редактирования: ");
            string code = Console.ReadLine();

            if (!airports.ContainsKey(code))
            {
                Console.WriteLine("Аэропорт не найден");
                return;
            }

            Airport airport = airports[code];

            Console.Write("Новое название аэропорта: ");
            string name = Console.ReadLine();
            if (name != "") airport.Name = name;

            Console.Write("Новый город: ");
            string city = Console.ReadLine();
            if (city != "") airport.City = city;

            Console.Write("Новая страна: ");
            string country = Console.ReadLine();
            if (country != "") airport.Country = country;

            Console.WriteLine("Аэропорт " + code + " обновлён");
        }

        public static void AddFlight()
        {
            Console.Write("Номер рейса: ");
            string flightNumber = Console.ReadLine();

            Console.Write("Авиакомпания: ");
            string airline = Console.ReadLine();

            Console.Write("Код аэропорта отправления: ");
            string originCode = Console.ReadLine();

            Console.Write("Код аэропорта назначения: ");
            string destinationCode = Console.ReadLine();

            if (!airports.ContainsKey(originCode) || !airports.ContainsKey(destinationCode))
            {
                Console.WriteLine("Один из аэропортов не найден");
                return;
            }

            Console.Write("Вместимость в самолете: ");
            int capacity = int.Parse(Console.ReadLine());

            flights.Add(flightNumber, new Flight(flightNumber, airline, originCode, destinationCode, capacity, "Запланирован"));
            Console.WriteLine("Рейс " + flightNumber + " добавлен");
        }

        public static void EditFlight()
        {
            Console.Write("Номер рейса для редактирования: ");
            string flightNumber = Console.ReadLine();

            if (!flights.ContainsKey(flightNumber))
            {
                Console.WriteLine("Рейс не найден");
                return;
            }

            Flight flight = flights[flightNumber];

            Console.Write("Новая авиакомпания: ");
            string airline = Console.ReadLine();
            if (airline != "") flight.Airline = airline;

            Console.Write("Новый код аэропорта отправления: ");
            string originCode = Console.ReadLine();
            if (originCode != "")
            {
                if (!airports.ContainsKey(originCode))
                {
                    Console.WriteLine("Аэропорт не найден");
                    return;
                }
                flight.OriginCode = originCode;
            }

            Console.Write("Новый код аэропорта назначения: ");
            string destinationCode = Console.ReadLine();
            if (destinationCode != "")
            {
                if (!airports.ContainsKey(destinationCode))
                {
                    Console.WriteLine("Аэропорт не найден");
                    return;
                }
                flight.DestinationCode = destinationCode;
            }

            Console.Write("Новый статус рейса: ");
            string status = Console.ReadLine();
            if (status != "") flight.Status = status;

            Console.WriteLine("Рейс " + flightNumber + " обновлён");
        }

        public static void AddDeparture()
        {
            Console.Write("Номер рейса: ");
            string flightNumber = Console.ReadLine();

            if (!flights.ContainsKey(flightNumber))
            {
                Console.WriteLine("Рейс не найден");
                return;
            }

            Flight flight = flights[flightNumber];

            if (!airports.ContainsKey(flight.OriginCode))
            {
                Console.WriteLine("Аэропорт отправления не найден");
                return;
            }

            Airport airport = airports[flight.OriginCode];

            Console.Write("Время вылета: ");
            DateTime departureTime = DateTime.Parse(Console.ReadLine());

            Console.Write("Выход на посадку: ");
            string gate = Console.ReadLine();

            departures.Add(new Departure(flight, airport, departureTime, gate));
            flight.Status = "Вылетел";

            Console.WriteLine("Отправление рейса " + flightNumber + " зарегистрировано");
        }

        public static void EditDeparture()
        {
            Console.Write("Номер рейса: ");
            string flightNumber = Console.ReadLine();

            Departure dep = null;
            for (int i = 0; i < departures.Count; i++)
            {
                if (departures[i].Flight.FlightNumber == flightNumber)
                {
                    dep = departures[i];
                    break;
                }
            }

            if (dep == null)
            {
                Console.WriteLine("Отправление для данного рейса не найдено");
                return;
            }

            Console.Write("Новое время вылета: ");
            string timeInput = Console.ReadLine();
            if (timeInput != "") dep.DepartureTime = DateTime.Parse(timeInput);

            Console.Write("Новый выход на посадку: ");
            string gate = Console.ReadLine();
            if (gate != "") dep.Gate = gate;

            Console.WriteLine("Отправление рейса " + flightNumber + " обновлено");
        }

        public static void AddArrival()
        {
            Console.Write("Номер рейса: ");
            string flightNumber = Console.ReadLine();

            if (!flights.ContainsKey(flightNumber))
            {
                Console.WriteLine("Рейс не найден");
                return;
            }

            Flight flight = flights[flightNumber];

            if (!airports.ContainsKey(flight.DestinationCode))
            {
                Console.WriteLine("Аэропорт назначения не найден");
                return;
            }

            Airport airport = airports[flight.DestinationCode];

            Console.Write("Терминал: ");
            string terminal = Console.ReadLine();

            arrivals.Add(new Arrival(flight, airport, terminal));
            Console.WriteLine("Прибытие рейса " + flightNumber + " зарегистрировано");
        }

        public static void EditArrival()
        {
            Console.Write("Номер рейса: ");
            string flightNumber = Console.ReadLine();

            Arrival arr = null;
            for (int i = 0; i < arrivals.Count; i++)
            {
                if (arrivals[i].Flight.FlightNumber == flightNumber)
                {
                    arr = arrivals[i];
                    break;
                }
            }

            if (arr == null)
            {
                Console.WriteLine("Прибытие для данного рейса не найдено");
                return;
            }

            Console.Write("Время прибытия: ");
            string timeInput = Console.ReadLine();
            if (timeInput != "")
            {
                arr.ArrivalTime = DateTime.Parse(timeInput);
                arr.Flight.Status = "Прибыл";
            }

            Console.Write("Новый терминал: ");
            string terminal = Console.ReadLine();
            if (terminal != "") arr.Terminal = terminal;

            Console.WriteLine("Прибытие рейса " + flightNumber + " обновлено");
        }

        public static void ShowInFlightFlights()
        {
            Console.WriteLine("Рейсы, которые вылетели, но ещё не прибыли:");

            bool found = false;

            for (int i = 0; i < departures.Count; i++)
            {
                Departure dep = departures[i];
                string flightNumber = dep.Flight.FlightNumber;

                bool hasArrived = false;
                for (int j = 0; j < arrivals.Count; j++)
                {
                    if (arrivals[j].Flight.FlightNumber == flightNumber
                        && arrivals[j].ArrivalTime != null)
                    {
                        hasArrived = true;
                        break;
                    }
                }

                if (!hasArrived)
                {
                    found = true;
                    Flight f = dep.Flight;
                    Console.WriteLine("Рейс: " + f.FlightNumber);
                    Console.WriteLine("Авиакомпания: " + f.Airline);
                    Console.WriteLine("Откуда: " + f.OriginCode);
                    Console.WriteLine("Куда: " + f.DestinationCode);
                    Console.WriteLine("Время вылета: " + dep.DepartureTime);
                    Console.WriteLine("Статус: " + f.Status);
                }
            }

            if (!found)
                Console.WriteLine("Таких рейсов нет");
        }

        public static void ShowFlight()
        {
            Console.Write("Номер рейса: ");
            string flightNumber = Console.ReadLine();

            if (!flights.ContainsKey(flightNumber))
            {
                Console.WriteLine("Рейс не найден!");
                return;
            }

            Flight flight = flights[flightNumber];
            Console.WriteLine("Номер рейса: " + flight.FlightNumber);
            Console.WriteLine("Авиакомпания: " + flight.Airline);
            Console.WriteLine("Откуда: " + flight.OriginCode);
            Console.WriteLine("Куда: " + flight.DestinationCode);
            Console.WriteLine("Вместимость: " + flight.Capacity);
            Console.WriteLine("Статус: " + flight.Status);

            for (int i = 0; i < departures.Count; i++)
            {
                if (departures[i].Flight.FlightNumber == flightNumber)
                {
                    Console.WriteLine("Время вылета: " + departures[i].DepartureTime);
                    Console.WriteLine("Выход (gate): " + departures[i].Gate);
                    break;
                }
            }

            for (int i = 0; i < arrivals.Count; i++)
            {
                if (arrivals[i].Flight.FlightNumber == flightNumber)
                {
                    Console.WriteLine("Время прибытия: " + (arrivals[i].ArrivalTime.HasValue ? arrivals[i].ArrivalTime.ToString() : "не указано"));
                    Console.WriteLine("Терминал: " + arrivals[i].Terminal);
                    break;
                }
            }
        }

        public static void ShowAirport()
        {
            Console.Write("Код аэропорта: ");
            string code = Console.ReadLine();

            if (!airports.ContainsKey(code))
            {
                Console.WriteLine("Аэропорт не найден");
                return;
            }

            Airport airport = airports[code];
            Console.WriteLine("Код: " + airport.Code);
            Console.WriteLine("Название: " + airport.Name);
            Console.WriteLine("Город: " + airport.City);
            Console.WriteLine("Страна: " + airport.Country);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int m = 0;

        do
        {
            Console.WriteLine("1 - Добавить аэропорт");
            Console.WriteLine("2 - Редактировать аэропорт");
            Console.WriteLine("3 - Добавить рейс");
            Console.WriteLine("4 - Редактировать рейс");
            Console.WriteLine("5 - Зарегистрировать вылет");
            Console.WriteLine("6 - Редактировать вылет");
            Console.WriteLine("7 - Зарегистрировать прилёт");
            Console.WriteLine("8 - Редактировать прилёт");
            Console.WriteLine("9 - Вылетевшие, но не прибывшие рейсы");
            Console.WriteLine("10 - Информация о рейсе");
            Console.WriteLine("11 - Информация об аэропорте");
            Console.WriteLine("0 - Выход");

            m = int.Parse(Console.ReadLine());

            switch (m)
            {
                case 1:  AirTransportation.AddAirport(); break;
                case 2:  AirTransportation.EditAirport(); break;
                case 3:  AirTransportation.AddFlight(); break;
                case 4:  AirTransportation.EditFlight(); break;
                case 5:  AirTransportation.AddDeparture(); break;
                case 6:  AirTransportation.EditDeparture(); break;
                case 7:  AirTransportation.AddArrival(); break;
                case 8:  AirTransportation.EditArrival(); break;
                case 9:  AirTransportation.ShowInFlightFlights(); break;
                case 10: AirTransportation.ShowFlight(); break;
                case 11: AirTransportation.ShowAirport(); break;
            }

        } while (m != 0);
    }
}