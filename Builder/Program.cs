 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new OldCustomerProductBuilder();

            director.GenerateBuilder(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.DiscountedPrice);

            Console.ReadLine();
            
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    //ViewModeli Üretecek Builder
    abstract class ProductBuilder
    {//Why Abstract? --> You need to make easier to switch builder sources when it's necessary
        public abstract void GetProductData();
        public abstract void AppliedDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();

        public override void AppliedDiscount()
        {
            
            model.DiscountedPrice = model.UnitPrice *(decimal)0.90;
            model.DiscountApplied = true;
        }

        public override void GetProductData()
        {
            //Assume you get those values from database
            model.Id = 1;
            model.ProductName = "Chai";
            model.CategoryName = "Beverage";
            model.UnitPrice = 20;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void AppliedDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override void GetProductData()
        {
            //Assume you get those values from database
            model.Id = 1;
            model.ProductName = "Chai";
            model.CategoryName = "Beverage";
            model.UnitPrice = 20;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

     class ProductDirector
    {
        public void GenerateBuilder(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.AppliedDiscount();
        }
    }

}
