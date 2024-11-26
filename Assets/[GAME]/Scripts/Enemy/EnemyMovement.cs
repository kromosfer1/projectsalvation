using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] private Rigidbody2D _rb;

    [Header ("ATTRIBUTES")]
    [SerializeField] private EnemyData _enemyData;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = EnemyPathManager.main.Path[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex >= EnemyPathManager.main.Path.Length)
            {
                Actions.OnEnemyDestroyed?.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = EnemyPathManager.main.Path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 dir = (target.position - transform.position).normalized;

        _rb.linearVelocity = dir * _enemyData._movementSpeed;
    }
}
