using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

[assembly: LevelOfParallelism(4)]
namespace AutoTest
{
    [TestFixture]
    [Parallelizable]
    public class LoggingTests
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LoggingTests()
        {
            FileInfo fileInfo = new FileInfo(@"D:\Tsypliak\HomeTask1-master\AutoTest\Log4Net.config");
            log4net.Config.XmlConfigurator.Configure(fileInfo);
        }
        [SetUp]
        public void StartTest()
        {
            string TestName = TestContext.CurrentContext.Test.Name;
            log.Info(TestName);
            TestContext.Out.WriteLine(TestName);
        }
        [TearDown]
        public void EndTest()
        {
            //string AssertsInTest = TestContext.CurrentContext.Result.Message;
            //log.Debug(TestContext.CurrentContext.Result.Message.Length);
            //if (TestContext.CurrentContext.Result.Message.Length == 0)
            //{
            //    log.Debug("Passed");
            //}
            //else
            //{
            //    log.Debug(AssertsInTest);
            //}
            string status = Convert.ToString(TestContext.CurrentContext.Result.Outcome.Status);
            log.Debug("Status = " + status);
            TestContext.Out.WriteLine("Status = " + status);
            string error = TestContext.CurrentContext.Result.Message;
            if(!String.IsNullOrEmpty(error))
            {
                log.Error(error);
                TestContext.Out.WriteLine("Error: "+ error);
            }
        }
    }
}
