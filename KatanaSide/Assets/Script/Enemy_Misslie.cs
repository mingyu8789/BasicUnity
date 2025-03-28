using UnityEngine;

public class Enemy_Misslie : MonoBehaviour
{
    public float speed = 5f;    //미사일 속도
    public float lifeTime = 3f; //미사일 생존 시간
    public int damage = 10;     //미사일 데미지
    private Vector2 direction;  //미사일 이동 방향


    void Start()
    {
        Destroy(gameObject, lifeTime);  //일정 시간 후 미사일 제거     
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }


    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //여기에 플레이어 데미지 로직 추가
            Destroy(gameObject);
        }
    }
}
