
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    Animator ani;   //애니메이터를 가져올 변수

    void Start()
    {
        ani = GetComponent<Animator>();
    }


    void Update()
    {
        //방향키에 따른 움직임
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // -1   0   1
        if (Input.GetAxis("Horizontal") <= -0.1f)
            ani.SetBool("left", true); //set을 써서 bool로 바꿔줌
        else
            ani.SetBool("left", false);


        if (Input.GetAxis("Horizontal") >= 0.1f)
            ani.SetBool("right", true); //set을 써서 bool로 바꿔줌
        else
            ani.SetBool("right", false);

        if (Input.GetAxis("Vertical") >= 0.1f)
            ani.SetBool("up", true); //set을 써서 bool로 바꿔줌
        else
            ani.SetBool("up", false);



        transform.Translate(moveX, moveY, 0);


    }
}


////카메라 벽을 막는 콘솔

//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float speed = 5f;
//    private Vector2 minBounds;
//    private Vector2 maxBounds;

//    void Start()
//    {
//        // 화면의 경계를 설정
//        Camera cam = Camera.main;
//        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
//        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

//        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
//        maxBounds = new Vector2(topRight.x, topRight.y);
//    }

//    void Update()
//    {
//        // 플레이어 이동
//        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
//        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

//        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

//        // 경계를 벗어나지 않도록 위치 제한
//        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
//        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

//        transform.position = newPosition;
//    }
//}


