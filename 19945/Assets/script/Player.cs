using UnityEngine;

public class Player : MonoBehaviour
{
    //스피드
    public float moveSpeed = 5f;

    public GameObject bullet;

    Animator ani; //애니메이터를 가져올 변수

    public Transform pos = null;




    void Start()
    {
        //플레이어에 있는 에니메이터를 가져옵니다.
        ani = GetComponent<Animator>();
    }

  
    void Update()
    {
        //방향키에따른 움직임
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // -1   0   1
        if (Input.GetAxis("Horizontal") <= -0.5f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);


        if (Input.GetAxis("Horizontal") >= 0.5f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);


        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }

        transform.Translate(moveX, moveY, 0);
    }
}
