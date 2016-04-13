using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL.Interfaces;
using Domain;
using NLog.Internal;

namespace DAL.Repositories
{
    public class CallRepository : EFRepository<Call>, ICallRepository
    {
        public CallRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public bool AddCall(Call newCall)
        {


            Call postDbCall = new Call();

            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseConnectionStr"].ConnectionString;
           // string connectionString =proper

            SqlConnection sql = new SqlConnection(cs);
            SqlCommand sqlsd = sql.CreateCommand();
            sqlsd.CommandType = CommandType.StoredProcedure;
            sqlsd.CommandText = "PostDb";

            SqlParameter serviceId = new SqlParameter("@ServiceId", SqlDbType.Int);
            serviceId.Value = newCall.ServiceId;
            serviceId.Direction = ParameterDirection.InputOutput;
            sqlsd.Parameters.Add(serviceId);

            SqlParameter audioFileName = new SqlParameter("@AudioFileName", SqlDbType.VarChar, 50);
            audioFileName.Value = newCall.AudioFileName;
            audioFileName.Direction = ParameterDirection.InputOutput;
            sqlsd.Parameters.Add(audioFileName);

            SqlParameter dir = new SqlParameter("@InOut", SqlDbType.VarChar, 50);
            dir.Value = newCall.Dir;
            dir.Direction = ParameterDirection.InputOutput;
            sqlsd.Parameters.Add(dir);

            SqlParameter duration = new SqlParameter("@Duration", SqlDbType.VarChar, 50);
            duration.Value = newCall.Duration;
            duration.Direction = ParameterDirection.InputOutput;
            sqlsd.Parameters.Add(duration);

            SqlParameter storage_dir = new SqlParameter("@StorageDir", SqlDbType.VarChar, 50);
            storage_dir.Value = newCall.AudioDir;
            storage_dir.Direction = ParameterDirection.InputOutput;
            sqlsd.Parameters.Add(storage_dir);



            SqlParameter userId = new SqlParameter("@UserId", SqlDbType.Int);
            userId.Value = newCall.UserId;
            userId.Direction = ParameterDirection.InputOutput;
            sqlsd.Parameters.Add(userId);

            SqlParameter aNumber = new SqlParameter("@ANumber", SqlDbType.VarChar, 50);
            aNumber.Value = newCall.Anumber;
            aNumber.Direction = ParameterDirection.InputOutput;
            sqlsd.Parameters.Add(aNumber);


            SqlParameter bNumber = new SqlParameter("@BNumber", SqlDbType.VarChar, 50);
            bNumber.Value = newCall.Bnumber;
            bNumber.Direction = ParameterDirection.InputOutput;
            sqlsd.Parameters.Add(bNumber);

            SqlParameter startDate = new SqlParameter("@StartDate", SqlDbType.DateTime);
            startDate.Value = newCall.Created;
            startDate.Direction = ParameterDirection.Input;
            sqlsd.Parameters.Add(startDate);

            //@Custom1 varchar(50) output
            SqlParameter custom1 = new SqlParameter("@Custom1", SqlDbType.VarChar, 50);
            custom1.Value = newCall.Custom1;
            custom1.Direction = ParameterDirection.InputOutput;
            sqlsd.Parameters.Add(custom1);
            sql.Open();

            sqlsd.ExecuteNonQuery();
            //   listBox1.Items.Add(parm.Value);
            //    listBox1.Items.Add(sqlsd.Parameters["@Name"].Value);
            postDbCall.AudioFileName = sqlsd.Parameters["@AudioFileName"].Value.ToString();
            postDbCall.Dir = sqlsd.Parameters["@InOut"].Value.ToString();
            postDbCall.Duration = sqlsd.Parameters["@Duration"].Value.ToString();
            postDbCall.AudioDir = sqlsd.Parameters["@StorageDir"].Value.ToString();
            postDbCall.UserId = (int)sqlsd.Parameters["@UserId"].Value;
            postDbCall.ServiceId = (int)sqlsd.Parameters["@ServiceId"].Value;
            postDbCall.Created = (DateTime)sqlsd.Parameters["@StartDate"].Value;
            postDbCall.Anumber = sqlsd.Parameters["@ANumber"].Value.ToString();
            postDbCall.Bnumber = sqlsd.Parameters["@BNumber"].Value.ToString();
            postDbCall.Custom1 = sqlsd.Parameters["@Custom1"].Value.ToString();
            sql.Close();
            DbSet.Add(postDbCall);
            return true;

        }

    }
}