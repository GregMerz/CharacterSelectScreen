﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class RollCharacterManager : MonoBehaviour
{
    //Buttons
    PlayerManager playerManager;
    public Button mainMenuButton;
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

    //Abilities
    public Text rolledStrength;
    public Text rolledDexterity;
    public Text rolledConstitution;
    public Text rolledIntelligence;
    public Text rolledWisdom;
    public Text rolledCharisma;

    public class Race {
        public string name = "";
        public string summary = "";
        public int HP = 0;
        public float speedWalking = 0;
        public float speedRunning = 0;
        public float jumpHeight = 0;
        public string languages = "Common";
    }

    public Race race;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();

        mainMenuButton = GameObject.Find("Button_Main_Menu").GetComponent<Button>();
        mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene(0));

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

//        GameObject objRaceDropdown = GameObject.FindGameObjectWithTag("Dropdown_Race");
        raceDescription = GameObject.Find("Text_Race_Description").GetComponent<Text>();

        raceDropdown = GameObject.Find("Dropdown_Race").GetComponent<Dropdown>();
        raceDropdown.ClearOptions();
        List<string> newOptions = new List<string>();
        for (int i = 0; i < raceList.Count; i++) {
            newOptions.Add(raceList[i].name);
        }

        raceDropdown.AddOptions(newOptions);
        raceDropdown_IndexChanged(0);

        raceDropdown.onValueChanged.AddListener(raceDropdown_IndexChanged);
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
            + "\n HP = " + selected.HP.ToString()
            + "\n WalkingSpeed = " + selected.speedWalking.ToString()
            + "\n Languages = " + selected.languages.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeTextStrength() {
        int strength = Roll7d4();
        playerManager.player.strength = strength;

        rolledStrength.text = "" + strength;
    }

    void changeTextDexterity() {
        int dexterity = Roll7d4();
        playerManager.player.dexterity = dexterity;

        rolledDexterity.text = "" + dexterity;
    }

    void changeTextConstitution() {
        int constitution = Roll7d4();
        playerManager.player.constitution = constitution;

        rolledConstitution.text = "" + constitution;
    }

    void changeTextIntelligence() {
        int intelligence = Roll7d4();
        playerManager.player.intelligence = intelligence;

        rolledIntelligence.text = "" + intelligence;
    }

    void changeTextWisdom() {
        int wisdom = Roll7d4();
        playerManager.player.wisdom = wisdom;

        rolledWisdom.text = "" + wisdom;
    }

    void changeTextCharisma() {
        int charisma = Roll7d4();
        playerManager.player.charisma = charisma;

        rolledCharisma.text = "" + charisma;
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
