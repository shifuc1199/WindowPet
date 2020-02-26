using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingMenu : MonoBehaviour
{
    public void OnStartUpToggleValueChanged(bool value)
    {
        if (value)
            Util.SetupStartup("WindowPet.exe");
        else
            Util.CancelStartup("WindowPet.exe");
    }
}
