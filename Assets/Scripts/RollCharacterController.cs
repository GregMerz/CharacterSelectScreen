using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class RollCharacterController : MonoBehaviour
{
    //Buttons
    public Button mainMenuButton;
    public Button makeCharacter;
    public Button rollStrengthButton;
    public Button rollDexterityButton;
    public Button rollConstitutionButton;
    public Button rollIntelligenceButton;
    public Button rollWisdomButton;
    public Button rollCharismaButton;

    //Race
    public Dropdown raceDropdown;
    public Text raceDescription;
    protected List<Race> raceList;

    //Class
    public Dropdown classDropdown;
    public Text classDescription;
    protected List<DnDClass> classList;

    //Abilities
    public Text rolledStrength;
    public Text rolledDexterity;
    public Text rolledConstitution;
    public Text rolledIntelligence;
    public Text rolledWisdom;
    public Text rolledCharisma;

    // InputField
    public InputField inputCharacterName;
    public Text characterName;

    //JSON
    public Text jsonFile;

    public class Race {
        public string name = "";
        public string summary = "";
        public int HP = 0;
        public float speedWalking = 0;
        public float speedRunning = 0;
        public float jumpHeight = 0;
        public string languages = "Common";
    }

    public class DnDClass {
        public string name = "";
        public string summary = "";
    }

    public Race race;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton = GameObject.Find("Button_Main_Menu").GetComponent<Button>();
        mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene(0));

        //JSON File
        jsonFile = GameObject.Find("Text_JSON").GetComponent<Text>();

        makeCharacter = GameObject.Find("Button_Make_Character").GetComponent<Button>();
        makeCharacter.onClick.AddListener(() => setJSON());

        //Abilities
        rollStrengthButton = GameObject.Find("Button_Roll_Strength").GetComponent<Button>();
        rollStrengthButton.onClick.AddListener(() => changeTextStrength());

        rollDexterityButton = GameObject.Find("Button_Roll_Dexterity").GetComponent<Button>();
        rollDexterityButton.onClick.AddListener(() => changeTextDexterity());

        rollConstitutionButton = GameObject.Find("Button_Roll_Constitution").GetComponent<Button>();
        rollConstitutionButton.onClick.AddListener(() => changeTextConstitution());

        rollIntelligenceButton = GameObject.Find("Button_Roll_Intelligence").GetComponent<Button>();
        rollIntelligenceButton.onClick.AddListener(() => changeTextIntelligence());

        rollWisdomButton = GameObject.Find("Button_Roll_Wisdom").GetComponent<Button>();
        rollWisdomButton.onClick.AddListener(() => changeTextWisdom());

        rollCharismaButton = GameObject.Find("Button_Roll_Charisma").GetComponent<Button>();
        rollCharismaButton.onClick.AddListener(() => changeTextCharisma());

        rolledStrength = GameObject.Find("Text_Rolled_Strength").GetComponent<Text>();
        rolledDexterity = GameObject.Find("Text_Rolled_Dexterity").GetComponent<Text>();
        rolledConstitution = GameObject.Find("Text_Rolled_Constitution").GetComponent<Text>();
        rolledIntelligence = GameObject.Find("Text_Rolled_Intelligence").GetComponent<Text>();
        rolledWisdom = GameObject.Find("Text_Rolled_Wisdom").GetComponent<Text>();
        rolledCharisma = GameObject.Find("Text_Rolled_Charisma").GetComponent<Text>();

        // Class Dropdown
        classList = new List<DnDClass>() {
        new DnDClass() { name = "Barbarian", summary = "In battle, you fight with primal ferocity. For some barbarians, rage is a means to an end–that end being violence."},
        new DnDClass() { name = "Bard", summary = "Whether singing folk ballads in taverns or elaborate compositions in royal courts, bards use their gifts to hold audiences spellbound."},
        new DnDClass() { name = "Cleric", summary = "Clerics act as conduits of divine power."},
        new DnDClass() { name = "Druid", summary = "Druids venerate the forces of nature themselves. Druids holds certain plants and animals to be sacred, and most druids are devoted to one of the many nature deities."},
        new DnDClass() { name = "Fighter", summary = "Different fighters choose different approaches to perfecting their fighting prowess, but they all end up perfecting it."},
        new DnDClass() { name = "Monk", summary = "Coming from monasteries, monks are masters of martial arts combat and meditators with the ki living forces."},
        new DnDClass() { name = "Paladin", summary = "Paladins are the ideal of the knight in shining armor; they uphold ideals of justice, virtue, and order and use righteous might to meet their ends."},
        new DnDClass() { name = "Ranger", summary = "Acting as a bulwark between civilization and the terrors of the wilderness, rangers study, track, and hunt their favored enemies."},
        new DnDClass() { name = "Rogue", summary = "Rogues have many features in common, including their emphasis on perfecting their skills, their precise and deadly approach to combat, and their increasingly quick reflexes."},
        new DnDClass() { name = "Sorcerer", summary = "An event in your past, or in the life of a parent or ancestor, left an indelible mark on you, infusing you with arcane magic. As a sorcerer the power of your magic relies on your ability to project your will into the world."},
        new DnDClass() { name = "Warlock", summary = "You struck a bargain with an otherworldly being of your choice: the Archfey, the Fiend, or the Great Old One who has imbued you with mystical powers, granted you knowledge of occult lore, bestowed arcane research and magic on you and thus has given you facility with spells."},
        new DnDClass() { name = "Wizard", summary = "The study of wizardry is ancient, stretching back to the earliest mortal discoveries of magic. As a student of arcane magic, you have a spellbook containing spells that show glimmerings of your true power which is a catalyst for your mastery over certain spells."}
        };

        classDescription = GameObject.Find("Text_Class_Description").GetComponent<Text>();
        classDropdown = GameObject.Find("Dropdown_Class").GetComponent<Dropdown>();
        classDropdown.ClearOptions();
        List<string> newOptions = new List<string>();
        for (int i = 0; i < classList.Count; i++) {
            newOptions.Add(classList[i].name);
        }

        classDropdown.AddOptions(newOptions);
        classDropdown_IndexChanged(0);

        classDropdown.onValueChanged.AddListener(classDropdown_IndexChanged);

        // Race Dropdown
        raceList = new List<Race>() {
        new Race() { name = "Dragonborn", summary = "Your draconic heritage manifests in a variety of traits you share with other dragonborn.", HP = 1, speedWalking = 1, speedRunning = 2, jumpHeight = 1, languages = "Common, Draconic"},
        new Race() { name = "Dwarf", summary = "Your dwarf character has an assortment of in abilities, part and parcel of dwarven nature.", HP = 1, speedWalking = 1, speedRunning = 2, jumpHeight = 1, languages = "Common, Dwarfish"},
        new Race() { name = "Elf", summary = "Your elf character has a variety of natural abilities, the result of thousands of years of elven refinement.", HP = 1, speedWalking = 1, speedRunning = 2, jumpHeight = 1, languages = "Common, Elfish"},
        new Race() { name = "Gnome", summary = "Your gnome character has certain characteristics in common with all other gnomes.", HP = 1, speedWalking = 1, speedRunning = 2, jumpHeight = 1, languages = "Common, Gnomic"},
        new Race() { name = "Half-Elf", summary = "Your half-elf character has some qualities in common with elves and some that are unique to half-elves.", HP = 1, speedWalking = 1, speedRunning = 2, jumpHeight = 1, languages = "Common, Elfish"},
        new Race() { name = "Half-Orc", summary = "Your half-orc character has certain traits deriving from your orc ancestry.", HP = 1, speedWalking = 1, speedRunning = 2, jumpHeight = 1, languages = "Common, Orcish"},
        new Race() { name = "Halfling", summary = "Your halfling character has a number of traits in common with all other halflings.", HP = 1, speedWalking = 1, speedRunning = 2, jumpHeight = 1, languages = "Common, Halflaic"},
        new Race() { name = "Human", summary = "It's hard to make generalizations about humans, but your human character has these traits.", HP = 1, speedWalking = 1, speedRunning = 2, jumpHeight = 1, languages = "Common"},
        new Race() { name = "Tiefling", summary = "Tieflings share certain racial traits as a result of their infernal descent.", HP = 1, speedWalking = 1, speedRunning = 2, jumpHeight = 1, languages = "Common, Tieflaic"}
        };

        raceDescription = GameObject.Find("Text_Race_Description").GetComponent<Text>();
        raceDropdown = GameObject.Find("Dropdown_Race").GetComponent<Dropdown>();
        raceDropdown.ClearOptions();
        newOptions = new List<string>();
        for (int i = 0; i < raceList.Count; i++) {
            newOptions.Add(raceList[i].name);
        }

        raceDropdown.AddOptions(newOptions);
        raceDropdown_IndexChanged(0);

        raceDropdown.onValueChanged.AddListener(raceDropdown_IndexChanged);

        characterName = GameObject.Find("Text_Character_Name").GetComponent<Text>();
        inputCharacterName = GameObject.Find("InputField_Character_Name").GetComponent<InputField>();

        inputCharacterName.onValueChanged.AddListener(output);
    }

    public void setJSON() {
        jsonFile.text = "{\"name\": ,\"race\": ,\"playerClass\": ,\"allignment\": ,\"strength\": ,\"dexterity\": ,\"constitution\": ,\"intelligence\": ,\"wisdom\": ,\"charisma\": ,\"currXp\": ,\"maxXp\": ,\"currHp\": ,\"maxHp\": ,\"armorClass\": ,\"walkingSpeed\": ,\"runningSpeed\": ,\"jumpHeight\": ,\"itemList\": }";   
    }
    public void output(string text) {
        
    }

    public void raceDropdown_IndexChanged(int index) {
        Race selected = raceList[raceDropdown.value];

/*
        playerManager.player.race = selected.name;
        playerManager.player.walkingSpeed = selected.speedWalking;
        playerManager.player.runningSpeed = selected.speedRunning;
        playerManager.player.jumpHeight = selected.jumpHeight;
        playerManager.player.maxHp = selected.HP;
        playerManager.player.currHp = selected.HP;
        */

        raceDescription.text = selected.name + "- " + selected.summary
            + "\nHP = " + selected.HP.ToString()
            + "\nWalkingSpeed = " + selected.speedWalking.ToString()
            + "\nLanguages = " + selected.languages.ToString();
    }

    public void classDropdown_IndexChanged(int index) {
        DnDClass selected = classList[classDropdown.value];

        classDescription.text = selected.name + "- " + selected.summary;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeTextStrength() {
        int strength = Roll7d4();
//        playerManager.player.strength = strength;

        rolledStrength.text = strength.ToString();
    }

    void changeTextDexterity() {
        int dexterity = Roll7d4();
//        playerManager.player.dexterity = dexterity;

        rolledDexterity.text = "" + dexterity.ToString();
    }

    void changeTextConstitution() {
        int constitution = Roll7d4();
//        playerManager.player.constitution = constitution;

        rolledConstitution.text = "" + constitution.ToString();
    }

    void changeTextIntelligence() {
        int intelligence = Roll7d4();
//        playerManager.player.intelligence = intelligence;

        rolledIntelligence.text = "" + intelligence.ToString();
    }

    void changeTextWisdom() {
        int wisdom = Roll7d4();
//        playerManager.player.wisdom = wisdom;

        rolledWisdom.text = "" + wisdom.ToString();
    }

    void changeTextCharisma() {
        int charisma = Roll7d4();
//        playerManager.player.charisma = charisma;

        rolledCharisma.text = "" + charisma.ToString();
    }

    int Roll7d4() {
        int sum = 0;
        int modifier = 2;
        int highestRoll = 0;
        int secondHighestRoll = 0;
        int thirdHighestRoll = 0;

        for (int i = 0; i < 7; i++) {
            int roll = UnityEngine.Random.Range(1, 5);

            if (roll > highestRoll) {
                thirdHighestRoll = secondHighestRoll;
                secondHighestRoll = highestRoll;
                highestRoll = roll;
            }

            else if (roll > secondHighestRoll) {
                thirdHighestRoll = secondHighestRoll;
                secondHighestRoll = roll;
            }

            else if (roll > thirdHighestRoll) {
                thirdHighestRoll = roll;
            }
        }

        sum = highestRoll + secondHighestRoll + thirdHighestRoll;
        sum += modifier;

        return sum;
    }
}
