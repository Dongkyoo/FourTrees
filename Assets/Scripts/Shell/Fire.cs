﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    private const float MIN_POWER = 500.0f;
    private const float MAX_POWER = 3000.0f;
    public float currentPower;
    private int sign = 1;
    private const float PUSH_TIME = 0.9f;
    private bool IsSpacePressed = false;
    public Transform firePosition;
    private float chargeSpeed;
    public Slider powerGage;
    public Shell shell;

    // Start is called before the first frame update
    void Start()
    {
        currentPower = MIN_POWER;
        powerGage.maxValue = MAX_POWER;
        powerGage.value = currentPower;
        chargeSpeed = (MAX_POWER - MIN_POWER) / PUSH_TIME;
    }


    // Update is called once per frame
    void Update()
    {
        //push space bar
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            shell.direction = this.transform.forward + new Vector3(0, 1.0f, 0);
            IsSpacePressed = true;
        }
        //released spcae bar
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            shell.power = currentPower;
            Instantiate(shell, firePosition.position, firePosition.rotation);
            IsSpacePressed = false;
            //reset
            currentPower = MIN_POWER;
            shell.power = MIN_POWER;
        }
        //space bar is being pressed
        if (IsSpacePressed)
        {

            currentPower += chargeSpeed * Time.deltaTime * sign;
            powerGage.value = currentPower;

            if (currentPower >= MAX_POWER)
            {
                sign = -1;
                currentPower += chargeSpeed * Time.deltaTime * sign;
                powerGage.value = currentPower;
            }
            else if (currentPower <= MIN_POWER)
            {
                sign = 1;
            }
        }
    }
}
