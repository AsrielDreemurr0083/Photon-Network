using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Chat;
using UnityEngine.UI;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform parentTransform;
    [SerializeField] ScrollRect scrollRect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if(inputField.text.Length <= 0)
            {

                // inputField�� �ִ� �ؽ�Ʈ�� �����ɴϴ�.
                string talk = PhotonNetwork.NickName + " : " + inputField.text;

                //RPC Target.All : ���� �뿡 �ִ� ��� Ŭ���̾�Ʈ���� Talk �Լ��� �����϶�� ����� �Ѵ�.
                photonView.RPC("Talk", RpcTarget.All, talk);
            }
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        //Prefab�� �ϳ� ������ ���� text ���� �����Ѵ�.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));

        talk.GetComponent<Text>().text = message;

        // ��ũ�� �� - content�� �ڽ����� ����Ѵ�
        talk.transform.SetParent(parentTransform);

        //ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� �����Ѵ�.
        inputField.ActivateInputField();

        scrollRect.verticalNormalizedPosition = 0.0f;
        //inputField�� �ؽ�Ʈ�� �ʱ�ȭ �Ѵ�.
        inputField.text = "";
    }
}
