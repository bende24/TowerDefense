using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class BaseUnitTests {
        [Test]
        public void BaseGetDamaged() {
            Base basee = new Base();
            basee.isUnitTesting = true;

            basee.health = 100;
            basee.getDamaged(10);
            Assert.AreEqual(basee.health, 90);

            basee.health = 100;
            basee.getDamaged(110);
            Assert.IsTrue(basee.isDead);
        }
    }
}
