using Unity.Netcode;
using UnityEngine;

public class CleanUpManager : MonoBehaviour
{
    private void Awake()
    {
        if (NetworkManager.Singleton != null)
        {
            Destroy(NetworkManager.Singleton.gameObject);
        }

        if (PanzeriaGameMultiplayer.Instance != null)
        {
            Destroy(PanzeriaGameMultiplayer.Instance.gameObject);
        }

        //if (PanzeriaGameLobby.Instance != null)
        //{
        //    Destroy(PanzeriaGameLobby.Instance.gameObject);
        //}
    }
}
