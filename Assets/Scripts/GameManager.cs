using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerManager playerManager;
    public bool isCharacterMade = false;

    private void Awake() {
        playerManager.GetComponent<PlayerManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int level) {
        SceneManager.LoadScene(level);
    }

    public void onRollCharacterClicked() {
        Debug.Log("Roll Character button clicked");
        LoadScene(1);
    }

    public void onPlayGameClicked() {
        Debug.Log("Play Game button clicked");

        if (isCharacterMade) {
            LoadScene(2);
        }

        Debug.Log("Press Roll Character first");
    }

    public void onQuitClicked() {
        Debug.Log("Quit button clicked");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
        Application.Quit();
        #endif
    }
}
