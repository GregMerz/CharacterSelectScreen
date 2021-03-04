using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public bool isCharacterMade = false;
    public Button rollCharacterButton;
    public Button playGameButton;
    public Button quitButton;
    public Button mainMenuButton;

    
    public void Awake() {
        playerManager.GetComponent<PlayerManager>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("Start method called");

        rollCharacterButton = GameObject.Find("Button_Roll_Character").GetComponent<Button>();
        rollCharacterButton.onClick.AddListener(() => LoadScene(1) );

        playGameButton = GameObject.Find("Button_Play_Game").GetComponent<Button>();
        playGameButton.onClick.AddListener(() => LoadScene(2));

        quitButton = GameObject.Find("Button_Quit").GetComponent<Button>();
        quitButton.onClick.AddListener(() => quitGame());

        mainMenuButton = GameObject.Find("Button_Main_Menu").GetComponent<Button>();
        mainMenuButton.onClick.AddListener(() => LoadScene(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int level) {
        SceneManager.LoadScene(level);
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
