using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace lab3
{
    internal class Mutex
    {
        int threadId = -1;

        public void Lock()
        {
            while (Interlocked.CompareExchange(ref threadId, Thread.CurrentThread.ManagedThreadId, -1) != -1)
            {
                Thread.Sleep(40);
            }
            
        }


        public bool TryLock()
        {
            if (Interlocked.CompareExchange(ref threadId, Thread.CurrentThread.ManagedThreadId, -1) != -1)
                return false;
            return true;
        }

        public void Unlock()
        {
            if (Interlocked.CompareExchange(ref threadId, -1, Thread.CurrentThread.ManagedThreadId) != Thread.CurrentThread.ManagedThreadId)
            {
                throw new ApplicationException("Current thread does not own mutex or Lock is not called.");
            }
        }
    }
}
