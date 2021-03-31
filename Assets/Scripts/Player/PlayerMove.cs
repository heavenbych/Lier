using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour         //플레이어 이동 벡터 설정 파일
{
    public float speed;
    public Rigidbody2D rbody;

    VariableJoystick variableJoystick;           //조이스틱 선언
    PlayerRender playerRenderer;


    private void Awake()
    {
        variableJoystick = ControllManager.Instance.variableJoystick;
        rbody = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponentInChildren<PlayerRender>();
    }
    public void FixedUpdate()
    {
        //이하 아래 두 줄은 바로 이동하는게 아닌 AddForce를 사용해 이동
        //Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime);

        //Rigidbody에서 좌표값, 조이스틱에서 x, y이동값 받아서 벡터 생성
        Vector2 currentPos = rbody.position;


        float horizontalInput = variableJoystick.Horizontal;
        float verticalInput = variableJoystick.Vertical;
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);

        //벡터 단일화 후 스피드 곱해서 이동거리 계산 후 
        //프레임당 움직이는 거리 계수 곱해줌
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector.normalized * speed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;


        playerRenderer.SetDirection(movement);
        //rigidbody 이동
        rbody.MovePosition(newPos);
    }
}
