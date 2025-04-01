using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
     [Header("?îå?†à?ù¥?ñ¥ ?Üç?Ñ±")]
    public float speed = 5;
    public float jumpUp = 1;
    public float power = 5;
    public Vector3 direction;
    public GameObject slash;

    //Í∑∏Î¶º?ûê
    public GameObject Shadow1;
    List<GameObject> sh = new List<GameObject>();

    //?ûà?ä∏ ?ù¥?éô?ä∏
    public GameObject hit_lazer;




    Animator pAnimator;
    Rigidbody2D pRig2D;
    SpriteRenderer sp;

    public GameObject Jdust;


    //Î≤ΩÏ†ê?îÑ
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
        direction.x = Input.GetAxisRaw("Horizontal"); //?ôºÏ™ΩÏ?? -1   0   1

        if(direction.x <0)
        {
            //left
            sp.flipX = true;
            pAnimator.SetBool("Run", true);

            //?†ê?îÑÎ≤ΩÏû°Í∏? Î∞©Ìñ•
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
                Destroy(sh[i]); //Í≤åÏûÑ?ò§Î∏åÏ†ù?ä∏Ïß??ö∞Í∏?
                sh.RemoveAt(i); //Í≤åÏûÑ?ò§Î∏åÏ†ù?ä∏ Í¥?Î¶¨Ìïò?äî Î¶¨Ïä§?ä∏Ïß??ö∞Í∏?
            }





        }


        if (Input.GetMouseButtonDown(0)) //0Î≤? ?ôºÏ™ΩÎßà?ö∞?ä§
        {
            pAnimator.SetTrigger("Attack");
            Instantiate(hit_lazer, transform.position, Quaternion.identity);

        }




    }

    
    void Update()
    {
        
        //?ãúÍ∞? Ï°∞Ï†à ?ûÖ?†• Ï≤¥ÌÅ¨ (?ôºÏ™? ?ãú?îÑ?ä∏ ?Ç§Î•? ?àÑÎ•¥Î©¥ ?ä¨Î°úÏö∞ Î™®ÏÖò ?ãú?ûë)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //?è¨?ä§?ä∏?îÑÎ°úÏÑ∏?ã± ?ôîÎ©¥Ìö®Í≥?
            TimeController.Instance.SetSlowMotion(true); //?ä¨Î°úÏö∞ Î™®ÏÖò ?ãú?ûë
        }
        if(!isWallJump)
        {
            KeyInput();
            Move();
        }
       


        //Î≤ΩÏù∏Ïß? Ï≤¥ÌÅ¨
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
            //Î≤ΩÏ†ê?îÑ?ÉÅ?Éú
            pRig2D.linearVelocity = new Vector2(pRig2D.linearVelocityX, pRig2D.linearVelocityY * slidingSpeed);
            //Î≤ΩÏùÑ ?û°Í≥†Ïûà?äî ?ÉÅ?Éú?óê?Ñú ?†ê?îÑ
            if(Input.GetKeyDown(KeyCode.W))
            {
                isWallJump = true;
                //Î≤ΩÏ†ê?îÑ Î®ºÏ??
                GameObject go = Instantiate(walldust, transform.position + new Vector3(0.8f * isRight, 0, 0), Quaternion.identity);
                go.GetComponent<SpriteRenderer>().flipX = sp.flipX;

                Invoke("FreezeX", 0.3f);
                //Î¨ºÎ¶¨
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

     //?†à?ù¥Ï∫êÏä§?ä∏Î°? ?ïÖÏ≤¥ÌÅ¨ 
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
         //?ñ®?ñ¥Ïß?Í≥? ?ûà?ã§
         if (!isWall)
         {
             //Í∑∏ÎÉ• ?ñ®?ñ¥Ïß??äîÏ§?
             pAnimator.SetBool("Jump", true);
         }
         else
         {
             //Î≤ΩÌ??Í∏?
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
        //?îå?†à?ù¥?ñ¥ ?ò§Î•∏Ï™Ω
        if(sp.flipX == false)
        {
            pRig2D.AddForce(Vector2.right * power, ForceMode2D.Impulse);
            //?îå?†à?ù¥?ñ¥ ?ò§Î•∏Ï™Ω
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
        }
        else
        {

            pRig2D.AddForce(Vector2.left * power, ForceMode2D.Impulse);
            //?ôºÏ™?
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
        }   

    }

    //Í∑∏Î¶º?ûê
    public void RunShadow()
    {
        if(sh.Count<6)
        {
            GameObject go = Instantiate(Shadow1, transform.position, Quaternion.identity);
            go.GetComponent<Shadow>().TwSpeed = 10 - sh.Count; 
            sh.Add(go);
        }
    }



    //?ùôÎ®ºÏ??
    public void RandDust(GameObject dust)
    {



        Instantiate(dust, transform.position +new Vector3(-0.114f,-0.467f,0), Quaternion.identity);




    }

    //?†ê?îÑÎ®ºÏ??
    public void JumpDust()
    {
        if(!isWall)
        {
            Instantiate(Jdust, transform.position, Quaternion.identity);
            Debug.Log("?†ê?îÑÎ®ºÏ?? ?Éù?Ñ±Ï§ëÏù¥?ïº");
        }
        else
        {
            //Î≤ΩÎ®ºÏß?
            //Instantiate(walldust, transform.position, Quaternion.identity);
            //Debug.Log("?ÇòÎ≤ΩÎ®ºÏß? ?Éù?Ñ±Ï§ëÏù¥?ïº");
        }

      
    }

    //Î≤ΩÏ†ê?îÑ
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(wallChk.position, Vector2.right * isRight * wallchkDistance);
    }

   private void OnTriggerEnter2D(Collider2D other)
 {
     //∫∏Ω∫ æ¿ ¡¯¿‘ ∆˜≈ª∞˙ √Êµπ √º≈©
     if(other.CompareTag("BossScene"))
     {
         //∫∏Ω∫ æ¿¿∏∑Œ ¿¸»Ø
         SceneManager.LoadScene("Boss");
     }
 }
}