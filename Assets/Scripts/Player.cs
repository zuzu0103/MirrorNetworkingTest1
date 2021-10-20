using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{


    void HandleMovement(float deltaTime)
    {
        if (isLocalPlayer)
        {
            float moveSense = 7.5f;
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * deltaTime * moveSense, moveVertical * deltaTime * moveSense, 0);
            transform.position = transform.position + movement;
        }
    }


    void Update()
    {
        HandleMovement(Time.deltaTime);
    }
}
