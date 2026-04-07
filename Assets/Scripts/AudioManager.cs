using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private GameData _gameData;
    [SerializeField] private AudioMixer _audioMixer;

    private AudioSource _musicSource;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _musicSource = GetComponent<AudioSource>();

        SaveSystem.Load(_gameData);
        ApplyVolume();
    }

    public void ApplyVolume()
    {
        float musicDb = _gameData.musicVolume > 0.001f
            ? Mathf.Log10(_gameData.musicVolume) * 20f
            : -80f;

        float sfxDb = _gameData.sfxVolume > 0.001f
            ? Mathf.Log10(_gameData.sfxVolume) * 20f
            : -80f;

        _audioMixer.SetFloat("MusicVol", musicDb);
        _audioMixer.SetFloat("SFXVol", sfxDb);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (_musicSource == null || clip == null) return;

        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void StopMusic()
    {
        if (_musicSource != null)
            _musicSource.Stop();
    }

    void OnApplicationQuit()
    {
        SaveSystem.Save(_gameData);
    }
}