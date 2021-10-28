using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace GitMonitor
{
    class RepoCheck
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public int MaxCommits { get; set; }
        public string Location { get; set; }

        public RepoReport Run()
        {
            const string tempBatFileName = "Temp.bat";

            var fileBuilder = new StringBuilder();
            fileBuilder.AppendLine(this.Location.Substring(0, 2));
            fileBuilder.AppendLine($"cd {this.Location}");
            fileBuilder.AppendLine($"git fetch");
            fileBuilder.AppendLine($"git log {this.Destination}..{this.Source}");

            File.WriteAllText(tempBatFileName, fileBuilder.ToString());

            Process process = new Process();
            process.StartInfo.FileName = tempBatFileName;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            var output = process.StandardOutput.ReadToEnd();

            var outputLines = 
                new List<string>(output.Split("\n"))
                    .ConvertAll(l => l.Replace("\r", "").Trim());

            var authors = new HashSet<String>();
            var commitCount = 0;

            outputLines.ForEach(l =>
                {
                    var commitMatch = Regex.Match(l, "^commit ");
                    var authorMatch = Regex.Match(l, "^Author: (?<name>[^<]+)");

                    if (commitMatch.Success)
                    {
                        commitCount++;
                    }

                    if (authorMatch.Success)
                    {
                        authors.Add(authorMatch.Groups["name"].Value.Trim());
                    }
                });

            return new RepoReport
            {
                Authors = authors,
                CommitCount = commitCount,
            };
        }
    }
}
