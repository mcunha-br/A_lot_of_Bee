using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider2D _collider;
    private HealthSystem _healthSystem;
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    private bool _isAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _healthSystem = GetComponent<HealthSystem>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_healthSystem.IsAlive()) return;
        
        HandleHit();
        Die();
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

    private void Die()
    {
        if (!_healthSystem.IsAlive() || _collider.IsTouchingLayers(LayerMask.GetMask("OutMapCollider")))
        {
            _healthSystem.SetPlayerIsDead(true);
            // Adiciona uma morte mais dramática.
            _rigidBody.velocity = new Vector2(5f, 5f);
            transform.Rotate(0f, 0f, 90f);
            // TODO Aqui deveria ser um estado na máquina de estados.
            _animator.enabled = false;
            // Carrega a tela de "Game Over".
            FindObjectOfType<UIManager>().LoadDeathScreen();
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
