using System;
using System.Collections.Generic;
using System.Text;

namespace GitMonitor
{
    class RepoReport
    {
        public int CommitCount { get; set; }
        public HashSet<string> Authors { get; set; }
    }
}
