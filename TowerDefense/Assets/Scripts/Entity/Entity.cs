using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity {
    protected static int entityId = 0;
    public int id;

    public Entity() {
        id = entityId;
        entityId++;
    }
}