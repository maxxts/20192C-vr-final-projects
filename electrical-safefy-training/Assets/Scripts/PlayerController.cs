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
    //private GameObject objectInSight = null;
    private bool objectInHand = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out _rayHit, interactRange))
        {
            var itemInRange = _rayHit.transform.gameObject;
            if (itemInRange.CompareTag("InteractiveItem"))
            {
                // Highlight item in range
                itemInRange.GetComponent<InteractiveItem>().HighlightOn();

                if (Input.GetButtonDown("Fire1")) //TODO: identify correct input code for VrBox controller

                {
                    GrabAndDropItem(_rayHit.transform.gameObject);
                }
            }
        }

        PlayerMovement();
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
