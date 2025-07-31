using System.Collections;
using UnityEngine;

public class DeliverPackage : MonoBehaviour
{
    public GameObject player;
    public GameObject package;
    public GameObject deliveredPackage;
    private void Start()
    {
        deliveredPackage.SetActive(false);
        package.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Arrived at npc");
        if (collision.gameObject.CompareTag("Player"))
        {
            deliveredPackage.SetActive(true);
            package.SetActive(false);
            Debug.Log("Package was delivered");
            StartCoroutine(ChangeDay(2f));
        }
    }

    IEnumerator ChangeDay(float delayTime)
    {
        Debug.Log("Waiting " + delayTime + " seconds");
        yield return new WaitForSeconds(delayTime);
        Debug.Log("Performing day change");
        GameManager.nextDay = true;
    }
}
