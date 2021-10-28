using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitMonitor
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void checkButton_Click(object sender, EventArgs e)
		{

			var repoLines = 
				this.reposTextBox.Text.Split("\r\n")
					.Where(l => !string.IsNullOrWhiteSpace(l))
					.ToList();

			var repoMatches =
				repoLines
					.Select(l => Regex.Match(
						l, "^(?<src>[^ ]*)[ ][-][>][ ](?<dst>[^ ]*)[ ][>][ ](?<max>[1-9]+) @ (?<loc>.*)"))
					.Where(m => m.Success)
					.ToList();

			var repoChecks = 
				repoMatches
					.Select(m => new RepoCheck
					{
						Source = m.Groups["src"].Value,
						Destination = m.Groups["dst"].Value,
						MaxCommits = int.Parse(m.Groups["max"].Value),
						Location = m.Groups["loc"].Value,
					})
					.ToList();

			var reports = repoChecks.Select(c => c.Run()).ToList();

			var reportBuilder = new StringBuilder();

            foreach (var repoCheck in repoChecks)
            {
				var report = repoCheck.Run();

				reportBuilder.AppendLine($"{report.CommitCount} commits pending for {repoCheck.Destination}");
				report.Authors.ToList().ForEach(a => reportBuilder.AppendLine($"* {a}"));

                if (report.CommitCount > repoCheck.MaxCommits)
                {
					reportBuilder.AppendLine();
					reportBuilder.AppendLine("TIME TO DEPLOY!");
				}

				reportBuilder.AppendLine();
			}

			this.reportTextBox.Text = reportBuilder.ToString();
		 }

        private void Form1_Load(object sender, EventArgs e)
        {
			const string configFileName = "Repos.txt";

            if (!File.Exists(configFileName))
            {
				using (File.CreateText(configFileName)) { }
			}

			this.reposTextBox.Text = File.ReadAllText(configFileName);
        }
    }
}
