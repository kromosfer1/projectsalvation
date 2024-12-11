using System;
using UnityEngine;

public class SlowTower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask _enemyMask;

    [Header("Attributes")]
    [SerializeField] private float _targetingRange = 5f;
    [SerializeField] private float _aps = 3f; // attacks per second
    [SerializeField] private float _slowSpeed = 0.5f;

    private float timeUntilFire;

    private void Update()
    {
        timeUntilFire += Time.deltaTime;

        if (timeUntilFire >= 1f / _aps)
        {
            FreezeEnemies();
            timeUntilFire = 0;
        }

    }

    private void FreezeEnemies()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _targetingRange, (Vector2)transform.position, 0f, _enemyMask);

        if(hits.Length > 0)
        {
            for(int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                
            }
        }
    }
}
