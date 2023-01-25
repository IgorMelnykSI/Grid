using UnityEngine;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField _createInput;
    public TMP_InputField _joinInput;

    public void CreateRoom()
    {
        MainMenuManager.Instance.playerFaction = Faction.Hero;
        PhotonNetwork.CreateRoom(_createInput.text);
    }

    public void JoinRoom()
    {
        MainMenuManager.Instance.playerFaction = Faction.Enemy;
        PhotonNetwork.JoinRoom(_joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }
}
