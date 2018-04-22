using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float horizontalAmount = 0.1f;
    public float verticalAmount = 0.1f;
    public float bobbingSpeed = 0.13f;

    private Vector3 startPoint;
    private float timer;

    void Start()
    {
        //Getting the default position of the weapon.
        startPoint = transform.localPosition;
    }

    void Update()
    {
        //Variables for the weapon bob.
        float waveSliceX = 0f;
        float waveSliceY = 0f;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //If we are not moving, reset the timer.
        if (horizontal == 0 && vertical == 0)
        {
            timer = 0;
        }

        //If we are moving...
        else
        {
            //...building the waveslice and the timer.
            waveSliceX = Mathf.Cos(timer);
            waveSliceY = Mathf.Sin(timer * 2);

            timer = timer + bobbingSpeed;

            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }

        //If there is change...
        if (waveSliceX != 0)
        {
            //...calculate the amount of change.
            float translateChangeX = waveSliceX * horizontalAmount;
            float translateChangeY = waveSliceY * verticalAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

            //Clamp the change.
            totalAxes = Mathf.Clamp(totalAxes, 0, 1);
            translateChangeX = totalAxes * translateChangeX;
            translateChangeY = totalAxes * translateChangeY;

            //Finally, move the weapon.
            Vector3 cameraPos = new Vector3(startPoint.x + translateChangeX, startPoint.y - translateChangeY, transform.localPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, cameraPos, Time.deltaTime * 5);
        }

        //If there is no change...
        else
        {
            //...move the weapon to its original position.
            Vector3 cameraPos = new Vector3(startPoint.x, startPoint.y, transform.localPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, cameraPos, Time.deltaTime * 5);
        }
    }
}
