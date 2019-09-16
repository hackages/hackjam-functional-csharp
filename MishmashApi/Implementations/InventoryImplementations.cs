using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MishmashApi.Entities.Shop;
using StackExchange.Redis;

namespace MishmashApi.Implementations
{
    public class InventoryImplementations
    {
        private readonly IList<Product> _products;

        public InventoryImplementations(IList<Product> products)
        {
            _products = products;
        }

        /// <summary>
        /// Return all available different shoes sizes sorted
        /// </summary>
        /// <returns>List of sizes</returns>
        public IEnumerable AvailableShoesSizes () => throw new NotImplementedException();


        /// <summary>
        /// Return all different clothes sizes
        /// </summary>
        /// <returns>List of sizes</returns>
        public IEnumerable AvailableClothesSizes() => throw new NotImplementedException();

        /// <summary>
        /// Return all the products with a quantity greater than 0 and not obsolete in case of a perishable, ordered by id
        /// </summary>
        /// <returns>A list of products</returns>
        public IEnumerable AvailableProducts() => throw new NotImplementedException();

        /// <summary>
        /// Return the total price for each product type
        /// </summary>
        /// <returns>
        /// [
        ///    {Type="Perishable", Sum=2678.23},
        ///    ...
        /// ]
        /// </returns>
        public IEnumerable Prices() => throw new NotImplementedException();


        /// <summary>
        /// Return the name and the quantity of each product id.
        /// </summary>
        /// <param name="productIds">String containing the product id's e.g.: "5,14,9,45,2,1".</param>
        /// <returns>An object list with quantity and name of each product ordered by name.</returns>
        public IEnumerable Quantity(string productIds) => throw new NotImplementedException();

        /// <summary>
        /// Return the price of the order.
        /// </summary>
        /// <param name="productIds">The array of product id's to order</param>
        /// <param name="quantities">The array of quantity to order</param>
        /// <returns>The price of the order</returns>
        public double Order(string productIds, string quantities) => throw new NotImplementedException();


        /// <summary>
        /// Retrieve the discount for each product id
        /// 15% if it's pink shoes of size 36
        /// 50% for a perishable that has expired
        /// 30% for woman clothes of type "Haute-couture"
        /// 20% for male clothes of size "2XL"
        /// 5% for the rest
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns>Array of {Id, Name, Discount}</returns>
        public IEnumerable Discount(string productIds) => throw new NotImplementedException();

    }
}