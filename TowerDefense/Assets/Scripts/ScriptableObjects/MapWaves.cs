using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneName", menuName = "Data/MapWaves")]
public class MapWaves : ScriptableObject {

    [Range(0.0f, 30.0f)]
    public float waittime;
    public EnemyWave[] waves;

    void Reset() {
        waves = new EnemyWave[1];
    }
}
