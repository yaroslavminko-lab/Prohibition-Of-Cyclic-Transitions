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
            var workOrder = new WorkOrder(Status.Черновик, DateTime.Now);

            workOrder.SetCurrentStatus(Status.Активен);

            workOrder.SetCurrentStatus(Status.Черновик);

            workOrder = new WorkOrder(Status.Проверено, DateTime.Now.AddHours(-25));

            workOrder.SetCurrentStatus(Status.Активен);

            workOrder.SetCurrentStatus(Status.Черновик);

            Console.ReadKey();
        }
    }
}
