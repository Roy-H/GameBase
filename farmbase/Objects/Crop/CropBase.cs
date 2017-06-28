using farmbase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace farmbase.Objects.Crop
{
    public class Crop: CropBase, IObjectPoolSupport
    {
        private int waterDays;
        private Time growTime;
        private bool isInGrowing;
        

        public Crop(int id):base(id)
        {
            
        }
        #region Properties
        public bool IsInGrowing
        { get { return isInGrowing; } set { isInGrowing = value; } }
        
        public bool IsInUsed { get;set;}

        #endregion
        #region Methods
        public void GiveWater()
        {

            waterDays++;
        }

        public void Grow()
        {
            IsInUsed = true;
            isInGrowing = true;
            growTime = TimeManager.Instace.CurrentTime;
        }

        public void SpendOneDay()
        {
            if (isInGrowing)
            {

            }
        }

        public void Destroy()
        {
            IsInUsed = false;
            isInGrowing = false;
            growTime = null;
        }
        #endregion

    }

    public class CropBase : ICropBase
    {
        protected int id;
        public int ID
        {
            get
            {
                return id;
            }
        }
        protected CropInformation info;

        public CropBase(int id)
        {
            this.id = id;
            Initialize();
        }

        private void Initialize()
        {
            var isOk = CropInformationList.Crops.TryGetValue(id,out info);
            if (!isOk)
            {
                throw new Exception("not found the object with this id");
            }
            this.id = info.Id;
        }

        public void ChangeCropKind(CropInformation info)
        {
            this.id = info.Id;
            this.info = info;
        }

        public void ChangeCropKind(int id)
        {
            CropInformation cropInfo;
            var isOk = CropInformationList.Crops.TryGetValue(id, out cropInfo);
            if (!isOk)
            {
                throw new Exception("not found the object with this id");
            }
            this.id = info.Id;
            this.info = cropInfo;
        }
    }

    public class CropInformationList
    {
        public static Dictionary<int, CropInformation> Crops = new Dictionary<int, CropInformation>()
        {
            { 1,new CropInformation("",1,1,10,2,false,new int[] { 1,2,3,4})},
            { 2,new CropInformation("",1,2,1,2,false,new int[] { 1,2,3,4})},
            { 3,new CropInformation("",1,3,1,2,false,new int[] { 1,2,3,4})},
            { 4,new CropInformation("",1,4,1,2,false,new int[] { 1,2,3,4})},
            { 5,new CropInformation("",1,5,1,2,false,new int[] { 1,2,3,4})},
            { 6,new CropInformation("",1,6,1,2,false,new int[] { 1,2,3,4})},
            { 7,new CropInformation("",1,7,1,2,false,new int[] { 1,2,3,4})},
            { 8,new CropInformation("",1,8,1,2,false,new int[] { 1,2,3,4})},
            { 9,new CropInformation("",1,9,1,2,false,new int[] { 1,2,3,4})},
            { 10,new CropInformation("",1,10,1,2,false,new int[] { 1,2,3,4})},
            { 11,new CropInformation("",1,11,1,2,false,new int[] { 1,2,3,4})},
            { 12,new CropInformation("",1,12,1,2,false,new int[] { 1,2,3,4})},
            { 13,new CropInformation("",1,13,1,2,false,new int[] { 1,2,3,4})},
            { 14,new CropInformation("",1,14,1,2,false,new int[] { 1,2,3,4})},
        };
    }

    public class CropInformation
    {
        public CropInformation(string name,int id,int growthDays,double price,double seedPrice, bool isContinueGrow,int[] growthSeason)
        {
            this.name = name;
            this.id = id;
            this.growthDays = growthDays;
            this.price = price;
            this.isContinueGrow = isContinueGrow;
            this.growthSeason = growthSeason;
            this.seedPrice = seedPrice;
        }
        string name;
        int id;
        int growthDays;
        double price;
        double seedPrice;
        bool isContinueGrow;
        int[] growthSeason;

        public string Name { get { return name; } }
        public int Id { get { return id; } }
        public int GrowthDays { get { return growthDays; } }
        public double Price { get { return price; } }
        public double SeedPrice { get { return seedPrice; } }
        public bool IsContinueGrow { get { return isContinueGrow; } }
        public int[] GrowthSeason { get { return growthSeason; } }
    }
}
