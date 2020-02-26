using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingMenu : MonoBehaviour
{
    public void OnStartUpToggleValueChanged(bool value)
    {
        if (value)
        {
          Debug.Log( Util.SetupStartup("WindowPet.lnk"));
        }
        else
        {
            Util.CancelStartup("WindowPet.lnk");
        }
    }
}
