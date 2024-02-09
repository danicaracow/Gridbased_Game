using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegates : MonoBehaviour
{
    public delegate int testDelegate(int i);
    public Action Action;

    public testDelegate delegateVariable;

    private void Start()
    {
        delegateVariable = (int i) => i + 5;

        Action = () => SpaceFire();

        //Debug.Log(delegateVariable(5));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SwitchSpaceMode() ;
        if (Input.GetKeyDown(KeyCode.LeftControl)) SwitchControlMode();
        if (Input.GetKeyDown(KeyCode.Mouse0)) Action();
    }

    public void SwitchSpaceMode()
    {
        Action += () => SpaceFire();
        Action -= () => ControlFire();
    }

    public void SwitchControlMode()
    {
        Action += () => ControlFire();
        Action -= () => SpaceFire();
    }

    public void SpaceFire()
    {
        Debug.Log("Space Fire!");
    }

    public void ControlFire()
    {
        Debug.Log("Control Fire!");
    }
}
