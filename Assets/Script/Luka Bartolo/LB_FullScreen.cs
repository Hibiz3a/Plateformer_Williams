using UnityEngine;

public class LB_FullScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, true);
    }
}
