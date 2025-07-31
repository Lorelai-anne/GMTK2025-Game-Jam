using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "NewDayData", menuName = "Day Data")]
public class Day : ScriptableObject
{
    public int dayNum;
    public static int deliveredPackages;
    public int packagesToBeDelivered;
    public bool dayFinished {get; set;}

    public void CheckIfFinished()
    {
        if (deliveredPackages == packagesToBeDelivered)
        {
            Debug.Log(deliveredPackages + " packages have been delivered out of " + packagesToBeDelivered);
            dayFinished = true;
            Debug.Log("All " + packagesToBeDelivered + " packages delivered on " + dayNum);
        }
        else
        {
            dayFinished =false;
        }
    }
}
