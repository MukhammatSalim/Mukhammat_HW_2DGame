using UnityEngine;
public class InputController : MonoBehaviour
{
    //General Components
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private KeyCode _JumpButton;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _froggoSprite;

    // AirJumps
    public int MaxJumps;
    private int _jumpCount;


    void Update()
    {
        // Movement
        float inputDir = Input.GetAxis("Horizontal");

        _froggoSprite.flipX = inputDir < 0;

        _animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + inputDir, transform.position.y, 0), Time.deltaTime * _moveSpeed);

        //Jumps and AirJumps
        if (Input.GetKeyDown(_JumpButton))
        {
            if (_jumpCount == 0){
                Jump();
            }else if (_jumpCount < MaxJumps){
                AirJump();
            }
        }
    }

    public void PlayerDeath(){
        Debug.Log("PlayerIsDead");
        _player.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
            LandPlayer(); //Reset jumps 

    }

    private void Jump(){
        _rb.AddForce(Vector2.up * _jumpForce);
        _animator.SetBool("IsOnGround", false);
        _animator.SetBool("HasJumped", true);
        _jumpCount += 1;
    }

    private void AirJump(){
        _rb.AddForce(Vector2.up * _jumpForce);
        _animator.SetBool("HasAirJumped", true);


    }

    private void LandPlayer(){
        _animator.SetBool("IsOnGround", true);
            _animator.SetBool("IsJumped", false);
            _jumpCount = 0;
    }

    public void MakeDMG(){
        _animator.SetBool("IsDead", true);
    }
}
