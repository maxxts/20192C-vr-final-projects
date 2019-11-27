using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabAction : MonoBehaviour
{
    public GameObject playerHand;

    GameObject targetObject = null;
    bool objectInHand = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AquireTarget(GameObject target)
    {
        if (target.tag == "InteractiveItem")
        {
            targetObject = target;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && targetObject != null) {
            if (!objectInHand)
            {
                targetObject.transform.SetParent(playerHand.transform);
                //targetObject.transform.localPosition = playerHand.transform.localPosition;
                targetObject.transform.localPosition = new Vector3(0f, 0f, 0f);
                objectInHand = true;
            }
            else
            {
                targetObject.transform.SetParent(null);
                objectInHand = false;
                targetObject = null;
            }            
        }
    }
}
