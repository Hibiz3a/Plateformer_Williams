using System.Runtime.InteropServices;
using UnityEngine;

public class NrmWindow : MonoBehaviour {
    [SerializeField] Camera Camera;
    [SerializeField]Rigidbody2D PlayerBody;
    float PixelsPerUnit = 100f;


    //For Moving the gameWindow (use user32.dll from Windows API)
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool SetWindowPos(System.IntPtr gameWindow, System.IntPtr gameWindowInsertAfter, int X, int Y, int cx, int cy, uint uFlags);


    //For Searching the gameWindow by Name (use user32.dll from Windows API)
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern System.IntPtr FindWindow(string windowClassName, string windowName);

    //For block the rescale of the gameWindow
    const uint SWP_NOSIZE = 0x0001;


    void Start(){
        float cameraHeight = 2 * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        float worldHeight = cameraHeight;
        float worldWidth = worldHeight * Display.main.systemWidth / Display.main.systemHeight;

        int windowWidthInPixels = (int)(worldWidth * PixelsPerUnit);
        int windowHeightInPixels = (int)(worldHeight * PixelsPerUnit);

        Screen.SetResolution(windowWidthInPixels, windowHeightInPixels, false);
    }

    void FixedUpdate() {
        MoveWindow(PlayerBody.position);
    }

    void MoveWindow(Vector3 _playerPosition) {
        Camera.transform.position = new Vector3(PlayerBody.position.x, PlayerBody.position.y, Camera.transform.position.z);
        System.IntPtr gameWindow = FindWindow(null, "Plateformer_Williams");

        if (gameWindow != System.IntPtr.Zero) {

            int gameWindowX = Mathf.RoundToInt((Display.main.systemWidth / 2 - Screen.width / 2) + (_playerPosition.x * PixelsPerUnit));
            int gameWindowY = Mathf.RoundToInt((Display.main.systemHeight / 2 - Screen.height / 2) + (-_playerPosition.y * (PixelsPerUnit - 5)));

            SetWindowPos(gameWindow, System.IntPtr.Zero, gameWindowX, gameWindowY, 0, 0, SWP_NOSIZE);
        }
    }
}
