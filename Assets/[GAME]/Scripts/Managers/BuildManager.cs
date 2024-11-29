using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]

    [SerializeField] private GameObject[] _towerPrefabs;

    private int selectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public GameObject GetSelectedTower()
    {
        return _towerPrefabs[selectedTower];
    }
}
