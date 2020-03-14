using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator _animator;
    private CapsuleCollider2D _collider;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleHit();
    }

    private void HandleHit()
    {
        if (_collider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            _animator.SetBool("isHit", true);
            GetComponent<HealthSystem>().DecreaseHealth();
            DisableCollider();
            Invoke(nameof(EnableCollider), 2f);
        }
        
    }

    private void DisableCollider()
    {
        _collider.enabled = false;
    }

    private void EnableCollider()
    {
        _collider.enabled = true;
        _animator.SetBool("isHit", false);
    }
}
