using System.Collections;
using UnityEngine;

public class DeliverPackage : MonoBehaviour
{
    public GameObject player;
    public GameObject package;
    public GameObject deliveredPackage;
    private bool hasPlayerEntered;
    private void Start()
    {
        deliveredPackage.SetActive(false);
        package.SetActive(true);
        //hasPlayerEntered = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            deliveredPackage.SetActive(true);
            package.SetActive(false);
            Debug.Log("Package was delivered");
            Delivered();
            Day.deliveredPackages++;
            //hasPlayerEntered = true;
        }
    }

    public static bool Delivered()
    {
        return true;
    }
}
