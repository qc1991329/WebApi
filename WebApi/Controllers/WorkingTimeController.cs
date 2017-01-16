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
    public class WorkingTimeController : ApiController
    {
        public ResultObject getWorkingTime(int month) {
            List<WorkingTime> worktimes = new List<WorkingTime>();
            WorkingTime worktime = null;
            //String connectionString = "Data Source=192.168.1.50:1521/xudb;Persist Security Info=True;User ID=XUZHONG;PassWord=XUZHONG;Unicode=True";
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string queryString = "select  t.at_province,t.at_month,sum(t.at_total) as total  from AREA_WORK_TOTAL t where  t.at_year =2013 and t.at_province='江苏' group by  t.at_province,t.at_month order by t.at_month";
            OracleConnection con = new OracleConnection(connectionString);
            OracleCommand command = con.CreateCommand();
            command.CommandText = queryString;
            con.Open();
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                if (month != 0)
                {
                    while (reader.Read())
                    {
                        if (month == reader.GetInt32(1))
                        {
                            worktime = new WorkingTime(reader.GetString(0), reader.GetInt32(1), reader.GetDouble(2));

                            return getResultObject("001", "获取成功", worktime);
                        }
                    }
                    return getResultObject("002", "未找到数据", worktime);

                }
                else
                {
                    while (reader.Read())
                    {
                        worktimes.Add(new WorkingTime(reader.GetString(0), reader.GetInt32(1), reader.GetDouble(2)));
                        //worktimes.Add(new WorkingTime { province = reader.GetString(0), month = reader.GetInt32(1), total = reader.GetDouble(2) });
                    }
                    return getResultObject("001", "获取成功", worktimes);
                }
            }
            finally
            {
                con.Close();
            }
        }
        public ResultObject getWorkingTime() {
            
            return getWorkingTime(0);
        }

        public ResultObject getResultObject(String state, String msg, Object result) {
            ResultObject resultObject = new ResultObject();
            resultObject.state = state;
            resultObject.msg = msg;
            resultObject.Data = result;
            return resultObject;
        }
    }
}
