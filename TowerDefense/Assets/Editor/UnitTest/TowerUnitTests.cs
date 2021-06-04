using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class TowerUnitTests {
        // A Test behaves as an ordinary method
        [Test]
        public void TowerInitialization() {
            EntityManager.Instance = new EntityManager();
            EntityManager.Instance.onReload();
            TowerSystem t = new TowerSystem();
            t.runtimeData = new Tower(3);

            Assert.AreEqual(t.runtimeData.exp, 0);
            Assert.AreEqual(t.runtimeData.level, 1);
            Assert.AreEqual(t.runtimeData.isEnabled, true);
        }

        [Test]
        public void TowerExperience() {
            EntityManager.Instance = new EntityManager();
            EntityManager.Instance.onReload();
            TowerSystem t = new TowerSystem();
            t.platformSystem = new TowerPlatformSystem();
            t.runtimeData = new Tower(3);
            t.sharedData = Resources.Load<TowerData>("Data/Towers/NORMAL");
            int maxLevel = t.sharedData.expRequirements.Count;

            t.gainExp(5);
            Assert.AreEqual(t.runtimeData.exp, 5);

            t.runtimeData.exp = 0;
            t.gainExp(10);
            Assert.AreEqual(t.runtimeData.level, 2);

            t.runtimeData.exp = 0;
            t.gainExp(1000);
            Assert.AreEqual(t.runtimeData.level, maxLevel);

            t.runtimeData.exp = 0;
            t.runtimeData.level = 2;
            t.levelUp();
            Assert.AreEqual(t.runtimeData.level, 3);
            
            t.runtimeData.level = maxLevel-1;
            t.levelUp();
            Assert.AreEqual(t.runtimeData.level, maxLevel);
            
            t.runtimeData.level = maxLevel;
            t.levelUp();
            Assert.AreEqual(t.runtimeData.level, maxLevel);
        }

        [Test]
        public void TowerDisable() {
            EntityManager.Instance = new EntityManager();
            EntityManager.Instance.onReload();
            TowerSystem t = new TowerSystem();
            t.runtimeData = new Tower(3);
            t.sharedData = Resources.Load<TowerData>("Data/Towers/NORMAL");
            
            t.disable();
            Assert.AreEqual(t.runtimeData.isEnabled, false);
            
            t.disable();
            Assert.AreEqual(t.runtimeData.isEnabled, false);
            
            t.enable();
            Assert.AreEqual(t.runtimeData.isEnabled, true);

            t.disable();
            Assert.AreEqual(t.runtimeData.isEnabled, false);
        }

        [Test]
        public void TowerRefund() {
            EntityManager.Instance = new EntityManager();
            EntityManager.Instance.onReload();
            TowerSystem t = new TowerSystem();
            t.runtimeData = new Tower(3);
            t.sharedData = Resources.Load<TowerData>("Data/Towers/NORMAL");
            Player p = EntityManager.Instance.Player;

            p.money = 0;
            t.refundMoney();
            Assert.AreEqual(p.money, t.sharedData.cost);
        }
    }
}