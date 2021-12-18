using BurgerApp.BusinessLayer.Interfaces;
using BurgerApp.DataAccess.Repositories;
using BurgerApp.Domain.Models;
using BurgerApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BurgerApp.BusinessLayer.Services
{
    public class BurgerService : IBurgerService
    {
        private readonly IRepository<Burger> _burgerRepository;
        private const string _currency = "C2";

        public BurgerService(IRepository<Burger> burgerRepository)
        {
            _burgerRepository = burgerRepository;
        }

        public MenuVM GetMenu()
        {
            var burgers = _burgerRepository.GetAll();

            List<BurgerVM> listofBurgers = new List<BurgerVM>();
            foreach (var burger in burgers)
            {
                listofBurgers.Add(BurgerVM.Map(burger));
            }

            listofBurgers = listofBurgers
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Size)
                .ToList();


            // LINQ

            //var burgersMapped = burgers
            //    .Select(x => BurgerVM.Map(x))
            //    .OrderBy(x => x.Name)
            //    .ThenBy(x => x.Size)
            //    .ToList();


            return new MenuVM()
            {
                Burgers = listofBurgers,
                Currency = _currency
            };
        }
    }
}
