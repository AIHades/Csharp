using System;
using N2;

namespace N2
{
    class Goods
    {
        private int goodsId;
        private string name;
        private double unit_price;
        private string category;
        private double weight;

        public Goods(
            int goodsId,
            string name,
            double unit_price,
            string category,
            double weight
        )
        {
            this.goodsId = goodsId;
            this.name = name;
            this.unit_price = unit_price;
            this.category = category;
            this.weight = weight;
        }

        public int GoodsId
        {
            get{return goodsId;}
        }

        public string Name
        {
            get{return name;}
            set { name = value; }
        }

        public double UnitPrice
        {
            get{return unit_price;}
            set { unit_price = value; }
        }

        public string Category
        {
            get{return category;}
            set { category = value; }
        }

        public double Weight
        {
            get{return weight;}
            set { weight = value; }
        }
    }


    class Stores
    {
        private int storeId;
        private string store_name;
        private string address;
        private string store_phone;
        private List<StoreKeepers> storeKeepers;
        
        public Stores(
            int storeId,
            string store_name,
            string address,
            string store_phone
        )
        {
            this.storeId = storeId;
            this.store_name = store_name;
            this.address = address;
            this.store_phone = store_phone;
            storeKeepers = new List<StoreKeepers>();
        }

        public int StoreId
        {
            get{return storeId;}
        }

        public string StoreName
        {
            get{return store_name;}
        }
        
        public string Address
        {
            get{return address;}
        }

        public string StorePhone
        {
            get{return store_phone;}
        }
        public void AssignKeeper(StoreKeepers keeper)
        {
            storeKeepers.Add(keeper);
        }
 
        public void RemoveKeeper(StoreKeepers keeper)
        {
            storeKeepers.Remove(keeper);
        }
        public List<StoreKeepers> GetKeepers()
        {
            return storeKeepers;
        }
    }


    class StoreKeepers
    {
        private int storeKeeperId;
        private string fullName;
        private string storeKeeperPhone;
        private string storeKeeperPassport;
        private int age;

        public StoreKeepers(
            int storeKeeperId,
            string fullName,
            string storeKeeperPhone,
            string storeKeeperPassport,
            int age
        )
        {
            this.storeKeeperId = storeKeeperId;
            this.fullName = fullName;
            this.storeKeeperPhone = storeKeeperPhone;
            this.storeKeeperPassport = storeKeeperPassport;
            this.age = age;
        }

        public int StoreKeeperId
        {
            get{return storeKeeperId;}
        }

        public string StoreKeeperPhone
        {
            get{return storeKeeperPhone;}
        }

        public string StoreKeeperPassport
        {
            get{return storeKeeperPassport;}
        }

        public string FullName
        {
            get{return fullName;}
        }

        public int Age
        {
            get{return age;}
        }
        
    }


    class GoodsInStores
    {
        private int recordId;
        private Goods goods;
        private Stores store;
        private int quantity;
        private DateTime arrivalDate;

        public GoodsInStores(
            int recordId,
            Goods goods,
            Stores store,
            int quantity,
            DateTime arrivalDate
        )

    {
        this.recordId = recordId;
        this.goods = goods;
        this.store = store;
        this.quantity = quantity;
        this.arrivalDate = arrivalDate;
    }
    
        public int RecordId
        {
            get { return recordId; }
        }
 
        public Goods Goods
        {
            get { return goods; }
        }
 
