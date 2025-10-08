using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rive;
using Rive.Components;

public class RiveController : MonoBehaviour
{
    [SerializeField] private RiveWidget riveWidget;
    ViewModelInstance vm;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            vm = riveWidget.StateMachine.ViewModelInstance;
            ViewModelInstanceNumberProperty numberProp = vm.GetNumberProperty("DanceMove");
            numberProp.Value = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            vm = riveWidget.StateMachine.ViewModelInstance;
            ViewModelInstanceNumberProperty numberProp = vm.GetNumberProperty("DanceMove");
            numberProp.Value = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            vm = riveWidget.StateMachine.ViewModelInstance;
            ViewModelInstanceNumberProperty numberProp = vm.GetNumberProperty("DanceMove");
            numberProp.Value = 2;
        }
    }
    public void Jump()
    {
        vm = riveWidget.StateMachine.ViewModelInstance;
        ViewModelInstanceTriggerProperty triggerProp = vm.GetTriggerProperty("Jump");
        triggerProp.Trigger();
    }
}
