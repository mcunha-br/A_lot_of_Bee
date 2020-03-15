using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField] private float runSpeed = 5f;
	[SerializeField] private float jumpSpeed = 5f;
	[SerializeField] private AudioClip jumpEffect;
	
	private Rigidbody2D _rigidBody;
	private BoxCollider2D _feetCollider;
	private Animator _animator;
	private HealthSystem _healthSystem;
	private LayerMask _foregroundLayerMask;
	private LayerMask _waterLayerMask;

	// Controles pra evitar que o personagem fique rodando infinitamente.
	private bool _isAlreadyFacingRight = true;
	private bool _isAlreadyFacingLeft = false;

	// Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _feetCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _healthSystem = GetComponent<HealthSystem>();
        _foregroundLayerMask = 1 << LayerMask.NameToLayer("Foreground");
        _waterLayerMask = 1 << LayerMask.NameToLayer("Water");
    }

    // Update is called once per frame
    void Update()
    {
	    if (!_healthSystem.IsAlive())
	    {
		    return;
	    }
	    
	    Run();
	    Jump();
	    FlipSprite();
	    UpdateAnimation();
    }
    
    private void Run() {
		Vector2 newHorizontalVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, _rigidBody.velocity.y);
		_rigidBody.velocity = newHorizontalVelocity;
	}

	private void Jump()
	{
		if (Input.GetButtonDown("Jump") && (_feetCollider.IsTouchingLayers(_foregroundLayerMask) || _feetCollider.IsTouchingLayers(_waterLayerMask)))
		{
			var newVerticalVelocity = new Vector2(0f, jumpSpeed);
			_rigidBody.velocity = newVerticalVelocity;
			SoundManager.PlaySound(jumpEffect);
		}
	}

	private void FlipSprite()
	{
		var hasHorizontalSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;
		var isFacingRight = Mathf.Sign(Input.GetAxisRaw("Horizontal")) > 0f;
		if (hasHorizontalSpeed)
		{
			if (isFacingRight && !_isAlreadyFacingRight)
			{
				transform.Rotate(0f, 180f, 0f);
				_isAlreadyFacingLeft = false;
				_isAlreadyFacingRight = true;
			} else if (!isFacingRight && !_isAlreadyFacingLeft)
			{
				transform.Rotate(0f, 180f, 0f);
				_isAlreadyFacingLeft = true;
				_isAlreadyFacingRight = false;
			}
		}
	}

	private void UpdateAnimation()
	{
		var hasHorizontalSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;
		_animator.SetBool("isRunning", hasHorizontalSpeed);
	}
}
