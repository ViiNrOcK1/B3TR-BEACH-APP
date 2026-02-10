using UnityEngine;
using UnityEditor;

public class B3TRSceneSetup : EditorWindow
{
    [MenuItem("B3TR/Generate Game Environment")]
    public static void GenerateEnvironment()
    {
        GameObject root = new GameObject("B3TR_Environment");

        // Use a safe shader lookup
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");
        if (!shader) shader = Shader.Find("Universal Render Pipeline/Simple Lit");
        if (!shader) shader = Shader.Find("Standard"); // Fallback for safety

        // Ocean
        GameObject ocean = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ocean.name = "Ocean";
        ocean.transform.parent = root.transform;
        ocean.transform.localScale = new Vector3(20, 1, 20);
        ocean.transform.position = new Vector3(0, -0.5f, 0);
        SetColor(ocean, new Color(0, 0.5f, 1f, 0.8f), shader);

        // Beach
        GameObject beach = GameObject.CreatePrimitive(PrimitiveType.Cube);
        beach.name = "Beach_Zone";
        beach.transform.parent = root.transform;
        beach.transform.localScale = new Vector3(20, 1, 10);
        beach.transform.position = new Vector3(0, 0, -10);
        SetColor(beach, new Color(1f, 0.9f, 0.6f), shader);

        // River
        GameObject river = GameObject.CreatePrimitive(PrimitiveType.Cube);
        river.name = "River_Zone";
        river.transform.parent = root.transform;
        river.transform.localScale = new Vector3(4, 0.8f, 20);
        river.transform.position = new Vector3(10, -0.1f, 0);
        SetColor(river, new Color(0, 0.3f, 0.8f), shader);

        // Forest
        GameObject forest = GameObject.CreatePrimitive(PrimitiveType.Cube);
        forest.name = "Forest_Ground";
        forest.transform.parent = root.transform;
        forest.transform.localScale = new Vector3(20, 1, 10);
        forest.transform.position = new Vector3(0, 0, 10);
        SetColor(forest, new Color(0.1f, 0.6f, 0.2f), shader);

        Debug.Log("B3TR Environment Generated!");
    }

    static void SetColor(GameObject go, Color c, Shader s)
    {
        var renderer = go.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.sharedMaterial = new Material(s);
            renderer.sharedMaterial.color = c;
        }
    }
}
