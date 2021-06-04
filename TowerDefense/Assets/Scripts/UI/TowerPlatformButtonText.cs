using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlatformButtonText : MonoBehaviour
{
    public Effect effect;
    public Text textObject;
    void Start()
    {
        textObject.text = textObject.text + " - " + effect.cost.ToString();
    }
}
