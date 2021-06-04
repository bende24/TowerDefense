using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceComponent {
    public int exp;
    public int level;
    public Tower tower;
    public List<int> expRequirements;
    public List<Stats> stats;

    public ExperienceComponent(Tower tower) { 
        this.tower = tower;
        level = 1;
        exp = 0;
        //tower.stats = stats[level-1];
    }

    private void levelUp() {
        level++;
        //tower.stats = stats[level-1];
    }

    public void gainExp(int exp) {
        this.exp += exp;
        if (this.exp >= expRequirements[level - 1]) {
            levelUp();
        }
    }
}