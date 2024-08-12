using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   private string _currentControlScheme;
   private string _prevControlScheme;
   private IControls[] _componants;
   
   
   private void Start()
   {
      _componants = GetComponents<IControls>();
      
      _currentControlScheme = ControlSchemeManager.GetCurrentControlScheme();
      _prevControlScheme = _currentControlScheme;

      SwitchControlSchemeTo(_currentControlScheme);
   }

   private void SwitchControlSchemeTo(string currentControlScheme)
   {
      if (currentControlScheme.Equals("Dragging"))
      {
         foreach (var componant in _componants)
         {
            if (componant is Dragging)
            {
               componant.Enable();
            }
            else
            {
               componant.Disable();
            }
         }
      }
      
      if (currentControlScheme.Equals("Swiping"))
      {
         foreach (var componant in _componants)
         {
            if (componant is Swiping)
            {
               componant.Enable();
            }
            else
            {
               componant.Disable();
            }
         }
      }
      
   }
   
   
}
