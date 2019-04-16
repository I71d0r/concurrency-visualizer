using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Visualizer.UI;
using WorkplaceEngine.Contract;
using WorkplaceEngine.Execution;

namespace Visualizer
{
    public partial class Main : Form
    {
        const string StartText = "Start";
        const string StopText = "Stop";
        const string SynchronousItemText = "Synchronous";
        const string AsynchronousItemText = "Asynchronous";

        IExecutor executor;
        bool regenerate = true;
        readonly Stopwatch executionWatch = new Stopwatch();

        public Main()
        {
            InitializeComponent();
            LoadControls();

            refreshTimer.Enabled = true;

            workScopeGB.Controls
                .OfType<NumericUpDown>()
                .ToList()
                .ForEach(c => c.ValueChanged += (_, __) => RegenerateWork());
        }

        #region FormEvents

        private async void goButton_Click(object sender, EventArgs e)
        {
            if (executor == null || executor.State == WorkState.Cancelling)
                return;

            if (executor.State == WorkState.InProgress)
            {
                await executor.CancelAsync();
                executionWatch.Stop();

                workScopeGB.Enabled = true;
                goButton.Text = StartText;
            }
            else
            {
                workScopeGB.Enabled = false;
                goButton.Text = StopText;
                executor.ResetWorkItemsState();
                activeThreadChart.Reset();

                cpuLoadChart.ReadCpuLoad = true;

                executionWatch.Restart();
                await executor.ExecuteAsync();
                executionWatch.Stop();

                cpuLoadChart.ReadCpuLoad = false;

                goButton.Text = StartText;
                workScopeGB.Enabled = true;
            }
        }

        private void main_Resize(object sender, EventArgs e)
            => workProgress.Invalidate();

        private void refreshTimer_Tick(object sender, EventArgs e)
            => UpdateUIElements();

        private void itemGroupCB_SelectedIndexChanged(object sender, EventArgs e)
            => LoadCombos();

        private void processorTypeCB_SelectedIndexChanged(object sender, EventArgs e)
            => RegenerateWork();

        private void itemTypeCB_SelectedIndexChanged(object sender, EventArgs e)
            => RegenerateWork();

        private void generateWorkButton_Click(object sender, EventArgs e)
            => RegenerateWork();

        #endregion

        private void LoadControls()
        {
            itemGroupCB.Items.Clear();
            itemGroupCB.Items.Add(SynchronousItemText);
            itemGroupCB.Items.Add(AsynchronousItemText);
            itemGroupCB.SelectedIndex = 0;
            itemTypeCB.SelectedIndex = 0;
            processorTypeCB.SelectedIndex = 0;
        }

        private void LoadCombos()
        {
            regenerate = false;

            if (itemGroupCB.SelectedIndex == 0) // synchronous
            {
                UIHelper.LoadComboBox<ISyncWorkItem>(itemTypeCB);
                UIHelper.LoadComboBox<IWorkItemProcessor<ISyncWorkItem>>(processorTypeCB, includeMixed: false);
            }
            else
            {
                UIHelper.LoadComboBox<IAsyncWorkItem>(itemTypeCB);
                UIHelper.LoadComboBox<IWorkItemProcessor<IAsyncWorkItem>>(processorTypeCB, includeMixed: false);
            }

            regenerate = true;

            RegenerateWork();
        }

        private void RegenerateWork()
        {
            if (regenerate)
            {
                executor?.Dispose();
                executor = null;

                var itemType = (TypeItem)itemTypeCB.SelectedItem;
                var processorType = (TypeItem)processorTypeCB.SelectedItem;

                if (itemType == null || processorType == null)
                    return;

                executor?.Dispose();

                if (itemGroupCB.SelectedIndex == 0) // synchronous
                {
                    executor = WorkFactory.GenerateWork<ISyncWorkItem>(
                        minItemSize: (int)minSizeNDD.Value,
                        maxItemSize: (int)maxSizeNDD.Value,
                        itemCount: (int)itemCountNDD.Value,
                        itemTypes: itemType.Types,
                        processorType: processorType.Types.Single());
                }
                else
                {
                    executor = WorkFactory.GenerateWork<IAsyncWorkItem>(
                        minItemSize: (int)minSizeNDD.Value,
                        maxItemSize: (int)maxSizeNDD.Value,
                        itemCount: (int)itemCountNDD.Value,
                        itemTypes: itemType.Types,
                        processorType: processorType.Types.Single());
                }
            }
        }

        private void UpdateUIElements()
        {
            var snapshot = executor?.GetSnapshot();

            workProgress.SetData(snapshot);

            if (snapshot != null)
            {
                var activeItems = snapshot.Where(p => p.State == WorkState.InProgress);

                if (activeItems.Count() > 0)
                {
                    activeThreadChart.AddValue(
                        activeItems.Select(p => p.WorkThreadIds.LastOrDefault())
                                   .Where(t => t != 0)
                                   .Distinct()
                                   .Count());
                }
            }

            timeLabel.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                           executionWatch.Elapsed.Hours,
                                           executionWatch.Elapsed.Minutes,
                                           executionWatch.Elapsed.Seconds,
                                           executionWatch.Elapsed.Milliseconds);
        }
    }
}
