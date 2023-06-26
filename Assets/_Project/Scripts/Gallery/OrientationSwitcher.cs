using UnityEngine;

public class OrientationSwitcher : MonoBehaviour
{
    public void SetPortrait() => 
        Screen.orientation = ScreenOrientation.Portrait;

    public void SetAuto() => 
        Screen.orientation = ScreenOrientation.AutoRotation;
}
