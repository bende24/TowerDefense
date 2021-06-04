using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWave {

    [System.Serializable]
    public struct EnemySpawnData {
        // [ReadOnly]
        [SerializeField]
        public EnemyType type;
        [Range(0, 100)]
        public int count;

        public EnemySpawnData(EnemyType type) {
            this.type = type;
            count = 0;
        }
    }

    public enum EnemyType {
        Hellhound, Hellbeast, Nightmare, Ghost, Skeleton
    }

    public EnemySpawnData[] enemies;

    EnemyWave() {
        enemies = new EnemySpawnData[5];
        enemies[0] = new EnemySpawnData(EnemyType.Skeleton);
        enemies[1] = new EnemySpawnData(EnemyType.Hellhound);
        enemies[2] = new EnemySpawnData(EnemyType.Ghost);
        enemies[3] = new EnemySpawnData(EnemyType.Nightmare);
        enemies[4] = new EnemySpawnData(EnemyType.Hellbeast);
    }
}
