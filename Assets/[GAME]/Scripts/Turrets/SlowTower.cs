using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlowTower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask _enemyMask;

    [Header("Attributes")]
    [SerializeField] private float _targetingRange = 5f;
    [SerializeField] private float _aps = 1f; // actions per second
    [SerializeField] private float _slowSpeed = 0.5f;
    [SerializeField] private float _slowTime = 1f;

    private Transform currentTarget;
    private float timeUntilFire;

    private void Update()
    {
        timeUntilFire += Time.deltaTime;
        // Check if the current target is still valid (exists and within range)
        if (currentTarget == null || !IsTargetInRange(currentTarget))
        {
            FindTarget();
        }

        // If there's a valid target, slow it periodically
        if (currentTarget != null)
        {
            
            if (timeUntilFire >= 1f / _aps)
            {
                ApplySlowEffect(currentTarget);
                timeUntilFire = 0f;
            }
        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _targetingRange, Vector2.zero, 0f, _enemyMask);
        if (hits.Length > 0)
        {
            currentTarget = hits[0].transform; // First enemy in range
        }
        else
        {
            currentTarget = null; // No target available
        }
    }

    private void ApplySlowEffect(Transform target)
    {
        if (target != null)
        {
            Debug.Log("slowed");
            Actions.UpdateEnemySpeed?.Invoke(target, _slowSpeed);
            StartCoroutine(ResetSlowAfterDelay(target));
        }
    }

    private IEnumerator ResetSlowAfterDelay(Transform target)
    {
        yield return new WaitForSeconds(_slowTime);

        // Reset speed only if the target is still in range
        if (target != null)
        {
            Actions.ResetEnemySpeed?.Invoke(target);
        }
    }

    private bool IsTargetInRange(Transform target)
    {
        return target != null && Vector2.Distance(transform.position, target.position) <= _targetingRange;
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, _targetingRange);
    }
}
