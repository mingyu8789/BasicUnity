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
        //Y�� �̵�
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        //�̻����� ȭ������� ��������
        //�̻��� ������
        Destroy(gameObject);       //��ũ��Ʈ�� ���� ������Ʈ�� ����ϴ� (�ڱ��ڽ�)
    }

    //2D�浹 Ʈ�����̺�Ʈ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�̻��ϰ� ���� �ε�����
        //if (collision.gameObject.tag == "Enemy")
        if (collision.gameObject.CompareTag("Enemy"))   //�̰� �� �����ϴٰ� ��
        {
                //���� ����Ʈ ����
                Instantiate(exposion, transform.position, Quaternion.identity);
                //��������
                SoundManager.instance.SoundDie(); //�� ���� ����
                GameManger.intance.AddScore(10);

                //�� �����
                Destroy(collision.gameObject);
                //�Ѿ� �����
                Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy2"))
        {
            //���� ����Ʈ ����
            Instantiate(exposion, transform.position, Quaternion.identity);
            //��������
            SoundManager.instance.SoundDie(); //�� ���� ����
            GameManger.intance.AddScore(50);

            //�� �����
            Destroy(collision.gameObject);
            //�Ѿ� �����
            Destroy(gameObject);
        }

    }

}
//private void OnTriggerEnter2D(Collider2D collision)    ������Ʈ�� �հ� �������� �̺�Ʈ�� �߻� (������ ���� ����)

//private void OnCollisionEnter2D(Collision2D collision)    ������Ʈ�� ������ �ε����� ������ ������ ��

//stay �浹�� �ӹ�����

//
