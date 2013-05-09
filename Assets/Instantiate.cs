using UnityEngine;
public class Instantiate : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject Cube;
    void uLink_OnConnectedToServer()
    {
        uLink.Network.Instantiate(PlayerPrefab, transform.position, transform.rotation, 0);
        uLink.Network.Instantiate(Cube, new Vector3(2, 1, 1), transform.rotation, 0);
        uLink.Network.Instantiate(Cube, new Vector3(2, 1, 2), transform.rotation, 0);
        uLink.Network.Instantiate(Cube, new Vector3(2, 1, 3), transform.rotation, 0);
        Debug.Log("Network aware game object is now created by client.");
    }
}