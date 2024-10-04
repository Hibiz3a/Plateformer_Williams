using UnityEngine;

public class SetupFullScreen : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true);
    }
}
