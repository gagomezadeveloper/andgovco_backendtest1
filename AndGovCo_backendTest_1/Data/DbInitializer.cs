using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AndGovCo_backendTest_1.Models;

namespace AndGovCo_backendTest_1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDataContext context)
        {
            // Solo si no hay productos en la base de datos
            if (context.Products.Any())
            {
                return;
            }

            // Agregar áreas
            var areas = new Area[]
            {
                new Area { Name = "Hogar", Description = "Mejores equipos para el hogar.", State = true},
                new Area { Name = "Empresa", Description = "Infraestructura de calidad para soportar su negocio.", State = true}
            };
            context.Areas.AddRange(areas);
            context.SaveChanges();

            // Agregar tipos de productos
            var productTypes = new ProductType[]
            {
                new ProductType { Name = "Portátiles", Description = "", State = true },
                new ProductType { Name = "Computadoras de escritorio", Description = "", State = true },
                new ProductType { Name = "Accesorios", Description = "", State = true }
            };
            context.ProductTypes.AddRange(productTypes);
            context.SaveChanges();

            // Agregar estados de productos
            var productStates = new ProductState[]
            {
                new ProductState { Name = "Disponible", Description = "", State = true },
                new ProductState { Name = "No disponible", Description = "", State = true },
                new ProductState { Name = "En oferta", Description = "", State = true }
            };
            context.ProductStates.AddRange(productStates);
            context.SaveChanges();

            // Agregar productos
            var products = new Product[]
            {
                new Product { Name = "Inspi 3000", Description = "Laptos economica para el hogar.", Serial = "3000", PurchaseValue = 1950000, PurchaseDate = DateTime.Now, ProductStateID = 1, ProductTypeID = 1, AreaID =  1},
                new Product { Name = "Inspi 5000", Description = "Laptos economica para el hogar.", Serial = "5000", PurchaseValue = 1550000, PurchaseDate = DateTime.Now, ProductStateID = 2, ProductTypeID = 1, AreaID =  1},
                new Product { Name = "XXS 10", Description = "PC para profesionales.", Serial = "10", PurchaseValue = 2500000, PurchaseDate = DateTime.Now, ProductStateID = 3, ProductTypeID = 2, AreaID =  2},
                new Product { Name = "XXS 12", Description = "PC para profesionales.", Serial = "12", PurchaseValue = 2300333, PurchaseDate = DateTime.Now, ProductStateID = 1, ProductTypeID = 2, AreaID =  2},
                new Product { Name = "Impresora laser V105", Description = "Impresora profesional.", Serial = "105", PurchaseValue = 500000, PurchaseDate = DateTime.Now, ProductStateID = 2, ProductTypeID = 3, AreaID =  1},
                new Product { Name = "Impresora P700", Description = "Impresora para el hogar.", Serial = "700", PurchaseValue = 250000, PurchaseDate = DateTime.Now, ProductStateID = 3, ProductTypeID = 3, AreaID =  2},
            };
            context.Products.AddRange(products);
            context.SaveChanges();

        }
    }
}