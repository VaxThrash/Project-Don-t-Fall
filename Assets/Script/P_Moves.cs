using System.Collections; // Pour Coroutine
using UnityEngine;

public class P_Moves : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float groundChekRadius;

    private float horizontalMovement;

    private bool isJumping;    
    private bool isGrounded;

    public Transform groundChek;

    public LayerMask collisionLayers;

    public Rigidbody2D rb;

    private Vector3 velocity = Vector3.zero;

   public Animator animatorDeath;

   public BoxCollider2D boxCollider2D;



    void Start()
    {
        // Trouve et active la hitBox 2D
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = true;
        // Désactive la 1ière animation
        animatorDeath.enabled = false;
    }

    void Update ()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
            //chrono.StartChrono();
        }
    }
    
    void FixedUpdate ()
    {
       
        isGrounded = Physics2D.OverlapCircle(groundChek.position, groundChekRadius, collisionLayers);
        
        MovePlayer(horizontalMovement);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
    }

    public void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundChek.position, groundChekRadius);
    }

    // Animation Death
 public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AnimatorDeath"))
        {
            // Active et joue l'animation
            animatorDeath.enabled = true;
            animatorDeath.SetTrigger("Dead");
            //Démarre la couroutine ResetHitBoxcolider2d
            StartCoroutine(ResetBoxCollider2D());
            
        }
    }

    // Coroutine Desactive/Active la BoxCillider2D (1 seconde)
    public IEnumerator ResetBoxCollider2D()
    {
        //Désactive la HitBox2D
        boxCollider2D.enabled = false;
        // Attend 1 seconds | Desactive le la HitBox2D
        yield return new WaitForSeconds(1f);
        // Active la HitBox2D
        boxCollider2D.enabled = true;

    }
}