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
        //���Ӱ� �������� offset ��ü�� �����մϴ�.
        Vector2 newoffset = thisMaterial.mainTextureOffset;
        //Y�κп� ���� y���� �ӵ��� ������ �����ؼ� �����ݴϴ�.
        newoffset.Set(0, newoffset.y + (backgroundSpeed * Time.deltaTime));
        //���������� offset���� �������ݴϴ�.
        thisMaterial.mainTextureOffset = newoffset;
    }
}
