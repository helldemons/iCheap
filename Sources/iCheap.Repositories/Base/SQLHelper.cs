using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Linq;
using System.Configuration;

namespace iCheap.Repositories
{
    public static class SQLHelper
    {
        #region Query
        public static IEnumerable<dynamic> QuerySP(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();
                    return connection.Query(storedProcedure, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<dynamic> QuerySQL(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();
                    return connection.Query(sqlQuery, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySP<T>(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();
                    return connection.Query<T>(storedProcedure, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySQL<T, T1>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null,
            string splitOn = null,
            Func<T, T1, T> delegateFunc = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(sqlQuery, delegateFunc, splitOn: splitOn, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySP<T, T1>(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null,
            string splitOn = null,
            Func<T, T1, T> delegateFunc = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(storedProcedure, delegateFunc, splitOn: splitOn, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySQL<T, T1, T2>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null,
            string splitOn = null,
            Func<T, T1, T2, T> delegateFunc = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(sqlQuery, delegateFunc, splitOn: splitOn, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySP<T, T1, T2>(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null,
            string splitOn = null,
            Func<T, T1, T2, T> delegateFunc = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(storedProcedure, delegateFunc, splitOn: splitOn, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySQL<T, T1, T2, T3>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null,
            string splitOn = null,
            Func<T, T1, T2, T3, T> delegateFunc = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(sqlQuery, delegateFunc, splitOn: splitOn, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySQL<T, T1, T2, T3, T4>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null,
            string splitOn = null,
            Func<T, T1, T2, T3, T4, T> delegateFunc = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(sqlQuery, delegateFunc, splitOn: splitOn, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySQL<T, T1, T2, T3, T4, T5>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null,
            string splitOn = null,
            Func<T, T1, T2, T3, T4, T5, T> delegateFunc = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(sqlQuery, delegateFunc, splitOn: splitOn, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySQL<T, T1, T2, T3, T4, T5, T6>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null,
            string splitOn = null,
            Func<T, T1, T2, T3, T4, T5, T6, T> delegateFunc = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(sqlQuery, delegateFunc, splitOn: splitOn, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySQL<T1, T2, T3, T4, T5, T6, T7, T>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null,
            string splitOn = null,
            Func<T1, T2, T3, T4, T5, T6, T7, T> delegateFunc = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(sqlQuery, delegateFunc, splitOn: splitOn, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySP<T, T1, T2, T3>(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null,
            string splitOn = null,
            Func<T, T1, T2, T3, T> delegateFunc = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(storedProcedure, delegateFunc, splitOn: splitOn, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<T> QuerySQL<T>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();
                    return connection.Query<T>(sqlQuery, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<object> QuerySP(
            Type type,
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(type, storedProcedure, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static IEnumerable<object> QuerySQL(
            Type type,
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);
            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Query(type, sqlQuery, param: (object)param, transaction: transaction, buffered: buffered, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #region QueryMultiple

        #region IEnumerable<IEnumerable<dynamic>>
        public static IEnumerable<IEnumerable<dynamic>> QueryMultipleSP(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            return QueryMultiple(storedProcedure, param, outParam, transaction, commandTimeout, CommandType.StoredProcedure, connectionString);
        }

        public static IEnumerable<IEnumerable<dynamic>> QueryMultipleSQL(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            return QueryMultiple(sqlQuery, param, outParam, transaction, commandTimeout, CommandType.Text, connectionString);
        }

        public static IEnumerable<IEnumerable<dynamic>> QueryMultiple(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    Dapper.SqlMapper.GridReader gr = connection.QueryMultiple(sqlQuery, param: (object)param, transaction: transaction, commandTimeout: GetTimeout(commandTimeout), commandType: commandType);
                    List<IEnumerable<dynamic>> lists = new List<IEnumerable<dynamic>>();
                    while (!gr.IsConsumed)
                        lists.Add(gr.Read());

                    return lists;
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #region IEnumerable<IEnumerable<T>>
        public static IEnumerable<IEnumerable<T>> QueryMultipleSP<T>(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            return QueryMultiple<T>(storedProcedure, param, outParam, transaction, commandTimeout, CommandType.StoredProcedure, connectionString);
        }

        public static IEnumerable<IEnumerable<T>> QueryMultipleSQL<T>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            return QueryMultiple<T>(sqlQuery, param, outParam, transaction, commandTimeout, CommandType.Text, connectionString);
        }

        public static IEnumerable<IEnumerable<T>> QueryMultiple<T>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    SqlMapper.GridReader gr = connection.QueryMultiple(sqlQuery, param: (object)param, transaction: transaction, commandTimeout: GetTimeout(commandTimeout), commandType: commandType);
                    List<IEnumerable<T>> lists = new List<IEnumerable<T>>();
                    while (!gr.IsConsumed)
                        lists.Add(gr.Read<T>());

                    return lists;
                }
                catch
                {

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #region Tuples
        public static Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultipleSP<T1, T2>(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            IEnumerable[] lists = QueryMultiple<T1, T2, object, object, object, object, object, object, object, object, object, object, object, object>(2, storedProcedure, param, outParam, transaction, commandTimeout, CommandType.StoredProcedure, connectionString);

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(
                (IEnumerable<T1>)lists[0],
                (IEnumerable<T2>)lists[1]
            );
        }

        public static Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultipleSQL<T1, T2>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            IEnumerable[] lists = QueryMultiple<T1, T2, object, object, object, object, object, object, object, object, object, object, object, object>(2, sqlQuery, param, outParam, transaction, commandTimeout, CommandType.Text, connectionString);

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(
                (IEnumerable<T1>)lists[0],
                (IEnumerable<T2>)lists[1]
            );
        }

        public static Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultipleSP<T1, T2, T3>(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            IEnumerable[] lists = QueryMultiple<T1, T2, T3, object, object, object, object, object, object, object, object, object, object, object>(3, storedProcedure, param, outParam, transaction, commandTimeout, CommandType.StoredProcedure, connectionString);

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(
                (IEnumerable<T1>)lists[0],
                (IEnumerable<T2>)lists[1],
                (IEnumerable<T3>)lists[2]
            );
        }

        public static Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultipleSQL<T1, T2, T3>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            IEnumerable[] lists = QueryMultiple<T1, T2, T3, object, object, object, object, object, object, object, object, object, object, object>(3, sqlQuery, param, outParam, transaction, commandTimeout, CommandType.Text, connectionString);

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(
                (IEnumerable<T1>)lists[0],
                (IEnumerable<T2>)lists[1],
                (IEnumerable<T3>)lists[2]
            );
        }

        public static Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> QueryMultipleSP<T1, T2, T3, T4>(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            IEnumerable[] lists = QueryMultiple<T1, T2, T3, T4, object, object, object, object, object, object, object, object, object, object>(4, storedProcedure, param, outParam, transaction, commandTimeout, CommandType.StoredProcedure, connectionString);

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>(
                (IEnumerable<T1>)lists[0],
                (IEnumerable<T2>)lists[1],
                (IEnumerable<T3>)lists[2],
                (IEnumerable<T4>)lists[3]
            );
        }

        public static Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> QueryMultipleSQL<T1, T2, T3, T4>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            IEnumerable[] lists = QueryMultiple<T1, T2, T3, T4, object, object, object, object, object, object, object, object, object, object>(4, sqlQuery, param, outParam, transaction, commandTimeout, CommandType.Text, connectionString);

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>(
                (IEnumerable<T1>)lists[0],
                (IEnumerable<T2>)lists[1],
                (IEnumerable<T3>)lists[2],
                (IEnumerable<T4>)lists[3]
            );
        }

        public static Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> QueryMultipleSP<T1, T2, T3, T4, T5>(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            IEnumerable[] lists = QueryMultiple<T1, T2, T3, T4, T5, object, object, object, object, object, object, object, object, object>(5, storedProcedure, param, outParam, transaction, commandTimeout, CommandType.StoredProcedure, connectionString);

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>(
                (IEnumerable<T1>)lists[0],
                (IEnumerable<T2>)lists[1],
                (IEnumerable<T3>)lists[2],
                (IEnumerable<T4>)lists[3],
                (IEnumerable<T5>)lists[4]
            );
        }

        public static Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> QueryMultipleSQL<T1, T2, T3, T4, T5>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            IEnumerable[] lists = QueryMultiple<T1, T2, T3, T4, T5, object, object, object, object, object, object, object, object, object>(5, sqlQuery, param, outParam, transaction, commandTimeout, CommandType.Text, connectionString);

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>(
                (IEnumerable<T1>)lists[0],
                (IEnumerable<T2>)lists[1],
                (IEnumerable<T3>)lists[2],
                (IEnumerable<T4>)lists[3],
                (IEnumerable<T5>)lists[4]
            );
        }

        private static IEnumerable[] QueryMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            int readCount,
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    SqlMapper.GridReader gr = connection.QueryMultiple(sqlQuery, param: (object)param, transaction: transaction, commandTimeout: GetTimeout(commandTimeout), commandType: commandType);
                    IEnumerable[] lists = new IEnumerable[readCount];
                    if (readCount >= 1 && !gr.IsConsumed)
                    {
                        lists[0] = gr.Read<T1>();
                        if (readCount >= 2 && !gr.IsConsumed)
                        {
                            lists[1] = gr.Read<T2>();
                            if (readCount >= 3 && !gr.IsConsumed)
                            {
                                lists[2] = gr.Read<T3>();
                                if (readCount >= 4 && !gr.IsConsumed)
                                {
                                    lists[3] = gr.Read<T4>();
                                    if (readCount >= 5 && !gr.IsConsumed)
                                    {
                                        lists[4] = gr.Read<T5>();
                                        if (readCount >= 6 && !gr.IsConsumed)
                                        {
                                            lists[5] = gr.Read<T6>();
                                            if (readCount >= 7 & !gr.IsConsumed)
                                            {
                                                lists[6] = gr.Read<T7>();
                                                if (readCount >= 8 && !gr.IsConsumed)
                                                {
                                                    lists[7] = gr.Read<T8>();
                                                    if (readCount >= 9 && !gr.IsConsumed)
                                                    {
                                                        lists[8] = gr.Read<T9>();
                                                        if (readCount >= 10 && !gr.IsConsumed)
                                                        {
                                                            lists[9] = gr.Read<T10>();
                                                            if (readCount >= 11 && !gr.IsConsumed)
                                                            {
                                                                lists[10] = gr.Read<T11>();
                                                                if (readCount >= 12 && !gr.IsConsumed)
                                                                {
                                                                    lists[11] = gr.Read<T12>();
                                                                    if (readCount >= 13 && !gr.IsConsumed)
                                                                    {
                                                                        lists[12] = gr.Read<T13>();
                                                                        if (readCount >= 14 && !gr.IsConsumed)
                                                                            lists[13] = gr.Read<T14>();
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    return lists;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #endregion

        #region ExecuteScalar
        public static object ExecuteScalarSP(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.ExecuteScalar(storedProcedure, param: (object)param, transaction: transaction, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static object ExecuteScalarSQL(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.ExecuteScalar(sqlQuery, param: (object)param, transaction: transaction, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static T ExecuteScalarSP<T>(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.ExecuteScalar<T>(storedProcedure, param: (object)param, transaction: transaction, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    return (T)Convert.ChangeType(null, typeof(T));
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static T ExecuteScalarSQL<T>(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.ExecuteScalar<T>(sqlQuery, param: (object)param, transaction: transaction, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {
                    return (T)Convert.ChangeType(null, typeof(T));
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #region Execute
        public static int ExecuteSP(
            string storedProcedure,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Execute(storedProcedure, param: (object)param, transaction: transaction, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.StoredProcedure);
                }
                catch
                {

                    return 0;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static int ExecuteSQL(
            string sqlQuery,
            dynamic param = null,
            dynamic outParam = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            string connectionString = null)
        {
            CombineParameters(ref param, outParam);

            using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionString)))
            {
                try
                {
                    connection.Open();

                    return connection.Execute(sqlQuery, param: (object)param, transaction: transaction, commandTimeout: GetTimeout(commandTimeout), commandType: CommandType.Text);
                }
                catch
                {
                    return BaseConstants.EXCEPTION_NUMBER;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #region CombineParameters
        private static void CombineParameters(ref dynamic param, dynamic outParam = null)
        {
            if (outParam != null)
            {
                if (param != null)
                {
                    param = new DynamicParameters(param);
                    ((DynamicParameters)param).AddDynamicParams(outParam);
                }
                else param = outParam;
            }
        }
        #endregion

        #region Connection String & Timeout
        public static string GetConnectionString(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
                return ConfigurationManager.ConnectionStrings["iCheap"].ConnectionString;

            return connectionString;
        }

        public static int ConnectionTimeout { get; set; }

        public static int GetTimeout(int? commandTimeout = null)
        {
            if (commandTimeout.HasValue)
                return commandTimeout.Value;

            return ConnectionTimeout;
        }
        #endregion

        #region ToDataTable
        public static DataTable ToDataTable(
            this Type type,
            string typeName = null,
            MemberTypes memberTypes = MemberTypes.Field | MemberTypes.Property)
        {
            return ToDataTable(null, type, typeName, memberTypes, null);
        }

        public static DataTable ToDataTable<T>(
            this IEnumerable<T> instances,
            string typeName = null,
            MemberTypes memberTypes = MemberTypes.Field | MemberTypes.Property,
            DataTable table = null)
        {
            return ToDataTable(instances, typeof(T), typeName, memberTypes, table);
        }

        private static DataTable ToDataTable(
            IEnumerable instances,
            Type type,
            string typeName,
            MemberTypes memberTypes,
            DataTable table)
        {
            bool isField = ((memberTypes & MemberTypes.Field) == MemberTypes.Field);
            bool isProperty = ((memberTypes & MemberTypes.Property) == MemberTypes.Property);

            var columns =
                type.GetFields(BindingFlags.Public | BindingFlags.Instance)
                    .Where(f => isField)
                    .Select(f => new
                    {
                        ColumnName = f.Name,
                        ColumnType = f.FieldType,
                        IsField = true,
                        MemberInfo = (MemberInfo)f
                    })
                    .Union(
                        type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(p => isProperty)
                            .Where(p => p.CanRead)
                            .Where(p => p.GetGetMethod(true).IsPublic)
                            .Where(p => p.GetIndexParameters().Length == 0)
                            .Select(p => new
                            {
                                ColumnName = p.Name,
                                ColumnType = p.PropertyType,
                                IsField = false,
                                MemberInfo = (MemberInfo)p
                            })
                    )
                    .OrderBy(c => c.MemberInfo.MetadataToken);
            if (table == null)
            {
                table = new DataTable();

                table.Columns.AddRange(
                    columns.Select(c => new DataColumn(
                        c.ColumnName,
                        (c.ColumnType.IsGenericType && c.ColumnType.GetGenericTypeDefinition() == typeof(Nullable<>) ?
                        c.ColumnType.GetGenericArguments()[0] : c.ColumnType)
                    )).ToArray()
                );
            }

            if (instances != null)
            {
                table.BeginLoadData();

                try
                {
                    foreach (var instance in instances)
                    {
                        if (instance != null)
                        {
                            DataRow row = table.NewRow();

                            foreach (var column in columns)
                                row[column.ColumnName] = (column.IsField ? ((FieldInfo)column.MemberInfo).GetValue(instance) : ((PropertyInfo)column.MemberInfo).GetValue(instance, null)) ?? DBNull.Value;

                            table.Rows.Add(row);
                        }
                    }
                }
                finally
                {
                    table.EndLoadData();
                }
            }
            table.SetTypeName(typeName);

            return table;
        }

        public static void SetOrdinal(
            this DataTable table,
            params string[] columnNames)
        {
            if (table == null || columnNames == null || columnNames.Length == 0)
                return;

            int index = 0;
            foreach (string columnName in columnNames)
                table.Columns[columnName].SetOrdinal(index++);
        }
        #endregion

        #region OtherHelper
        //public static DynamicParameters GetBasicDynamicParamters<T>(
        //    RequestModel<T> request,
        //    string action = null)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("Activity", action, DbType.String, ParameterDirection.Input);
        //    param.Add("UserId", request.UserId, DbType.Int32, ParameterDirection.Input);

        //    return param;
        //}

        public static DynamicParameters CreateOutParams()
        {
            var result = new DynamicParameters();
            result.Add(BaseConstants.RETURN_MESS_SQL, "", DbType.String, ParameterDirection.InputOutput, 255);
            result.Add(BaseConstants.RETURN_VALUE_SQL, "", DbType.String, ParameterDirection.InputOutput, 255);

            return result;
        }

        public static DynamicParameters GetBasicDynamicParamters<T>(
            T data,
            int? userId = null,
            string action = null)
        {
            var param = new DynamicParameters();
            param.Add("Activity", action, DbType.String, ParameterDirection.Input);
            param.Add("UserId", userId ?? 1, DbType.Int32, ParameterDirection.Input);

            return param;
        }
        #endregion
    }
}
