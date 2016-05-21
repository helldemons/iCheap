using iCheap.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace iCheap.Repositories
{
    public interface IBlogCategoryRepository
    {
        IEnumerable<BlogCategories> GetAllBlogCategories();
        BlogCategories GetBlogCategoryById(int blogCategoryId);
        string InsertBlogCategory(int userId, BlogCategories blogCategory);
        string UpdateBlogCategory(int userId, BlogCategories blogCategory);
        string DeleteBlogCategory(int userId, string blogCategoryIds);
    }

    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        private readonly string storedName = "sp_BlogCategories";

        public IEnumerable<BlogCategories> GetAllBlogCategories()
        {
            var param = SQLHelper.GetBasicDynamicParamters(DBNull.Value, action: BaseConstants.GET_ALL_ITEMS);

            return SQLHelper.QuerySP<BlogCategories, BlogCategories>(storedName, param, delegateFunc: MapHelper.MapBlogCategory, splitOn: "BlogCategoryID");
        }

        public BlogCategories GetBlogCategoryById(int blogCategoryId)
        {
            var param = SQLHelper.GetBasicDynamicParamters(blogCategoryId, action: BaseConstants.GET_ITEM_BY_ID);
            param.Add("BlogCategoryID", blogCategoryId, DbType.Int32);

            var BlogCategorys = SQLHelper.QuerySP<BlogCategories, BlogCategories>(storedName, param, delegateFunc: MapHelper.MapBlogCategory, splitOn: "BlogCategoryID");
            if (BlogCategorys != null && BlogCategorys.Any())
                return BlogCategorys.Single();

            return null;
        }

        public string InsertBlogCategory(int userId, BlogCategories blogCategory)
        {
            var param = SQLHelper.GetBasicDynamicParamters(blogCategory, userId, BaseConstants.INSERT_COMMAND);
            param.Add("BlogCategoryCode", blogCategory.BlogCategoryCode, DbType.String);
            param.Add("VNName", blogCategory.VNName, DbType.String);
            param.Add("ENName", blogCategory.ENName, DbType.String);
            param.Add("VNRewriteUrl", blogCategory.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", blogCategory.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", blogCategory.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", blogCategory.ENNameSEO, DbType.String);
            param.Add("VNDescription", blogCategory.VNDescription, DbType.String);
            param.Add("ENDescription", blogCategory.ENDescription, DbType.String);
            param.Add("ParentID", blogCategory.ParentID, DbType.Int32);
            param.Add("Level", blogCategory.Level, DbType.Int32);
            param.Add("InSystem", blogCategory.InSystem, DbType.Boolean);
            param.Add("InDefault", blogCategory.InDefault, DbType.Boolean);
            param.Add("Rank", blogCategory.Rank, DbType.Int32);
            param.Add("Tag", blogCategory.Tag, DbType.String);
            param.Add("WebsiteDescription", blogCategory.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", blogCategory.Thumbnail, DbType.String);
            param.Add("Note", blogCategory.Note, DbType.String);
            param.Add("InActive", blogCategory.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string UpdateBlogCategory(int userId, BlogCategories blogCategory)
        {
            var param = SQLHelper.GetBasicDynamicParamters(blogCategory, userId, BaseConstants.UPDATE_COMMAND);
            param.Add("BlogCategoryID", blogCategory.BlogCategoryID, DbType.Int32);
            param.Add("BlogCategoryCode", blogCategory.BlogCategoryCode, DbType.String);
            param.Add("VNName", blogCategory.VNName, DbType.String);
            param.Add("ENName", blogCategory.ENName, DbType.String);
            param.Add("VNRewriteUrl", blogCategory.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", blogCategory.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", blogCategory.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", blogCategory.ENNameSEO, DbType.String);
            param.Add("VNDescription", blogCategory.VNDescription, DbType.String);
            param.Add("ENDescription", blogCategory.ENDescription, DbType.String);
            param.Add("ParentID", blogCategory.ParentID, DbType.Int32);
            param.Add("Level", blogCategory.Level, DbType.Int32);
            param.Add("InSystem", blogCategory.InSystem, DbType.Boolean);
            param.Add("InDefault", blogCategory.InDefault, DbType.Boolean);
            param.Add("Rank", blogCategory.Rank, DbType.Int32);
            param.Add("Tag", blogCategory.Tag, DbType.String);
            param.Add("WebsiteDescription", blogCategory.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", blogCategory.Thumbnail, DbType.String);
            param.Add("Note", blogCategory.Note, DbType.String);
            param.Add("InActive", blogCategory.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string DeleteBlogCategory(int userId, string blogCategoryIds)
        {
            var isDeleteList = blogCategoryIds.Contains("$");
            var param = SQLHelper.GetBasicDynamicParamters(blogCategoryIds, userId, isDeleteList ? BaseConstants.DELETE_LIST_COMMAND : BaseConstants.DELETE_COMMAND);
            param.Add(isDeleteList ? "BlogCategoryIDs" : "BlogCategoryID", blogCategoryIds, DbType.String);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }
    }
}
