using UnityEngine;

public class background : MonoBehaviour
{
    public float backgroundSpeed = 1.2f;

    private Material thisMaterial;

    void Start()
    {
        thisMaterial = GetComponent<Renderer>().material;
    }

  
    void Update()
    {
        //새롭게 지정해줄 offset 객체를 선언합니다.
        Vector2 newoffset = thisMaterial.mainTextureOffset;
        //Y부분에 현재 y값에 속도에 프레임 보정해서 더해줍니다.
        newoffset.Set(0, newoffset.y + (backgroundSpeed * Time.deltaTime));
        //최종적으로 offset값을 지정해줍니다.
        thisMaterial.mainTextureOffset = newoffset;
    }
}
