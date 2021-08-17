using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.IO.DriveInfo;

namespace Quasar.Common.Tests.CustomTest
{
    [TestClass]
    public class FileHelperTests
    {
        
        [TestMethod, TestCategory("Custom")]
        public void CompressionTest()
        {
            var driveInfos = GetDrives().Where(d => d.IsReady).ToArray();
            foreach (var driveInfo in driveInfos)
            {
                Console.Write(driveInfo.Name);
            }
        }
      
    }
}
