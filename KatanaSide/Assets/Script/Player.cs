using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
     [Header("?��?��?��?�� ?��?��")]
    public float speed = 5;
    public float jumpUp = 1;
    public float power = 5;
    public Vector3 direction;
    public GameObject slash;

    //그림?��
    public GameObject Shadow1;
    List<GameObject> sh = new List<GameObject>();

    //?��?�� ?��?��?��
    public GameObject hit_lazer;




    Animator pAnimator;
    Rigidbody2D pRig2D;
    SpriteRenderer sp;

    public GameObject Jdust;


    //벽점?��
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
        direction.x = Input.GetAxisRaw("Horizontal"); //?��쪽�?? -1   0   1

        if(direction.x <0)
        {
            //left
            sp.flipX = true;
            pAnimator.SetBool("Run", true);

            //?��?��벽잡�? 방향
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
                Destroy(sh[i]); //게임?��브젝?���??���?
                sh.RemoveAt(i); //게임?��브젝?�� �?리하?�� 리스?���??���?
            }





        }


        if (Input.GetMouseButtonDown(0)) //0�? ?��쪽마?��?��
        {
            pAnimator.SetTrigger("Attack");
            Instantiate(hit_lazer, transform.position, Quaternion.identity);

        }




    }

    
    void Update()
    {
        
        //?���? 조절 ?��?�� 체크 (?���? ?��?��?�� ?���? ?��르면 ?��로우 모션 ?��?��)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //?��?��?��?��로세?�� ?��면효�?
            TimeController.Instance.SetSlowMotion(true); //?��로우 모션 ?��?��
        }
        if(!isWallJump)
        {
            KeyInput();
            Move();
        }
       


        //벽인�? 체크
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
            //벽점?��?��?��
            pRig2D.linearVelocity = new Vector2(pRig2D.linearVelocityX, pRig2D.linearVelocityY * slidingSpeed);
            //벽을 ?��고있?�� ?��?��?��?�� ?��?��
            if(Input.GetKeyDown(KeyCode.W))
            {
                isWallJump = true;
                //벽점?�� 먼�??
                GameObject go = Instantiate(walldust, transform.position + new Vector3(0.8f * isRight, 0, 0), Quaternion.identity);
                go.GetComponent<SpriteRenderer>().flipX = sp.flipX;

                Invoke("FreezeX", 0.3f);
                //물리
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

     //?��?��캐스?���? ?��체크 
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
         //?��?���?�? ?��?��
         if (!isWall)
         {
             //그냥 ?��?���??���?
             pAnimator.SetBool("Jump", true);
         }
         else
         {
             //벽�??�?
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
        //?��?��?��?�� ?��른쪽
        if(sp.flipX == false)
        {
            pRig2D.AddForce(Vector2.right * power, ForceMode2D.Impulse);
            //?��?��?��?�� ?��른쪽
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
        }
        else
        {

            pRig2D.AddForce(Vector2.left * power, ForceMode2D.Impulse);
            //?���?
            GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
            //go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
        }   

    }

    //그림?��
    public void RunShadow()
    {
        if(sh.Count<6)
        {
            GameObject go = Instantiate(Shadow1, transform.position, Quaternion.identity);
            go.GetComponent<Shadow>().TwSpeed = 10 - sh.Count; 
            sh.Add(go);
        }
    }



    //?��먼�??
    public void RandDust(GameObject dust)
    {



        Instantiate(dust, transform.position +new Vector3(-0.114f,-0.467f,0), Quaternion.identity);




    }

    //?��?��먼�??
    public void JumpDust()
    {
        if(!isWall)
        {
            Instantiate(Jdust, transform.position, Quaternion.identity);
            Debug.Log("?��?��먼�?? ?��?��중이?��");
        }
        else
        {
            //벽먼�?
            //Instantiate(walldust, transform.position, Quaternion.identity);
            //Debug.Log("?��벽먼�? ?��?��중이?��");
        }

      
    }

    //벽점?��
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(wallChk.position, Vector2.right * isRight * wallchkDistance);
    }

   private void OnTriggerEnter2D(Collider2D other)
 {
     //���� �� ���� ��Ż�� �浹 üũ
     if(other.CompareTag("BossScene"))
     {
         //���� ������ ��ȯ
         SceneManager.LoadScene("Boss");
     }
 }
}