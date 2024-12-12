using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] private Rigidbody2D _rb;

    [Header ("ATTRIBUTES")]
    [SerializeField] private EnemyData _enemyData;

    private Transform target;
    private int pathIndex = 0;

    private float movementSpeed;

    private void OnEnable()
    {
        Actions.UpdateEnemySpeed += UpdateSpeed;
        Actions.ResetEnemySpeed += ResetSpeed;
    }

    private void OnDisable()
    {
        Actions.UpdateEnemySpeed -= UpdateSpeed;
        Actions.ResetEnemySpeed -= ResetSpeed;
    }

    private void Start()
    {
        movementSpeed = _enemyData.BaseMovementSpeed;
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

        _rb.linearVelocity = dir * movementSpeed;
    }

    public void UpdateSpeed(Transform target, float newSpeed)
    {
        if (target == transform)
        {
            movementSpeed = newSpeed;
        }
    }

    public void ResetSpeed(Transform target)
    {
        if (target == transform)
        {
            movementSpeed = _enemyData.BaseMovementSpeed;
        }
    }
}
