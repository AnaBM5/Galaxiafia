using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public GameObject listingPrefab;
    public Transform listingContainer;

    // Start is called before the first frame update
    void Start()
    {
        var requestLeaderboard = new GetLeaderboardRequest
            {StartPosition = 0, StatisticName = "Score", MaxResultsCount = 20};
        PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetLeaderboard, OnErrorLeaderboard );
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetLeaderBoard()
    {
        var requestLeaderboard = new GetLeaderboardRequest
            {StartPosition = 0, StatisticName = "Score", MaxResultsCount = 10};
        PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetLeaderboard, OnErrorLeaderboard );
    }

    void OnGetLeaderboard(GetLeaderboardResult result)
    {
        //Debug.Log(result.Leaderboard[0].StatValue);
        foreach (PlayerLeaderboardEntry player in result.Leaderboard)
        {
            GameObject tempListing = Instantiate(listingPrefab, listingContainer);
            LeaderBoardListing LL = tempListing.GetComponent<LeaderBoardListing>();
            LL.playerNameText.text = player.DisplayName;
            LL.playerScoreText.text = player.StatValue.ToString();
            Debug.Log(player.DisplayName + ": " + player.StatValue );
            
        }
    }

    void OnErrorLeaderboard(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }
}
