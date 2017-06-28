using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace farmbase.Interface
{
    public interface IObjectPoolSupport
    {
         bool IsInUsed { get; set; }
    }
}
