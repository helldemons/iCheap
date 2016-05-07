using iCheap.Models;
using System.Collections.Generic;
using System;
using System.Data;
using System.Linq;

namespace iCheap.Repositories
{
    public interface IBrandRepository
    {
        IEnumerable<Brands> GetAllBrands();
        Brands GetBrandById(int brandId);
        string InsertBrand(int userId, Brands brand);
        string UpdateBrand(int userId, Brands brand);
        string DeleteBrand(int userId, string brandIds);
    }

    public class BrandRepository : IBrandRepository
    {
        private readonly string storedName = "sp_Brands";

        public IEnumerable<Brands> GetAllBrands()
        {
            var param = SQLHelper.GetBasicDynamicParamters(DBNull.Value, action: BaseConstants.GET_ALL_ITEMS);

            return SQLHelper.QuerySP<Brands>(storedName, param);
        }

        public Brands GetBrandById(int brandId)
        {
            var param = SQLHelper.GetBasicDynamicParamters(brandId, action: BaseConstants.GET_ITEM_BY_ID);
            param.Add("BrandID", brandId, DbType.Int32);

            var Brands = SQLHelper.QuerySP<Brands>(storedName, param);
            if (Brands != null && Brands.Any())
                return Brands.Single();

            return null;
        }

        public string InsertBrand(int userId, Brands brand)
        {
            var param = SQLHelper.GetBasicDynamicParamters(brand, userId, BaseConstants.INSERT_COMMAND);
            param.Add("BrandCode", brand.BrandCode, DbType.String);
            param.Add("VNName", brand.VNName, DbType.String);
            param.Add("ENName", brand.ENName, DbType.String);
            param.Add("VNRewriteUrl", brand.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", brand.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", brand.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", brand.ENNameSEO, DbType.String);
            param.Add("VNDescription", brand.VNDescription, DbType.String);
            param.Add("ENDescription", brand.ENDescription, DbType.String);
            param.Add("Rank", brand.Rank, DbType.Int32);
            param.Add("Tag", brand.Tag, DbType.String);
            param.Add("WebsiteDescription", brand.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", brand.Thumbnail, DbType.String);
            param.Add("Note", brand.Note, DbType.String);
            param.Add("InActive", brand.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string UpdateBrand(int userId, Brands brand)
        {
            var param = SQLHelper.GetBasicDynamicParamters(brand, userId, BaseConstants.UPDATE_COMMAND);
            param.Add("BrandID", brand.BrandID, DbType.Int32);
            param.Add("BrandCode", brand.BrandCode, DbType.String);
            param.Add("VNName", brand.VNName, DbType.String);
            param.Add("ENName", brand.ENName, DbType.String);
            param.Add("VNRewriteUrl", brand.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", brand.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", brand.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", brand.ENNameSEO, DbType.String);
            param.Add("VNDescription", brand.VNDescription, DbType.String);
            param.Add("ENDescription", brand.ENDescription, DbType.String);
            param.Add("Rank", brand.Rank, DbType.Int32);
            param.Add("Tag", brand.Tag, DbType.String);
            param.Add("WebsiteDescription", brand.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", brand.Thumbnail, DbType.String);
            param.Add("Note", brand.Note, DbType.String);
            param.Add("InActive", brand.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string DeleteBrand(int userId, string brandIds)
        {
            var isDeleteList = brandIds.Contains("$");
            var param = SQLHelper.GetBasicDynamicParamters(brandIds, userId, isDeleteList ? BaseConstants.DELETE_LIST_COMMAND : BaseConstants.DELETE_COMMAND);
            param.Add(isDeleteList ? "BrandIDs" : "BrandID", brandIds, DbType.String);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }
    }
}
