using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class PlayerUnitTests {
        // A Test behaves as an ordinary method
        [Test]
        public void MoneyChecks() {
            Player player = new Player();

            player.money = 100;
            player.pay(50);
            Assert.AreEqual(player.money, 50);
            player.money = 100;
            player.pay(500);
            Assert.AreEqual(player.money, 0);
            player.money = 100;
            player.earnMoney(50);
            Assert.AreEqual(player.money, 150);
        }
    }
}