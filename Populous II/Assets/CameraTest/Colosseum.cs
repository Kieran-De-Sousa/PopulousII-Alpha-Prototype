using UnityEngine;
using UnityEngine.UI;

// Makes the colosseum fill up

public class Colosseum : MonoBehaviour
{
    [SerializeField] int rowSize;
    [SerializeField] int colSize;
    [SerializeField] float seatSpacing;

    GameObject[] colosseumSeats; 

    int blueTeamCount;
    int redTeamCount;

    int blueTeamNextSeat;
    int redTeamNextSeat;

    int numberOfCollosseumSeats;


    enum Team {  BLUE, RED };

    void Start()
    {
        numberOfCollosseumSeats = rowSize * colSize;
        colosseumSeats = new GameObject[numberOfCollosseumSeats];

        int initializedSeatCount = 0;

        for (int x = 0; x < rowSize; x++)
        {
            for (int y = 0; y < colSize; y++)
            {
                float xPos = seatSpacing * x;
                float yPos = seatSpacing * y;

                colosseumSeats[initializedSeatCount] = new GameObject("Seat (" + initializedSeatCount + ")");
                colosseumSeats[initializedSeatCount].AddComponent<Image>();
                colosseumSeats[initializedSeatCount].GetComponent<RectTransform>().position = new Vector2(xPos, yPos);
                colosseumSeats[initializedSeatCount].GetComponent<RectTransform>().SetParent(transform);

                initializedSeatCount++;
            }
        }

        blueTeamNextSeat = 0;
        redTeamNextSeat = numberOfCollosseumSeats - 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) AddColosseumSeat(Team.BLUE);
        if (Input.GetKeyDown(KeyCode.W)) AddColosseumSeat(Team.RED);

        if (Input.GetKeyDown(KeyCode.E)) RemoveColosseumSeat(Team.BLUE);
        if (Input.GetKeyDown(KeyCode.R)) RemoveColosseumSeat(Team.RED);
    }

    void AddColosseumSeat(Team team)
    {
        switch (team)
        {
            case Team.BLUE:
                colosseumSeats[blueTeamNextSeat].GetComponent<Image>().color = Color.blue;

                blueTeamCount += 1;
                blueTeamNextSeat += blueTeamNextSeat != numberOfCollosseumSeats - 1 ? 1 : 0;
                break;
            case Team.RED:
                colosseumSeats[redTeamNextSeat].GetComponent<Image>().color = Color.red;

                redTeamCount++;
                redTeamNextSeat -= redTeamNextSeat != 0 ? 1 : 0;
                break;
            default:
                Debug.LogError("Team " + team + " is not accounted for!");
                break;
        }
    }

    void RemoveColosseumSeat(Team team)
    {
        switch (team)
        {
            case Team.BLUE:
                colosseumSeats[blueTeamNextSeat].GetComponent<Image>().color = Color.white;

                blueTeamCount--;
                blueTeamNextSeat -= blueTeamNextSeat != 0 ? 1 : 0;
                break;
            case Team.RED:
                colosseumSeats[redTeamNextSeat].GetComponent<Image>().color = Color.white;

                redTeamCount--;
                redTeamNextSeat += redTeamNextSeat != numberOfCollosseumSeats - 1 ? 1 : 0;
                break;
            default:
                Debug.LogError("Team " + team + " is not accounted for!");
                break;
        }
    }
}
