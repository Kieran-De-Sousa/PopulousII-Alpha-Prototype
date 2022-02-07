using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [Header("Power Selector")]
    public Button peopleGroup;
    public Button vegetationGroup;
    public Button earthGroup;
    public Button airGroup;
    public Button fireGroup;
    public Button waterGroup;
    private enum powerGroup
    {
        PEOPLE = 1,
        VEGETATION = 2,
        EARTH = 3,
        AIR = 4,
        FIRE = 5,
        WATER = 6
    };
    private powerGroup selectedPower = powerGroup.PEOPLE;
    private powerGroup previousPower = powerGroup.WATER;
    private Button selectedPowerGroup;
    private Button previousPowerGroup;
    
    [Header("Ability Buttons")]
    public Button ability1;
    public Button ability2;
    public Button ability3;
    public Button ability4;
    public Button ability5;
    public Button ability6;
    [Header("Unit Buttons")] 
    public Button temp1;
    public Button temp2;
    public Button temp3;
    public Button temp4;
    public Button temp5;
    public Button temp6;
    
    void Start()
    {
        peopleGroup.onClick.AddListener(delegate { clickedEvent(1); });
        vegetationGroup.onClick.AddListener(delegate { clickedEvent(2); });
        earthGroup.onClick.AddListener(delegate { clickedEvent(3); });
        airGroup.onClick.AddListener(delegate { clickedEvent(4); });
        fireGroup.onClick.AddListener(delegate { clickedEvent(5); });
        waterGroup.onClick.AddListener(delegate { clickedEvent(6); });
        
        ability1.onClick.AddListener(delegate { clickedEvent(7); });
        ability2.onClick.AddListener(delegate { clickedEvent(8); });
        ability3.onClick.AddListener(delegate { clickedEvent(9); });
        ability4.onClick.AddListener(delegate { clickedEvent(10); });
        ability5.onClick.AddListener(delegate { clickedEvent(11); });
        ability6.onClick.AddListener(delegate { clickedEvent(12); });
        
        temp1.onClick.AddListener(delegate { clickedEvent(13); });
        temp2.onClick.AddListener(delegate { clickedEvent(14); });
        temp3.onClick.AddListener(delegate { clickedEvent(15); });
        temp4.onClick.AddListener(delegate { clickedEvent(16); });
        temp5.onClick.AddListener(delegate { clickedEvent(17); });
        temp6.onClick.AddListener(delegate { clickedEvent(18); });

        
        selectedPowerGroup = peopleGroup;
        previousPowerGroup = waterGroup;
    }

    private void Update()
    {
        switch (selectedPower)
        {
            case powerGroup.PEOPLE:
                selectedButton(peopleGroup, previousPower);
                break;
            case powerGroup.VEGETATION:
                selectedButton(vegetationGroup, previousPower);
                break;
            case powerGroup.EARTH:
                selectedButton(earthGroup, previousPower);
                break;
            case powerGroup.AIR:
                selectedButton(airGroup, previousPower);
                break;
            case powerGroup.FIRE:
                selectedButton(fireGroup, previousPower);
                break;
            case powerGroup.WATER:
                selectedButton(waterGroup, previousPower);
                break;
        }
    }

    void clickedEvent(int btnidx)
    {
        switch (btnidx)
        {
            // Ability Groups
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                abilityGroupSelection(btnidx);
                break;
            // Abilities
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
                abilityActivation(btnidx);
                break;
            // Hero Tools
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
                heroControls(btnidx);
                break;
        }
    }

    void abilityGroupSelection(int idx)
    {
        previousPower = selectedPower;
        selectedPower = (powerGroup) idx;
        Debug.Log("Power Selected: " + selectedPower);
    }

    void abilityActivation(int idx)
    {
        switch (idx)
        {
            case 7:
                break;
            
            case 8:
                break;
            
            case 9:
                break;
            
            case 10:
                break;
            
            case 11:
                break;
            
            case 12:
                break;
        }
        // Get player mana
        // If player has enough mana for ability using idx
    }

    void heroControls(int idx)
    {
        
    }

    void selectedButton(Button selectedButton, powerGroup previousPower)
    {
        switch (previousPower)
        {
            case powerGroup.PEOPLE:
                peopleGroup.interactable = true;
                break;
            
            case powerGroup.VEGETATION:
                vegetationGroup.interactable = true;
                break;
            
            case powerGroup.EARTH:
                earthGroup.interactable = true;
                break;
            
            case powerGroup.AIR:
                
                airGroup.interactable = true;
                break;
            
            case powerGroup.FIRE:
                fireGroup.interactable = true;
                break;
            
            case powerGroup.WATER:
                waterGroup.interactable = true;
                break;
        }
        
        selectedButton.interactable = false;
    }

    int abilityUsedDecision()
    {
        switch (selectedPower)
        {
            
        }
    }
}
