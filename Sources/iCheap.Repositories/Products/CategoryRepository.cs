using iCheap.Models;
using System.Collections.Generic;
using System;
using System.Data;
using System.Linq;

namespace iCheap.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Categories> GetAllCategories();
        Categories GetCategoryById(int categoryId);
        string InsertCategory(int userId, Categories category);
        string UpdateCategory(int userId, Categories category);
        string DeleteCategory(int userId, string categoryIds);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly string storedName = "sp_Categorys";

        public IEnumerable<Categories> GetAllCategories()
        {
            var param = SQLHelper.GetBasicDynamicParamters(DBNull.Value, action: BaseConstants.GET_ALL_ITEMS);

            return SQLHelper.QuerySP<Categories>(storedName, param);
        }

        public Categories GetCategoryById(int categoryId)
        {
            var param = SQLHelper.GetBasicDynamicParamters(categoryId, action: BaseConstants.GET_ITEM_BY_ID);
            param.Add("CategoryID", categoryId, DbType.Int32);

            var Categorys = SQLHelper.QuerySP<Categories>(storedName, param);
            if (Categorys != null && Categorys.Any())
                return Categorys.Single();

            return null;
        }

        public string InsertCategory(int userId, Categories category)
        {
            var param = SQLHelper.GetBasicDynamicParamters(category, userId, BaseConstants.INSERT_COMMAND);
            param.Add("CategoryCode", category.CategoryCode, DbType.String);
            param.Add("VNName", category.VNName, DbType.String);
            param.Add("ENName", category.ENName, DbType.String);
            param.Add("VNRewriteUrl", category.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", category.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", category.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", category.ENNameSEO, DbType.String);
            param.Add("VNDescription", category.VNDescription, DbType.String);
            param.Add("ENDescription", category.ENDescription, DbType.String);
            param.Add("ParentID", category.ParentID, DbType.Int32);
            param.Add("Level", category.Level, DbType.Int32);
            param.Add("Rank", category.Rank, DbType.Int32);
            param.Add("Tag", category.Tag, DbType.String);
            param.Add("WebsiteDescription", category.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", category.Thumbnail, DbType.String);
            param.Add("Note", category.Note, DbType.String);
            param.Add("InActive", category.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string UpdateCategory(int userId, Categories category)
        {
            var param = SQLHelper.GetBasicDynamicParamters(category, userId, BaseConstants.UPDATE_COMMAND);
            param.Add("CategoryID", category.CategoryID, DbType.Int32);
            param.Add("CategoryCode", category.CategoryCode, DbType.String);
            param.Add("VNName", category.VNName, DbType.String);
            param.Add("ENName", category.ENName, DbType.String);
            param.Add("VNRewriteUrl", category.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", category.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", category.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", category.ENNameSEO, DbType.String);
            param.Add("VNDescription", category.VNDescription, DbType.String);
            param.Add("ENDescription", category.ENDescription, DbType.String);
            param.Add("ParentID", category.ParentID, DbType.Int32);
            param.Add("Level", category.Level, DbType.Int32);
            param.Add("Rank", category.Rank, DbType.Int32);
            param.Add("Tag", category.Tag, DbType.String);
            param.Add("WebsiteDescription", category.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", category.Thumbnail, DbType.String);
            param.Add("Note", category.Note, DbType.String);
            param.Add("InActive", category.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string DeleteCategory(int userId, string categoryIds)
        {
            var isDeleteList = categoryIds.Contains("$");
            var param = SQLHelper.GetBasicDynamicParamters(categoryIds, userId, isDeleteList ? BaseConstants.DELETE_LIST_COMMAND : BaseConstants.DELETE_COMMAND);
            param.Add(isDeleteList ? "CategoryIDs" : "CategoryID", categoryIds, DbType.String);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }
    }
}
