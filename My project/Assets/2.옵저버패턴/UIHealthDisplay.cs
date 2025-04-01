using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    //�̺�Ʈ ������ (������)
    void Start()
    {
        //�̺�Ʈ ����
        EventManager.Instance.AddListener("PlayerHealthChanged",OnPlayerHealthcHanged);
        EventManager.Instance.AddListener("PlayerDied", OnPlayerDied);
    }


    private void Oestroy()
    {
        //��ü�� �����ɶ� �����ϴ� �Լ�
        EventManager.Instance.Removelistener("PlayerHealthChanged",OnPlayerHealthcHanged);
        EventManager.Instance.Removelistener("PlayerDied", OnPlayerDied); 
    }

    private void OnPlayerHealthcHanged(object data)
    {
        int health = (int)data;
        Debug.Log($"UI ������Ʈ : �÷��̾� ü���� {health}�� ����Ǿ����ϴ�.");
        //�����δ� ���⼭ UI��Ҹ� ������Ʈ ��
    }

    private void OnPlayerDied(object data)
    {
        Debug.Log("UI ������Ʈ : �÷��̾ ����߽��ϴ�!");
        //���� ���� ȭ�� ǥ�� ���� ���� ����
    }
}
