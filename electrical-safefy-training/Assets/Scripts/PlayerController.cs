using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerHand;
    public float speed = 3.5f;
    public float interactRange = 1.2f;

    private float gravity = 10f;
    private CharacterController controller;
    private RaycastHit _rayHit;
    private GameObject objectInSight = null;
    private bool objectInHand = false;
    private DebugPanel debugPanel = null;
    System.Array keys;

    // Start is called before the first frame update
    void Start()
    {
        // key mapping for vrbox controller debugging
        keys = System.Enum.GetValues(typeof(KeyCode));
        controller = GetComponent<CharacterController>();
        var panel = GameObject.FindGameObjectWithTag("DebugPanel");
        if (panel != null)
        {
            debugPanel = panel.GetComponent<DebugPanel>();
        }
    }

    public void AquireTarget(GameObject target)
    {
        float dist = Vector3.Distance(target.transform.position, playerHand.transform.position);
        if (target.tag == "InteractiveItem" && dist <= interactRange)
        {
            objectInSight = target;
            objectInSight.GetComponent<InteractiveItem>().HighlightOn();
        }
    }

    public void ReleaseTarget()
    {
        objectInSight = null;
    }

    // Update is called once per frame
    void Update()
    {
        // for debugging - todo: change to VR panel for ingame debugging
        if (debugPanel != null && Input.anyKeyDown)
        {
            foreach (KeyCode code in keys)
            {
                if (Input.GetKeyDown(code)) { debugPanel.print(System.Enum.GetName(typeof(KeyCode), code)); }
            }
        }

        // RAYCAST NOT WORKING IN ANDROID
        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        //if (Physics.Raycast(ray, out _rayHit, interactRange))
        //{
        //    var itemInRange = _rayHit.transform.gameObject;
        //    if (itemInRange.CompareTag("InteractiveItem"))
        //    {
        //        // Highlight item in range
        //        itemInRange.GetComponent<InteractiveItem>().HighlightOn();

        //        if (ValidGrabKey())

        //        {
        //            GrabAndDropItem(_rayHit.transform.gameObject);
        //        }
        //    }
        //}

        if (ValidGrabKey() && objectInSight != null)
        {
            GrabAndDropItem(objectInSight);
        }

        PlayerMovement();
    }

    bool ValidGrabKey()
    {
        return (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire3"));
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
    }

 

    void GrabAndDropItem(GameObject objectInSight)
    {
        if (!objectInHand)
        {
            objectInSight.transform.SetParent(playerHand.transform);
            //targetObject.transform.localPosition = playerHand.transform.localPosition;
            objectInSight.transform.localPosition = new Vector3(0f, 0f, 0f);
            objectInHand = true;
        }
        else
        {
            objectInSight.transform.SetParent(GameObject.FindGameObjectWithTag("ItemContainer").transform);
            objectInHand = false;
            objectInSight = null;
        }
    } 
}
