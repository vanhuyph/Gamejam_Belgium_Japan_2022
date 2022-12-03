using UnityEngine;

public class PlayerKarma : MonoBehaviour
{
    public int minKarma = 0;
    public int maxKarma = 100;
    public int currentKarma;
    public KarmaIndicator karmaIndicator;

    void Start()
    {
        karmaIndicator.SetValue(currentKarma);
        karmaIndicator.SetupIndicator(minKarma, maxKarma);
    }

    public void TakeKarma(int karmaPoint, string orbTypes)
    {
        if (orbTypes == "BlackOrb")
        {
            currentKarma += karmaPoint * 5;
            currentKarma = Mathf.Clamp(currentKarma, minKarma, maxKarma);
            karmaIndicator.SetValue(currentKarma);
        }
        else
        {
            currentKarma -= karmaPoint * 5;
            currentKarma = Mathf.Clamp(currentKarma, minKarma, maxKarma);
            karmaIndicator.SetValue(currentKarma);
        }
    }
}
