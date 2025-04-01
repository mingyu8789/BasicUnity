using UnityEngine;

public class GameManger : MonoBehaviour
{

    //�̱��� �ν��Ͻ��� ������ ���� ����
    private static GameManger _instance;

    //�ܺο��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ
    public static GameManger Instance
    {
        get
        {
            //�ν��Ͻ��� ������ ã�ƺ���
            if(_instance == null)
            {
                _instance = FindAnyObjectByType<GameManger>();

                //�������� ã�� �� ������ ���� ����
                if(_instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    _instance = singletonObject.AddComponent<GameManger>();
                }
            }
            return _instance;
        }
    }

    //���� ���۽� ȣ��
    private void Awake()
    {
        //�̹� �ν��Ͻ��� �ִ��� Ȯ��
        if (_instance != null && _instance != this)
        {
            //�ߺ��� �ν��Ͻ��� ����
            Destroy(gameObject);
            return;
        }


        //�� �ν��Ͻ��� �̱������� ����
        _instance = this;

        //�� ��ȯ �ÿ��� ����
        DontDestroyOnLoad(gameObject);
    }

    //�������� ���� ����
    private int _score = 0;

    public int Score => _score;

    public void AddScore(int points)
    {
        _score += points;
        Debug.Log($"Score updated: {_score}");
    }

}
