using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static int dayNum = 4;
    public static int currDay = 0;
    public GameObject startDest;
    private Vector3 startPos;
    public static bool nextDay;
    public GameObject player;

    public GameObject package;
    public GameObject[] deliveredPackages;
    public Day[] days;

    public GameObject day1;
    public GameObject day2;
    public GameObject day3;

    private int i = 0;

    private void Start()
    {
        InitializeObjects();
        Debug.Log("Day " + currDay + " started");
        startPos = startDest.transform.position;
        nextDay = false;
        days[i].dayFinished = false;
    }

    private void Update()
    {
        if (days[i].dayFinished == false && currDay == i && i<dayNum)
        {
            days[i].CheckIfFinished();
        }
        if (days[i].dayFinished == true )
        {
            Debug.Log("The day is finished");
            nextDay = true;
            currDay++;
            days[i].dayFinished = false;
            if(i < 1 && days[i].lastDay == false)
            {
                i++;
            }
        }
        if (nextDay && days[i].lastDay == false)
        {
            Day.deliveredPackages = 0;
            Debug.Log("Day " + currDay +" started");
            player.transform.position = startPos;
            InitializeObjects();
            nextDay = false;
        }
    }

    private void InitializeObjects()
    {
        if(currDay == 0)
        {
            day1.SetActive(true);
            day2.SetActive(false);
            day3.SetActive(false);
        }
        if(currDay == 1)
        {
            day1.SetActive(false);
            day2.SetActive(true);
            day3.SetActive(false);
        }
        if(currDay == 2)
        {
            day1.SetActive(false);
            day2.SetActive(false);
            day3.SetActive(true);
        }
        for (int j = 0; j < deliveredPackages.Length; j++)
        {
            deliveredPackages[j].gameObject.SetActive(false);
        }
        package.SetActive(true);
    }
}
