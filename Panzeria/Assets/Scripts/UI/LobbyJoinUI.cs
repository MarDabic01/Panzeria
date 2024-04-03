using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LobbyJoinUI : MonoBehaviour
{
    [SerializeField] private Button quickJoinButton;
    [SerializeField] private Button joinByCodeButton;
    [SerializeField] private Button backButton;
    [SerializeField] private TMP_InputField lobbyCodeInputField;
    [SerializeField] private Transform lobbyContainer;
    [SerializeField] private Transform lobbyTemplate;
    [SerializeField] private LobbyUI lobbyUI;

    private void Awake()
    {
        quickJoinButton.onClick.AddListener(() =>
        {
            PanzeriaGameLobby.Instance.QuickJoin();
        });

        joinByCodeButton.onClick.AddListener(() =>
        {
            PanzeriaGameLobby.Instance.JoinByCode(lobbyCodeInputField.text);
        });

        backButton.onClick.AddListener(() =>
        {
            HIde();
            lobbyUI.Show();
        });

        lobbyTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        HIde();

        PanzeriaGameLobby.Instance.OnLobbyListChanged += PanzeriaGameLobby_OnLobbyListChanged;
        UpdateLobbyList(new List<Lobby>());
    }

    private void PanzeriaGameLobby_OnLobbyListChanged(object sender, PanzeriaGameLobby.OnLobbyListChangedEventArgs e)
    {
        UpdateLobbyList(e.lobbyList);
    }

    private void UpdateLobbyList(List<Lobby> lobbyList)
    {
        foreach (Transform child in lobbyContainer)
        {
            if (child == lobbyTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (Lobby lobby in lobbyList)
        {
            Transform lobbyTransform = Instantiate(lobbyTemplate, lobbyContainer);
            lobbyTransform.gameObject.SetActive(true);
            lobbyTransform.GetComponent<LobbyListSingleUI>().SetLobby(lobby);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void HIde()
    {
        gameObject.SetActive(false);
    }
}
