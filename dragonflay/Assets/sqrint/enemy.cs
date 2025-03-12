using UnityEngine;

public class enemy : MonoBehaviour
{
    public float moveSpeed = 1.3f;

  
    void Update()
    {
        //움직일 거리를 계산해줍니다.
        float distanceY = moveSpeed * Time.deltaTime;

        //움직임을 반영합니다.
        transform.Translate(0, -distanceY, 0);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject); //객체를 삭제한다.
    }
}
