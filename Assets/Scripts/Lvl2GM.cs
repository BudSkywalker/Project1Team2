using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lvl2GM : MonoBehaviour
{
    public TMP_Text peopleTextbox;
    /// <summary>
    /// 0 - Officer, 1 - Nanny, 2 - Mayor, 3 - Chef, 4 - Welder
    /// </summary>
    //public static bool[] vistedPeople = { true, true, true, true, true };
    public static bool[] vistedPeople = { false, false, false, false, false };

    private void Update()
    {
        peopleTextbox.text = "Visited People:\n";
        if (vistedPeople[0]) peopleTextbox.text += "Officer\n";
        if (vistedPeople[1]) peopleTextbox.text += "Nanny\n";
        if (vistedPeople[2]) peopleTextbox.text += "Mayor\n";
        if (vistedPeople[3]) peopleTextbox.text += "Chef\n";
        if (vistedPeople[4]) peopleTextbox.text += "Welder";
    }
}
