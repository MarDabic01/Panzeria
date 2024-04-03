using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyCreateUI : MonoBehaviour
{
    [SerializeField] private Button createPublicButton;
    [SerializeField] private Button createPrivateButton;
    [SerializeField] private Button backButton;
    [SerializeField] private TMP_InputField lobbyNameInputField;
    [SerializeField] private LobbyUI lobbyUI;

    private void Awake()
    {
        createPublicButton.onClick.AddListener(() =>
        {
            PanzeriaGameLobby.Instance.CreateLobby(lobbyNameInputField.text, false);
        });

        createPrivateButton.onClick.AddListener(() =>
        {
            PanzeriaGameLobby.Instance.CreateLobby(lobbyNameInputField.text, true);
        });

        backButton.onClick.AddListener(() =>
        {
            HIde();
            lobbyUI.Show();
        });
    }

    private void Start()
    {
        HIde();
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
