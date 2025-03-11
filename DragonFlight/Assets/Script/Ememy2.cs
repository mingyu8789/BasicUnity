using UnityEngine;

public class Ememy2 : MonoBehaviour
{
    public float movespeed = 2.0f;



    void Update()
    {
        float moveY = movespeed * Time.deltaTime;

        transform.Translate(0, -moveY, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
