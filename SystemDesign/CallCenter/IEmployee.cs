using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemDesign.CallCenter
{
    public interface IEmployee
    {
        string Name { get; set; }
        int Priority();
        void HandleCall(Call call, Action callBack);
    }
}