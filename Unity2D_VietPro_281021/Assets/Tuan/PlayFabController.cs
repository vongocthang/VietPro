using PlayFab;
using PlayFab.ClientModels;
using PlayFab.DataModels;
using PlayFab.ProfilesModels;

using UnityEngine;
using System.Collections.Generic;
using PlayFab.PfEditor.Json;

public class PlayFabController : MonoBehaviour
{
    public static PlayFabController PFC;
    
    private string userEmail;
    private string userPassword;
    private string username;
    public GameObject loginPanel;
    public GameObject addloginPanel;
    public GameObject Btn_recover;


    private void OnEnable()
    {
        if (PlayFabController.PFC ==null)
        {
            PlayFabController.PFC = this;
        }
        else
        {
            if(PlayFabController.PFC !=this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void Start()
    {
        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "AD5AA"; // Please change this value to your own titleId from PlayFab Game Manager
        }


        //PlayerPrefs.DeleteAll();
        //var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            
            userEmail = PlayerPrefs.GetString("EMAIL");
            userPassword = PlayerPrefs.GetString("PASSWORD");
            Debug.Log(userEmail + "**" + userPassword);

            var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
        }
        else
        {
            #if UNITY_ANDROID
                        var requestAndroid = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = ReturnMobileID(),CreateAccount = true };
                        PlayFabClientAPI.LoginWithAndroidDeviceID(requestAndroid, OnLoginMobileSuccess, OnLoginMobileFailure);
            #endif
            #if UNITY_IOS
                        var requestIOS = new LoginWithIOSDeviceIDRequest { DeviceId = ReturnMobileID(), CreateAccount = true };
                        PlayFabClientAPI.LoginWithIOSDeviceID(requestIOS, OnLoginMobileSuccess, OnLoginMobileFailure);
            #endif
        }
    }
    #region login
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Ket noi server thanh cong, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest { DisplayName=username}, OnDisplayName, OnLoginMobileFailure);
        loginPanel.SetActive(false);
        Btn_recover.SetActive(false);
        GetStats();
        myID = result.PlayFabId;//region PlayerData

        GetPlayerData();//region PlayerData

    }
    void OnDisplayName (UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log(result.DisplayName+ "is your new display name");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email=userEmail, Password = userPassword, Username = username};
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest,OnRegisterSucess, OnRegisterFailure);
    }
    private void OnLoginMobileFailure(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    private void OnLoginMobileSuccess(LoginResult result)
    {
        Debug.Log("Ket noi server thanh cong, you made your first successful API call!");
        GetStats();

        myID = result.PlayFabId;//region PlayerData
        GetPlayerData();//region PlayerData

        
        loginPanel.SetActive(false);

    }
    private void OnRegisterSucess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Dang Ky Thanh Cong, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        GetStats();
        loginPanel.SetActive(false);
    }
    private void OnRegisterFailure(PlayFabError error)
    {
        //Debug.LogError(error.GenerateErrorReport());
        Debug.Log("Dang Nhap Lai");
        loginPanel.SetActive(true);
    }
    public void GetUserEmail(string emailIn)
    {
        userEmail = emailIn;
    }
    public void GetUserPassword(string passwordIn)
    {
        userPassword = passwordIn;
    }

    public void GetUserName(string NameIn)
    {
        username = NameIn;
    }
    public void OnClickLogin()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    public static string ReturnMobileID()
    {
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        return deviceID;
    }
    //recovery, dang ky lai, hay nhap lai thong tin daưng nhap sau khi da tao tai khoan tren thiet bi , phia server se ko nhan ra tai khoan, ma se thuc hien update lai tai khoan luc truoc
    public void OpenAddLogin()
    {
        addloginPanel.SetActive(true);
        loginPanel.SetActive(false);
    }
    public void CloseAddLogin()
    {
        addloginPanel.SetActive(false);
        loginPanel.SetActive(true);
    }
    public void OnClickAddLogin()
    {
        var addLoginRequest = new AddUsernamePasswordRequest { Email = userEmail, Password = userPassword, Username = username };
        PlayFabClientAPI.AddUsernamePassword(addLoginRequest, OnAddLoginSucess, OnRegisterFailure);
    }
    private void OnAddLoginSucess(AddUsernamePasswordResult result)
    {
        Debug.Log("Dang Ky Thanh Cong, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        addloginPanel.SetActive(false);
    }
    #endregion login

    #region PlayerStats

    public int playerLevel;
    public int gameLevel;
    public int playerHealth;
    public int playerDamage;
    public int PlayerHighScore;

    public void SetStats()
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate { StatisticName="PlayerLevel", Value=playerLevel} ,
                new StatisticUpdate { StatisticName = "gameLevel", Value = gameLevel },
                new StatisticUpdate { StatisticName = "playerHealth", Value = playerHealth },
                new StatisticUpdate { StatisticName = "playerDamage", Value = playerDamage },
                new StatisticUpdate { StatisticName = "PlayerHighScore", Value = PlayerHighScore },
            }
        },
        result => { Debug.Log("User statistics updated"); },
        error => { Debug.LogError(error.GenerateErrorReport()); });
    }

    void GetStats()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetStatistics,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    void OnGetStatistics(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
        {
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);
            switch(eachStat.StatisticName)
            {
                case "PlayerLevel":
                    playerLevel = eachStat.Value;
                    break;
                case "gameLevel":
                    gameLevel = eachStat.Value;
                    break;
                case "playerHealth":
                    playerHealth = eachStat.Value;
                    break;
                case "playerDamage":
                    playerDamage = eachStat.Value;
                    break;
                case "PlayerHighScore":
                    PlayerHighScore = eachStat.Value;
                    break;

            }
        }
    }
    // Build the request object and access the API
    public  void StartCloudUpdatePlayerStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new { Level_1 = playerLevel,highScore_1 = PlayerHighScore , apples_1 =0}, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdateStats, OnErrorShared);
    }
    // OnCloudHelloWorld defined in the next code block
    private static void OnCloudUpdateStats(ExecuteCloudScriptResult result)
    {
        // CloudScript returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(JsonWrapper.SerializeObject(result.FunctionResult));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in CloudScript
        Debug.Log((string)messageValue);
    }

    private static void OnErrorShared(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    #endregion PlayerStats

    public GameObject leaderboardPanel;
    public GameObject listingPrefab;
    public Transform listingContainer;

    #region Leaderboard
    public void GetLeaderboarder()
    {
        var requestLeaderboard = new GetLeaderboardRequest
        {
            StartPosition = 0,
            StatisticName = "PlayerHighScore",
            MaxResultsCount = 20/*,ProfileConstraints=*/
        };
        PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetLeadboard, OnErrorLeaderboard);
        
    }
    void OnGetLeadboard(GetLeaderboardResult result)
    {
        leaderboardPanel.SetActive(true);
        Debug.Log(result.Leaderboard[0].StatValue);
        foreach(PlayerLeaderboardEntry player in result.Leaderboard)
        {
            GameObject tempListing = Instantiate(listingPrefab,listingContainer);
            LeaderboardLighting LL = tempListing.GetComponent<LeaderboardLighting>();
            LL.playerNameText.text = player.DisplayName;
            LL.playerScoreText.text = player.StatValue.ToString();
            Debug.Log(player.DisplayName + ": " + player.StatValue);
        }
    }
    public void CloseLeaderboardPanel()
    {
        leaderboardPanel.SetActive(false);
        for(int i=listingContainer.childCount-1;i>=0;i--)
        {
            Destroy(listingContainer.GetChild(i).gameObject);
        }
    }
    void OnErrorLeaderboard(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }
    #endregion leaderboard

    private string myID;
    #region PlayerData

    public void GetPlayerData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest() {
            PlayFabId = myID,
            Keys=null

        },UserDataSuccess, OnErrorLeaderboard);
    }
    void UserDataSuccess(GetUserDataResult result)
    {
        if(result.Data==null|| !result.Data.ContainsKey("Skins"))
        {
            Debug.Log("Skins not set");
        }
        else
        {
            PersistentData.PD.SkinsStringToData(result.Data["Skins"].Value);
        }
    }
    public void SetUserData(string SkinsData)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data=new Dictionary<string, string>()
            {
                {"Skins",SkinsData }
            }
        }, SetDataSuccess, OnErrorLeaderboard);
    }
    void SetDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log(result.DataVersion);
    }
    public void SendSkins()
    {
        if(PersistentData.PD.NewSkins!=null)
            SetUserData(PersistentData.PD.NewSkins);
    }
    #endregion PlayerData
}