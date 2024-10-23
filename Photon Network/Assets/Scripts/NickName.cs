using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] string nickName;
    [SerializeField] InputField inputField;
    [SerializeField] Button button;

    public void SetName()
    {
        // 1. nickName에 inputField로 입력한 값을 저장
        nickName = inputField.text;
        // 2. PhotonNetwork.NickName에 nickName 값을 넣어준다.
        PhotonNetwork.NickName = nickName;
        // 3. NickName을 저장
        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);
        // 4. 비활성화
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (inputField.text.Length <= 0)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
