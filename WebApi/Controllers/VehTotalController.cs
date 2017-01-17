using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class VehTotalController : ApiController
    {
        public ResultObject getVehTotal() {
            List<VehTotal> totallist = new List<VehTotal>();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string queryString = "select at_province,total from (select t.at_province,sum(t.at_total) as total from AREA_VEHICLE_TOTAL t where t.at_year = 2016 and t.at_province is not null  group by t.at_province order by total ) where rownum<=10";
            OracleConnection con = new OracleConnection(connectionString);
            OracleCommand command = con.CreateCommand();
            command.CommandText = queryString;
            con.Open();
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read()) {
                    totallist.Add(new VehTotal(reader.GetString(0),reader.GetInt32(1)));
                }
                return getResultObject("001", "获取成功", totallist);
            }
            finally
            {
                con.Close();
            }
        }

        //返回对象封装
        public ResultObject getResultObject(String state, String msg, Object result)
        {
            ResultObject resultObject = new ResultObject();
            resultObject.state = state;
            resultObject.msg = msg;
            resultObject.Data = result;
            return resultObject;
        }
    }
}
