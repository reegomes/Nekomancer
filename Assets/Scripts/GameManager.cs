using UnityEngine;
public class GameManager : MonoBehaviour
{
    private void Update()
    {
        QualitySettings.vSyncCount = 0; //disable Vsync
        Application.targetFrameRate = 60; // fix frame rate 
    }
}
