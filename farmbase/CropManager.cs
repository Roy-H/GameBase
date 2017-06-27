using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace farmbase
{
    public class CropManager : IManager
    {

        public int ID
        {
            get
            {
                return Convert.ToInt32(nameof(CropManager));
            }
        }
    }
}
