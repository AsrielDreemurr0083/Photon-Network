using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{

    [SerializeField] InputField roomTitleInputField;
    [SerializeField] InputField roomCapacityInputField;
    [SerializeField] Transform contentTransform;

    private Dictionary<string,GameObject> dictionary = new Dictionary<string,GameObject>();

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = byte.Parse(roomCapacityInputField.text);

        roomOptions.IsOpen = true;

        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(roomTitleInputField.text, roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject temporaryRoom;

        foreach(RoomInfo room in roomList) 
        {
            if(room.RemovedFromList == true)
            {
                dictionary.TryGetValue(room.Name, out temporaryRoom);

                Destroy(temporaryRoom);

                dictionary.Remove(room.Name);
            }
            else
            {
                if(dictionary.ContainsKey(room.Name) == false)
                {
                    GameObject roomObject = Instantiate(Resources.Load<GameObject>("Room"), contentTransform);

                    roomObject.GetComponent<Information>().SetData(room.Name, room.PlayerCount, room.MaxPlayers);

                    roomObject.GetComponent<Information>().SetData
                    (
                        room.Name,
                        room.PlayerCount,
                        room.MaxPlayers
                    );
                    dictionary.Add(room.Name, roomObject);
                }
                else
                {
                    dictionary.TryGetValue(room.Name, out temporaryRoom);

                    temporaryRoom.GetComponent<Information>().SetData
                    (
                        room.Name,
                        room.PlayerCount, 
                        room.MaxPlayers
                    );
                }
            }
        }
    }

    public void UpdateRoom()
    {

    }

    public void RemoveRoom()
    {

    }
}
