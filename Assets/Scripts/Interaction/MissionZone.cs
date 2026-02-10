using UnityEngine;

public class MissionZone : MonoBehaviour
{
    public string missionName = "Mission";
    public string description = "Start this mission?";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Entered Mission Zone: {missionName}");
            // In the future, this will pop up the UI
        }
    }
}
