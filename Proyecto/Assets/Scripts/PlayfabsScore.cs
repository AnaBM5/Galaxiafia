// Import statements introduce all the necessary classes for this example.

using System;
using Facebook.Unity;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using LoginResult = PlayFab.ClientModels.LoginResult;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayfabsScore: MonoBehaviour
{
    // holds the latest message to be displayed on the screen
   
    public int puntuacion;
    public static PlayfabController PFC;
    


    #region Playerstats

    public void SetStats()
    {
        puntuacion = ShowScore.scoreValue ;
        
        PlayFabClientAPI.UpdatePlayerStatistics( new UpdatePlayerStatisticsRequest {
                // request.Statistics is a list, so multiple StatisticUpdate objects can be defined if required.
                Statistics = new List<StatisticUpdate> {
                    new StatisticUpdate { StatisticName = "Score", Value = puntuacion },
                }
            },
            result => { Debug.Log("User statistics updated"); },
            error => { Debug.LogError(error.GenerateErrorReport()); });
    }
    
    void GetStats()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetStats,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    void OnGetStats(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);
    }

    #endregion
}