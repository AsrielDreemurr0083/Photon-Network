using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Dropdown dropdown;
    [SerializeField] Canvas lobbyCanvas;
    [SerializeField] GameObject nickNamePanel;

    private void Awake()
    {
        Debug.Log(PhotonNetwork.NickName);

        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");

        if(string.IsNullOrEmpty(PlayerPrefs.GetString("NickName")))
        {
            nickNamePanel.SetActive(true);
        }

        if (PhotonNetwork.IsConnected)
        {
            lobbyCanvas.gameObject.SetActive(false);
        }
    }
    public void Connect()
    {
        //서버에 접속하는 함수
        PhotonNetwork.ConnectUsingSettings();
        lobbyCanvas.gameObject.SetActive(false);

    }
    public override void OnJoinedLobby()
    {
        lobbyCanvas.gameObject.SetActive(true);
    }
    public override void OnConnectedToMaster()
    {
        //JoinLobby : 특정 로비를 생성하여 진입하는 함수
        PhotonNetwork.JoinLobby
        (
            new TypedLobby
            (
                dropdown.options[dropdown.value].text,
                LobbyType.Default
            )
        );
    }
}
