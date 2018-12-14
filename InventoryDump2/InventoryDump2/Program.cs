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
                new Vehicle(Guid.NewGuid(),"Company car no.1",new DateTime(2017, 3, 21),120,21.3m,Manufacturer.Bmw,new DateTime(2019,2,12),21000){},
                new Vehicle(Guid.Parse("b2b8a9f8-f541-4681-9b10-11223531c3ab"),"Company car no.2",new DateTime(2017, 5, 12),120,19.5m,Manufacturer.Toyota,new DateTime(2019,4,19),15000){},
                new Vehicle(Guid.NewGuid(),"Company car no.3",new DateTime(2017,12, 9),96,16.5m,Manufacturer.Toyota,new DateTime(2019,8,15),10000){},
                new Vehicle(Guid.NewGuid(),"Company car no.4",new DateTime(2018, 1, 15),180,17.8m,Manufacturer.Hyundai,new DateTime(2019,8,27),7000){},
                new Vehicle(Guid.NewGuid(),"Company car no.5",new DateTime(2018, 7, 21),120,22.7m,Manufacturer.Bmw,new DateTime(2019,9,21),5000){}
            };

            var companyComputers = new List<Computer>
            {
                new Computer(Guid.NewGuid(),"Company computer no.1",new DateTime(2017,12,21),36,1.6m,Manufacturer.Dell,true,"Windows 8.1",true){},
                new Computer(Guid.NewGuid(),"Company computer no.2",new DateTime(2018, 1, 12),60, 2.6m, Manufacturer.Toshiba, false, "Windows 8.1", false){},
                new Computer(Guid.NewGuid(),"Company computer no.3",new DateTime(2018,2,15),60,2.8m,Manufacturer.Toshiba,false,"Windows 10",false){},
                new Computer(Guid.Parse("adf71fc0-362b-4bbf-8aef-1a7dac10eea6"),"Company computer no.4",new DateTime(2018, 5, 2), 36, 1.8m, Manufacturer.Lenovo, true,"Linux Mint 19",true){},
                new Computer(Guid.NewGuid(),"Company computer no.5",new DateTime(2018, 5, 5), 36, 1.3m, Manufacturer.Toshiba, true,"Windows 10",true){}
            };

            var companyCellPones = new List<CellPhone>
            {
                new CellPhone(Guid.NewGuid(),"Company cellphone no.1",new DateTime(2017,12,14),36,1.1m,Manufacturer.Huawei,true,"091/111/1111","Ana Anic"){},
                new CellPhone(Guid.NewGuid(),"Company cellphone no.2",new DateTime(2018,1,21),48,1.2m,Manufacturer.Samsung,true,"099/999/9999","Mate Matic"){},
                new CellPhone(Guid.Parse("426295b6-6dca-4879-b6df-8d17e4250c97"),"Company cellphone no.3",new DateTime(2018,2,13),36,0.9m,Manufacturer.Huawei,true,"098/888/888","Jozo Jozic"){},
                new CellPhone(Guid.NewGuid(),"Company cellphone no.4",new DateTime(2018,8,3),48,1.4m,Manufacturer.LG,true,"097/777/7777","Ivana Ivanic"){},
                new CellPhone(Guid.NewGuid(),"Company cellphone no.5",new DateTime(2018,9,2),36,1.0m,Manufacturer.Huawei,true,"092/222/2222","Maja Majic"){}
            };

            Console.WriteLine("Enter the serial number:");
            Guid serNum = Guid.Parse(Console.ReadLine());
            SearchVehicleBySerialNum(companyVehicles,serNum);
            SearchComputerBySerialNum(companyComputers,serNum);
            SearchPhoneBySerialNum(companyCellPones,serNum);

            

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
                }
            }
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
