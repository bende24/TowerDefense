using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class EnemyUnitTests {

        [Test]
        public void EnemyInitialization() {
            EnemySystem enemy = new EnemySystem();
            EnemyData enemyData = Resources.Load<EnemyData>("Data/Enemies/Hellhound");
            enemy.enemy = new Enemy(enemyData);

            Assert.AreEqual(enemy.enemy.health, enemyData.health);
            Assert.AreEqual(enemy.enemy.expDrop, enemyData.xpValue);
            Assert.AreEqual(enemy.enemy.moneyDrop, enemyData.moneyValue);
            Assert.AreEqual(enemy.enemy.movespeed, enemyData.movementSpeed);
            Assert.AreEqual(enemy.enemy.damage, enemyData.damage);
            Assert.AreEqual(enemy.enemy.spawntime, enemyData.spawntime);
        }

        [Test]
        public void EnemyGetDamaged() {
            // From Player
            EnemySystem enemy = new EnemySystem();
            EnemyData enemyData = Resources.Load<EnemyData>("Data/Enemies/Hellhound");
            enemy.enemy = new Enemy(enemyData);
            enemy.recieveDamageFromPlayer(4);
            Assert.AreEqual(enemy.enemy.health, enemyData.health - 4);

            // From Tower
            enemy = new EnemySystem();
            enemy.enemy = new Enemy(enemyData);

            EntityManager.Instance = new EntityManager();
            EntityManager.Instance.onReload();

            TowerSystem t = new TowerSystem();
            t.runtimeData = new Tower(3);

            enemy.recieveDamage(t, 4);
            Assert.AreEqual(enemy.enemy.health, enemyData.health - 4);
        }

        [Test]
        public void EnemyDamage() {
            EnemySystem enemy = new EnemySystem();
            EnemyData enemyData = Resources.Load<EnemyData>("Data/Enemies/Hellhound");
            enemy.enemy = new Enemy(enemyData);
            enemy.isUnitTesting = true;

            BaseSystem basee = new BaseSystem();
            basee.baseData = new Base();

            EntityManager.Instance = new EntityManager();
            EntityManager.Instance.onReload();
            EntityManager.Instance.Base = basee;

            enemy.damage();
            Assert.AreNotEqual(basee.baseData.health, 100);
        }

        [Test]
        public void EnemyGiveMoney() {
            EnemySystem enemy = new EnemySystem();
            EnemyData enemyData = Resources.Load<EnemyData>("Data/Enemies/Hellhound");
            enemy.enemy = new Enemy(enemyData);

            Player player = new Player();
            player.money = 0;

            EntityManager.Instance = new EntityManager();
            EntityManager.Instance.onReload();
            EntityManager.Instance.Player = player;

            enemy.giveMoney();

            Assert.AreEqual(player.money, enemy.enemy.moneyDrop);
        }

        [Test]
        public void EnemyGiveReward() {
            EnemySystem enemy = new EnemySystem();
            EnemyData enemyData = Resources.Load<EnemyData>("Data/Enemies/Hellhound");
            enemy.enemy = new Enemy(enemyData);

            EntityManager.Instance = new EntityManager();
            EntityManager.Instance.onReload();

            TowerSystem t = new TowerSystem();
            t.runtimeData = new Tower(3);
            t.sharedData = Resources.Load<TowerData>("Data/Towers/NORMAL");

            enemy.giveReward(t);

            Assert.AreEqual(t.runtimeData.exp, enemy.enemy.expDrop);
        }
    }
}