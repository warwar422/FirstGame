using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class HeroSkript : MonoBehaviour
{
    //speed
    public float speed = 10f;
    public float move;

    //one jump and check on ground
    bool grounded = false;
    public Transform GroundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    //move true face
    bool facingRight = true;

    //Spawn
    float PosX, PosY;

    //Animator
    private Animator animator;

    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        PosX = rigid.position.x;
        PosY = rigid.position.y;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.OverlapCircle(GroundCheck.position,groundRadius,whatIsGround);

        
        move = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(move * speed, rigid.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rigid.AddForce(new Vector2(0, 125f));
        }

        if (move < 0 && facingRight)
            Flip();
        else if (move > 0 && !facingRight)
            Flip();
        if (grounded)
        {
            animator.SetFloat("Speed", Mathf.Abs(move));
            animator.SetBool("OnGround", true);
        }
        else
            animator.SetBool("OnGround", false);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *=-1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DeathZone")
            rigid.position = new Vector2(PosX, PosY);
    }
}
