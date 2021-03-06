using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerController playerController;
    RollCharacterController rollCharacterController;
    MainMenuController mainMenuController;

    private void Awake() {
        playerController = GetComponent<PlayerController>();
        rollCharacterController = GetComponent<RollCharacterController>();
        mainMenuController = GetComponent<MainMenuController>();
    }


    // Start is called before the first frame update
    public void Start()
    {
        mainMenuController.initMainMenu(playerController);
        
    }

    // Update is called once per frame
    void Update()
    {
        rollCharacterController.initRollCharacter(playerController);
    }

    
}
