using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRender : MonoBehaviour
{
    public static readonly string[] staticDirections = { "Idle_N", "Idle_NW", "Idle_W", "Idle_SW", "Idle_S", "Idle_SE", "Idle_E", "Idle_NE" };
    public static readonly string[] runDirections = { "Move_N", "Move_NW", "Move_W", "Move_SW", "Move_S", "Move_SE", "Move_E", "Move_NE" };
    public static readonly string[] dashDirections = { "Dash_N", "Dash_NW", "Dash_W", "Dash_SW", "Dash_S", "Dash_SE", "Dash_E", "Dash_NE" };
    public static readonly string[] attackDirections = { "Att_N", "Att_N", "Att_N", "Att_N", "Att_N", "Att_N", "Att_N", "Att_N" };
        //"Att_NW", "Att_W", "Att_SW", "Att_S", "Att_SE", "Att_E", "Att_NE" };

    Animator animator;
    int lastDirection;

    private void Awake()
    {
        //cache the animator component
        //애니메이터 컴포넌트 캐싱
        animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction)
    {

        //use the Run states by default
        string[] directionArray = null;

        //measure the magnitude of the input.
        if (direction.magnitude < .01f) //벡터의 길이가 0.1미만일때?
        {
            //if we are basically standing still, we'll use the Static states
            //we won't be able to calculate a direction if the user isn't pressing one, anyway!
            directionArray = staticDirections;
        }
        else
        {
            //we can calculate which direction we are going in
            //use DirectionToIndex to get the index of the slice from the direction vector
            //save the answer to lastDirection
            directionArray = runDirections;
            lastDirection = DirectionToIndex(direction, 8);
        }
        if (SkillManager.Instance.isAttacking)
        {
            directionArray = attackDirections;
        }
        if (SkillManager.Instance.isDashing)
        {
            directionArray = dashDirections;
        }
        

        //tell the animator to play the requested state
        animator.Play(directionArray[lastDirection]);
    }

    //helper functions

    //this function converts a Vector2 direction to an index to a slice around a circle
    //this goes in a counter-clockwise direction.
    public static int DirectionToIndex(Vector2 dir, int sliceCount)
    {
        //get the normalized direction
        Vector2 normDir = dir.normalized;
        //calculate how many degrees one slice is
        float step = 360f / sliceCount;
        //calculate how many degress half a slice is.
        //we need this to offset the pie, so that the North (UP) slice is aligned in the center
        float halfstep = step / 2;
        //get the angle from -180 to 180 of the direction vector relative to the Up vector.
        //this will return the angle between dir and North.
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        //add the halfslice offset
        angle += halfstep;
        //if angle is negative, then let's make it positive by adding 360 to wrap it around.
        if (angle < 0)
        {
            angle += 360;
        }
        //calculate the amount of steps required to reach this angle
        float stepCount = angle / step;
        //round it, and we have the answer!
        return Mathf.FloorToInt(stepCount);
    }







    //this function converts a string array to a int (animator hash) array.
    public static int[] AnimatorStringArrayToHashArray(string[] animationArray)
    {
        //allocate the same array length for our hash array
        int[] hashArray = new int[animationArray.Length];
        //loop through the string array
        for (int i = 0; i < animationArray.Length; i++)
        {
            //do the hash and save it to our hash array
            hashArray[i] = Animator.StringToHash(animationArray[i]);
        }
        //we're done!
        return hashArray;
    }

}
