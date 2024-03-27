using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button createLobbyButton;
    [SerializeField] private Button quickJoinButton;
    [SerializeField] private Button joinByCodeButton;
    [SerializeField] private LobbyCreateUI lobbyCreateUI;
    [SerializeField] private TMP_InputField lobbyCodeInputField;
    [SerializeField] private TMP_InputField playerNameInputField;

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            PanzeriaGameLobby.Instance.LeaveLobby();
            Loader.Load(Loader.Scene.MainMenuScene);
        });

        createLobbyButton.onClick.AddListener(() =>
        {
            lobbyCreateUI.Show();
        });

        quickJoinButton.onClick.AddListener(() =>
        {
            PanzeriaGameLobby.Instance.QuickJoin();
        });

        joinByCodeButton.onClick.AddListener(() =>
        {
            PanzeriaGameLobby.Instance.JoinByCode(lobbyCodeInputField.text);
        });
    }

    private void Start()
    {
        playerNameInputField.text = PanzeriaGameMultiplayer.Instance.GetPlayerName();
        playerNameInputField.onValueChanged.AddListener((string newPlayerName) =>
        {
            PanzeriaGameMultiplayer.Instance.SetPlayerName(newPlayerName);
        });
    }
}
