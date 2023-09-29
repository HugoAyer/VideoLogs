using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    class VideoLogs
    {
    public class LogEntry
    {
        public string user { get; set; }
        public long start { get; set; }
        public long end { get; set; }
        public int count { get; set; }
    }
    public static string VideoStreamingLogs(LogEntry[] nums)
    {
        //Algoritmo Kadane/Intervals
        if (nums.Length == 0)
        {
            return "";
        }
        if (nums.Length == 1)
        {
            return nums[0].user;
        }

        Dictionary<string, LogEntry> grupos = new Dictionary<string, LogEntry>();
        int maxCount = 0;
        string winnerUser = "";

        foreach (LogEntry log in nums)
        {
            Intervals(log, nums, ref maxCount, ref winnerUser, grupos);
        }
        return winnerUser;
    }

    public static void Intervals(LogEntry currlog, LogEntry[] nums, ref int maxCount, ref string winnerUser, Dictionary<string, LogEntry> grupos)
    {
        if (!grupos.ContainsKey(currlog.user))
        {
            grupos.Add(currlog.user, currlog);
        }
        foreach (LogEntry log in nums)
        {
            if (!log.user.Equals(currlog.user))
            {
                if (log.start >= currlog.start && log.end <= currlog.end)
                {
                    currlog.count++;
                    if (currlog.count > maxCount)
                    {
                        maxCount = currlog.count;
                        winnerUser = currlog.user;
                    }
                }
            }
        }
    }
}
