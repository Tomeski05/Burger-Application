using BurgerApp.Domain.Enums;
using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.Models.ViewModels
{
    public class BurgerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BurgerSize Size { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        
        public static BurgerVM Map(Burger burger)
        {
            return new BurgerVM
            {
                Id = burger.Id,
                ImageUrl = $"~/images/{burger.Image}",
                Name = burger.Name,
                Price = burger.Price,
                Size = burger.Size,
            };
        }
    }
}
