using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField] private float runSpeed = 5f;
	[SerializeField] private float jumpSpeed = 5f;
	
	private Rigidbody2D _rigidBody;
	private BoxCollider2D _feetCollider;
	private Animator _animator;
	private LayerMask _foregroundLayerMask;
	private LayerMask _waterLayerMask;

	// Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _feetCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _foregroundLayerMask = 1 << LayerMask.NameToLayer("Foreground");
        _waterLayerMask = 1 << LayerMask.NameToLayer("Water");
    }

    // Update is called once per frame
    void Update()
    {
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
		if (Input.GetKeyDown(KeyCode.Space) && (_feetCollider.IsTouchingLayers(_foregroundLayerMask) || _feetCollider.IsTouchingLayers(_waterLayerMask)))
		{
			var newVerticalVelocity = new Vector2(0f, jumpSpeed);
			_rigidBody.velocity = newVerticalVelocity;
		}
	}

	private void FlipSprite()
	{
		var hasHorizontalSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;
		if (hasHorizontalSpeed)
		{
			transform.localScale = new Vector2(Mathf.Sign(_rigidBody.velocity.x), 1f);
		}
	}

	private void UpdateAnimation()
	{
		var hasHorizontalSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;
		_animator.SetBool("isRunning", hasHorizontalSpeed);
	}
}
