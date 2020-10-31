using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Logger
{
    internal class LogBuffer : IDisposable
    {
        private bool _disposed = false;
        private object _locker = new object();
        private List<string> _buffer = new List<string>();
        private TextWriter _stream;
        private Timer _timer;

        
        public int BufferSize { get; set; } = 50;
        public LogBuffer(Stream stream)
        {
            if (stream is  null)
                throw new ArgumentNullException(nameof(stream));

            _stream = new StreamWriter(stream);
            _timer = new Timer(FlushTimerCallback, null, 10_000, 10_000);
        }
        public void Add(string item, bool saveBuffer = false)
        {
            if (_disposed)
                throw new ObjectDisposedException("Logger");

            if (item is null)
                throw new ArgumentNullException(nameof(item));
            
            lock (_locker)
            {
                _buffer.Add(item);
            }

            if (saveBuffer && _buffer.Count > BufferSize)
            {
                Flush();
            }
        }
        public void AddAndFlushImmediate(string item)
        {
            if (_disposed)
                throw new ObjectDisposedException("Logger");

            if (item is null)
                throw new ArgumentNullException(nameof(item));
             lock(_locker)
             {
                _buffer.Add(item);
             }

             Flush();

        }
        public void FlushAsync()
        {
            if (_disposed)
                throw new ObjectDisposedException("Logger");
                

            Task.Run(()=>{
                Flush();
            }); 
        }

        public void Flush()
        {
            lock(_locker)
            {
                if (_disposed)
                    throw new ObjectDisposedException("Logger");
                
                _timer.Change(10_000, 10_000);

                foreach (string s in _buffer)
                {
                    _stream.WriteLine(s);
                }

                _buffer.Clear();
                _stream.Flush();
            }
        }
        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~LogBuffer()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _timer.Dispose();
                lock(_locker)
                {
                    _stream.Flush();
                    _stream.Dispose();
                }

                _disposed = true;
            }
        }

        private void FlushTimerCallback(object state)
        {            
            FlushAsync();
        }


    }
}