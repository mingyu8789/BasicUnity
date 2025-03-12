using UnityEngine;

public class bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;



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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�̻��ϰ� ���� �ε�����
        if (collision.gameObject.CompareTag("Enemy"))   //�̰� �� �����ϴٰ� ��
        {
            //�������
            Destroy(collision.gameObject);
            //�Ѿ� ����� �ڱ��ڽ�
            Destroy(gameObject);
        }
    }
}
