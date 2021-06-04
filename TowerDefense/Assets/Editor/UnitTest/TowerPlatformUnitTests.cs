using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TowerPlatformUnitTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Emptiness()
        {
            TowerPlatformSystem tp = new TowerPlatformSystem();
            
            Assert.AreEqual(tp.isEmpty, true);
        }
    }
}
