using UnityEngine;

public class MG_End : MonoBehaviour
{
    private float InitPos;
    private float MoveSpeed = 1.5f;
    [SerializeField] public GameObject EndPrefab;
    [SerializeField] public MG_Player PLayerSC;
    public bool PlayerIsOnEndPlatform = false;
    private void Start()
    {
        InitPos = EndPrefab.transform.position.y;
    }
    private void Update()
    {
        if(PlayerIsOnEndPlatform)
        {
            EndPrefab.transform.position = Vector3.MoveTowards(EndPrefab.transform.position, new Vector3(0, InitPos--, 0), MoveSpeed * Time.deltaTime);
        }
        if(EndPrefab.transform.position.y <= PLayerSC.transform.position.y + 1.5f)
        {
            PlayerIsOnEndPlatform = false;
        }
    }
}
    