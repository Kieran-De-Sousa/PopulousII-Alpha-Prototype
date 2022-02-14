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

    [Header("NPC Controller")] [SerializeField]
    private NpcManager npcManager;
    
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
                selectedButtonGroup(peopleGroup, previousPower);
                break;
            case powerGroup.VEGETATION:
                selectedButtonGroup(vegetationGroup, previousPower);
                break;
            case powerGroup.EARTH:
                selectedButtonGroup(earthGroup, previousPower);
                break;
            case powerGroup.AIR:
                selectedButtonGroup(airGroup, previousPower);
                break;
            case powerGroup.FIRE:
                selectedButtonGroup(fireGroup, previousPower);
                break;
            case powerGroup.WATER:
                selectedButtonGroup(waterGroup, previousPower);
                break;
        }
    }

    /// <summary>
    /// Triggered whenever a button is clicked
    /// btnidx 1-6   = Ability Group Button
    /// btnidx 7-12  = Ability Button
    /// btnidx 13-18 = Hero Related Button
    /// </summary>
    /// <param name="btnidx"></param>
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

    /// <summary>
    /// Decides which ability to activate based on button clicked
    /// Calls function within spell script
    /// </summary>
    ///<param name="abilityNumber"></param>
    void abilityActivation(int abilityNumber)
    {
        // Save ability group used
        int abilityGroup = abilityGroupActive(selectedPower);

        // Decide which ability button was clicked
        switch (abilityNumber)
        {
            // Ability 1
            case 7:
                switch (abilityGroup)
                {
                    // People Group- Ability 1
                    case 1:
                        break;
                    // Vegetation Group - Ability 1
                    case 2:
                        break;
                    // Earth Group - Ability 1
                    case 3:
                        break;
                    // Air Group - Ability 1
                    case 4:
                        break;
                    // Fire Group - Ability 1
                    case 5:
                        break;
                   // Water Group - Ability 1
                    case 6:
                        break;
                }

                break;
            
            // Ability 2
            case 8:
                switch (abilityGroup)
                {
                    // People Group- Ability 2
                    case 1:
                        break;
                    // Vegetation Group - Ability 2
                    case 2:
                        break;
                    // Earth Group- Ability 2
                    case 3:
                        break;
                    // Air Group - Ability 2
                    case 4:
                        break;
                    // Fire Group - Ability 2
                    case 5:
                        break;
                    // Water Group - Ability 2
                    case 6:
                        break;
                }

                break;
            
            // Ability 3
            case 9:
                switch (abilityGroup)
                {
                    // People Group- Ability 3
                    case 1:
                        break;
                    // Vegetation Group - Ability 3
                    case 2:
                        break;
                    // Earth Group- Ability 3
                    case 3:
                        break;
                    // Air Group - Ability 3
                    case 4:
                        break;
                    // Fire Group - Ability 3
                    case 5:
                        break;
                    // Water Group - Ability 3
                    case 6:
                        break;
                }

                break;
            
            // Ability 4
            case 10:
                switch (abilityGroup)
                {
                    // People Group- Ability 4
                    case 1:
                        break;
                    // Vegetation Group - Ability 4
                    case 2:
                        break;
                    // Earth Group- Ability 4
                    case 3:
                        break;
                    // Air Group - Ability 4
                    case 4:
                        break;
                    // Fire Group - Ability 4
                    case 5:
                        break;
                   // Water Group - Ability 4
                    case 6:
                        break;
                }

                break;
            
            // Ability 5
            case 11:
                switch (abilityGroup)
                {
                    // People Group- Ability 5
                    case 1:
                        break;
                    // Vegetation Group - Ability 5
                    case 2:
                        break;
                    // Earth Group- Ability 5
                    case 3:
                        break;
                    // Air Group - Ability 5
                    case 4:
                        break;
                    // Fire Group - Ability 5
                    case 5:
                        break;
                   // Water Group - Ability 5
                    case 6:
                        break;
                }
                break;
            
            // Ability 6
            case 12:
                switch (abilityGroup)
                {
                    // People Group- Ability 6
                    case 1:
                        break;
                    // Vegetation Group - Ability 6
                    case 2:
                        break;
                    // Earth Group- Ability 6
                    case 3:
                        break;
                    // Air Group - Ability 6
                    case 4:
                        break;
                    // Fire Group - Ability 6
                    case 5:
                        break;
                   // Water Group - Ability 6
                    case 6:
                        break;
                }
                break;
        }
    }

    void heroControls(int heroButtonIdx)
    {
        switch (heroButtonIdx)
        {
            case 13:
                Application.Quit(); // big ui code
                break;
            case 14 :
                npcManager.UpdateNPCState(NpcMovement.MoveState.NORMAL);
                break;
            case 15:
                npcManager.UpdateNPCState(NpcMovement.MoveState.FIGHT);
                break;
            case 16:
                npcManager.UpdateNPCState(NpcMovement.MoveState.GATHER);
                break;
            case 17:
                npcManager.UpdateNPCState(NpcMovement.MoveState.SETTLE);
                break;
            case 18:
                // For magnet just click on the map
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="selectedPowerGroup"></param>
    /// <param name="previousPowerGroup"></param>
    void selectedButtonGroup(Button selectedPowerGroup, powerGroup previousPowerGroup)
    {
        switch (abilityGroupActive(previousPowerGroup))
        {
            case 1:
                peopleGroup.interactable = true;
                break;
            
            case 2:
                vegetationGroup.interactable = true;
                break;
            
            case 3:
                earthGroup.interactable = true;
                break;
            
            case 4:
                airGroup.interactable = true;
                break;
            
            case 5:
                fireGroup.interactable = true;
                break;
            
            case 6:
                waterGroup.interactable = true;
                break;
        }
        
        selectedPowerGroup.interactable = false;
    }

    int abilityGroupActive(powerGroup powerGroupButton)
    {
        switch (powerGroupButton)
        {
            case powerGroup.PEOPLE:
                return 1;
            case powerGroup.VEGETATION:
                return 2;
            case powerGroup.EARTH:
                return 3;
            case powerGroup.AIR:
                return 4;
            case powerGroup.FIRE:
                return 5;
            case powerGroup.WATER:
                return 6;

            // Code broke.
            default:
                return 0;
        }
    }
}
