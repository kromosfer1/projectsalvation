using UnityEngine;

public class EnemyPathManager : MonoBehaviour
{
    public static EnemyPathManager main;

    private void Awake()
    {
        main = this;
    }

    public Transform[] Path;
    public Transform StartPoint;
}