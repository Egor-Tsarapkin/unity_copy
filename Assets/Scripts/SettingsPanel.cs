using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    void OnEnable()
    {
        _musicSlider.SetValueWithoutNotify(_gameData.musicVolume);
        _sfxSlider.SetValueWithoutNotify(_gameData.sfxVolume);

        _musicSlider.onValueChanged.AddListener(OnMusicChanged);
        _sfxSlider.onValueChanged.AddListener(OnSfxChanged);
    }

    void OnDisable()
    {
        _musicSlider.onValueChanged.RemoveListener(OnMusicChanged);
        _sfxSlider.onValueChanged.RemoveListener(OnSfxChanged);

        SaveSystem.Save(_gameData);
    }

    void OnMusicChanged(float value)
    {
        _gameData.musicVolume = value;

        if (AudioManager.Instance != null)
            AudioManager.Instance.ApplyVolume();
    }

    void OnSfxChanged(float value)
    {
        _gameData.sfxVolume = value;

        if (AudioManager.Instance != null)
            AudioManager.Instance.ApplyVolume();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}