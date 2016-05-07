using iCheap.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace iCheap.Repositories
{
    public interface IBlogRepository
    {
        IEnumerable<Blogs> GetAllBlogs { get; }

        Blogs GetBlogById(int BlogId);
        string InsertBlog(int userId, Blogs Blog);
        string UpdateBlog(int userId, Blogs Blog);
        string DeleteBlog(int userId, string BlogIds);
    }

    public class BlogRepository : IBlogRepository
    {
        private readonly string storedName = "sp_Blogs";

        public IEnumerable<Blogs> GetAllBlogs
        {
            get
            {
                var param = SQLHelper.GetBasicDynamicParamters(DBNull.Value, action: BaseConstants.GET_ALL_ITEMS);

                return SQLHelper.QuerySP<Blogs>(storedName, param);
            }
        }

        public Blogs GetBlogById(int BlogId)
        {
            var param = SQLHelper.GetBasicDynamicParamters(BlogId, action: BaseConstants.GET_ITEM_BY_ID);
            param.Add("BlogID", BlogId, DbType.Int32);

            var Blogs = SQLHelper.QuerySP<Blogs>(storedName, param);
            if (Blogs != null && Blogs.Any())
                return Blogs.Single();

            return null;
        }

        public string InsertBlog(int userId, Blogs blog)
        {
            var param = SQLHelper.GetBasicDynamicParamters(blog, userId, BaseConstants.INSERT_COMMAND);
            param.Add("BlogCode", blog.BlogCode, DbType.String);
            param.Add("VNName", blog.VNName, DbType.String);
            param.Add("ENName", blog.ENName, DbType.String);
            param.Add("VNRewriteUrl", blog.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", blog.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", blog.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", blog.ENNameSEO, DbType.String);
            param.Add("VNDescription", blog.VNDescription, DbType.String);
            param.Add("ENDescription", blog.ENDescription, DbType.String);
            param.Add("BlogCategoryID", blog.BlogCategoryID, DbType.Int32);
            param.Add("ViewCount", blog.ViewCount, DbType.Int32);
            param.Add("VoteCount", blog.VoteCount, DbType.Int32);
            param.Add("VoteRatio", blog.VoteRatio, DbType.Decimal);
            param.Add("LikeCount", blog.LikeCount, DbType.Int32);
            param.Add("VNContent", blog.VNContent, DbType.String);
            param.Add("ENContent", blog.ENContent, DbType.String);
            param.Add("Level", blog.Level, DbType.Int32);
            param.Add("Rank", blog.Rank, DbType.Int32);
            param.Add("Tag", blog.Tag, DbType.String);
            param.Add("WebsiteDescription", blog.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", blog.Thumbnail, DbType.String);
            param.Add("Note", blog.Note, DbType.String);
            param.Add("InActive", blog.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string UpdateBlog(int userId, Blogs blog)
        {
            var param = SQLHelper.GetBasicDynamicParamters(blog, userId, BaseConstants.UPDATE_COMMAND);
            param.Add("BlogID", blog.BlogID, DbType.Int32);
            param.Add("BlogCode", blog.BlogCode, DbType.String);
            param.Add("VNName", blog.VNName, DbType.String);
            param.Add("ENName", blog.ENName, DbType.String);
            param.Add("VNRewriteUrl", blog.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", blog.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", blog.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", blog.ENNameSEO, DbType.String);
            param.Add("VNDescription", blog.VNDescription, DbType.String);
            param.Add("ENDescription", blog.ENDescription, DbType.String);
            param.Add("BlogCategoryID", blog.BlogCategoryID, DbType.Int32);
            param.Add("ViewCount", blog.ViewCount, DbType.Int32);
            param.Add("VoteCount", blog.VoteCount, DbType.Int32);
            param.Add("VoteRatio", blog.VoteRatio, DbType.Decimal);
            param.Add("LikeCount", blog.LikeCount, DbType.Int32);
            param.Add("VNContent", blog.VNContent, DbType.String);
            param.Add("ENContent", blog.ENContent, DbType.String);
            param.Add("Level", blog.Level, DbType.Int32);
            param.Add("Rank", blog.Rank, DbType.Int32);
            param.Add("Tag", blog.Tag, DbType.String);
            param.Add("WebsiteDescription", blog.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", blog.Thumbnail, DbType.String);
            param.Add("Note", blog.Note, DbType.String);
            param.Add("InActive", blog.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string DeleteBlog(int userId, string blogIds)
        {
            var isDeleteList = blogIds.Contains("$");
            var param = SQLHelper.GetBasicDynamicParamters(blogIds, userId, isDeleteList ? BaseConstants.DELETE_LIST_COMMAND : BaseConstants.DELETE_COMMAND);
            param.Add(isDeleteList ? "BlogIDs" : "BlogID", blogIds, DbType.String);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }
    }
}
