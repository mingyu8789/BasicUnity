using UnityEngine;

public class Enemy_Misslie : MonoBehaviour
{
    public float speed = 5f;    //�̻��� �ӵ�
    public float lifeTime = 3f; //�̻��� ���� �ð�
    public int damage = 10;     //�̻��� ������
    private Vector2 direction;  //�̻��� �̵� ����


    void Start()
    {
        Destroy(gameObject, lifeTime);  //���� �ð� �� �̻��� ����     
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
            //���⿡ �÷��̾� ������ ���� �߰�
            Destroy(gameObject);
        }
    }
}
