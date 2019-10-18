using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour , IDamagable{

    private Rigidbody2D _rigid;
    [SerializeField]
    private float jumpforce = 6.0f;
    private bool resetJump = false;
    [SerializeField]
    private float speed = 3.0f;
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    private bool _grounded = false;
    private SpriteRenderer swordSprite;
    private Animator _anim;
    public int Health { get; set; }
    public int _diamonds;
    // Use this for initialization
    void Start () {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _anim = GetComponentInChildren<Animator>();
        Health = 4;
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        if(Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _playerAnim.Attack();
        }
        
    }
    //For moving the player.
    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();
        Flip(horizontalInput);
        
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, jumpforce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jump(true);
        }
        _rigid.velocity = new Vector2(horizontalInput * speed, _rigid.velocity.y);
        _playerAnim.move(horizontalInput);
    }
    //Checks if player is grounded or not.
    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f, 1<<8);
        Debug.DrawRay(transform.position, Vector2.down,Color.green);
        //if on the ground
        if(hit.collider != null)
        {
            if(resetJump == false)
            {
                _playerAnim.Jump(false);
                return true;
            }
                        
        }
        return false;
    }
    //Give some time before jumping is activated once more.
    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }
    //Flip sprite when direction changes.
    void Flip(float direction)
    {
        if(direction > 0)
        {
            _playerSprite.flipX = false;
            swordSprite.flipX = false;
            swordSprite.flipY = false;
            Vector3 newPos = swordSprite.transform.localPosition;
            newPos.x = 1.01f;
            swordSprite.transform.localPosition = newPos;
        }
        else if(direction < 0)
        {
            _playerSprite.flipX = true;
            swordSprite.flipX = true;
            swordSprite.flipY = true;
            Vector3 newPos = swordSprite.transform.localPosition;
            newPos.x = -1.01f;
            swordSprite.transform.localPosition = newPos;
        }
    }
    public void Damage()
    {
        Debug.Log("Damage called on player");
        Health -= 1;
        UIManager.Instance.UpdateLives(Health);
        if(Health < 1)
        {
            _playerAnim.Death();
            Destroy(this.gameObject, _anim.GetCurrentAnimatorStateInfo(0).length);
        }

    }
    public void AddGems(int amount)
    {
        _diamonds += amount;
        UIManager.Instance.UpdateGemCount(_diamonds);
    }
}
