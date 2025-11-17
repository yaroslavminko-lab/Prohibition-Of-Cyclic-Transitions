using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prohibition_Of_Cyclic_Transitions
{
    interface IStatusValidator
    {
        bool ValidateNewStatus(Status status);
    }
}
