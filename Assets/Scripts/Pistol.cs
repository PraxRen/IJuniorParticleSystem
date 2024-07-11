using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _force;

    public void Shot()
    {
        Projectile projectile = Instantiate(_projectilePrefab, _startPoint.position, transform.rotation);
        projectile.Rigidbody.velocity = transform.forward * _force;
    }
    
}
