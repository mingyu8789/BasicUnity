using System.Collections;
using TMPro;
using UnityEngine;

public class TMPcolor : MonoBehaviour
{
    //���� ��ȯ�� �ɸ��� �ð�
    [SerializeField]
    float lerpTime = 0.1f;

    //�ؽ�Ʈ ������Ʈ
    TextMeshProUGUI textBossWarning;


    //Awake �޼��� : ������Ʈ �ʱ�ȭ
    private void Awake()
    {
        textBossWarning = GetComponent<TextMeshProUGUI>();
    }

    //OnEnable�޼��� : ������Ʈ�� Ȱ��ȭ�ɶ� ȣ��

    private void OnEnable()
    {
        StartCoroutine("ColorLerpLoop");
    }


    //���� ��ȯ ���� �ڷ�ƾ

    IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    //���� ��ȯ �ڷ�ƾ
    IEnumerator ColorLerp(Color starColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;
            textBossWarning.color = Color.Lerp(starColor, endColor, percent);
            yield return null;
        }
    }


    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
