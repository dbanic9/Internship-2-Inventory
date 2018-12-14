using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace InventoryDump2
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyVehicles = new List<Vehicle>
            {
                new Vehicle(Guid.NewGuid(),"Company car no.1",new DateTime(2017, 3, 21),120,500000,Manufacturer.Bmw,new DateTime(2019,1,12),21000){},
                new Vehicle(Guid.Parse("b2b8a9f8-f541-4681-9b10-11223531c3ab"),"Company car no.2",new DateTime(2017, 5, 12),120,250000,Manufacturer.Toyota,new DateTime(2019,4,19),15000){},
                new Vehicle(Guid.NewGuid(),"Company car no.3",new DateTime(2017,12, 9),96,80000,Manufacturer.Toyota,new DateTime(2019,8,15),10000){},
                new Vehicle(Guid.NewGuid(),"Company car no.4",new DateTime(2018, 1, 15),180,100000,Manufacturer.Hyundai,new DateTime(2019,8,27),7000){},
                new Vehicle(Guid.NewGuid(),"Company car no.5",new DateTime(2018, 7, 21),120,600000,Manufacturer.Bmw,new DateTime(2019,9,21),5000){}
            };

            var companyComputers = new List<Computer>
            {
                new Computer(Guid.NewGuid(),"Company computer no.1",new DateTime(2017,12,21),36,6000,Manufacturer.Dell,true,"Windows 8.1",true){},
                new Computer(Guid.NewGuid(),"Company computer no.2",new DateTime(2018, 1, 12),60, 7000, Manufacturer.Toshiba, false, "Windows 8.1", false){},
                new Computer(Guid.NewGuid(),"Company computer no.3",new DateTime(2018,2,15),60,8000,Manufacturer.Toshiba,false,"Windows 10",false){},
                new Computer(Guid.Parse("adf71fc0-362b-4bbf-8aef-1a7dac10eea6"),"Company computer no.4",new DateTime(2018, 5, 2), 36, 10000, Manufacturer.Lenovo, true,"Linux Mint 19",true){},
                new Computer(Guid.NewGuid(),"Company computer no.5",new DateTime(2018, 5, 5), 36, 6500, Manufacturer.Toshiba, true,"Windows 10",true){}
            };

            var companyCellPones = new List<CellPhone>
            {
                new CellPhone(Guid.NewGuid(),"Company cellphone no.1",new DateTime(2017,12,14),36,3400,Manufacturer.Huawei,true,"091/111/1111","Ana Anic"){},
                new CellPhone(Guid.NewGuid(),"Company cellphone no.2",new DateTime(2018,1,21),48,3700,Manufacturer.Samsung,true,"099/999/9999","Mate Matic"){},
                new CellPhone(Guid.Parse("426295b6-6dca-4879-b6df-8d17e4250c97"),"Company cellphone no.3",new DateTime(2018,2,13),36,2400,Manufacturer.Huawei,true,"098/888/888","Jozo Jozic"){},
                new CellPhone(Guid.NewGuid(),"Company cellphone no.4",new DateTime(2018,8,3),48,2700,Manufacturer.LG,true,"097/777/7777","Ivana Ivanic"){},
                new CellPhone(Guid.NewGuid(),"Company cellphone no.5",new DateTime(2018,9,2),36,1500,Manufacturer.Huawei,true,"092/222/2222","Maja Majic"){}
            };

            while (true)
            {
                Menu();

                Console.WriteLine("----Choose an option from the menu: ");
                var option = int.Parse(Console.ReadLine());

                if (option == 3)
                {
                    Console.WriteLine("Enter the serial number:");
                    Guid serNum = Guid.Parse(Console.ReadLine());
                    SearchVehicleBySerialNum(companyVehicles,serNum);
                    SearchComputerBySerialNum(companyComputers,serNum);
                    SearchPhoneBySerialNum(companyCellPones,serNum);
                }

                if (option == 4)
                {
                    WarrantyCalculator(companyComputers);
                }

                if (option == 5)
                {
                    Console.WriteLine("Devices with batteries: " + HaveBatteriesCount(companyCellPones, companyComputers));
                    Console.WriteLine("\n");
                }

                if (option == 6)
                {
                    SearchByBrand(companyCellPones);
                }

                if (option == 7)
                {
                    SearchByOS(companyComputers);
                }

                if (option == 8)
                {
                    PhoneWarrantyExpiration(companyCellPones);
                }

                if (option == 9)
                {
                    VehicleRegistrationExpiry(companyVehicles);
                }

                if (option == 10)
                {
                    break;
                }
            }


            /*for (int i = 0; i < companyCellPones.Count; i++)
            {
                Console.WriteLine("Computer no." + (i+1));
                companyCellPones[i].PrintCellPhone();
                Console.WriteLine("\n");
            }*/
        }

        static void SearchVehicleBySerialNum(List<Vehicle> VList, Guid serialNumber)
        {
            for (int i = 0; i < VList.Count; i++)
            {
                if (VList[i].SerialNumber == serialNumber)
                {
                    VList[i].PrintVehicle();
                    Console.WriteLine("\n");
                }

            }
        }

        static void SearchComputerBySerialNum(List<Computer> CList, Guid serialNumber)
        {
            for (int i = 0; i < CList.Count; i++)
            {
                if (CList[i].SerialNumber == serialNumber)
                {
                    CList[i].PrintComputer();
                    Console.WriteLine("\n");
                }
            }
        }

        static void SearchPhoneBySerialNum(List<CellPhone> PList, Guid serialNumber)
        {
            for (int i = 0; i < PList.Count; i++)
            {
                if (PList[i].SerialNumber == serialNumber)
                {
                    PList[i].PrintCellPhone();
                    Console.WriteLine("\n");
                }
            }
        }

        static void WarrantyCalculator(List<Computer> CList)
        {
            Console.WriteLine("Enter a year:");
            var year = int.Parse(Console.ReadLine());
            for (int i = 0; i < CList.Count; i++)
            {
                var date = CList[i].DateOfPurchase;
                var warranty = CList[i].WarrantyDuration;
                date=date.AddYears(warranty / 12);
                if (date.Year == year)
                {
                    CList[i].PrintComputer();
                    Console.WriteLine("\n");
                }
            }
        }

        static int HaveBatteriesCount(List<CellPhone> PList, List<Computer> CList)
        {
            var counter = 0;
            for (int i = 0; i < PList.Count; i++)
            {
                if (PList[i].HasBatteries == true)
                {
                    counter++;
                }
            }

            for (int i = 0; i < CList.Count; i++)
            {
                if (CList[i].HasBatteries == true)
                {
                    counter++;
                }
            }

            return counter;
        }

        static void SearchByBrand(List<CellPhone> PList)
        {
            var entry = "";
            Console.WriteLine("Enter brand name:");
            entry = Console.ReadLine();
            for (int i = 0; i < PList.Count; i++)
            {
                if (PList[i].Manufacturer.ToString().ToLower()==entry.ToLower())
                {
                    PList[i].PrintCellPhone();
                    Console.WriteLine("\n");
                }
            }
        }

        static void SearchByOS(List<Computer> CList)
        {
            Console.WriteLine("Enter an OS:");
            var entry = Console.ReadLine();
            for (int i = 0; i < CList.Count; i++)
            {
                if (CList[i].OperatingSystem.ToLower().Contains(entry.ToLower()))
                {
                    CList[i].PrintComputer();
                    Console.WriteLine("\n");
                }
            }
        }

        static void PhoneWarrantyExpiration(List<CellPhone> PList)
        {
            Console.WriteLine("Enter a year:");
            var year = int.Parse(Console.ReadLine());
            for (int i = 0; i < PList.Count; i++)
            {
                var date = PList[i].DateOfPurchase;
                var warranty = PList[i].WarrantyDuration;
                date = date.AddYears(warranty / 12);
                if (date.Year == year)
                {
                    Console.WriteLine("Phone no." + (i + 1));
                    Console.WriteLine("Current owner: " + PList[i].UserID);
                    Console.WriteLine("Phone number: " + PList[i].PhoneNumber);
                    Console.WriteLine("\n");
                }
            }
        }

        static void VehicleRegistrationExpiry(List<Vehicle> VList)
        {
            for (int i = 0; i < VList.Count; i++)
            {
                var date = DateTime.Now;
                var timeSpan = VList[i].RegistrationExpiryDate.Subtract(date);
                if (timeSpan.TotalDays <= 31)
                {
                    VList[i].PrintVehicle();
                    Console.WriteLine("\n");
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("|Inventory tracker menu|");
            Console.WriteLine("(3)-Search inventory by serial number");
            Console.WriteLine("(4)-Computer warranty expiration by year");
            Console.WriteLine("(5)-Get number of devices with batteries");
            Console.WriteLine("(6)-Search cellphones by brand");
            Console.WriteLine("(7)-Search computers by OS");
            Console.WriteLine("(8)-Cellphone info by warranty expiration year");
            Console.WriteLine("(9)-Vehicle registrations expiring within the next month");
            Console.WriteLine("(10)-Exit");
            Console.WriteLine("\n");
        }

        

    }
    public enum Manufacturer
    {
        Toyota = 1,
        Bmw = 2,
        Hyundai = 3,
        Samsung = 4,
        Huawei = 5,
        LG = 6,
        Toshiba = 7,
        Lenovo = 8,
        Dell = 9,

    }
}
