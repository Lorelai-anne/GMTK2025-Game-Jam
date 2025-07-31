using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static int dayNum;
    public GameObject startDest;
    private Vector3 startPos;
    public static bool nextDay;
    public GameObject player;
    [SerializeField] GameObject fadeToBlack;

    public GameObject package;
    public GameObject deliveredPackage;

    private void Start()
    {
        startPos = startDest.transform.position;
        nextDay = false;
    }

    private void Update()
    {
        if (nextDay)
        {
            fadeToBlack.GetComponent<PlayableDirector>().Play();
            dayNum++;
            Debug.Log("Fade to black");
            Debug.Log("Day "+ dayNum);
            player.transform.position = startPos;
            InitializeObjects();
            Debug.Log("placed player at start location");
            nextDay = false;
        }
    }

    private void InitializeObjects()
    {
        deliveredPackage.SetActive(false);
        package.SetActive(true);
    }
}
