using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float ScroolMove = 0.1f;
    Material MyMaterial;

    void Start()
    {
        MyMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float moveY = MyMaterial.mainTextureOffset.y + ScroolMove * Time.deltaTime;
        Vector2 move = new Vector2(0, moveY);
        MyMaterial.mainTextureOffset = move;
    }
}
