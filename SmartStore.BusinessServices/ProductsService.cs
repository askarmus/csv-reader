using Microsoft.EntityFrameworkCore;
using SmartStore.BusinessServices.ServiceMapper;
using SmartStore.DataAccess;
using SmartStore.DataAccess.Entity;
using SmartStore.Model;
using System.Linq;
using System.Threading.Tasks;

namespace SmartStore.Services
{
    public interface IProductsService
    {
        Task<QueryResult<ProductModel>> GetAllProductsAsync(Query query);
    }
    public class ProductsService: IProductsService
    {

        private FleetContext _context;
         
        public ProductsService(FleetContext context)
        {
            _context = context;
        }

        public async  Task<QueryResult<ProductModel>> GetAllProductsAsync(Query query)
        {
           var count = await _context.Products.CountAsync();
           var products = await _context.Products
                                    .Where(x => !x.IsDeleted && !x.Category.IsDeleted)
                                    .OrderBy(x => x.ID)
                                    .ToListAsync();
            var productModels = products.Select(s => ProductServiceMapper.ToModel(s)).ToList();

            return new QueryResult<ProductModel>
            {
                Success = true,
                Message = string.Empty,
                Data = productModels,
                Count = count
            };
        }

        //public List<Product> SearchFeaturedProducts(int? pageNo = 1, int? recordSize = 0, List<int> excludeProductIDs = null)
        //{
        //    excludeProductIDs = excludeProductIDs ?? new List<int>();

        //    var products = context.Products
        //                            .Where(x => !x.IsDeleted && !x.Category.IsDeleted && x.isFeatured && !excludeProductIDs.Contains(x.ID))
        //                            .OrderBy(x => x.ID)
        //                            .AsQueryable();

        //    if (recordSize.HasValue && recordSize.Value > 0)
        //    {
        //        pageNo = pageNo ?? 1;
        //        var skip = (pageNo.Value - 1) * recordSize.Value;

        //        products = products.Skip(skip)
        //                               .Take(recordSize.Value);
        //    }

        //    return products.ToList();
        //}

        //public List<Product> SearchProducts(List<int> categoryIDs, string searchTerm, decimal? from, decimal? to, string sortby, int? pageNo, int recordSize, out int count)
        //{
        //    var products = context.Products
        //                          .Where(x => !x.IsDeleted && !x.Category.IsDeleted)
        //                          .AsQueryable();

        //    if (!string.IsNullOrEmpty(searchTerm))
        //    {
        //        products = context.ProductRecords
        //                          .Where(x => !x.IsDeleted && x.Name.ToLower().Contains(searchTerm.ToLower()))
        //                          .Select(x => x.Product)
        //                          .AsQueryable();
        //    }

        //    if (categoryIDs != null && categoryIDs.Count > 0)
        //    {
        //        products = products.Where(x => categoryIDs.Contains(x.CategoryID));
        //    }

        //    if (from.HasValue && from.Value > 0.0M)
        //    {
        //        products = products.Where(x => x.Price >= from.Value);
        //    }

        //    if (to.HasValue && to.Value > 0.0M)
        //    {
        //        products = products.Where(x => x.Price <= to.Value);
        //    }

        //    if (!string.IsNullOrEmpty(sortby))
        //    {
        //        if(string.Equals(sortby, "price-high", StringComparison.OrdinalIgnoreCase))
        //        {
        //            products = products.OrderByDescending(x => x.Price);
        //        }
        //        else {
        //            products = products.OrderBy(x => x.Price);
        //        }
        //    }
        //    else //sortBy Product Date
        //    {
        //        products = products.OrderByDescending(x => x.ModifiedOn);
        //    }

        //    count = products.Count();

        //    pageNo = pageNo ?? 1;
        //    var skipCount = (pageNo.Value - 1) * recordSize;

        //    return products.Skip(skipCount).Take(recordSize).Include("Category.CategoryRecords").Include("ProductPictures.Picture").ToList();
        //}

        //public Product GetProductByID(int ID)
        //{
        //    var product = context.Products.Include("Category.CategoryRecords").Include("ProductPictures.Picture").FirstOrDefault(x=>x.ID == ID);

        //    return product != null && !product.IsDeleted && !product.Category.IsDeleted ? product : null;
        //}

        //public List<Product> GetProductsByIDs(List<int> IDs)
        //{
        //    return IDs.Select(id => context.Products.Find(id)).Where(x=>!x.IsDeleted && !x.Category.IsDeleted).OrderBy(x=>x.ID).ToList();
        //}

        //public ProductRecord GetProductRecordByID(int ID)
        //{
        //    var productRecord = context.ProductRecords.Find(ID);

        //    return productRecord != null && !productRecord.IsDeleted ? productRecord : null;
        //}

        //public decimal GetMaxProductPrice()
        //{
        //    var products = context.Products.Where(x => !x.IsDeleted && !x.Category.IsDeleted);

        //    return products.Count() > 0 ? products.Max(x => x.Price) : 0;
        //}

        //public bool SaveProduct(Product product)
        //{
        //    context.Products.Add(product);

        //    return context.SaveChanges() > 0;
        //}

        //public bool SaveProductRecord(ProductRecord productRecord)
        //{
        //    context.ProductRecords.Add(productRecord);

        //    return context.SaveChanges() > 0;
        //}

        //public bool UpdateProduct(Product product)
        //{
        //    var oldProductPictures = product.ProductPictures.Where(x => x.ID > 0).ToList();
        //    context.ProductPictures.RemoveRange(oldProductPictures);

        //    context.Entry(product).State = System.Data.Entity.EntityState.Modified;

        //    return context.SaveChanges() > 0;
        //}

        //public bool UpdateProductRecord(ProductRecord productRecord)
        //{
        //    var oldProductSpecification = productRecord.ProductSpecifications.Where(x => x.ID > 0).ToList();
        //    context.ProductSpecifications.RemoveRange(oldProductSpecification);

        //    context.Entry(productRecord).State = System.Data.Entity.EntityState.Modified;

        //    return context.SaveChanges() > 0;
        //}

        //public bool DeleteProduct(int ID)
        //{
        //    var product = context.Products.Find(ID);

        //    product.IsDeleted = true;

        //    context.Entry(product).State = System.Data.Entity.EntityState.Modified;

        //    return context.SaveChanges() > 0;
        //}
    }
}
