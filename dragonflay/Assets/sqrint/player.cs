using UnityEngine;

public class player : MonoBehaviour
{
    public float PlayerMoveSpeed = 5.0f;

  
    void Update()
    {
        playermove();
    }


    void playermove()
    {
        //지정한 Axis를 통해 키의 방향을 판단하고 속도와 프레임 판정을 곱해 이동량을 정한다.
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMoveSpeed;
        //이동량만큼 실제로 이동을 해주는 함수
        transform.Translate(distanceX, 0, 0);
    }
}
