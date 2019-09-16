using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MishmashApi.Entities.Shop;
using MishmashApi.Implementations;
using StackExchange.Redis;

namespace MishmashApi.Controllers
{
    
    public class InventoryController : Controller
    {
        private readonly InventoryImplementations _inventory;

        public InventoryController(InventoryImplementations inventory)
        {
            _inventory = inventory;
        }

        //GET -> Inventory/AvailableShoesSizes
        [HttpGet]
        public IActionResult AvailableShoesSizes() => Utils.BenchAndResponse(() => _inventory.AvailableShoesSizes());

        //GET -> Inventory/AvailableClothesSizes
        [HttpGet]
        public IActionResult AvailableClothesSizes() => Utils.BenchAndResponse(() => _inventory.AvailableClothesSizes());

        //GET -> Inventory/AvailableProducts
        [HttpGet]
        public IActionResult AvailableProducts() => Utils.BenchAndResponse(() => _inventory.AvailableProducts());

        //GET -> Inventory/Prices
        [HttpGet]
        public IActionResult Prices() => Utils.BenchAndResponse(() => _inventory.Prices());

        //GET -> Inventory/Quantity
        [HttpGet]
        public IActionResult Quantity(string productIds) => Utils.BenchAndResponse(() => _inventory.Quantity(productIds));

        //GET -> Inventory/Order
        [HttpGet]
        public IActionResult Order(string productIds, string quantities) => Utils.BenchAndResponse(() => _inventory.Order(productIds, quantities));

        //GET -> Inventory/Discount
        [HttpGet]
        public IActionResult Discount(string productIds) => Utils.BenchAndResponse(() => _inventory.Discount(productIds));
    }
}
