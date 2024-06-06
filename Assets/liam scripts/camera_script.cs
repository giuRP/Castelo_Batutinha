using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xrotation;
    float yrotation;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yrotation += mouseX;

        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90, 90);

        transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
        orientation.rotation = Quaternion.Euler(0, yrotation, 0);

    }

    public void changeSens(float newsens)
    {
        sensX = newsens;    
        sensY = newsens;    
    }

}
