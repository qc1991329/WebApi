using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace WebApi.Controllers
{
    public class SendsmsController : ApiController
    {
        private String url = "http://gw.api.taobao.com/router/rest";
        private String appkey = "23550438";
        private String secret = "efd64ee5b4101eb45aab398b276a049f";
        [HttpGet]
        public String postSendsms(String mobile) {
            /*
             * post方法调用java后台验证码接口
             */
            /*
            HttpClient client = new HttpClient();
            String url = "http://10.8.1.161:8080/sendsms";
            var values = new List<KeyValuePair<String, String>>();
            values.Add(new KeyValuePair<String, String>("mobile", "15805212701"));
            var content = new FormUrlEncodedContent(values);
            HttpResponseMessage result = client.PostAsync(url, content).Result;
            return result.Content.ReadAsStringAsync().Result;
            */

            /*
             * 短信验证吗.NET接口(阿里大于.NET API)
             */
            ITopClient client = new DefaultTopClient(url, appkey, secret);
            AlibabaAliqinFcSmsNumSendRequest req = new AlibabaAliqinFcSmsNumSendRequest();
            req.SmsType = "normal";
            req.SmsFreeSignName = "XCMG测试";
            req.SmsParam = "{\"code\":\"1234\",\"product\":\"徐工起重在线\"}";
            req.RecNum = mobile;
            req.SmsTemplateCode = "SMS_30210012";
            AlibabaAliqinFcSmsNumSendResponse rsp = client.Execute(req);
            if (rsp.IsError)
            {
                return "失败！"+rsp.SubErrCode+":"+rsp.SubErrMsg;
            }
            else {
                return "成功！"+mobile;
            }
        }

        [HttpPost]
        public String getSendsms()
        {
            /*
             * get方法调用java后台验证码接口
             */
            HttpClient client = new HttpClient();
            String url = "http://10.8.1.161:8080/sendsms?mobile=15805212701";
            HttpResponseMessage result = client.GetAsync(url).Result;
            return result.Content.ReadAsStringAsync().Result;

        }
    }
}
