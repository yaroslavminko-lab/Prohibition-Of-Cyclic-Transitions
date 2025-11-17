using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prohibition_Of_Cyclic_Transitions
{
    class WorkOrder : IStatusValidator
    {
        private Status _currentStatus;
        public Status CurrentStatus {
            get => _currentStatus; 
            
            set
            {
                if (ValidateNewStatus(value))
                {
                    _currentStatus = value;
                    _lastStatusChangeDate = DateTime.Now;
                }
            }
        }
        private DateTime _lastStatusChangeDate;
        public DateTime LastStatusChangeDate { get => _lastStatusChangeDate; }

        public WorkOrder(Status status = Status.Черновик)
        {
            this._currentStatus = status;
            this._lastStatusChangeDate = DateTime.Now;
        }

        //нужен только чтобы показать работу валидации с датой(его как бы не должно быть)
        public WorkOrder(Status status, DateTime dateTime)
        {
            this._currentStatus = status;
            this._lastStatusChangeDate = dateTime;
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
