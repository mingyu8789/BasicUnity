using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public float speed = 5.0f; //이동속도
   

  
    void Update()
    {

        ////키 입력에 따라 이동
        //float move = Input.GetAxis("Horizontal");
        //// 방향 * 스피드 * 타임델타타임
        //transform.Translate(Vector3.right * move * speed * Time.deltaTime);




        ////위아래 옆까지 움직임
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        //transform.position += move * speed * Time.deltaTime;



        //위아래 앞뒤까지 움직임
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //transform.position += move * speed * Time.deltaTime;  //회전영향 없이 움직일 수 있음
        transform.Translate(move * speed * Time.deltaTime);     //회전 방향에 따라 움직임이 달라짐

    }
}
