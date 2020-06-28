using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace GameJam1920.Assets.Scripts
{
    public class InfoScreensConfirmation : MonoBehaviour
    {
        [SerializeField] private DaySwitcher _daySwitcher;

        public void ConfirmVisibleScreen(CallbackContext context)
        {
            if (!context.started)
            {
                return;
            }

            if (_daySwitcher.state == DaySwitcherState.END_DAY)
            {
                _daySwitcher.PreDay();
            }
            else if (_daySwitcher.state == DaySwitcherState.PRE_DAY)
            {
                _daySwitcher.NextDay();
            }
        }    
    }
}
