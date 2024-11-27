using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private Rigidbody2D _rb;

    [Header("Attributes")]
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private int _bulletDamage = 1;

    private Transform target;

    private void FixedUpdate()
    {
        if (!target)
            return;

        Vector2 direction = (target.position - transform.position).normalized;

        _rb.linearVelocity = direction * _bulletSpeed;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(_bulletDamage);
        Destroy(gameObject);
    }
}
