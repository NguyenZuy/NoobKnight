using Nakama;
using UnityEngine;
using NoobKnight.Utils;
using NoobKnight.Managers.Nakama;
using CustomInspector;
using System.Collections.Generic;
using Newtonsoft.Json;
using NoobKnight.Entities;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;
using UnityEngine.AddressableAssets;

public class Test : MonoBehaviour
{
    //#region Variables
    //public IClient client;
    //public ISession session;
    //public ISocket socket;

    //[ForceFill] public NakamaConnection nakamaConnection;

    //[HideInInspector] public ServerHandler serverHandler;

    //#endregion

    ////public void ConnectToServer()
    ////{
    ////    client = new Client(nakamaConnection.scheme, nakamaConnection.host, nakamaConnection.port, nakamaConnection.serverKey, UnityWebRequestAdapter.Instance);
    ////    Debug.Log(LOG_TYPE.NAKAMA + "Connected to Nakama Server");

    ////    serverHandler = new ServerHandler();
    ////}

    ////private async void Start()
    ////{
    ////    ConnectToServer();
    ////    session = await client.AuthenticateDeviceAsync(SystemInfo.deviceUniqueIdentifier);
    ////    Debug.Log(session);
    ////    Debug.Log(session.AuthToken); // raw JWT token
    ////    Debug.LogFormat("Session user id: '{0}'", session.UserId);
    ////    Debug.LogFormat("Session user username: '{0}'", session.Username);
    ////    Debug.LogFormat("Session has expired: {0}", session.IsExpired);
    ////    Debug.LogFormat("Session expires at: {0}", session.ExpireTime); // in seconds.

    ////    socket = client.NewSocket();
    ////    socket.Connected += () => Debug.Log("Socket connected.");
    ////    socket.Closed += () => Debug.Log("Socket closed.");
    ////    await socket.ConnectAsync(session);

    ////    IApiMatchList matches = await client.ListMatchesAsync(session, 0, 100, 10, true, "", "");
    ////    Debug.Log(matches);

    ////    var matchList = new List<IApiMatch>();
    ////    foreach (var mat in matches.Matches)
    ////    {
    ////        matchList.Add(mat);
    ////    }

    ////    var metadata = new Dictionary<string, string>
    ////    {
    ////        { "data", "dit me may" }
    ////    };

    ////    IMatch match = await socket.JoinMatchAsync(matchList[0].MatchId, metadata);
    ////    string matchInfo = match.Label;
    ////    var matchModel = JsonConvert.DeserializeObject<Match>(matchInfo);

    ////    Debug.Log("Joined match: " + match);
    ////    Debug.Log("Match's label: " + match.Label);
    ////    Debug.Log("Match model: " + matchModel);
    ////}

    //public void OnClick()
    //{
    //    Debug.Log("OnClick@@@");
    //}

    public Image img;

    private void Start()
    {
        LoadAtlas();
    }

    private async void LoadAtlas()
    {
        AsyncOperationHandle<SpriteAtlas> atlasHandle = Addressables.LoadAssetAsync<SpriteAtlas>("Atlas/AppearanceAtals");
        await atlasHandle.Task;

        if (atlasHandle.Status == AsyncOperationStatus.Succeeded)
        {
            SpriteAtlas atlas = atlasHandle.Result;

            img.sprite = atlas.GetSprite("FrontHead");
        }
        else
        {
            Debug.LogError("Failed to load atlas: " + atlasHandle.Status);
        }

        // Đừng quên giải phóng tài nguyên khi không cần thiết
        Addressables.Release(atlasHandle);
    }
}
