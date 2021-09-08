﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class ShoppingCart
    {
        public Guid ShoppingCartId { get; set; }
        public Guid BuyerId { get; set; }
        public decimal TotalCostAllProducts { get; set; }
        public List<Cartline> Cartlines { get; set; }

        public Cartline AddItem(Product product)
        {
            Cartline line = Cartlines.Where(x => x.Product.ProductId == product.ProductId).FirstOrDefault();
            if ( line == null)
            {
                line = new Cartline { Product = product, Quantity = 1, TotalCostProducts = product.Cost };
                return line;
            }
            else
                line.TotalCostProducts += product.Cost;
                line.Quantity += 1;
                return line;


        }
        public void RemoveLine(Product product)
        {
            Cartlines.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }
        public IEnumerable<Cartline> Lines
        {
            get { return Cartlines; }
        }

        public void ComputeTotalCostAllProducts()
        {
            decimal sum = 0;
            foreach(Cartline c in Cartlines)
            {
                sum += c.TotalCostProducts;
            }

            TotalCostAllProducts = sum;

        }


    }
    public class Cartline
    {
        public Guid CartLineId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public decimal TotalCostProducts { get; set; }

    }
}

