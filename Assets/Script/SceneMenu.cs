using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour
{
    private void Awake()
    {
        SoundManager.instance.PlayBGM(0);
    }
    public void muteBtn() => SoundManager.instance.muteBGM();
    public void Quit() => Application.Quit();
    public void toSceneA()
    {
        SoundManager.instance.stopSound();
        SceneManager.LoadScene("ModeA");
    }
    public void toSceneB()
    {
        SoundManager.instance.stopSound();
        SceneManager.LoadScene("ModeB");
    }
}
