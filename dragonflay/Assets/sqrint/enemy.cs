using UnityEngine;

public class enemy : MonoBehaviour
{
    public float moveSpeed = 1.3f;

  
    void Update()
    {
        //������ �Ÿ��� ������ݴϴ�.
        float distanceY = moveSpeed * Time.deltaTime;

        //�������� �ݿ��մϴ�.
        transform.Translate(0, -distanceY, 0);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject); //��ü�� �����Ѵ�.
    }
}
