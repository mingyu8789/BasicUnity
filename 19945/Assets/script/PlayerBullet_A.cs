using UnityEngine;

public class PlayerBullet_A : MonoBehaviour
{
    public float Speed = 4.0f;

    public GameObject effect;

    void Start()
    {
        transform.position = Vector3.up * Speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        //�ڱ� �ڽ� �����
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            GameObject boom = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(boom, 1);   //1�ʵڿ� �����

            //collision.gameObject.GetComponent<Monster>().Damage(1);

            Destroy(gameObject);
        }
    }

}
