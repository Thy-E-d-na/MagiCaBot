using System;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _winPnl;
    [SerializeField] private GameObject _losePnl;
    [SerializeField] private GameObject _cheeseHp;
   
    int ratCount;
    public static GameController gameinstance;
    private void Start()
    {
        Instantiate(_cheeseHp);
    }

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
        SoundManager.instance.PlayBGM(0);
    }
    private void Update()
    {
        if (ratCount == 0)
        {
            gameWin();
        }
        else if (ratCount > 0)
        {
            gameLose();
        }
    }

    public void gameWin() => _winPnl.SetActive(true);
    public void gameLose() => _losePnl.SetActive(true);
    public void AddDrone()
    {
        ratCount++;
    }
    public void destroyDrone()
    {
        ratCount--;
    }
    public void resetGame()
    {
        ratCount = 0;
    }
}
