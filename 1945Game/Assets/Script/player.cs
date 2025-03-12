
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    Animator ani;   //�ִϸ����͸� ������ ����

    void Start()
    {
        ani = GetComponent<Animator>();
    }


    void Update()
    {
        //����Ű�� ���� ������
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // -1   0   1
        if (Input.GetAxis("Horizontal") <= -0.1f)
            ani.SetBool("left", true); //set�� �Ἥ bool�� �ٲ���
        else
            ani.SetBool("left", false);


        if (Input.GetAxis("Horizontal") >= 0.1f)
            ani.SetBool("right", true); //set�� �Ἥ bool�� �ٲ���
        else
            ani.SetBool("right", false);

        if (Input.GetAxis("Vertical") >= 0.1f)
            ani.SetBool("up", true); //set�� �Ἥ bool�� �ٲ���
        else
            ani.SetBool("up", false);



        transform.Translate(moveX, moveY, 0);


    }
}


////ī�޶� ���� ���� �ܼ�

//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public float speed = 5f;
//    private Vector2 minBounds;
//    private Vector2 maxBounds;

//    void Start()
//    {
//        // ȭ���� ��踦 ����
//        Camera cam = Camera.main;
//        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
//        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

//        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
//        maxBounds = new Vector2(topRight.x, topRight.y);
//    }

//    void Update()
//    {
//        // �÷��̾� �̵�
//        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
//        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

//        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

//        // ��踦 ����� �ʵ��� ��ġ ����
//        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
//        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

//        transform.position = newPosition;
//    }
//}


