using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Social : MonoBehaviour
{

public void OpenWeb(string url)
    {
        Application.OpenURL(url);
    }
}
