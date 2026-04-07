using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private Button[] _levelButtons;

    void OnEnable()
    {
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (_levelButtons[i] == null) continue;
            _levelButtons[i].interactable = (i + 1) <= _gameData.lastUnlockedLevel;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level" + levelIndex);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}