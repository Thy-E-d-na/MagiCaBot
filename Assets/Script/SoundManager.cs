using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _BGM;
    [SerializeField] private AudioSource _SFX;
    [SerializeField] private AudioClip[] _clip;
    [SerializeField] private AudioClip[] _bgm;
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayBGM(int inde)
    {
        if (inde < _bgm.Length)
        {
            _BGM.clip = _bgm[inde]; //put tha CD in the Speaker
            _BGM.Play();

        }
    }
    public void stopSound()
    {
        _BGM.Stop();
    }
    public void SetVolume(float vol)
    {
        _BGM.volume = vol;
    }
    public void muteBGM()
    {
        _BGM.mute = !_BGM.mute;

    }
    public void muteSFX()
    {
        _SFX.mute = !_SFX.mute;
    }
    public void PauseSound()
    {
        _BGM.Pause();
    }
}
