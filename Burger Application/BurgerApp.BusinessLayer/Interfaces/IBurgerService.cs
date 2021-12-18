using BurgerApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.BusinessLayer.Interfaces
{
    public interface IBurgerService
    {
        MenuVM GetMenu(); 
    }
}
