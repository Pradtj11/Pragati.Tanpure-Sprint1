using EcommerceWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        EcommerceDBContext db;
        public ProductController(EcommerceDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<TblProduct> GetProducts()
        {
            return db.TblProducts;
        }

        [HttpPost]
        public string Post([FromBody] TblProduct user)
        {
            TblProduct product = new TblProduct();
            product.Id = user.Id;
            product.ProductName = user.ProductName;
            product.ProductDescription = user.ProductDescription;
            product.CatId = user.CatId;
            product.ProductMrp = user.ProductMrp;
            product.ProductDiscount = user.ProductDiscount;
            product.ProductFinal = user.ProductFinal;
            product.ProductQuantity = user.ProductQuantity;
            db.TblProducts.Add(user);
            db.SaveChanges();
            return "success";
        }
    }
 }
    
