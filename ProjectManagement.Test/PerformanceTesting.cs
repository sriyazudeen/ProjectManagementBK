using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using System.Web.Http;
using System.Net.Http;
using ProjectManagementBK.Controllers;
using ProjectManagement.Entities;

namespace TaskManager.Test
{
    public class PerformanceTesting
    {
        


        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput,
        TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 600000)]
        public void Benchmark_Performance_ElaspedTime()
        {
            var controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();
        }

        

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Benchmark_Performance_GC()
        {
            var controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();
        }


        [PerfBenchmark(Description = "You can write your description here.",
        NumberOfIterations = 5, RunMode = RunMode.Throughput, RunTimeMilliseconds = 2500, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo,10485760)]
        public void Benchmark_Performance_Memory()
        {
            var controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();
        }
    }
}
