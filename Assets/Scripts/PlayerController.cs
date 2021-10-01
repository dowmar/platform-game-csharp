using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // start variable
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll; //collider
    

    

    //FSM
    private enum State {idle, running, jumping, falling, hurt, climb} //status int
    private State state = State.idle;

    //climb variables
    public bool canClimb = false;
    public bool bawahtangga = false;
    public bool atastangga = false;
    public Tangga tangga;
    private float naturalGravity;
    [SerializeField] float climbspeed = 3f;


    //inspector var
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpforce = 10f;
    
    [SerializeField] private float hurtforce = 10f;
    [SerializeField] private AudioSource berry;
    [SerializeField] private AudioSource footstep;
    [SerializeField] private string scenename;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        naturalGravity = rb.gravityScale;
        PermanentUI.perm.jmlnyawa.text = PermanentUI.perm.nyawa.ToString();
        
       
    }

    
    private void Update()
    {
        if(state == State.climb)
        {
            Climb();
        }
        else if (state != State.hurt)
        {
            Movement();
        }
        AnimationState();
        anim.SetInteger("state", (int)state); //manggil var anim(animasi) bwt setinteger = value integer state(Enumerator)
    }

    private void OnTriggerEnter2D(Collider2D collision) // skor cherry
    {
        if(collision.tag == "Koleksi")
        {
            berry.Play();
            Destroy(collision.gameObject);
            PermanentUI.perm.cherry += 1;
            PermanentUI.perm.CherryText.text = PermanentUI.perm.cherry.ToString();
            PlayerPrefs.SetInt("highscore", PermanentUI.perm.cherry);
        }
        if (collision.tag == "Powerup")
            BigPower(collision);
    }

    private void BigPower(Collider2D collision)
    {
        Debug.Log("powerup check"); //TODO 
        Destroy(collision.gameObject);
        speed = 8;
        jumpforce = 40f;
        GetComponent<SpriteRenderer>().color = Color.yellow;
        StartCoroutine(ResetPower());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy") //&& state == State.falling
        {
            Musuh musuh = other.gameObject.GetComponent<Musuh>();
            
            if(state == State.falling)
            {
                musuh.tindih();
                Jump();
            }
            else
            {
                state = State.hurt;
                NyawaSetting(); //nyawa berkurang update UI reset dari awal if nyawa = 0
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    //Musuh dikanan jadi kena damage dan player bergerak ke kiri
                    rb.velocity = new Vector2(-hurtforce, rb.velocity.y);
                }
                else
                {
                    //musuh di kiri ~~ kanan
                    rb.velocity = new Vector2(hurtforce, rb.velocity.y);
                }
            }

        }
    }

    //TODO fix
    private void NyawaSetting()
    {

        PermanentUI.perm.nyawa -= 1;
        PermanentUI.perm.jmlnyawa.text = PermanentUI.perm.nyawa.ToString();
        if (PermanentUI.perm.nyawa <= 0)
        {
            PlayerPrefs.SetInt("highscore", PermanentUI.perm.cherry);
            SceneManager.LoadScene("theend");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           // PermanentUI.perm.ResetSkor();
            
        }
    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if(canClimb && Mathf.Abs(Input.GetAxis("Vertical")) > .1f)
        {
            state = State.climb;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            transform.position = new Vector3(tangga.transform.position.x, rb.position.y);
           // rb.gravityScale = 0f;
        }

        //jalan ke kiri
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }

        // jalan ke kanan
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }

        // loncat TODO
       // if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
       if (Input.GetButtonDown("Jump"))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, 1.3f, ground);
            if(hit.collider != null)
            Jump();
        }
    }

    private void Jump() //function
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        state = State.jumping;
    }
    private void AnimationState()
    {
        if (state == State.climb)
        {

        }
        else if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            //jalan
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
       
    }

    private void langkah()
    {
        footstep.Play();
    }

    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(4);
        jumpforce = 25;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Climb()
    {
        if (Input.GetButtonDown("Jump"))
        {

            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            canClimb = false;
            rb.gravityScale = naturalGravity;
            anim.speed = 1f;
            Jump();
            return;
        }
        float vDirection = Input.GetAxis("Vertical");
        //naik
        if(vDirection > .1f && !atastangga)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0f, vDirection * climbspeed);
            anim.speed = 1f;
        }
        //turun
        else if(vDirection < -.1f && !bawahtangga)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0f, vDirection * climbspeed);
            anim.speed = 1f;
        }
        //default
        else
        {
            anim.speed = 0f;
            rb.velocity = Vector2.zero;
        }
    }
}
    