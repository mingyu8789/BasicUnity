using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{

    //�̺�Ʈ ������ (������)
    void Start()
    {
        //�̺�Ʈ ����
        EventManager.Instance.AddListener("PlayerHealthChanged",OnPlayerHealthChanged);
        EventManager.Instance.AddListener("PlayerDied", OnPlyaerDied);
    }

    private void OnDestroy()
    {
        //��ü�� �����ɶ� �����ϴ� �Լ�
        EventManager.Instance.Removelistener("PlayerHealthChanged",OnPlayerHealthChanged);
        EventManager.Instance.Removelistener("PlayerDied", OnPlyaerDied);
    }
    private void OnPlayerHealthChanged(object data)
    {
        int health = (int)data;
        Debug.Log($"UI ������Ʈ : �÷��̾� ü���� {health}�� ����Ǿ����ϴ�.");
        //�����δ� ���⼭ UI��Ҹ� ������Ʈ �մϴ�.
    }

    private void OnPlyaerDied(object data)
    {
        Debug.Log("UI ������Ʈ : �÷��̾ ����߽��ϴ�!");
        //���� ���� ȭ�� ǥ�� ���� ���� ����
    }
    void Update()
    {
        
    }
}
