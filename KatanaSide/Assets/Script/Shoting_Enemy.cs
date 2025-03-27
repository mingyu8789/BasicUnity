using UnityEngine;

public class Shoting_Enemy : MonoBehaviour
{
    [Header("�� ĳ���� �Ӽ�")]
    public float detctionRange = 10f;   //�÷��̾ ������ �� �ִ� �ִ� �Ÿ�
    public float shootingInterval = 2f; //�̻��� �߻� ������ ��� �ð�
    public GameObject missilePrefab;    //�ٻ��� �̻��� ������
    [Header("���� ������Ʈ")]
    public Transform firePoint; //�̻����� �߻�� ��ġ
    private Transform player;   //�÷��׾��� ��ġ ����
    private float shootTimer;   //�߻� Ÿ�̸�
    private SpriteRenderer spriteRenderer; //��������Ʈ ���� ��ȯ��


    void Start()
    {
        //�ʿ��� ������Ʈ �ʱ�ȭ
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        shootTimer = shootingInterval;  //Ÿ�̸� �ֱ�ȭ
    }


    void Update()
    {
        if (player == null) return; //�÷��̾ ������ ������ �������� ����

        //�÷��̾���� �Ÿ� ���
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detctionRange)
        {
            //�÷��̾� �������� ��������Ʈ ȸ��
            spriteRenderer.flipX = (player.position.x < transform.position.x);

            //�̻��� �߻� ����
            shootTimer -= Time.deltaTime;   //Ÿ�̸� ����

            if (shootTimer <= 0)
            {
                Shoot(); //�̻��� �߻�
                shootTimer = shootingInterval; //Ÿ�̸� �ʱ�ȭ
            }
        }
    }


        //�̻��� �߻� �Լ�
        void Shoot()
        {
            //�̻��� ����
            GameObject missile = Instantiate(missilePrefab, firePoint.position, Quaternion.identity);

            //�÷��̾� �������� �߻� ���� ����
            Vector2 direction = (player.position - firePoint.position).normalized;
            missile.GetComponent<Enemy_Misslie>().SetDirection(direction);
            missile.GetComponent<SpriteRenderer>().flipX = (player.position.x < transform.position.x);
        }

    //������ �����
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detctionRange);
    }
}
