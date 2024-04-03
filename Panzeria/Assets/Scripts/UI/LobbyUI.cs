using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button createLobbyButton;
    [SerializeField] private Button joinLobbyButton;
    [SerializeField] private LobbyCreateUI lobbyCreateUI;
    [SerializeField] private LobbyJoinUI lobbyJoinUI;
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
            Hide();
            lobbyCreateUI.Show();
        });

        joinLobbyButton.onClick.AddListener(() =>
        {
            Hide();
            lobbyJoinUI.Show();
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

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
