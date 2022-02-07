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
        PEOPLE,
        VEGETATION,
        EARTH,
        AIR,
        FIRE,
        WATER
    };
    private powerGroup selectedPower = powerGroup.PEOPLE;
    
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void clickedEvent(int btnidx)
    {
        switch (btnidx)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                break;
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
                break;
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
                break;
        }
    }
}
