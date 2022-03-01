using System;
// https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/concepts/async/

// 나중에 Entity Framwork를 다루다보면 async await가 게속등장할 것임

namespace Study
{ 
    // async/await 비동기?
    // 게임 서버> 비동기 = multithread? 꼭 그렇지 않다.
    // single thread에서도 비동기가 있을 수 있다. 
    // Unity Coroutine = 일종의 비동기, but single thread

    class Program
    {
        static Task Test()
        {
            Console.WriteLine("Start Test");
            // 호출한 순간부터 3초를 셈
            Task t = Task.Delay(3000);
            return t;
        }

        static void TestAsync()
        {
            Console.WriteLine("Start TestAsync");
            // 복잡한 작업 (ex. DB 파일 작업)
            Task t = Task.Delay(3000);

            // 무식하게 끝날 때까지 기다린다.
            t.Wait();
            Console.WriteLine("End TestAsync");
        }

        // await를 쓰는 경우 반환형이 Task이여야함
        static async Task TestAsync2() 
        {
            Console.WriteLine("Start TestAsync2");
            // Task t = Task.Delay(3000);
            // 끝날 때까지 기다리지 않고 바로 제어권을 넘긴다.
            // await t;
            // 경우에 따라서 여기가 mutithread로 실행될 수 있다.

            // 한번에 만드는 방법
            await Task.Delay(3000);
            Console.WriteLine("End TestAsync2");
        }

        
        static async Task<int> TestAsync3()
        {
            Console.WriteLine("Start TestAsync3");
            await Task.Delay(3000);
            Console.WriteLine("End TestAsync3");
            return 1;
        }

        static void main(string[] args)
        {
            // Task t = Test();
            // t.Wait(); // 끝날 때까지 기다릴 수 있다.

            // 이런식으로도 할 수 있다.
            // TestAsync();

            Console.WriteLine("while start");

            while (true)
            {

            }
        }

        static async Task Main(string[] args)
        {
            // 대기, main함수를 호출한쪽에 흐름을 넘김 
            // await TestAsync2();

            // 3초후에 while start가 뜬다.
            // Console.WriteLine("while start");

            Task<int> t = TestAsync3(); // task를 받은 다음에
            // 중간에 다른 일도 할 수 있음
            Console.WriteLine("while start");
            int ret = await t;

            while (true)
            {

            }
        }
    }
}