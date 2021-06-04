using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Data/Tower")]
public class TowerData : ScriptableObject{
    public int cost;
    public int upgradeCost;
    public TowerType type;
    public List<int> expRequirements;
    public List<Stats> stats;
}
