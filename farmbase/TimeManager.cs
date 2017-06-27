using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace farmbase
{
    
    public class Time
    {
        public static void ValidTime(Time time)
        {
            if (time.Day > 30 || time.Day < 1 || time.Hour > 23 || time.Hour < 0 || time.Season > 4 || time.Season < 0 || time.Min > 59 || time.Min < 0)
            {
                throw new Exception("the time format is invalid");
            }
        }

        public static void ValidTime(int season, int day, int hour, int min)
        {
            if (day > 30 || day < 1 || hour > 23 || hour < 0 || season > 4 || season < 0 || min > 59 || min < 0)
            {
                throw new Exception("the time format is invalid");
            }
        }

        public Time(int season,int day, int hour,int min)
        {
            ValidTime(season, day, hour, min);
            this.season = season;
            this.day = day;
            this.min = min;
            this.hour = hour;
        }

        public Time()
        {
            this.season = 0;
            this.day = 1;
            this.min = 0;
            this.hour = 0;
        }
        int season;
        int day;
        int min;
        int hour;
        public int Day { get { return day; } set { day = value; } }
        public int Min { get { return min; } set { min = value; } }
        public int Hour { get { return hour; } set { hour = value; } }
        public int Season { get { return season; } set { season = value; } }
    }

    public delegate void TimeChangeEventHandler(TimeManager holder ,Time time);
    //public delegate void TimeSeasonChangeEventHandler(TimeManager holder ,Time time);
    public class TimeManager: IManager
    {
        Time startTime;
        Time previousTime;
        float timeSpeed=1;
        object async = new object();
        public event TimeChangeEventHandler SpendDay;
        public event TimeChangeEventHandler SpendSeason;
        public event TimeChangeEventHandler ShowTime;

        private static TimeManager instance;
        public static TimeManager Instace
        {
            get
            {
                if (instance == null)
                {
                    instance = new TimeManager(null);
                }
                return instance;
            }
        }

        Thread timeThread;
        public TimeManager(Time timeFrom)
        {
            if (timeFrom != null)
                startTime = timeFrom;
            else
                startTime = new Time();
            previousTime = startTime;
            currentTime = startTime;

        }

        public Time StartTime
        {
            get
            {
                return startTime;
            }
        }


        private Time currentTime;
        public Time CurrentTime { get; set; }

        public int ID
        {
            get
            {
                return Convert.ToInt32(nameof(TimeManager).GetHashCode());
            }

        }

        public void Start()
        {
            if(timeThread==null)
            {
                timeThread = new Thread(Count);
                timeThread.IsBackground = true;
                timeThread.Name = "count time";
            }
            lock (async)
            {
                timeThread.Start();
            }
                
        }

        public void Stop()
        {
            previousTime = currentTime;
            timeThread.Abort();
            timeThread = null;
        }

        

        public void StartFromTime(Time time)
        {
            Time.ValidTime(time);
            startTime = time;
            previousTime = time;
            currentTime = time;
            if((timeThread.ThreadState&( ThreadState.Running|ThreadState.Background))== (ThreadState.Running | ThreadState.Background))
            {
                Stop();
            }
            
            Start();
        }

        public void SetCurrentTime(Time time)
        {
            currentTime = time;
        }

        public Time GetPreviourTime()
        {
            if(previousTime!=null)
                return previousTime;
            previousTime = currentTime;
            return previousTime;
        }

        private void Count()
        {
            while (true)
            {
                Thread.Sleep((int)(100 * timeSpeed));
                currentTime.Min++;
                if (currentTime.Min % 10 == 0)
                {
                    if (currentTime.Min == 60)
                    {
                        currentTime.Min = 0;
                        currentTime.Hour++;
                        if (currentTime.Hour == 24)
                        {
                            currentTime.Hour = 0;
                            currentTime.Day++;
                            TimeChangeEventHandler tempDay = SpendDay;
                            if (tempDay != null)
                            {
                                tempDay.Invoke(this, currentTime);
                            }
                            if (currentTime.Day > 30)
                            {
                                currentTime.Season++;
                                currentTime.Season = currentTime.Season % 4;
                                TimeChangeEventHandler tempSeason = SpendSeason;
                                if (tempSeason != null)
                                {
                                    tempSeason.Invoke(this, currentTime);
                                }
                            }
                            
                        }
                    }
                    TimeChangeEventHandler tempShowTime = ShowTime;
                    if (tempShowTime != null)
                    {
                        tempShowTime.Invoke(this, currentTime);
                    }
                }
            }
        }
    }
}
