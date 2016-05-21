using iCheap.Models;
using System.Collections.Generic;
using System;
using System.Data;
using System.Linq;

namespace iCheap.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAllProducts();
        Products GetProductById(int ProductId);
        IEnumerable<Products> GetProductByProductFilter(Products condition);
        string InsertProduct(int userId, Products Product);
        string UpdateProduct(int userId, Products Product);
        string DeleteProduct(int userId, string ProductIds);
        string UpdateViewCount(int productId);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly string storedName = "sp_Products";

        public IEnumerable<Products> GetAllProducts()
        {
            var param = SQLHelper.GetBasicDynamicParamters(DBNull.Value, action: BaseConstants.GET_ALL_ITEMS);

            return SQLHelper.QuerySP<Products, Origins, Brands, Categories>(storedName, param, delegateFunc: MapHelper.MapProducts, splitOn: "OriginID,BrandID,CategoryID");
        }

        public Products GetProductById(int ProductId)
        {
            var param = SQLHelper.GetBasicDynamicParamters(ProductId, action: BaseConstants.GET_ITEM_BY_ID);
            param.Add("ProductID", ProductId, DbType.Int32);

            var Products = SQLHelper.QuerySP<Products, Origins, Brands, Categories>(storedName, param, delegateFunc: MapHelper.MapProducts, splitOn: "OriginID,BrandID,CategoryID");
            if (Products != null && Products.Any())
                return Products.Single();

            return null;
        }

        public IEnumerable<Products> GetProductByProductFilter(Products condition)
        {
            var param = SQLHelper.GetBasicDynamicParamters(condition, action: "GetProductByProductFilter");
            param.Add("CategoryId", condition.CategoryID, DbType.Int32);

            return SQLHelper.QuerySP<Products, Origins, Brands, Categories>(storedName, param, delegateFunc: MapHelper.MapProducts, splitOn: "OriginID,BrandID,CategoryID");
        }

        public string InsertProduct(int userId, Products product)
        {
            var param = SQLHelper.GetBasicDynamicParamters(product, userId, BaseConstants.INSERT_COMMAND); 
            param.Add("ProductCode", product.ProductCode, DbType.String);
            param.Add("VNName", product.VNName, DbType.String);
            param.Add("ENName", product.ENName, DbType.String);
            param.Add("VNRewriteUrl", product.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", product.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", product.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", product.ENNameSEO, DbType.String);
            param.Add("VNDescription", product.VNDescription, DbType.String);
            param.Add("ENDescription", product.ENDescription, DbType.String);
            param.Add("VNFullInformation", product.VNFullInformation, DbType.String);
            param.Add("ENFullInformation", product.ENFullInformation, DbType.String);
            param.Add("Available", product.Available, DbType.Boolean);
            param.Add("SoldQuantity", product.SoldQuantity, DbType.Int32);
            param.Add("InNew", product.InNew, DbType.Boolean);
            param.Add("InHot", product.InHot, DbType.Boolean);
            param.Add("InBestSale", product.InBestSale, DbType.Boolean);
            param.Add("InSaleOff", product.InSaleOff, DbType.Boolean);
            param.Add("Price", product.Price, DbType.Decimal);
            param.Add("OriginalPrice", product.OriginalPrice, DbType.Decimal);
            param.Add("MarketPrice", product.MarketPrice, DbType.Decimal);
            param.Add("InterestRate", product.InterestRate, DbType.Decimal);
            param.Add("DifferenceRate", product.DifferenceRate, DbType.Decimal);
            param.Add("InWarranty", product.InWarranty, DbType.Boolean);
            param.Add("Warranty", product.Warranty, DbType.Int32);
            param.Add("WarrantyType", product.WarrantyType, DbType.Int32);
            param.Add("OriginID", product.Origin == null ? null : product.Origin.OriginID, DbType.Int32);
            param.Add("BrandID", product.Brand == null ? null : product.Brand.BrandID, DbType.Int32);
            param.Add("CategoryID", product.Category == null ? null : product.Category.CategoryID, DbType.Int32);
            param.Add("DiscountQuantity", product.DiscountQuantity, DbType.Int32);
            param.Add("DiscountRate", product.DiscountRate, DbType.Decimal);
            param.Add("DiscountAmount", product.DiscountAmount, DbType.Decimal);
            param.Add("Rank", product.Rank, DbType.Int32);
            param.Add("Tag", product.Tag, DbType.String);
            param.Add("WebsiteDescription", product.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", product.Thumbnail, DbType.String);
            param.Add("Images", product.Images, DbType.String);
            param.Add("Videos", product.Videos, DbType.String);
            param.Add("Note", product.Note, DbType.String);
            param.Add("InActive", product.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string UpdateProduct(int userId, Products product)
        {
            var param = SQLHelper.GetBasicDynamicParamters(product, userId, BaseConstants.UPDATE_COMMAND);
            param.Add("ProductID", product.ProductID, DbType.Int32);
            param.Add("ProductCode", product.ProductCode, DbType.String);
            param.Add("VNName", product.VNName, DbType.String);
            param.Add("ENName", product.ENName, DbType.String);
            param.Add("VNRewriteUrl", product.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", product.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", product.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", product.ENNameSEO, DbType.String);
            param.Add("VNDescription", product.VNDescription, DbType.String);
            param.Add("ENDescription", product.ENDescription, DbType.String);
            param.Add("VNFullInformation", product.VNFullInformation, DbType.String);
            param.Add("ENFullInformation", product.ENFullInformation, DbType.String);
            param.Add("Available", product.Available, DbType.Boolean);
            param.Add("SoldQuantity", product.SoldQuantity, DbType.Int32);
            param.Add("InNew", product.InNew, DbType.Boolean);
            param.Add("InHot", product.InHot, DbType.Boolean);
            param.Add("InBestSale", product.InBestSale, DbType.Boolean);
            param.Add("InSaleOff", product.InSaleOff, DbType.Boolean);
            param.Add("Price", product.Price, DbType.Decimal);
            param.Add("OriginalPrice", product.OriginalPrice, DbType.Decimal);
            param.Add("MarketPrice", product.MarketPrice, DbType.Decimal);
            param.Add("InterestRate", product.InterestRate, DbType.Decimal);
            param.Add("DifferenceRate", product.DifferenceRate, DbType.Decimal);
            param.Add("InWarranty", product.InWarranty, DbType.Boolean);
            param.Add("Warranty", product.Warranty, DbType.Int32);
            param.Add("WarrantyType", product.WarrantyType, DbType.Int32);
            param.Add("OriginID", product.Origin == null ? null : product.Origin.OriginID, DbType.Int32);
            param.Add("BrandID", product.Brand == null ? null : product.Brand.BrandID, DbType.Int32);
            param.Add("CategoryID", product.Category == null ? null : product.Category.CategoryID, DbType.Int32);
            param.Add("DiscountQuantity", product.DiscountQuantity, DbType.Int32);
            param.Add("DiscountRate", product.DiscountRate, DbType.Decimal);
            param.Add("DiscountAmount", product.DiscountAmount, DbType.Decimal);
            param.Add("Rank", product.Rank, DbType.Int32);
            param.Add("Tag", product.Tag, DbType.String);
            param.Add("WebsiteDescription", product.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", product.Thumbnail, DbType.String);
            param.Add("Images", product.Images, DbType.String);
            param.Add("Videos", product.Videos, DbType.String);
            param.Add("Note", product.Note, DbType.String);
            param.Add("InActive", product.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string DeleteProduct(int userId, string ProductIds)
        {
            var isDeleteList = ProductIds.Contains("$");
            var param = SQLHelper.GetBasicDynamicParamters(ProductIds, userId, isDeleteList ? BaseConstants.DELETE_LIST_COMMAND : BaseConstants.DELETE_COMMAND);
            param.Add(isDeleteList ? "ProductIDs" : "ProductID", ProductIds, DbType.String);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string UpdateViewCount(int productId)
        {
            var param = SQLHelper.GetBasicDynamicParamters(productId, action: "UpdateViewCount");
            param.Add("ProductID", productId, DbType.Int32);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }
    }
}
