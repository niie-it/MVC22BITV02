namespace Lab03.Models
{
    public class MyDemo
    {
        public async static Task<int> FuncAAsync()
        {
            await Task.Delay(2000);
            return new Random().Next(1, 1001);
        }

        public static async Task<string> FuncBAsync()
        {
            await Task.Delay(5000);
            return "21BITV01";
        }

        public async static Task FuncCAsync()
        {
            await Task.Delay(3000);
        }


        public static int FuncA()
        {
            Thread.Sleep(2000);
            return new Random().Next(1, 1001);
        }

        public static string FuncB()
        {
            Thread.Sleep(5000);
            return "21BITV01";
        }

        public static void FuncC()
        {
            Thread.Sleep(3000);
        }

    }
}
