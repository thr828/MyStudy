using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    /// <summary>
    ///1.只要有一个前台线程在运行,应用程序的进程就在运行。如果多个前台线程在运行,而 Main()方法结束了,应用程序的进程就仍然是激活的,直到所有前台线程完成其任务为止。
    ///2.在默认情况下,用 Thread类 创建的线程是前台线程。线程池中的线程总是后台线程。
    ///3.在用Thread类创建线程时,可 以设置IsBackgromd属性, 以确定该线程是前台线程还是后台线程。Main()方法将线程t1的IsBackground属性设置为 false 。在启动新线程后,主线程就把
    //// 结束消息写入控制台中。新线程会写入启动消息和结束消息,在这个过程中它要睡眠 3秒。在新线程会完成其工作前,这 3秒钟有利于主线程结束。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(ThradMain) { Name="MyNewThread",IsBackground=false};
            t1.Start();
            Console.WriteLine($"main end  name:{Thread.CurrentThread.Name} thread id: {Thread.CurrentThread.ManagedThreadId}");
        }

        static void ThradMain()
        {
            Console.WriteLine($"Thread start name:{Thread.CurrentThread.Name} thread id:{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(50000);
            Console.WriteLine($"Thread end name:{Thread.CurrentThread.Name} thread id:{Thread.CurrentThread.ManagedThreadId}");

        }
    }
}
