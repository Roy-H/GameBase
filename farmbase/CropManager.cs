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

        public CropManager()
        {
            TimeManager.Instace.SpendDay += TimeManager_SpendDay;
            TimeManager.Instace.SpendSeason += TimeManager_SpendSeason;
        }

        private void TimeManager_SpendSeason(TimeManager holder, Time time)
        {
            //throw new NotImplementedException();
        }

        private void TimeManager_SpendDay(TimeManager holder, Time time)
        {
            //throw new NotImplementedException();
        }

        private static CropManager instance;
        public static CropManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CropManager();
                }
                return instance;
            }
        }
    }
}
