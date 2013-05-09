using UnityEngine;
public class Instantiate : MonoBehaviour
{
    public GameObject PlayerPrefab;
    void uLink_OnConnectedToServer()
    {
        uLink.Network.Instantiate(PlayerPrefab, transform.position, transform.rotation, 0);
        Debug.Log("Network aware game object is now created by client.");
    }
}