using UnityEngine;
using UnityEditor;

public class B3TRSceneSetup : EditorWindow
{
    [MenuItem("B3TR/Initialize Game World")]
    public static void SetupWorld()
    {
        // 1. Create the Environment (Ground)
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "World_Ground";
        ground.transform.localScale = new Vector3(10, 1, 10);
        
        // Create specific biomes (colored planes)
        CreateBiome("Beach_Zone", new Vector3(-10, 0.01f, -10), Color.yellow);
        CreateBiome("River_Zone", new Vector3(10, 0.01f, 10), Color.blue);
        CreateBiome("Forest_Zone", new Vector3(-10, 0.01f, 10), Color.green);

        // 2. Create the Player (Placeholder for Inky/Ranger)
        GameObject player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        player.name = "Player_Character";
        player.tag = "Player";
        player.transform.position = new Vector3(0, 1, 0);
        player.AddComponent<PlayerController>();
        
        // Add a camera to follow the player
        GameObject cam = new GameObject("FollowCamera");
        cam.AddComponent<Camera>();
        cam.transform.parent = player.transform;
        cam.transform.localPosition = new Vector3(0, 3, -5);
        cam.transform.localEulerAngles = new Vector3(20, 0, 0);

        // 3. Create Mission Triggers
        CreateMissionTrigger("Beach Cleanup", new Vector3(-10, 1, -10));
        CreateMissionTrigger("River Patrol", new Vector3(10, 1, 10));
        CreateMissionTrigger("Forest Rescue", new Vector3(-10, 1, 10));

        Debug.Log("B3TR World Generated Successfully!");
    }

    static void CreateBiome(string name, Vector3 pos, Color color)
    {
        GameObject biome = GameObject.CreatePrimitive(PrimitiveType.Plane);
        biome.name = name;
        biome.transform.position = pos;
        biome.transform.localScale = new Vector3(3, 1, 3);
        var renderer = biome.GetComponent<Renderer>();
        renderer.sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        renderer.sharedMaterial.color = color;
    }

    static void CreateMissionTrigger(string name, Vector3 pos)
    {
        GameObject trigger = GameObject.CreatePrimitive(PrimitiveType.Cube);
        trigger.name = $"Mission_{name}";
        trigger.transform.position = pos;
        trigger.GetComponent<Collider>().isTrigger = true;
        var script = trigger.AddComponent<MissionZone>();
        script.missionName = name;
        
        // transparent visualization
        var renderer = trigger.GetComponent<Renderer>();
        renderer.sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        renderer.sharedMaterial.color = new Color(1, 0, 0, 0.3f);
    }
}
