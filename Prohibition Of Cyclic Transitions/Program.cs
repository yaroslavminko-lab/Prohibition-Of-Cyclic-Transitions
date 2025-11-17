using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prohibition_Of_Cyclic_Transitions
{
    class Program
    {
        static void Main(string[] args)
        {
            var workOrder = new WorkOrder();

            workOrder.CurrentStatus = Status.Активен;

            workOrder.CurrentStatus = Status.Черновик;

            workOrder = new WorkOrder(Status.Проверено, DateTime.Now.AddHours(-25));

            workOrder.CurrentStatus = Status.Активен;

            workOrder.CurrentStatus = Status.Черновик;

            Console.ReadKey();
        }
    }
}
