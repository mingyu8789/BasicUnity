using System.Threading;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject effect;
    Transform pos;
    int Attack = 10;


    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<player>().pos;     //한번 써본거 태그 쓰셈 이건 성능이 안좋음
    }


    void Update()
    {
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<monster_5>().Damage(Attack++);

            CreateEffect(collision.transform.position);
        }

        if (collision.CompareTag("boss"))
        {
            CreateEffect(collision.transform.position);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)  //stay 계속 실행함 위처럼 한번만 실행하지 않음
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<monster_5>().Damage(Attack++);

            CreateEffect(collision.transform.position);
        }

        if (collision.CompareTag("boss"))
        {
            CreateEffect(collision.transform.position);
        }
    }








    void CreateEffect(Vector3 position)
    {
        GameObject go = Instantiate(effect, position, Quaternion.identity);
        Destroy(go, 1);
    }



}