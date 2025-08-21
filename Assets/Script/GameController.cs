
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _winPnl;
    [SerializeField] private GameObject _losePnl;
   
    int ratCount = 10;
    public static GameController gameinstance;

    private void Awake()
    {
        if (gameinstance == null)
        {
            gameinstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
       
    }
    private void Start()
    {
        SoundManager.instance.PlayBGM(2);
    }
    private void Update()
    {
        if (ratCount <= 0)
        {
            gameWin();
        }
    }

    public void gameWin() => _winPnl.SetActive(true);
    public void gameLose() => _losePnl.SetActive(true);
    public void ratDeath()
    {
        ratCount--;
    }

}
