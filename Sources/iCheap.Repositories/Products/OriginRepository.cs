using iCheap.Models;
using System.Collections.Generic;
using System;
using System.Data;
using System.Linq;

namespace iCheap.Repositories
{
    public interface IOriginRepository
    {
        IEnumerable<Origins> GetAllOrigins();
        Origins GetOriginById(int originId);
        string InsertOrigin(int userId, Origins origin);
        string UpdateOrigin(int userId, Origins origin);
        string DeleteOrigin(int userId, string originIds);
    }

    public class OriginRepository : IOriginRepository
    {
        private readonly string storedName = "sp_Origins";

        public IEnumerable<Origins> GetAllOrigins()
        {
            var param = SQLHelper.GetBasicDynamicParamters(DBNull.Value, action: BaseConstants.GET_ALL_ITEMS);

            return SQLHelper.QuerySP<Origins>(storedName, param);
        }

        public Origins GetOriginById(int originId)
        {
            var param = SQLHelper.GetBasicDynamicParamters(originId, action: BaseConstants.GET_ITEM_BY_ID);
            param.Add("OriginID", originId, DbType.Int32);

            var origins = SQLHelper.QuerySP<Origins>(storedName, param);
            if (origins != null && origins.Any())
                return origins.Single();

            return null;
        }

        public string InsertOrigin(int userId, Origins origin)
        {
            var param = SQLHelper.GetBasicDynamicParamters(origin, userId, BaseConstants.INSERT_COMMAND);
            param.Add("OriginCode", origin.OriginCode, DbType.String);
            param.Add("VNName", origin.VNName, DbType.String);
            param.Add("ENName", origin.ENName, DbType.String);
            param.Add("VNRewriteUrl", origin.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", origin.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", origin.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", origin.ENNameSEO, DbType.String);
            param.Add("VNDescription", origin.VNDescription, DbType.String);
            param.Add("ENDescription", origin.ENDescription, DbType.String);
            param.Add("Rank", origin.Rank, DbType.Int32);
            param.Add("Tag", origin.Tag, DbType.String);
            param.Add("WebsiteDescription", origin.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", origin.Thumbnail, DbType.String);
            param.Add("Note", origin.Note, DbType.String);
            param.Add("InActive", origin.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string UpdateOrigin(int userId, Origins origin)
        {
            var param = SQLHelper.GetBasicDynamicParamters(origin, userId, BaseConstants.UPDATE_COMMAND);
            param.Add("OriginID", origin.OriginID, DbType.Int32);
            param.Add("OriginCode", origin.OriginCode, DbType.String);
            param.Add("VNName", origin.VNName, DbType.String);
            param.Add("ENName", origin.ENName, DbType.String);
            param.Add("VNRewriteUrl", origin.VNRewriteUrl, DbType.String);
            param.Add("ENRewriteUrl", origin.ENRewriteUrl, DbType.String);
            param.Add("VNNameSEO", origin.VNNameSEO, DbType.String);
            param.Add("ENNameSEO", origin.ENNameSEO, DbType.String);
            param.Add("VNDescription", origin.VNDescription, DbType.String);
            param.Add("ENDescription", origin.ENDescription, DbType.String);
            param.Add("Rank", origin.Rank, DbType.Int32);
            param.Add("Tag", origin.Tag, DbType.String);
            param.Add("WebsiteDescription", origin.WebsiteDescription, DbType.String);
            param.Add("Thumbnail", origin.Thumbnail, DbType.String);
            param.Add("Note", origin.Note, DbType.String);
            param.Add("InActive", origin.InActive, DbType.Boolean);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }

        public string DeleteOrigin(int userId, string originIds)
        {
            var isDeleteList = originIds.Contains("$");
            var param = SQLHelper.GetBasicDynamicParamters(originIds, userId, isDeleteList ? BaseConstants.DELETE_LIST_COMMAND : BaseConstants.DELETE_COMMAND);
            param.Add(isDeleteList ? "OriginIDs" : "OriginID", originIds, DbType.String);

            var outParam = SQLHelper.CreateOutParams();
            int result = SQLHelper.ExecuteSP(storedName, param, outParam);

            if (result != BaseConstants.EXCEPTION_NUMBER)
                return outParam.Get<string>(BaseConstants.RETURN_MESS_SQL);

            return null;
        }
    }
}
