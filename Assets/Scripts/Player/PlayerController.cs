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
        _animator.SetBool("isHit", _collider.IsTouchingLayers(LayerMask.GetMask("Enemy")));
    }
}
