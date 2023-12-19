using UnityEngine;

public class InputController : MonoBehaviour
{
    //General Components
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private KeyCode _JumpButton;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _froggoSprite;

    // AirJumps
    private bool _hasJumped;
    public int MaxJumps;
    private int _jumpCount;


    void Update()
    {
        
        float inputDir = Input.GetAxis("Horizontal");

        _froggoSprite.flipX = inputDir < 0;

        _animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + inputDir, transform.position.y, 0), Time.deltaTime * _moveSpeed);


        if (Input.GetKeyDown(_JumpButton))
        {
            if (_jumpCount < MaxJumps){
                Jump();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
            LandPlayer();

    }

    private void Jump(){
       _rb.AddForce(Vector2.up * _jumpForce);
            _animator.SetBool("IsOnGround", false);
            _animator.SetBool("IsJumped", true);
            _hasJumped = true; 
            _jumpCount += 1;
    }

    private void LandPlayer(){
        _animator.SetBool("IsOnGround", true);
            _animator.SetBool("IsJumped", false);
            _hasJumped = false;
            _jumpCount = 0;
            Debug.Log("OnGround true");
    }
}
