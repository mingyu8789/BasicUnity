using UnityEngine;
using static UnityEditor.Progress;

public class Bullet : MonoBehaviour
{
    public float Speed = 4.0f;
    //���ݷ�
    //����Ʈ
    public GameObject effect;

    void Update()
    {
        //�̻��� ���ʹ������� �����̱�
        //���� ���� * ���ǵ� * Ÿ��
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }


    //ȭ������� �������
    private void OnBecameInvisible()
    {
        //�ڱ� �ڽ� �����
        Destroy(gameObject);
    }


    //�浹ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            //����Ʈ����
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity); //collision.transform.position�� �̵� ���� ������ ����� ��ġ���� ����� ����!
            //1�ʵڿ� �����
            Destroy(go, 1); //1�ʵڿ� �����ش�

            //���� ����
            Destroy(collision.gameObject);

            //�̻��� ����
            Destroy(gameObject);
        }
    }

}