using UnityEngine;

public class bullet : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    void Start()
    {

    }


    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}