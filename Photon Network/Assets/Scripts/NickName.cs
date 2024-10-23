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
        // 1. nickName�� inputField�� �Է��� ���� ����
        nickName = inputField.text;
        // 2. PhotonNetwork.NickName�� nickName ���� �־��ش�.
        PhotonNetwork.NickName = nickName;
        // 3. NickName�� ����
        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);
        // 4. ��Ȱ��ȭ
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
