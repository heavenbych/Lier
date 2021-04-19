using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public SpriteRenderer spr;
    VariableJoystick variableJoystick;
    public Vector3 lastVector;
    public Vector3 inputVector;
    void Awake()
    {
        variableJoystick = ControllManager.Instance.variableJoystick;
        spr = this.gameObject.transform.Find("CrossHair").GetComponent<SpriteRenderer>();

    }

    
    private void FixedUpdate()
    {
        float horizontalInput = variableJoystick.Horizontal;
        float verticalInput = variableJoystick.Vertical;
        inputVector = new Vector3(horizontalInput, verticalInput,0);


        if (inputVector.normalized != Vector3.zero)
        {
            lastVector = inputVector.normalized;
        }

        spr.gameObject.transform.position = spr.gameObject.transform.parent.position + lastVector;
    }
}
