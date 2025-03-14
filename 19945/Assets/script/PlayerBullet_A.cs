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


    void Update()
    {
        
    }
}
