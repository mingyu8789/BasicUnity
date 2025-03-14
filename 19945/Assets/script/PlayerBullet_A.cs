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
        //자기 자신 지우기
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            GameObject boom = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(boom, 1);   //1초뒤에 지우기

            //collision.gameObject.GetComponent<Monster>().Damage(1);

            Destroy(gameObject);
        }
    }

}
