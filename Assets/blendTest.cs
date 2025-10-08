using UnityEngine;
using Rive;
using Rive.Components;

public class RiveBlendController : MonoBehaviour
{
    [SerializeField] private RiveWidget riveWidget;
    public float blendVal;
    public AudioVolumeReader avm; 


    private void Update()
    {
        riveWidget.StateMachine.GetNumber("Progress").Value = avm.currentVolC * blendVal;
    }
}
