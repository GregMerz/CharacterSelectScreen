using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerManager playerManager;
    RollCharacterController rollCharacterController;

    private void Awake() {
        playerManager = GetComponent<PlayerManager>();
        rollCharacterController = GetComponent<RollCharacterController>();
    }


    // Start is called before the first frame update
    public void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
