using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rive;
using Rive.Components;

public class RiveController : MonoBehaviour
{
    [SerializeField] private RiveWidget riveWidget;
    ViewModel viewModel;



    private void OnEnable()
    {
        riveWidget.OnWidgetStatusChanged += HandleWidgetStatusChanged;
    }

    private void OnDisable()
    {
        riveWidget.OnWidgetStatusChanged -= HandleWidgetStatusChanged;
    }

    private void HandleWidgetStatusChanged()
    {
        if (riveWidget.Status == WidgetStatus.Loaded)
        {
            File file = riveWidget.File;

            // Get reference by name
            viewModel = file.GetViewModelByName("CatViewModel");


            var properties = viewModel.Properties;
            foreach (var prop in properties)
            {
                Debug.Log($"Property: {prop.Name}, Type: {prop.Type}");
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ViewModelInstance vm = riveWidget.StateMachine.ViewModelInstance;
            ViewModelInstanceBooleanProperty boolProperty = vm.GetBooleanProperty("StartDancing");
            Debug.Log($"Boolean value: {boolProperty.Value}");
            boolProperty.Value = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ViewModelInstance vm = riveWidget.StateMachine.ViewModelInstance;
            ViewModelInstanceBooleanProperty boolProperty = vm.GetBooleanProperty("StartDancing");
            Debug.Log($"Boolean value: {boolProperty.Value}");
            boolProperty.Value = false;
        }
    }
}
