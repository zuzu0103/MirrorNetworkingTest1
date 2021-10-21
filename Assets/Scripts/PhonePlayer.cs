using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonePlayer : NetworkBehaviour
{


    void HandleMovement(float deltaTime)
    {
        if (isLocalPlayer)
        {
            float moveHorizontal = 0f;
            float moveVertical = 0f;

            if (Input.GetMouseButton(0))
            {
                
                Vector3 mousePos = new Vector3((Input.mousePosition.x - (Screen.width/2)), (Input.mousePosition.y - (Screen.height/2)), 0f);

                if (mousePos.x < -100f)
                {
                    moveHorizontal = -1f;
                }
                else if (mousePos.x > 100f)
                {
                    moveHorizontal = 1f;
                }

                if (mousePos.y < -100f)
                {
                    moveVertical = -1f;
                }
                else if (mousePos.y > 100f)
                {
                    moveVertical = 1f;
                }
            }
            
            float moveSense = 7.5f;
            Vector3 movement = new Vector3(moveHorizontal * deltaTime * moveSense, moveVertical * deltaTime * moveSense, 0);
            transform.position = transform.position + movement;
        }
    }


    void Update()
    {
        HandleMovement(Time.deltaTime);
    }
}
