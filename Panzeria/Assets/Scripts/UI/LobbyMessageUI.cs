using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMessageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    private void Start()
    {
        PanzeriaGameMultiplayer.Instance.OnFailedToJoinGame += PanzeriaGameMultiplayer_OnFailedToJoinGame;
        PanzeriaGameLobby.Instance.OnCreateLobbyStarted += PanzeriaGameLobby_OnCreateLobbyStarted;
        PanzeriaGameLobby.Instance.OnCreateLobbyFailed += PanzeriaGameLobby_OnCreateLobbyFailed;
        PanzeriaGameLobby.Instance.OnJoinStarted += PanzeriaGameLobby_OnJoinStarted;
        PanzeriaGameLobby.Instance.OnQuickJoinFailed += PanzeriaGameLobby_OnQuickJoinFailed;
        PanzeriaGameLobby.Instance.OnJoinByCodeFailed += PanzeriaGameLobby_OnJoinByCodeFailed;

        Hide();
    }

    private void PanzeriaGameLobby_OnJoinByCodeFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to join lobby");
    }

    private void PanzeriaGameLobby_OnQuickJoinFailed(object sender, EventArgs e)
    {
        ShowMessage("Could not find any lobby to join");
    }

    private void PanzeriaGameLobby_OnJoinStarted(object sender, EventArgs e)
    {
        ShowMessage("Joining lobby...");
    }

    private void PanzeriaGameLobby_OnCreateLobbyFailed(object sender, EventArgs e)
    {
        ShowMessage("Failed to create lobby");
    }

    private void PanzeriaGameLobby_OnCreateLobbyStarted(object sender, EventArgs e)
    {
        ShowMessage("Creating lobby...");
    }

    private void PanzeriaGameMultiplayer_OnFailedToJoinGame(object sender, System.EventArgs e)
    {
        if (NetworkManager.Singleton.DisconnectReason == "")
        {
            ShowMessage("Failed to connect");
        }
        else
        {
            ShowMessage(NetworkManager.Singleton.DisconnectReason);
        }
    }

    private void ShowMessage(string message)
    {
        Show();
        messageText.text = message;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PanzeriaGameMultiplayer.Instance.OnFailedToJoinGame -= PanzeriaGameMultiplayer_OnFailedToJoinGame;
    }
}
