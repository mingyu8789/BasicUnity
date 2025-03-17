using System.Threading;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject effect;
    Transform pos;
    int Attack = 10;


    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<player>().pos;     //�ѹ� �ẻ�� �±� ���� �̰� ������ ������
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


    private void OnTriggerStay2D(Collider2D collision)  //stay ��� ������ ��ó�� �ѹ��� �������� ����
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