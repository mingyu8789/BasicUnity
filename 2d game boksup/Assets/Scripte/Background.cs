using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 1.2f;
    //������ ���͸��� �����͸� �޾ƿ� ��ü�� �����մϴ�.
    private Material thisMaterial;

    void Start()
    {
        //��ü�� �����ɶ� ���� 1ȸ ȣ��Ǵ� �Լ�
        //���� ��ü�� Component���� ������ Renderer��� ������Ʈ�� Material����
        //�޾ƿɴϴ�.

        thisMaterial = GetComponent<Renderer>().material;
    }


    void Update()
    {
        //���Ӱ� �������� offset ��ü�� �����մϴ�.
        Vector2 newoffset = thisMaterial.mainTextureOffset;
        //Y�κп� ���� y���� �ӵ��� ������ �����ؼ� �����ݴϴ�.
        newoffset.Set(0, newoffset.y + (scrollSpeed * Time.deltaTime));
        //���������� offset���� �������ݴϴ�.
        thisMaterial.mainTextureOffset = newoffset;
    }
}
