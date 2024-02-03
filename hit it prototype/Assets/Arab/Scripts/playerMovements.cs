using System.Drawing;
using UnityEngine;

public class playerMovements : MonoBehaviour
{
    public float speed = 200f;
    public float jumpPower = 500f;
    public float gravityMultiplayer = 2;
    public Animator anim;
    public LayerMask groundLayer = 3;
    private Rigidbody2D rb;
    bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale += 1;
    }
    private void Update()
    {
        //move
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(1,transform.localScale.y);
            rb.velocity = Vector2.right * speed * Time.deltaTime + new Vector2(0, rb.velocity.y);
            if (isGrounded)
            {
                SoundManager.Instance.Step();
                anim.SetBool("isRunning", true);
            }
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
            rb.velocity = Vector2.right * -speed * Time.deltaTime + new Vector2(0, rb.velocity.y);
            if (isGrounded)
            {
                SoundManager.Instance.Step();
                anim.SetBool("isRunning", true);
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //jump
        isGrounded = Physics2D.Raycast(transform.position,Vector2.down, .1f, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down ,UnityEngine.Color.red,.1f);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpPower);
        }
        if (!isGrounded)
        {
            rb.gravityScale += Time.deltaTime * gravityMultiplayer;
            anim.SetBool("isRunning", false);
        }
        else
        {
            rb.gravityScale = 1;
        }
    }
}
