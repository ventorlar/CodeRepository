using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace httpSpeed.Model
{
    public class ResultModel
    {
        public string delayTime {  get; set; }
        public string errMessage { get; set; }
        public string hasRes { get; set; }
    }
    public class TimeWatch
    {
        ResultModel resultModel=new ResultModel();
        public ResultModel TimeCal(string ip)
        {
            // 创建并立即启动计时器
            Stopwatch stopwatch = Stopwatch.StartNew();

            // 执行你要测试的代码
            Task.Run(async () => await DoSomeHeavyWork(ip)).GetAwaiter().GetResult();

            // 停止计时
            stopwatch.Stop();

            // 1. 获取毫秒数（最常用，返回 long）
            string strtime = $"{stopwatch.ElapsedMilliseconds} ms";
            resultModel.delayTime = strtime;
            return resultModel;
        }
        private static readonly HttpClient client = new HttpClient();
        public async Task DoSomeHeavyWork(string ip)
        {
            try
            {
                string url = ip;

                // GitHub API 要求必须提供 User-Agent 请求头
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MSIE 6.0; Windows NT 5.1)");

                // 发送 GET 请求并直接获取字符串响应
                string responseBody = await client.GetStringAsync(url);

                if(responseBody == null || responseBody == "") resultModel.hasRes = "no";
                else resultModel.hasRes = "yes";
            }
            catch (HttpRequestException e)
            {
                resultModel.hasRes = "no";
                resultModel.errMessage = $"请求错误: {e.Message}";
            }
        }

    }
}