        public Stores Store
        {
            get { return store; }
        }
 
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
 
        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
        }

    }

    class Warehouse
    {
        static Dictionary<int, Goods> goods;
        static Dictionary<int, Stores> stores;
        static Dictionary<string, StoreKeepers> storeKeepers;
        static List<GoodsInStores> goodsInStores;
        static int nextGoodsId = 1;
        static int nextStoreId = 1;
        static int nextKeeperId = 1;
        static int nextRecordId = 1;

        static Warehouse()
        {
            goods = new Dictionary<int, Goods>();
            stores = new Dictionary<int, Stores>();
            storeKeepers = new Dictionary<string, StoreKeepers>();
            goodsInStores = new List<GoodsInStores>();
        }

        public static void AddGoods()
        {
            Console.WriteLine("Название товара: ");
            string name = Console.ReadLine();

            Console.WriteLine("Цена за единицу: ");
            double unit_price = double.Parse(Console.ReadLine());

            Console.WriteLine("Категория: ");
            string category = Console.ReadLine();

            Console.WriteLine("Вес: ");
            double weight = double.Parse(Console.ReadLine());

            int id = nextGoodsId++;
            goods.Add(id, new Goods(id, name, unit_price, category, weight));
            Console.WriteLine("Товар добавлен");
        }

        public static void AddStore()
        {
            Console.WriteLine("Название склада: ");
            string store_name = Console.ReadLine();

            Console.WriteLine("Адрес скалада: ");
            string address = Console.ReadLine();

            Console.WriteLine("Телефона склада: ");
            string store_phone = Console.ReadLine();

            int id = nextStoreId++;
            stores.Add(id, new Stores(id, store_name, address, store_phone));
            Console.WriteLine("Склад добавлен");
        }

        public static void AddStoreKeeper()
        {
            Console.Write("ФИО кладовщика: ");
            string name = Console.ReadLine();
 
            Console.Write("Телефон кладовщика: ");
            string phone = Console.ReadLine();
 
            Console.Write("Серия и номер паспорта кладовщика: ");
            string passport = Console.ReadLine();
 
            Console.Write("Возраст кладовщика: ");
            int age = int.Parse(Console.ReadLine());

            int id = nextKeeperId++;
            storeKeepers.Add(passport, new StoreKeepers(id, name, phone, passport, age));
            Console.WriteLine("Кладовщик добавлен");
        }

        public static void ShowGoods()
        {
            Console.Write("ID товара: ");
            int id = int.Parse(Console.ReadLine());
 
            if (!goods.ContainsKey(id))
            {
                Console.WriteLine("Товар не найден.");
                return;
            }
 
            Goods g = goods[id];
            Console.WriteLine("ID товара: " + g.GoodsId);
            Console.WriteLine("Название товара: " + g.Name);
            Console.WriteLine("Цена: " + g.UnitPrice);
            Console.WriteLine("Категория товара: " + g.Category);
            Console.WriteLine("Вес товара: " + g.Weight);
        }

        public static void EditGoods()
        {
            Console.Write("ID товара для редактирования: ");
            int id = int.Parse(Console.ReadLine());
 
            if (!goods.ContainsKey(id))
            {
                Console.WriteLine("Товар не найден.");
                return;
            }
 
            Goods g = goods[id];
 
            Console.Write("Новое название " + g.Name + ": ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) g.Name = name;
 
            Console.Write("Новая цена " + g.UnitPrice + ": ");
            string priceStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceStr)) g.UnitPrice = double.Parse(priceStr);
 
            Console.Write("Новая категория " + g.Category + ": ");
            string category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category)) g.Category = category;
            
            Console.Write("Новый вес " + g.Weight + ": ");
            string weightStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(weightStr)) g.Weight = double.Parse(weightStr);
 
            Console.WriteLine("Товар изменен");
        }

        public static void ShowStore()
        {
            Console.Write("ID склада: ");
            int id = int.Parse(Console.ReadLine());
 
            if (!stores.ContainsKey(id))
            {
                Console.WriteLine("Склад не найден.");
                return;
            }
 
            Stores s = stores[id];
            Console.WriteLine("ID склада: " + s.StoreId);
            Console.WriteLine("Название склада: " + s.StoreName);
            Console.WriteLine("Адрес склада: " + s.Address);
            Console.WriteLine("Телефон склада: " + s.StorePhone);
 
            var keepers = s.GetKeepers();
            if (keepers.Count == 0)
                Console.WriteLine("Кладовщики: не назначены");
            else
            {
                Console.WriteLine("Кладовщики:");
                foreach (var k in keepers)
                    Console.WriteLine("  " + k.StoreKeeperId + " " + k.FullName);
            }
        }

        public static void ShowStoreKeeper()
        {
            Console.Write("Паспорт кладовщика: ");
            string passport = Console.ReadLine();
 
            if (!storeKeepers.ContainsKey(passport))
            {
                Console.WriteLine("Кладовщик не найден.");
                return;
            }
 
            StoreKeepers sk = storeKeepers[passport];
            Console.WriteLine("ID кладовщика: " + sk.StoreKeeperId);
            Console.WriteLine("ФИО кладовщика: " + sk.FullName);
            Console.WriteLine("Телефон кладовщика: " + sk.StoreKeeperPhone);
            Console.WriteLine("Паспорт кладовщика: " + sk.StoreKeeperPassport);
            Console.WriteLine("Возраст кладовщика: " + sk.Age);
        }

        public static void AssignKeeperToStore()
        {
            Console.Write("ID склада: ");
            int storeId = int.Parse(Console.ReadLine());
 
            Console.Write("Паспорт кладовщика: ");
            string passport = Console.ReadLine();
 
            if (!stores.ContainsKey(storeId))
            {
                Console.WriteLine("Склад не найден.");
                return;
            }
            if (!storeKeepers.ContainsKey(passport))
            {
                Console.WriteLine("Кладовщик не найден.");
                return;
            }
 
            stores[storeId].AssignKeeper(storeKeepers[passport]);
            Console.WriteLine("Кладовщик " + storeKeepers[passport].FullName + " назначен на склад " + stores[storeId].StoreName + ".");
        }

        public static void AddGoodsToStore()
        {
            Console.Write("ID товара: ");
            int goodsId = int.Parse(Console.ReadLine());
 
            Console.Write("ID склада: ");
            int storeId = int.Parse(Console.ReadLine());
 
            Console.Write("Количество: ");
            int qty = int.Parse(Console.ReadLine());
 
            if (!goods.ContainsKey(goodsId))
            {
                Console.WriteLine("Товар не найден.");
                return;
            }
            if (!stores.ContainsKey(storeId))
            {
                Console.WriteLine("Склад не найден.");
                return;
            }
 
            int id = nextRecordId++;
            goodsInStores.Add(new GoodsInStores(id, goods[goodsId], stores[storeId], qty, DateTime.Now));
            Console.WriteLine("Поступление зарегистрировано");
        }

        public static void ShowGoodsInStore()
        {
            Console.Write("ID склада: ");
            int storeId = int.Parse(Console.ReadLine());
 
            if (!stores.ContainsKey(storeId))
            {
                Console.WriteLine("Склад не найден.");
                return;
            }
 
            Console.WriteLine("Товары на складе " + stores[storeId].StoreName + ": ");
            bool found = false;
            foreach (var rec in goodsInStores)
            {
                if (rec.Store.StoreId == storeId)
                {
                    Console.WriteLine(rec.RecordId + rec.Goods.Name + " — " + rec.Quantity + " шт. " + "(поступил: " + rec.ArrivalDate.ToString("dd.MM.yyyy HH:mm") + ")");
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Товары не найдены."); 
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
            Console.WriteLine("1  - Добавить товар");
            Console.WriteLine("2  - Просмотр товара");
            Console.WriteLine("3  - Редактировать товар");
            Console.WriteLine("4  - Добавить склад");
            Console.WriteLine("5  - Просмотр склада");
            Console.WriteLine("6  - Добавить кладовщика");
            Console.WriteLine("7  - Просмотр кладовщика");
            Console.WriteLine("8  - Назначить кладовщика на склад");
            Console.WriteLine("9  - Зарегистрировать поступление товара");
            Console.WriteLine("10 - Просмотр товаров на складе");
            Console.WriteLine("0  - Выход");

 
            m = int.Parse(Console.ReadLine());
 
            switch (m)
            {
                case 1:  Warehouse.AddGoods();         break;
                case 2:  Warehouse.ShowGoods();        break;
                case 3:  Warehouse.EditGoods();        break;
                case 4:  Warehouse.AddStore();         break;
                case 5:  Warehouse.ShowStore();        break;
                case 6:  Warehouse.AddStoreKeeper();   break;
                case 7:  Warehouse.ShowStoreKeeper();  break;
                case 8:  Warehouse.AssignKeeperToStore(); break;
                case 9:  Warehouse.AddGoodsToStore();  break;
                case 10: Warehouse.ShowGoodsInStore(); break;
            }
 
        } while (m != 0);
    }
}