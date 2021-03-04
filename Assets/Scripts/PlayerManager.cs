using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PlayerManager : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */
   
    public class Player {
        // Player Info
        public string name;
        public string race;
        public string playerClass;
        public string allignment;

        // Abilities
        public int strength;
        public int dexterity;
        public int constitution;
        public int intellignece;
        public int wisdom; 
        public int charisma;

        // Player Stats
        public int currXp;
        public int maxXp;
        public int currHp;
        public int maxHp;
        public int armorClass = 14;
        public float walkingSpeed;
        public float runningSpeed;
        public float jumpHeight;
        public List<string> itemList;
    }

    public static PlayerManager _instance;
    public Player player;

    void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }
        
        else {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
            player = new Player();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
