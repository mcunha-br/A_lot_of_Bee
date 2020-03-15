using UnityEngine;

public class GunShoot : MonoBehaviour
{

    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private AudioClip _gunSoundEffect;
    
    private float _force = 10f;

    private HealthSystem _healthSystem;

    // Start is called before the first frame update
    private void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (_healthSystem.IsAlive() && Input.GetButtonDown("Fire1"))
        {
            var bullet = Instantiate(_projectile, _firePoint.position, transform.rotation);
            var bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidBody.AddForce(_firePoint.right * _force, ForceMode2D.Impulse);
            SoundManager.PlaySound(_gunSoundEffect);
        }
    }
}
