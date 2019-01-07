using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskSample
{
    /// <summary>
    /// 声明task的三种方法
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //1.using taskfactory
            TaskFactory task = new TaskFactory();
            var t1 = task.StartNew(cal);

            //2.using Task.Factory
            var t2 = Task.Factory.StartNew(cal);
            //3.task构造函数
            Task t3 = new Task(cal);
            t3.Start();


            Task t4 = new Task(cal, TaskCreationOptions.PreferFairness);
            t4.Start();

        }

        public static void cal()
        {
            Console.WriteLine($"current thread id:{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
