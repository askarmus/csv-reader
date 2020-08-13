using SmartStore.DataAccess.Entity;
using SmartStore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartStore.BusinessServices.ServiceMapper
{
   public static class ProductServiceMapper
    {
        public static ProductModel ToModel(Product product)
        {
            var model = new ProductModel();

            model.CategoryID = product.CategoryID;
            model.Barcode = product.Barcode;
            model.Cost = product.Cost;
            model.Discount = product.Discount;
            model.isFeatured = product.isFeatured;
            model.Price = product.Price;
            model.SKU = product.SKU;
            model.Supplier = product.Supplier;
            model.Tags = product.Tags;
            model.ThumbnailPictureID = product.ThumbnailPictureID;

            return model;
        }
    }
}
