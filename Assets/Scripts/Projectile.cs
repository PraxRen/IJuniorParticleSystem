using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _lifetime;
    [SerializeField] private ParticleSystem _hitVFXPrefab;

    private float _offsetSpawnEffect = 0.1f;
    private bool _isHited;

    public Rigidbody Rigidbody => _rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isHited)
            return;

        _isHited = true;
        Vector3 reflectDirection = CalculateVectorReflect(collision);
        CreateVFX(collision.contacts[0].point, reflectDirection);
        Destroy(gameObject, _lifetime);
    }

    private Vector3 CalculateVectorReflect(Collision collision)
    {
        Vector3 surfaceNormal = collision.contacts[0].normal;
        return Vector3.Reflect(transform.forward, surfaceNormal).normalized;
    }

    private void CreateVFX(Vector3 hitPoint, Vector3 reflectDirection)
    {
        ParticleSystem hitEffect = Instantiate(_hitVFXPrefab, hitPoint, Quaternion.LookRotation(reflectDirection));
        hitEffect.transform.position += reflectDirection * _offsetSpawnEffect;
        Destroy(hitEffect.gameObject, _lifetime);
    }
}
