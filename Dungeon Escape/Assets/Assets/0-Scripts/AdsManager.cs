using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    private void Awake()
    {
        Advertisement.Initialize("4617673");
    }

    void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Showing rewarded ad.");
                GameManager.Instance.Player.AddGems(100);
                UIManager.Instance.openShop(GameManager.Instance.Player.diamonds);
                break;
            case ShowResult.Skipped:
                Debug.Log("Skipped, no gems awarded.");
                break;
            case ShowResult.Failed:
                Debug.Log("Failed, no gems awarded.");
                break;
        }
    }
    public void ShowRewardedAdd()
    {
        if(Advertisement.IsReady("Rewarded_Android"))
        {
            ShowOptions options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };
            Advertisement.Show("Rewarded_Android", options);
        }
    }
}
