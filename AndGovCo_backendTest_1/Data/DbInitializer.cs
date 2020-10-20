using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AndGovCo_backendTest_1.Models;

namespace AndGovCo_backendTest_1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppContext context)
        {
            // Solo si no hay productos en la base de datos
            if(context.Products.Any())
            {
                return;
            }

            // Agregar áreas
            var areas = new Area[]
            {

            };
            context.Areas.AddRange(areas);
            context.SaveChanges();

            // Agregar tipos de productos
            var productTypes = new ProductType[]
            {

            };
            context.ProductTypes.AddRange(productTypes);
            context.SaveChanges();

            // Agregar estados de productos
            var productStates = new ProductState[]
            {

            };
            context.ProductStates.AddRange(productStates);
            context.SaveChanges();
        }
    }
}