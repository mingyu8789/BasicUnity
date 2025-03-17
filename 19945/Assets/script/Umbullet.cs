using UnityEngine;

public class Umbullet : MonoBehaviour
{
    public GameObject target;   //�÷��̾� ã��
    public float Speed = 3f;
    Vector2 dir;
    Vector2 dirNo;


    void Start()
    {
        //�÷��̾ ã�Ƽ� ������ �� ��ġ�� �i��
        //�÷��̾� �±׷� ã��
        target = GameObject.FindGameObjectWithTag("Player");
        //A - B A�� �ٶ󺸴� ����      �÷��̾� - �̻���
        dir = target.transform.position - transform.position;
        //���⺤�͸� ���ϱ� �������� ����ȭ �븻 1�� ũ��� �����.
        dirNo = dir.normalized;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
