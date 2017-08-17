using System.Collections;
using UnityEngine;

[System.Serializable]  //unity saves and loads the values inside this class for us
public class TurretBlueprint {

    public GameObject prefab;
    public int cost;

    //add upgrade option
    //can put into an array to have more than 1 upgrade
    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()  //sell turrets for half of buying cost
    {
        return cost / 2;
    }

}
