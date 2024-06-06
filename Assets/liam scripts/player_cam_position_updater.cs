using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_cam_position_updater : MonoBehaviour
{
    public Transform camPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camPosition.position;
    }
}
