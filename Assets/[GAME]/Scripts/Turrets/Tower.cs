using UnityEngine;
using System;

[Serializable]
public class Tower 
{
    public string Name;
    public int Cost;
    public GameObject TowerPrefab;

    public Tower (string name, int cost, GameObject towerPrefab)
    {
        Name = name;
        Cost = cost;
        TowerPrefab = towerPrefab;
    }
}
