using System;

namespace OopRockPaperScissors
{
    public class Timer
    {
        private int duration;
        private int timeLeft;
        private DateTime startTime;
        private bool isRunning;

        public Timer(int duration)
        {
            this.duration = duration;
            this.timeLeft = duration;
            this.isRunning = false;
        }

        public int GetTimeLeft()
        {
            if (isRunning)
            {
                TimeSpan span = DateTime.Now - startTime;
                timeLeft = duration - (int)span.TotalSeconds;
                if (timeLeft < 0)
                {
                    timeLeft = 0;
                }
                return timeLeft;
            }
            return timeLeft;
        }

        public void StartTimer()
        {
            startTime = DateTime.Now;
            isRunning = true;
        }

        public void StopTimer()
        {
            isRunning = false;
            GetTimeLeft();
        }

        public void ResetTimer()
        {
            isRunning = false;
            timeLeft = duration;
        }
    }
}