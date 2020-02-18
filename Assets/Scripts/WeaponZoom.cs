using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] Camera FPCamera;

    [SerializeField] float zoomOutValue = 60f;
    [SerializeField] float zoomInValue = 40f;

    RigidbodyFirstPersonController rigidbodyFPCont;

    [SerializeField] float zoomedInSensitivity;

    [SerializeField] float zoomedOutSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyFPCont = gameObject.GetComponentInParent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            FPCamera.fieldOfView = zoomInValue;
            rigidbodyFPCont.mouseLook.YSensitivity = zoomedInSensitivity;
            rigidbodyFPCont.mouseLook.XSensitivity = zoomedInSensitivity;
        }

        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            ZoomOut();
        }

    }

    private void OnDisable()
    {
        ZoomOut();
    }

    public void ZoomOut()
    {
        FPCamera.fieldOfView = zoomOutValue;
        rigidbodyFPCont.mouseLook.YSensitivity = zoomedOutSensitivity;
        rigidbodyFPCont.mouseLook.XSensitivity = zoomedOutSensitivity;
    }

}
