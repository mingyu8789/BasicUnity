using UnityEngine;

public class player : MonoBehaviour
{
    public float PlayerMoveSpeed = 5.0f;

  
    void Update()
    {
        playermove();
    }


    void playermove()
    {
        //������ Axis�� ���� Ű�� ������ �Ǵ��ϰ� �ӵ��� ������ ������ ���� �̵����� ���Ѵ�.
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMoveSpeed;
        //�̵�����ŭ ������ �̵��� ���ִ� �Լ�
        transform.Translate(distanceX, 0, 0);
    }
}
