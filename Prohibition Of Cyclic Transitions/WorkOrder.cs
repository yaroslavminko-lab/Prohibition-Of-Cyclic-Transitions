using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prohibition_Of_Cyclic_Transitions
{
    class WorkOrder : IStatusValidator
    {
        public Status CurrentStatus { get; private set; }
        public DateTime LastStatusChangeDate { get; }

        public WorkOrder(Status currentStatus, DateTime lastStatusChangeDate)
        {
            this.CurrentStatus = currentStatus;
            this.LastStatusChangeDate = lastStatusChangeDate;
        }

        public void SetCurrentStatus(Status newStatus)
        {
            if(ValidateNewStatus(newStatus))
                CurrentStatus = newStatus;
        }

        public bool ValidateNewStatus(Status newStatus)
        {
            if (CurrentStatus == Status.Активен && newStatus == Status.Черновик)
            {
                Console.WriteLine("Переход запрещен.");
                return false;
            }

            if (CurrentStatus == Status.Проверено && newStatus == Status.Активен && (DateTime.Now - LastStatusChangeDate).TotalHours > 24)
            {
                Console.WriteLine("Переход запрещен: Слишком много времени прошло с последнего изменения.");
                return false;
            }

            return true;
        }
    }
}
