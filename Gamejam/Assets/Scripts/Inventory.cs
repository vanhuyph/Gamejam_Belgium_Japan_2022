using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int blackOrbsCount { get; set; }
    public int whiteOrbsCount;
    public TMP_Text blackOrbsCountText;
    public TMP_Text whiteOrbsCountText;

    public static Inventory instance;

    public float GetBlackOrbRate()
    {
        if (blackOrbsCount + whiteOrbsCount == 0)
        {
            return 0.0f;
        }
        
        return blackOrbsCount / (blackOrbsCount + whiteOrbsCount);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory");
            return;
        }
        instance = this;
    }

    public void AddOrbPoints(int count, string orbTypes)
    {
        if (orbTypes == "WhiteOrb")
        {
            whiteOrbsCount += count;
            whiteOrbsCountText.text = "White orbs: " + whiteOrbsCount.ToString();
        }
        else
        {
            blackOrbsCount += count;
            blackOrbsCountText.text = "Black orbs: " + blackOrbsCount.ToString();
        }
    }
}
