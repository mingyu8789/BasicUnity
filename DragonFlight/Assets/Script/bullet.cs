using System.Diagnostics.Tracing;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    public GameObject exposion;

    void Start()
    {
        //Singleton.Instance.PrintMessage();
    }


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

    //2D충돌 트리거이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //미사일과 적이 부딪혔다
        //if (collision.gameObject.tag == "Enemy")
        if (collision.gameObject.CompareTag("Enemy"))   //이게 더 안전하다고 함
        {
                //폭발 이펙트 생성
                Instantiate(exposion, transform.position, Quaternion.identity);
                //죽음사운드
                SoundManager.instance.SoundDie(); //적 죽음 사운드
                GameManger.intance.AddScore(10);

                //적 지우기
                Destroy(collision.gameObject);
                //총알 지우기
                Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy2"))
        {
            //폭발 이펙트 생성
            Instantiate(exposion, transform.position, Quaternion.identity);
            //죽음사운드
            SoundManager.instance.SoundDie(); //적 죽음 사운드
            GameManger.intance.AddScore(50);

            //적 지우기
            Destroy(collision.gameObject);
            //총알 지우기
            Destroy(gameObject);
        }

    }

}
//private void OnTriggerEnter2D(Collider2D collision)    오브젝트가 뚫고 지나가며 이벤트만 발생 (물리적 반응 없음)

//private void OnCollisionEnter2D(Collision2D collision)    오브젝트가 실제로 부딪히며 물리적 반응을 함

//stay 충돌이 머무를때

//
