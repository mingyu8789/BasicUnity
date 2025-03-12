using UnityEngine;

public class bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;



    void Update()
    {
        //Y축 이동
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        //미사일이 화면밖으로 나갔으면
        //미사일 지우자
        Destroy(gameObject);       //스크립트가 붙은 오브젝트를 지웁니다 (자기자신)
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //미사일과 적이 부딪혔다
        if (collision.gameObject.CompareTag("Enemy"))   //이게 더 안전하다고 함
        {
            //적지우기
            Destroy(collision.gameObject);
            //총알 지우기 자기자신
            Destroy(gameObject);
        }
    }
}
