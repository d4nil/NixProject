using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain.Core;

namespace User_Interface.Presentation.Datas
{
    public static class Dates
    {

        public static void Initialize(Context context)
        {
            if (!context.Categories.Any())
            {
                Category electronics = new Category { Name = "Электроника" };
                Category autoparts = new Category { Name = "Автомобильные запчасти" };
                Category musicinstruments = new Category { Name = "Музыкальные инструменты" };
                Category clothes = new Category { Name = "Одежда" };
                context.Categories.AddRange(
                 new Domain.Core.Category
                 {
                     Name = "Компьютеры и ноутбуки",
                     ParentCategory = electronics
                 },
                    new Domain.Core.Category
                    {
                        Name = "Смартфоны",
                        ParentCategory = electronics
                    },
                    new Domain.Core.Category
                    {
                        Name = "Бытовая техника",
                        ParentCategory = electronics
                    },
                    new Domain.Core.Category
                    {
                        Name = "Ударные",
                        ParentCategory = musicinstruments
                    },
                    new Domain.Core.Category
                    {
                        Name = "Гитары",
                        ParentCategory = musicinstruments
                    },
                    new Domain.Core.Category
                    {
                        Name = "Автомобильные принадлежности",
                        ParentCategory = clothes
                    }, 
                    clothes, musicinstruments, electronics, autoparts
            ) ;
                context.Cities.AddRange
                    (
                     new City { city = "Киев"},
                     new City { city = "Харьков" },
                     new City { city = "Днепр" },
                     new City { city = "Львов" },
                     new City { city = "Одесса" },
                     new City { city = "Винница" },
                     new City { city = "Запорожье" }
                    );
                context.Producers.AddRange
                    (
                     new Producer { Name = "Sony"},
                     new Producer { Name = "Samsung"}
                    );


                context.SaveChanges();
            }
        }

    }
}
