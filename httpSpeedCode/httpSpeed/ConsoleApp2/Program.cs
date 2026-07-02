using System.Diagnostics;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 创建并立即启动计时器
            Stopwatch stopwatch = Stopwatch.StartNew();

            // 执行你要测试的代码
            Task.Run(async () => DoSomeHeavyWork()).GetAwaiter().GetResult();

            // 停止计时
            stopwatch.Stop();

            // 1. 获取毫秒数（最常用，返回 long）
            Console.WriteLine($"耗时: {stopwatch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
        private static readonly HttpClient client = new HttpClient();
        static async Task DoSomeHeavyWork()
        {
            try
            {
                string url = "https://flysky.mycom/openwrt:443";

                // GitHub API 要求必须提供 User-Agent 请求头
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MSIE 6.0; Windows NT 5.1)");

                // 发送 GET 请求并直接获取字符串响应
                string responseBody = await client.GetStringAsync(url);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"请求异常: {e.Message}");
            }
        }
    }
}
