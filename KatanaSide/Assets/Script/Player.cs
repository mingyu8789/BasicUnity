using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
     [Header("?? ?΄?΄ ??±")]
    public float speed = 5;
    public float jumpUp = 1;
    public float power = 5;
    public Vector3 direction;
    public GameObject slash;

    //κ·Έλ¦Ό?
    public GameObject Shadow1;
    List<GameObject> sh = new List<GameObject>();

    //??Έ ?΄??Έ
    public GameObject hit_lazer;




    Animator pAnimator;
    Rigidbody2D pRig2D;
    SpriteRenderer sp;

    public GameObject Jdust;


    //λ²½μ ?
    public Transform wallChk;
    public float wallchkDistance;
    public LayerMask wLayer;
    bool isWall;
    public float slidingSpeed;
    public float wallJumpPower;
    public bool isWallJump;
    float isRight = 1;


    public GameObject walldust;


    void Start()
    {
        pAnimator = GetComponent<Animator>();
        pRig2D = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
        sp = GetComponent<SpriteRenderer>();

    }


    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal"); //?Όμͺ½μ?? -1   0   1

        if(direction.x <0)
        {
            //left
            sp.flipX = true;
            pAnimator.SetBool("Run", true);

            //? ?λ²½μ‘κΈ? λ°©ν₯
            isRight = -1;


            //Shadowflip
            for(int i =0; i<sh.Count; i++)
            {
                sh[i].GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }

        }
        else if(direction.x >0)
        {
            //right
            sp.flipX = false;
            pAnimator.SetBool("Run", true);

            isRight = 1;

            //Shadowflip
            for (int i = 0; i < sh.Count; i++)
            {
                sh[i].GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }


        }
        else if(direction.x == 0)
        {
            pAnimator.SetBool("Run", false);


            for (int i = 0; i < sh.Count; i++)
            {
                Destroy(sh[i]); //κ²μ?€λΈμ ?Έμ§??°κΈ?
                sh.RemoveAt(i); //κ²μ?€λΈμ ?Έ κ΄?λ¦¬ν? λ¦¬μ€?Έμ§??°κΈ?
            }





        }


        if (Input.GetMouseButtonDown(0)) //0λ²? ?Όμͺ½λ§?°?€
        {
            pAnimator.SetTrigger("Attack");
            Instantiate(hit_lazer, transform.position, Quaternion.identity);

        }




    }

    
    void Update()
    {
        
        //?κ°? μ‘°μ  ?? ₯ μ²΄ν¬ (?Όμͺ? ???Έ ?€λ₯? ?λ₯΄λ©΄ ?¬λ‘μ° λͺ¨μ ??)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //?¬?€?Έ?λ‘μΈ?± ?λ©΄ν¨κ³?
            TimeController.Instance.SetSlowMotion(true); //?¬λ‘μ° λͺ¨μ ??
        }
        if(!isWallJump)
        {
            KeyInput();
            Move();
        }
       


        //λ²½μΈμ§? μ²΄ν¬
        isWall = Physics2D.Raycast(wallChk.position, Vector2.right * isRight, wallchkDistance, wLayer);
        pAnimator.SetBool("Grab", isWall);





        if(Input.GetKeyDown(KeyCode.W))
        {
            if(pAnimator.GetBool("Jump")==false)
            {
                Jump();
                pAnimator.SetBool("Jump", true);
                JumpDust();
            }
          
        }



        if(isWall)
        {
            isWallJump = false;
            //λ²½μ ???
            pRig2D.linearVelocity = new Vector2(pRig2D.linearVelocityX, pRig2D.linearVelocityY * slidingSpeed);
            //λ²½μ ?‘κ³ μ? ???? ? ?
            if(Input.GetKeyDown(KeyCode.W))
            {
                isWallJump = true;
                //λ²½μ ? λ¨Όμ??
                GameObject go = Instantiate(walldust, transform.position + new Vector3(0.8f * isRight, 0, 0), Quaternion.identity);
                go.GetComponent<SpriteRenderer>().flipX = sp.flipX;

                Invoke("FreezeX", 0.3f);
                //λ¬Όλ¦¬
                pRig2D.linearVelocity = new Vector2(-isRight * wallJumpPower, 0.9f * wallJumpPower);

                sp.flipX = sp.flipX == false ? true : false;
                isRight = -isRight;
                
            }

        }

    }


    void FreezeX()
    {
        isWallJump = false;
    }



   





    private const float GROUND_CHECK_DISTANCE = 0.7f;



    private void FixedUpdate()
 {
     Debug.DrawRay(pRig2D.position, Vector3.down, new Color(0, GROUND_CHECK_DISTANCE, 0));

     //? ?΄μΊμ€?Έλ‘? ?μ²΄ν¬ 
     RaycastHit2D rayHit = Physics2D.Raycast(pRig2D.position, Vector3.down, GROUND_CHECK_DISTANCE, LayerMask.GetMask("Ground"));

     CheckGroundedState(rayHit);
 }


 void CheckGroundedState(RaycastHit2D rayHit)
 {

     bool isGrounded = rayHit.collider != null && rayHit.distance < GROUND_CHECK_DISTANCE;
    
     if (isGrounded)
     {
             pAnimator.SetBool("Jump", false);                
     }
     else
     {
         //?¨?΄μ§?κ³? ??€
         if (!isWall)
         {
             //κ·Έλ₯ ?¨?΄μ§??μ€?
             pAnimator.SetBool("Jump", true);
         }
         else
         {
             //λ²½ν??κΈ?
             pAnimator.SetBool("Grab", true);
         }
     }   
     
 }





    public void Jump()
    {
        pRig2D.linearVelocity = Vector2.zero;

        pRig2D.AddForce(new Vector2(0, jumpUp), ForceMode2D.Impulse);
    }





    public void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }



    public void AttSlash()
    {
        //?? ?΄?΄ ?€λ₯Έμͺ½
        if(sp.flipX == false)
        {
            pRig2D.AddForce(Vector2.right * power, ForceMode2D.Impulse);
            //?? ?΄?΄ ?€λ₯Έμͺ½
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
        }
        else
        {

            pRig2D.AddForce(Vector2.left * power, ForceMode2D.Impulse);
            //?Όμͺ?
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
        }   

    }

    //κ·Έλ¦Ό?
    public void RunShadow()
    {
        if(sh.Count<6)
        {
            GameObject go = Instantiate(Shadow1, transform.position, Quaternion.identity);
            go.GetComponent<Shadow>().TwSpeed = 10 - sh.Count; 
            sh.Add(go);
        }
    }



    //?λ¨Όμ??
    public void RandDust(GameObject dust)
    {



        Instantiate(dust, transform.position +new Vector3(-0.114f,-0.467f,0), Quaternion.identity);




    }

    //? ?λ¨Όμ??
    public void JumpDust()
    {
        if(!isWall)
        {
            Instantiate(Jdust, transform.position, Quaternion.identity);
            Debug.Log("? ?λ¨Όμ?? ??±μ€μ΄?Ό");
        }
        else
        {
            //λ²½λ¨Όμ§?
            //Instantiate(walldust, transform.position, Quaternion.identity);
            //Debug.Log("?λ²½λ¨Όμ§? ??±μ€μ΄?Ό");
        }

      
    }

    //λ²½μ ?
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(wallChk.position, Vector2.right * isRight * wallchkDistance);
    }

   private void OnTriggerEnter2D(Collider2D other)
 {
     //ΊΈ½Ί Ύΐ ΑψΐΤ ΖχΕ»°ϊ Γζ΅Ή ΓΌΕ©
     if(other.CompareTag("BossScene"))
     {
         //ΊΈ½Ί ΎΐΐΈ·Ξ ΐόΘ―
         SceneManager.LoadScene("Boss");
     }
 }
}