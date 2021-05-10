using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerGrupp2.Data.Migrations;
using HolidayMakerGrupp2.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace HolidayMakerGrupp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DropAndCreateDB();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async void DropAndCreateDB()
        {
            using (var context = new HolidayMakerGrupp2Context())
            {
                await context.Database.EnsureDeletedAsync();
                context.SaveChanges();
                context.Database.EnsureCreated();
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Cities]([Name]) VALUES (N'Malmö')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Cities]([Name]) VALUES(N'Sundsvall')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Cities]([Name]) VALUES(N'Kalmar')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Cities]([Name]) VALUES(N'Björneborg')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Cities]([Name]) VALUES(N'Tammerfors')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Cities]([Name]) VALUES(N'Kantlax')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Cities]([Name]) VALUES(N'Halmstad')");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(1, 5, 0, 1, 0, 1, 1.2, 0.5, N'Blablabla')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(1, 10, 1, 1, 0, 1, 1.5, 0.5, N'Malmö Stadshotell')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(1, 10, 0, 0, 0, 1, 0.5, 2, N'Malmö LIve')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(2, 10, 1, 1, 1, 1, 7, 1, N'Kalmar Slott')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(2, 10, 0, 1, 0, 1, 8, 2, N'Kalmar Fängelse')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(3, 10, 0, 0, 0, 1, 1, 0.5, N'Hotell Knaust')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(4, 10, 1, 0, 0, 1, 1, 2, N'Igloo Housing')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(4, 10, 1, 1, 0, 1, 2, 0.5, N'Björneborg Stadshotell')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(4, 10, 0, 1, 0, 1, 0.5, 1, N'Björneborg Strandhotell')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(5, 10, 0, 1, 0, 1, 0.5, 1, N'FinlandAirBnB')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(5, 10, 1, 1, 1, 1, 2, 0.5, N'Tammerfors Motel')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(6, 10, 1, 0, 0, 0, 5, 2, N'Kantlax Hostel')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(6, 10, 0, 0, 1, 1, 1.5, 1, N'Kantlax Beach Hotell')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(2, 5, 1, 0, 1, 0, 2.1, 1.3, N'Blabla')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Accomodation]([CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES(3, 5, 1, 1, 1, 1, 0.3, 0.9, N'Bla')");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Comfort]([Name]) VALUES(N'Självhushåll')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Comfort]([Name]) VALUES(N'Halvpension')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Comfort]([Name]) VALUES(N'Helpension')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Comfort]([Name]) VALUES(N'All inclusive')");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Customer]([Firstname], [Lastname], [Email], [PhoneNr], [Address], [City], [Zipcode], [GuID]) VALUES(N'Anton', N'Bajs', N'anton.carl@bajs.com', N'123456789', N'Bajsvägen 2', N'Malmö', 12345, N'9855cf67-a15a-42ff-9b21-31bacfa2f92b')");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Customer]([Firstname], [Lastname], [Email], [PhoneNr], [Address], [City], [Zipcode], [GuID]) VALUES(N'Elin', N'Elin', N'elin.elin@bajs.com', N'123456789', N'Bajsvägen 2', N'Malmö', 12355, N'bad55201-b03f-4725-993d-8c640e7001e8')");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Room]([Price], [NrOfBeds], [AccomodationsId], [RoomType]) VALUES(500, 1, 1, N'Garderob')    ");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Room]([Price], [NrOfBeds], [AccomodationsId], [RoomType]) VALUES(1000, 1, 2, N'Enkelrum')   ");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Room]([Price], [NrOfBeds], [AccomodationsId], [RoomType]) VALUES(1250, 2, 3, N'Dubbelrum')  ");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Room]([Price], [NrOfBeds], [AccomodationsId], [RoomType]) VALUES(3000, 3, 1, N'Familjerum') ");
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Room]([Price], [NrOfBeds], [AccomodationsId], [RoomType]) VALUES(5000, 4, 2, N'Löfvensuite')");
                await context.SaveChangesAsync();
                context.Database.ExecuteSqlRaw("INSERT[dbo].[Transportation]([Departure], [Destination], [Price], [TransportType]) VALUES(N'Juni 11', N'Någonstans', N'500', N'Katapullt')");
            }
        }
    }
}