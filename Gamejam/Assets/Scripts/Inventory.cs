using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int blackOrbsCount;
    public int whiteOrbsCount;
	public float blackOrbsRate;
    public TMP_Text blackOrbsCountText;
    public TMP_Text whiteOrbsCountText;

    public static Inventory instance;

    public float GetBlackOrbRate()
    {
		if((blackOrbsCount >= 60))
		{
			return blackOrbsRate;
		}
		blackOrbsRate = (((float)blackOrbsCount / (float)whiteOrbsCount)-1) * 10;
        return (blackOrbsRate < 0.0f ? 0.0f : blackOrbsRate);
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
			blackOrbsCount -= count;
            //whiteOrbsCountText.text = "White orbs: " + whiteOrbsCount.ToString();
        }
        else
        {
            blackOrbsCount += count;
			whiteOrbsCount -= count;
            //blackOrbsCountText.text = "Black orbs: " + blackOrbsCount.ToString();
        }
    }
}
