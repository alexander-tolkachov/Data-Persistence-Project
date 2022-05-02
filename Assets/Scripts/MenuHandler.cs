using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    public GameObject playerNameInput;
    public Text BestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = $"Best Score : {MenuManager.Instance.bestName} : {MenuManager.Instance.bestScore}";
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        // MenuManager.Instance.SaveSettings();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void PlayerNameChanged()
    {
        MenuManager.Instance.playerName = playerNameInput.GetComponent<InputField>().text;
    }

}
