using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    //�̵���
    //��𿡼��� ���� �� �� �ֵ��� static (����)���� �ڱ��ڽ��� �����ؼ� �̵����̶�� ������ ������
    //����غ���.
    public static GameManger intance;
    public Text ScoreText;  //������ ǥ���ϴ� Text��ü�� �����Ϳ��� �޾ƿɴϴ�.
    public Text StartText; //���ӽ�����3,2,1
    int score = 0;

    private void Awake()
    {
        if(intance == null) //�������� �ڽ��� üũ�մϴ�. null����
        {
            intance = this; //�ڱ��ڽ��� �����Ѵ�.
        }
    }

    void Start()
    {
        StartCoroutine("StartGame");


    }
    void Update()
    {
        if (score <= 150)
        {
            if (score >= 100)
            {
                StartCoroutine("Bossstge");
            }
        }
    }

    IEnumerator StartGame()

    {
        int i = 3;

        Time.timeScale = 0; //��ü �ð�����

        while (i > 0)
        {
            StartText.text = i.ToString();

            //  yield return new WaitForSeconds(1);
            yield return new WaitForSecondsRealtime(1); //������ ���絵 �����ϴ� ���
            i--;

            if (i == 0)
            {
                StartText.gameObject.SetActive(false);  //UI���߱�
                Time.timeScale = 1; //�ٽ� �ð� ��������
            }
        }
    }

    IEnumerator Bossstge()
    {
        int j = 3;

        Time.timeScale = 0; //��ü �ð�����

        while (j > 0)
        {
            StartText.gameObject.SetActive(true);
            StartText.text = "BOSS!!!";

            //  yield return new WaitForSeconds(1);
            yield return new WaitForSecondsRealtime(1); //������ ���絵 �����ϴ� ���
            j--;

            if (j == 0)
            {
                StartText.gameObject.SetActive(false);  //UI���߱�
                Time.timeScale = 1; //�ٽ� �ð� ��������
            }
        }
    }




    public void AddScore(int num)
    {
        score += num;   //������ �����ݴϴ�.
        ScoreText.text = "Score : " + score;    //�ؽ�Ʈ�� �ݿ��մϴ�.
    }


}
