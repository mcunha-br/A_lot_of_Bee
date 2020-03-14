using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{

    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _projectile;

    private float _force = 10f;
    private float _fireRate = 1f;
    private float _cooldownToNextShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(_projectile, _firePoint.position, Quaternion.identity);
            var bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidBody.AddForce(_firePoint.right * _force, ForceMode2D.Impulse);
            _cooldownToNextShoot = Time.deltaTime + _fireRate;
        }
    }
}
