using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider;

    [SerializeField] private LayerMask GroundLayer;

    public bool IsGrounded { get { return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.size, 0, Vector2.down, 0.15f, GroundLayer); } }

    [SerializeField] private float MoveSpeed, JumpForce;

    private bool _doubleJump;

    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float AttackRange;

    [SerializeField] private LayerMask EnemyLayer;

    [SerializeField] private Vector2 SpawnPos;
    private void Awake()
    {


        _rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _rb.gravityScale = 1.45f;

        SpawnPos = transform.position;
    }


    void Update()
    {
        Movement();

        if (IsGrounded)
            _doubleJump = false;

        Attack();

        if (Input.GetKeyDown(KeyCode.H))
        {
            Die();
        }
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2((x * Time.deltaTime * MoveSpeed) * 100, _rb.velocity.y);

        PlayerJump();

    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {

            if (IsGrounded)
            {
                Jump();
            }
            if (!IsGrounded && !_doubleJump)
            {
                Jump();
                _doubleJump = true;
            }
        }

    }


    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack");

            Collider2D[] hit = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayer);

            foreach (var item in hit)
            {
                Debug.Log(item.name);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameManager.Coin++;
            UIManager.Instance.Increase(1);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Checkpoint"))
        {
            SpawnPos = collision.transform.position;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Shop"))
        {
            Debug.Log("Shop");
            UIManager.Instance.ActiveShopPanel();
            
        }
    }

    public void Die()
    {
        Respawn();
    }

    private void Respawn()
    {
        transform.position = SpawnPos;
    }
    


}
