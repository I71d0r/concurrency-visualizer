using System.ComponentModel;
using System.Diagnostics;

namespace Visualizer.Controls
{
    public partial class CpuLoad : Chart
    {
        PerformanceCounter cpuLoadCounter;

        public bool ReadCpuLoad { get; set; }

        public CpuLoad()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                cpuLoadCounter = new PerformanceCounter(
                    categoryName: "Processor",
                    counterName: "% Processor Time",
                    instanceName: "_Total");

                RefreshTimer.Tick += (s, e) =>
                    {
                        if (ReadCpuLoad)
                        {
                            AddValue((double)cpuLoadCounter?.NextValue());
                        }
                    };
            }
        }
    }
}
