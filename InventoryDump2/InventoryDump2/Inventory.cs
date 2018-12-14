using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryDump2
{
    public class Inventory
    {
        public Guid SerialNumber { get; set; }
        public string Description { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int WarrantyDuration { get; set; }
        public decimal Price { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public Inventory(Guid serialNumber, string description, DateTime dateOfPurchase, int warrantyDuration,
            decimal price, Manufacturer manufacturer)
        {
            SerialNumber = serialNumber;
            Description = description;
            DateOfPurchase = dateOfPurchase;
            WarrantyDuration = warrantyDuration;
            Price = price;
            Manufacturer = manufacturer;
        }

    }

    public class Technology : Inventory
    {
        public bool HasBatteries { get; set; }

        public Technology(Guid serialNumber, string description, DateTime dateOfPurchase, int warrantyDuration,
            decimal price, Manufacturer manufacturer, bool hasBatteries)
            : base(serialNumber, description, dateOfPurchase, warrantyDuration, price, manufacturer)
        {
            HasBatteries = hasBatteries;
        }
    }

    public class Vehicle : Inventory
    {
        public DateTime RegistrationExpiryDate { get; set; }
        public int Mileage { get; set; }

        public Vehicle(Guid serialNumber, string description, DateTime dateOfPurchase, int warrantyDuration,
            decimal price, Manufacturer manufacturer, DateTime registrationExpiryDate, int mileage)
            : base(serialNumber, description, dateOfPurchase, warrantyDuration, price, manufacturer)
        {
            RegistrationExpiryDate = registrationExpiryDate;
            Mileage = mileage;
        }


        public void PrintVehicle()
        {
            Console.WriteLine("Serial number: " + SerialNumber);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Date of purchase: " + DateOfPurchase);
            Console.WriteLine("Warranty duration(months): " + WarrantyDuration);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Manufacturer: " + Manufacturer);
            Console.WriteLine("Registration expiry date: " + RegistrationExpiryDate);
            Console.WriteLine("Mileage:" + Mileage);
        }

    }

    public class Computer : Technology
    {
        public string OperatingSystem { get; set; }
        public bool IsPortable { get; set; }

        public Computer(Guid serialNumber, string description, DateTime dateOfPurchase, int warrantyDuration,
            decimal price, Manufacturer manufacturer, bool hasBatteries, string operatingSystem, bool isPortable)
            : base(serialNumber, description, dateOfPurchase, warrantyDuration, price, manufacturer, hasBatteries)
        {
            OperatingSystem = operatingSystem;
            IsPortable = isPortable;
        }

        public void PrintComputer()
        {
            Console.WriteLine("Serial number: " + SerialNumber);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Date of purchase: " + DateOfPurchase);
            Console.WriteLine("Warranty duration(months): " + WarrantyDuration);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Manufacturer: " + Manufacturer);
            Console.WriteLine("This device contains batteries: " + HasBatteries);
            Console.WriteLine("Operating system: " + OperatingSystem);
            Console.WriteLine("This device is portable: " + IsPortable);
        }

    }

    public class CellPhone : Technology
    {
        public string PhoneNumber { get; set; }
        public string UserID { get; set; }

        public CellPhone(Guid serialNumber, string description, DateTime dateOfPurchase, int warrantyDuration,
            decimal price, Manufacturer manufacturer, bool hasBatteries, string phoneNumber, string userID)
            : base(serialNumber, description, dateOfPurchase, warrantyDuration, price, manufacturer, hasBatteries)
        {
            PhoneNumber = phoneNumber;
            UserID = userID;
        }

        public void PrintCellPhone()
        {
            Console.WriteLine("Serial number: " + SerialNumber);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Date of purchase: " + DateOfPurchase);
            Console.WriteLine("Warranty duration(months): " + WarrantyDuration);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Manufacturer: " + Manufacturer);
            Console.WriteLine("This device contains batteries: " + HasBatteries);
            Console.WriteLine("Phone number: " + PhoneNumber);
            Console.WriteLine("Current user ID: " + UserID);
        }
    }
}
