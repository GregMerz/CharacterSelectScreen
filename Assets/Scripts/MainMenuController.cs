using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button rollCharacterButton;
    public Button playGameButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void initMainMenu(PlayerController playerController) {
        rollCharacterButton = GameObject.Find("Button_Roll_Character").GetComponent<Button>();
        rollCharacterButton.onClick.AddListener(() => SceneManager.LoadScene(1));

        playGameButton = GameObject.Find("Button_Play_Game").GetComponent<Button>();
        playGameButton.onClick.AddListener(() => SceneManager.LoadScene(2));

        quitButton = GameObject.Find("Button_Quit").GetComponent<Button>();
        quitButton.onClick.AddListener(() => quitGame());

        playerController.player.name = "Henry";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitGame() {
        Debug.Log("Quit button clicked");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
        Application.Quit();
        #endif
    }
}
