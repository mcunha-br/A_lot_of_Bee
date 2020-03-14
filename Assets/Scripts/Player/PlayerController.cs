using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider2D _collider;
    private HealthSystem _healthSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _healthSystem = GetComponent<HealthSystem>();
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
            StartCoroutine(BlinkPlayer());
            _healthSystem.DecreaseHealth();
            // Dá um tempo pro jogador fugir dos inimigos antes de levar um hit novamente.
            DisableCollider();
            Invoke(nameof(EnableCollider), 2f);
        }
        
    }

    private IEnumerator BlinkPlayer() {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = Color.white;
    }
    
    private void DisableCollider()
    {
        _collider.enabled = false;
    }

    private void EnableCollider()
    {
        _collider.enabled = true;
    }
}
