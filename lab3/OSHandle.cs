using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace lab3
{
    internal class OSHandle : IDisposable
    {
        private bool _disposed = false;
        private Mutex mutex = new Mutex();
        private IntPtr _handle;
        [DllImport("kernel32")]
        private static extern bool CloseHandle(IntPtr pointer);
        

        public OSHandle(IntPtr handle)
        {
            _handle = handle;
        }

        public IntPtr Handle 
        {
            get 
            {
                if (_disposed)
                    throw new ObjectDisposedException("OSHandle");
                return _handle;
            }
            set
            {
                if (_disposed)
                    throw new ObjectDisposedException("OSHandle");

                mutex.Lock();
                _handle = value;
                mutex.Unlock();
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                _disposed = true;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            mutex.Lock();
            CloseHandle(this.Handle);
            mutex.Unlock();
        }

        ~OSHandle()
        {
            Dispose(false);
        }

    }
}
