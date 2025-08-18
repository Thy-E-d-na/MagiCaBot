using System;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _endPnnl;
    [SerializeField] private GameObject _crosshair;
   
    int ratCount;
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
        SoundManager.instance.PlayBGM(0);
    }
    private void Update()
    {
        if (ratCount == 6)
        {
            gameEnd();
        }
    }

    public void gameEnd()
    {

        _endPnnl.SetActive(true);

        _crosshair.SetActive(false);
    }
       
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
        _endPnnl.SetActive(false);
        _crosshair.SetActive(true);
    }
}
