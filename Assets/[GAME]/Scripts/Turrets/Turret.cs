using UnityEngine;
using UnityEditor;
using System;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _turretRotationPoint;
    [SerializeField] private TurretData _redTurretData;
    [SerializeField] private Transform _firingPoint;

    private Transform target;
    private float timeUntilFire;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        if (!CheckTargetIsInRange())
        {
            target = null;
            return;

        }

        timeUntilFire += Time.deltaTime;

            if( timeUntilFire >= 1f / _redTurretData.Bps)
            {
                Shoot();
                timeUntilFire = 0;
            }
        

        RotateTowardsTarget();

    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(_redTurretData.BulletPrefab, _firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= _redTurretData.TargetingRange;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        _turretRotationPoint.rotation = Quaternion.RotateTowards(_turretRotationPoint.rotation, targetRotation, _redTurretData.RotationSpeed * Time.deltaTime);
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _redTurretData.TargetingRange, (Vector2)transform.position, 0f, _redTurretData.EnemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, _redTurretData.TargetingRange);
    }
}
