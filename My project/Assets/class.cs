using UnityEngine;

public class Player
{
    public string name;
    public int score;
    public Player(string playerName, int playerScore)
    {
        name = playerName;
        score = playerScore;
    }

    public void ShowInfo()
    {
        Debug.Log("Player : " + name + ", Score : " + scroe);
    }
}




public class class : MonoBehaviour
{
   
    void Start()
    {
        Player player1 = new Player("Hero", 10)
            player1.ShowInfo();
    }

  
    void Update()
    {
        
    }
}
