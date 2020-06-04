//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace ParkingManagement.Core.Model
//{
//    public class ActionExectionTime
//    {
//    }
//    public static class ElapsedTime
//    {
//        public static Dictionary IdentifiedElapseds = new Dictionary();

//        public static void InsertEntity(long milliseconds, string identifier)
//        {
//            lock (IdentifiedElapseds)
//            {
//                ElapsedTimeEntity entry;
//                if (!IdentifiedElapseds.TryGetValue(identifier, out entry))
//                {
//                    entry = new ElapsedTimeEntity();
//                    IdentifiedElapseds.Add(identifier, entry);
//                }

//                entry.LastTime = milliseconds;
//                entry.LastDate = DateTime.UtcNow;
//                entry.TotalTime += milliseconds;
//                entry.Count++;

//                if (milliseconds &lt; entry.MinTime)
//         entry.MinTime = milliseconds; entry.MinDate = DateTime.UtcNow;
//                if (milliseconds &gt; entry.MaxTime)
//         entry.MaxTime = milliseconds; entry.MaxDate = DateTime.UtcNow;
//            }
//        }
//    }

//    public class ElapsedTimeEntity
//    {
//        public long LastTime = 0;
//        public long TotalTime = 0;
//        public int Count = 0;
//        public long MinTime = long.MaxValue;
//        public long MaxTime = long.MinValue;
//        public double Average
//        {
//            get { return (TotalTime / Count); }
//        }

//        public DateTime MinDate;
//        public DateTime MaxDate;
//        public DateTime LastDate;
//    }
//    }