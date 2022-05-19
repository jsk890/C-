using System;

using System.Linq;

namespace SimpleLinq
{
    class Profile
    {

        public string Name { get; set; }
        public int Height { get; set; }
    }

    class Product
    {
        public string Title { get; set; }
        public string Star { get; set; }
    }

    class Car
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int MaxSpeed { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Profile[] arrProfile = {
                new Profile(){Name="���켺", Height=186},
                new Profile(){Name="������", Height=158},
                new Profile(){Name="������", Height=172},
                new Profile(){Name="�̹���", Height=178},
                new Profile(){Name="�ϵ���", Height=171}
            };

            Product[] arrProduct = {
                new Product(){Title="���켺", Star="���켺"},
                new Product(){Title="������", Star="������"},
                new Product(){Title="������", Star="������"},
                new Product(){Title="�̹���", Star="������"},
                new Product(){Title="�ϵ���", Star="�̹���"}
            };

            var profiles = from profile in arrProfile
                           where profile.Height < 175
                           orderby profile.Height
                           
                           select new
                           {
                               Name = profile.Name,
                               InchHeight = profile.Height * 0.393
                           };

            var listProfile = from profile in arrProfile
                              orderby profile.Height
                              group profile by profile.Height < 175 into g
                              select new { GroupKey = g.Key, Profiles = g };

            var listJoinProfile = from profile in arrProfile
                                  join product in arrProduct on profile.Name equals product.Star
                                  select new
                                  {
                                      Name = profile.Name,
                                      Work = product.Title,
                                      Height = profile.Height
                                  };

            foreach (var profile in profiles)
                Console.WriteLine($"{profile.Name}, {profile.InchHeight}");


            foreach (var Group in listProfile)
            {
                Console.WriteLine($"- 175cm �̸�? : {Group.GroupKey}");

                foreach (var profile in Group.Profiles)
                {
                    Console.WriteLine($"   {profile.Name}, {profile.Height}");
                }
            }

            Console.WriteLine("--- ���� ���� ��� ---");
            foreach (var profile in listJoinProfile)
            {
                Console.WriteLine("�̸� : {0}, ��ǰ:{1}, Ű:{2}cm",
                    profile.Name, profile.Work, profile.Height);
            }

            listJoinProfile =
                from profile in arrProfile
                join product in arrProduct on profile.Name equals product.Star into ps
                from sub_product in ps.DefaultIfEmpty(new Product() { Title = "�׷��� ����" })
                select new
                {
                    Name = profile.Name,
                    Work = sub_product.Title,
                    Height = profile.Height
                };

            Console.WriteLine();
            Console.WriteLine("--- �ܺ� ���� ��� ---");
            foreach (var profile in listJoinProfile)
            {
                Console.WriteLine("�̸�:{0}, ��ǰ:{1}, Ű:{2}cm",
                    profile.Name, profile.Work, profile.Height);
            }


            Car[] cars =
            {
                new Car(){Name = "1",Cost= 56, MaxSpeed= 120},
                new Car(){Name = "2",Cost= 70, MaxSpeed= 150},
                new Car(){Name = "3",Cost= 45, MaxSpeed= 180},
                new Car(){Name = "4",Cost= 32, MaxSpeed= 200},
                new Car(){Name = "5",Cost= 82, MaxSpeed= 280}
            };


            var listCar = from car in cars
                          group car by (car.Cost >= 50 && car.MaxSpeed >= 150) into g
                          select new { carKey = g.Key, Car = g };



            foreach (var car in listCar)
            {
                if (car.carKey)
                {
                    Console.WriteLine($"Cost>50 && MaxSpeed>150? : {car.carKey}");

                    foreach (var car2 in car.Car)
                    {
                        Console.WriteLine($"Cost:{car2.Cost}, MaxSpeed{car2.MaxSpeed}");
                    }
                }
            }

            Console.WriteLine("////////");
            var selected = cars.Where(c => c.Cost < 60).OrderBy(c => c.Cost);

            var listSelected = from car in cars
                               orderby car.Cost descending
                               group car by (car.Cost < 60) into g
                               select new { carKey = g.Key, Car = g };

            foreach (var car in selected)
            {
                Console.WriteLine($"Cost:{car.Cost}, MaxSpeed{car.MaxSpeed}");
            }

            Console.WriteLine("////////");
            foreach (var car in listSelected)
            {
                if (car.carKey)
                {
                    Console.WriteLine("60-, descending");
                    foreach (var car2 in car.Car)
                    {
                        Console.WriteLine($"Cost:{car2.Cost}, MaxSpeed{car2.MaxSpeed}");
                    }
                }
            }
        }
    }
}
