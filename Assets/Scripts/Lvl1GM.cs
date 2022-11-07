using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lvl1GM : MonoBehaviour
{
    public TMP_Text buildingsTextbox;
    /// <summary>
    /// 0 - Diner, 1 - workshop, 2 - town hall, 3 - library, 4 - bar
    /// </summary>
    //public static bool[] vistedBuildings = { true, true, true, true, true };
    public static bool[] vistedBuildings = { false, false, false, false, false };

    private void OnGUI()
    {
        buildingsTextbox.text = "Visited Buildings:\n";
        if (vistedBuildings[0]) buildingsTextbox.text += "Diner\n";
        if (vistedBuildings[1]) buildingsTextbox.text += "Workshop\n";
        if (vistedBuildings[2]) buildingsTextbox.text += "Town Hall\n";
        if (vistedBuildings[3]) buildingsTextbox.text += "Library\n";
        if (vistedBuildings[4]) buildingsTextbox.text += "Bar";
    }
}
