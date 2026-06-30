using UnityEngine;
using UnityEngine.UI;

public class HeartUISystem : MonoBehaviour
{
    private RawImage[] hearts;
    private void Awake()
    {
        hearts = GetComponentsInChildren<RawImage>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
