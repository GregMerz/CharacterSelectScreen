using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayerController playerController;
    public Button rollCharacterButton;
    public Button playGameButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("GameManager").GetComponent<GameManager>().playerController;

        rollCharacterButton = GameObject.Find("Button_Roll_Character").GetComponent<Button>();
        rollCharacterButton.onClick.AddListener(() => onRollCharacterClicked());

        playGameButton = GameObject.Find("Button_Play_Game").GetComponent<Button>();
        playGameButton.onClick.AddListener(() => onPlayGameClicked());

        quitButton = GameObject.Find("Button_Quit").GetComponent<Button>();
        quitButton.onClick.AddListener(() => onQuitClicked());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene(int level) {
        SceneManager.LoadScene(level);
    }

    void onRollCharacterClicked() {
        LoadScene(1);
    }

    void onPlayGameClicked() {
        if (playerController.isPlayerMade) {
            LoadScene(2);
        }
    }

    public void onQuitClicked() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
        Application.Quit();
        #endif
    }
}
