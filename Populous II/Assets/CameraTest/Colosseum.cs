using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Makes the colosseum fill up

public class Colosseum : MonoBehaviour
{
    [Header("Colosseum")]
    [SerializeField] int rowSize;
    [SerializeField] int colSize;

    [SerializeField] float seatSpacing;
    [SerializeField] Vector3 seatSize;

    [Header("UI")]
    [SerializeField] TMP_Text blueTeamCountText;
    [SerializeField] TMP_Text redTeamCountText;

    GameObject[] colosseumSeats; 

    int blueTeamCount;
    int redTeamCount;

    int blueTeamNextSeat;
    int redTeamNextSeat;

    int numberOfCollosseumSeats;

    public enum Team {  BLUE, RED };

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
                colosseumSeats[initializedSeatCount].GetComponent<RectTransform>().position = transform.position + new Vector3(xPos, yPos, 0);
                colosseumSeats[initializedSeatCount].GetComponent<RectTransform>().SetParent(transform);
                colosseumSeats[initializedSeatCount].GetComponent<RectTransform>().localScale = seatSize;

                initializedSeatCount++;
            }
        }

        blueTeamNextSeat = 0;
        redTeamNextSeat = numberOfCollosseumSeats - 1;
    }

    public void AddColosseumSeat(Team team)
    {
        switch (team)
        {
            case Team.BLUE:
                colosseumSeats[blueTeamNextSeat].GetComponent<Image>().color = Color.blue;

                blueTeamCount += 1;
                blueTeamNextSeat += blueTeamNextSeat != numberOfCollosseumSeats - 1 ? 1 : 0;

                blueTeamCountText.text = blueTeamCount.ToString();
                break;
            case Team.RED:
                colosseumSeats[redTeamNextSeat].GetComponent<Image>().color = Color.red;

                redTeamCount++;
                redTeamNextSeat -= redTeamNextSeat != 0 ? 1 : 0;

                redTeamCountText.text = redTeamCount.ToString();
                break;
            default:
                Debug.LogError("Team " + team + " is not accounted for!");
                break;
        }
    }

    public void RemoveColosseumSeat(Team team)
    {
        switch (team)
        {
            case Team.BLUE:
                colosseumSeats[blueTeamNextSeat].GetComponent<Image>().color = Color.white;

                blueTeamCount--;
                blueTeamNextSeat -= blueTeamNextSeat != 0 ? 1 : 0;

                blueTeamCountText.text = blueTeamCount.ToString();
                break;
            case Team.RED:
                colosseumSeats[redTeamNextSeat].GetComponent<Image>().color = Color.white;

                redTeamCount--;
                redTeamNextSeat += redTeamNextSeat != numberOfCollosseumSeats - 1 ? 1 : 0;

                redTeamCountText.text = redTeamCount.ToString();
                break;
            default:
                Debug.LogError("Team " + team + " is not accounted for!");
                break;
        }
    }

    public void ResetColosseum()
    {
        foreach (GameObject image in colosseumSeats)
        {
            image.GetComponent<Image>().color = Color.white;
        }

        blueTeamNextSeat = 0;
        redTeamNextSeat = numberOfCollosseumSeats - 1;

        blueTeamCount = 0;
        redTeamCount = 0;

        blueTeamCountText.text = "0";
        redTeamCountText.text = "0";
    }
}
