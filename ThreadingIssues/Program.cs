using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingIssues
{
    /// <summary>
    /// 线程安全处理
    /// 在给包含 5的变量递增了 1后 ,可能希望该变量的值就是 6。 
    /// 但事实不一定是这样。例如,如果一个线程刚刚执行完  if (state == 5)语句,它就被其他线程抢占,调度器运行另一个线程。第二个线程现在进入if体,因为 state的值仍是 5,所以将它递增到 6。 
    /// 第一个线程现在再次被调度,在下一条语旬中, state递增到 7。 这时就发生了争用条件,并显示断言消息。
    /// 解决方法1：要避免该问题,可 以锁定共享的对象。这可以在线程中完成:用下面的lock语 句锁定在线程中共享的 state变量。只有一个线程能在锁定块中处理共享的 state对象。由于这个对象在所有的线程之间共享, 因此如果一个线程锁定了state, 另 一个线程就必须等待该锁定的解除。一旦接受锁定,线程就拥有该锁定,直到该锁定块的末尾才解除锁定。如果改变 state变量引用的对象的每个线程都使用一个锁定,就不会出现争用条件
    /// 解决方法2：在使用共享对象时,除 了进行锁定之外,还可以将共享对象设置为线程安全的对象。其中ChangeState方法包含一条lock语句。由于不能锁定 state变 量本身(只有引用类型才能用于锁勋 ,因此定义一个 object类型的变量 sync 将它用于 lock语句。如果每次 state 的值更改时, 都使用同一个同步对象来锁定, 就不会出现争用条件。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //单线程 没有问题
            //StateObject stateObject = new StateObject();
            //SampleTask sampleTask = new SampleTask();
            //sampleTask.RaceCondition(stateObject);


            //多线程 存在争用条件
            StateObject stateObject = new StateObject();

            for (int i = 0; i < 20; i++)
            {
                //1.
                Task.Factory.StartNew(new SampleTask().RaceCondition, stateObject);//用的是同一个stateObject
                //2.
                //new Task(new SampleTask().RaceCondition, stateObject).Start();
                ////3.
                //TaskFactory taskFactory = new TaskFactory();
                //taskFactory.StartNew(new SampleTask().RaceCondition, stateObject);
            }
            Thread.Sleep(10000);


        }
    }

    public class StateObject
    {
        private int state = 5;
        private object sync = new object();
        public void ChangeState(int loop)
        {
            lock (sync)
            {
                if (state == 5)
                {
                    state++;
                    Trace.Assert(state == 6, "Race condition occurred after " + loop + " loops");
                }
                state = 5;
            }
            

        }
    }

    public class SampleTask
    {
      
        public void RaceCondition(object o)
        {
            Trace.Assert(o is StateObject, "o must be of type StateObject");
            StateObject state = o as StateObject;

            int i = 0;
            while (true)
            {
                //lock (state)//加锁1 因为是同一个StateObject对象  共享对象
                //{
                    state.ChangeState(i++);
                //}
                
            }

        }


    }
}
