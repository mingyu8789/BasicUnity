using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public float speed = 5.0f; //이동속도
   

  
    void Update()
    {
        //키 입력에 따라 이동
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
    }
}
