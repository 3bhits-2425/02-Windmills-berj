using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindmillManager : MonoBehaviour
{
    [SerializeField] private WindmillDynamicSpeed[] windmills; // Alle Windräder
    [SerializeField] private Button[] lockSpeedButtons; // Buttons für Speed Lock jedes Windrads
    WindmillDynamicSpeed activeWindmill;
    private bool[] isSpeedLocked;
    private float[] lockedSpeeds;

    private void Start()
    {

        isSpeedLocked = new bool[windmills.Length];
        lockedSpeeds = new float[windmills.Length];

        
        for (int i = 0; i < lockSpeedButtons.Length; i++)
        {
            int tempIndex = i; // Lokale Kopie des Index speichern
            lockSpeedButtons[i].onClick.AddListener(() => ToggleSpeedLock(tempIndex));
        }

    }

    private void Update()
    {
        for (int i = 0; i < windmills.Length; i++)
        {
            if (isSpeedLocked[i])
            {
                windmills[i].SetSpeed(lockedSpeeds[i]);
            }
        }
    }

    private void ToggleSpeedLock(int index)
    {
        if (index >= 0 && index < isSpeedLocked.Length)
        {
            isSpeedLocked[index] = !isSpeedLocked[index];
            if (isSpeedLocked[index])
            {
                lockedSpeeds[index] = windmills[index].GetCurrentSpeed();
            }
        }
    }

    public void SetActiveWindmill(int index)
    {
        if (index >= 0 && index < windmills.Length)
        {
            activeWindmill = windmills[index];
        }
    }
}
