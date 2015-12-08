using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public int currentView
    {
        get
        {
            return currentView;
        }
        set
        {
            if (value > 0 || value <= 4)
                currentView = value;
        }
    }
    public void SetCurrentView()
    {

    }
}
