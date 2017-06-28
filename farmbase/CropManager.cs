using farmbase.Objects.Crop;
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
        private List<Crop> cropPool;
        public CropManager()
        {
            cropPool = new List<Crop>();
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


        #region Methods
        public void PlantCrop(int id)
        {            
            var crop = new Crop(id);
            crop.Grow();
            cropPool.Add()
        }
        #endregion
    }

    public class CropsPool
    {
        private List<Crop> cropsPool;

        private int MaxCropsPoolNum = 50;

        public CropsPool()
        {
            cropsPool = new List<Crop>();
        }
        private static CropsPool instance;
        public static CropsPool Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CropsPool();
                }
                return instance;
            }
        }

        public Crop GetEnableCrop()
        {

        }
    }

}
