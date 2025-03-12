using UnityEngine;

public class Wapon : MonoBehaviour
{
    public GameObject bullet;
    void Start()
    {
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }


    void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
  
    void Update()
    {
        
    }
}
