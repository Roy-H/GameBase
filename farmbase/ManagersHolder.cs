using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace farmbase
{
    public class ManagersHolder
    {
        private Dictionary<int,IManager> Managers = new  Dictionary<int, IManager>();

        public void Register(IManager manager)
        {
            if (manager != null)
            {
                if (Managers.ContainsKey(manager.ID))
                {
                    throw new Exception("this manager has been registered");
                }
                else 
                    Managers.Add(manager.ID, manager);
            }
        }

        public IManager GetManagerByID(int id)
        {
            IManager manager;
            var isOk = Managers.TryGetValue(id,out manager);
            if (isOk)
                return manager;
            else
                throw new Exception("manager not found");
        }

        private static ManagersHolder instance;

        public static ManagersHolder Instance
        { 
            get
            {
                if (instance == null)
                    instance = new ManagersHolder();
                return instance;
            } 
        }

        public void RegisterAllManagers()
        {

            //read manager from config file,here;
            Register(TimeManager.Instace);
            
        }
    }
}
