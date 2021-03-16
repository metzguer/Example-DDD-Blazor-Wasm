using Domain.Entities;
using Domain.Interfaces.Products;
using Infraestructure.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Entity.Products
{
    public class ProductsRepository : RepositoryGeneric<Product>, IProductDomain
    {
    }
}
