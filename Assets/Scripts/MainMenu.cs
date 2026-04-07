using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private Button _continueButton;
    [SerializeField] private TMP_Text _continueButtonText;

    private bool _hasSave;

    void Start()
    {
        _levelsPanel.SetActive(false);
        _settingsPanel.SetActive(false);
        _hasSave = SaveSystem.Load(_gameData);
        _continueButtonText.text = _hasSave ? "Продолжить" : "Начать";
    }

    public void OnContinueClick()
    {
        if (_hasSave)
            OpenLevels();
        else
            SceneManager.LoadScene("Level1");
    }

    public void OpenLevels()
    {
        _levelsPanel.SetActive(true);
        _settingsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        _settingsPanel.SetActive(true);
        _levelsPanel.SetActive(false);
    }

    public void CloseAllPanels()
    {
        _levelsPanel.SetActive(false);
        _settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("[MainMenu] Выход из игры");
    }
}