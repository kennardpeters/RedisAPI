using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedisAPI.Models;

namespace RedisAPITest;

[TestClass]
public class RedisPlatformRepoTest
{
    [TestMethod]
    public void TestMethod1()
    {
        string [] words = {"Alphabet", "Aebra", "ABC"};
        foreach(var word in words) {
            bool result = word.StartsWith("A");
            Assert.IsTrue(result,
            String.Format("Expected for '{0}': true; Actual: {1}",
                                 word, result));
        }
    }

    [TestMethod]
    public void isPlatform()
    {
        Platform plat = new Platform();
        plat.Name = "Testing Platform";
        // bool result = (plat.GetType() == typeof(Platform));
        bool result = (plat is Platform);
        Assert.IsTrue(result,
                    String.Format("Expected for '{0}': true; Actual: {1}", plat, result));
        
    }

}