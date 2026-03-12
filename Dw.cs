using RestSharp;
using System;
using System.Net;
using System.Xml;

namespace SettleReport
{
    public class Dw
    {
        private static readonly string Dw_User_Name = "地纬登录账号";
        private static readonly string Dw_Pass_Word = "地纬登录密码";
        private static readonly string Dw_Hospital_Id = "医院标识";

        private static string loginData = "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><loginByYybm xmlns=\"http://service.communication.service.dareway.com/\"><arg0 xmlns=\"\">{0}</arg0><arg1 xmlns=\"\">{1}</arg1><arg2 xmlns=\"\">{2}</arg2></loginByYybm></s:Body></s:Envelope>";

        private static string jsdData = "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><invoke xmlns=\"http://service.communication.service.dareway.com/\"><arg0 xmlns=\"\">{0}</arg0><arg1 xmlns=\"\">{1}</arg1><arg2 xmlns=\"\">{2}</arg2><arg3 xmlns=\"\">{3}</arg3><arg4 xmlns=\"\">{4}</arg4></invoke></s:Body></s:Envelope>";


        /// <summary>
        /// 地纬登录
        /// </summary>
        /// <returns></returns>
        public static string Login()
        {
            var client = new RestClient("http://地纬服务器IP:7001");
            var request = new RestRequest("/mhs5/siSettleService", Method.POST);
            request.AddParameter("text/xml; charset=utf-8", String.Format(loginData, Dw_User_Name, Dw_Pass_Word, Dw_Hospital_Id), ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(response.Content);
                return document.InnerText;
            }
            return "";
        }

        public static string PrintJsd(string method, string ybbm, string param)
        {
            var client = new RestClient("http://地纬服务器IP:7001");
            var request = new RestRequest("/mhs5/siSettleService", Method.POST);
            request.AddParameter("text/xml; charset=utf-8", String.Format(jsdData, "000000", ybbm, Guid.NewGuid().ToString("N"), method, param), ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(response.Content);
                return document.InnerText;
            }
            return "";
        }
    }
}
