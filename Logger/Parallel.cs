using System;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace Logger
{
    internal static class Parallel
    {
        public static void WaitAll(this Action[] actions)
        {
            if (actions is null)
                throw new ArgumentNullException(nameof(actions));


            Task[] tasks = new Task[actions.Length];
            for (int i = 0; i < tasks.Length; i++)
            {
                int j = i;
                tasks[i] = Task.Run(() => actions[j]?.Invoke());
            }

            Task.WaitAll(tasks);
        }
    }



}