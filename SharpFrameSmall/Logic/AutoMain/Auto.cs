using Prism.Events;
using SharpFrameSmall.Logic.Base;
using SharpFrameSmall.Structure.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpFrameSmall.Logic.AutoMain
{
    public class Auto : ProcessBase
    {
        public enum MyEnum
        {
            One,Two
        }

        public override ManualResetEvent Interrupt { get ; set ; }

        public override event Action<DateTime, string> LogEvent;

        public IEventAggregator eventAggregator { get; set; }

        public ParameterStore Store { get; set; }

        protected override void OnGetShared()
        {
            eventAggregator = GetShared<IEventAggregator>();
            Store = GetShared<ParameterStore>();
        }

        public override void Initialize(ProcessBase thread)
        {

        }

        protected override void Main(ProcessBase thread)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected override void ThreadError(string class_na, ProcessBase thread, Exception exception)
        {
        }

        protected override void ThreadRestartEvent(string class_na, ProcessBase thread, ThreadAbortException ex)
        {

        }
    }
}
