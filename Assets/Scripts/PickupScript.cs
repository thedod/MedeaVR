using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      // nothing yet
    }

    // Update is called once per frame
    void Update()
    {
      // nothing yet
    }

    private void OnTriggerEnter(Collider other) {
      Debug.Log(other.tag.ToString() + " collides with " + gameObject.ToString());
    }
}
