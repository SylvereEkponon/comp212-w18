using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class Product
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
    }

    class Category
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            var InnerJoin = from p in products
                            join c in categories
                            on p.CategoryID equals c.ID
                            select new { Name = p.Name, CategoryName = c.Name };
            foreach (var item in InnerJoin)
            {
                Console.WriteLine($"{item.CategoryName,-20}:{item.Name}");
            }
            Console.WriteLine();
            var GroupJoin = from c in categories
                            join p in products
                            on c.ID equals p.CategoryID
                            into prodGroup
                            select new { CategoryName = c.Name, Products = prodGroup };

            foreach (var prodGrouping in GroupJoin)
            {
                Console.WriteLine($"{prodGrouping.CategoryName}");
                foreach (var item in prodGrouping.Products)
                {
                    Console.WriteLine($"\0\0{item.Name}");
                }
            }
            Console.WriteLine();
            var leftOuterJoin = from category in categories
                                join prod in products
                                on category.ID equals prod.CategoryID into prodGroup
                                from b in prodGroup.DefaultIfEmpty(new Product())
                                select new { catName = category.Name, ProdName = b.Name };
           
            foreach (var item in leftOuterJoin)
            {
                Console.WriteLine($"{item.catName,-20}{item.ProdName}");
            }

            Console.WriteLine();
            var rightOuterJoin = from prod in products
                                join category in categories
                                on prod.CategoryID equals category.ID into prodGroup2
                                from b in prodGroup2.DefaultIfEmpty(new Category())
                                select new { ProdName = prod.Name, catName=b.Name };

            foreach (var item in rightOuterJoin)
            {
                Console.WriteLine($"{item.catName,-20}{item.ProdName}");
            }



        }

        // Specify the first data source.
       static List<Category> categories = new List<Category>()
    {
        new Category(){Name="Beverages", ID=001},
        new Category(){ Name="Condiments", ID=002},
        new Category(){ Name="Vegetables", ID=003},
        new Category() {  Name="Grains", ID=004},
        new Category() {  Name="Fruit", ID=005}
    };

        // Specify the second data source.
       static List<Product> products = new List<Product>()
   {
      new Product{Name="Cola",  CategoryID=001},
      new Product{Name="Tea",  CategoryID=001},
      new Product{Name="Mustard", CategoryID=002},
      new Product{Name="Pickles", CategoryID=002},
      new Product{Name="Carrots", CategoryID=003},
      new Product{Name="Bok Choy", CategoryID=003},
      new Product{Name="Peaches", CategoryID=005},
      new Product{Name="Melons", CategoryID=005},
    };
    }
}
