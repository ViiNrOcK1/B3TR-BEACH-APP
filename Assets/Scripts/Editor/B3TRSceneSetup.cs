using UnityEngine;
using UnityEditor;

public class B3TRSceneSetup : EditorWindow
{
    [MenuItem("B3TR/Generate Game Environment")]
    public static void GenerateEnvironment()
    {
        // 1. Root Object
        GameObject root = new GameObject("B3TR_Environment");

        // 2. The Ocean (Big Blue Plane)
        GameObject ocean = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ocean.name = "Ocean";
        ocean.transform.parent = root.transform;
        ocean.transform.localScale = new Vector3(20, 1, 20);
        ocean.transform.position = new Vector3(0, -0.5f, 0);
        SetColor(ocean, new Color(0, 0.5f, 1f, 0.8f)); // Blue water

        // 3. The Beach (Sand)
        GameObject beach = GameObject.CreatePrimitive(PrimitiveType.Cube);
        beach.name = "Beach_Zone";
        beach.transform.parent = root.transform;
        beach.transform.localScale = new Vector3(20, 1, 10);
        beach.transform.position = new Vector3(0, 0, -10);
        SetColor(beach, new Color(1f, 0.9f, 0.6f)); // Sand color

        // 4. The River (Water cutting through)
        GameObject river = GameObject.CreatePrimitive(PrimitiveType.Cube);
        river.name = "River_Zone";
        river.transform.parent = root.transform;
        river.transform.localScale = new Vector3(4, 0.8f, 20);
        river.transform.position = new Vector3(10, -0.1f, 0);
        SetColor(river, new Color(0, 0.3f, 0.8f)); // Darker river blue

        // 5. The Forest (Green + Trees)
        GameObject forest = GameObject.CreatePrimitive(PrimitiveType.Cube);
        forest.name = "Forest_Ground";
        forest.transform.parent = root.transform;
        forest.transform.localScale = new Vector3(20, 1, 10);
        forest.transform.position = new Vector3(0, 0, 10);
        SetColor(forest, new Color(0.1f, 0.6f, 0.2f)); // Grass green

        // Add some "Trees" (Cylinders)
        for (int i = 0; i < 10; i++)
        {
            GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            tree.name = $"Tree_{i}";
            tree.transform.parent = forest.transform;
            float x = Random.Range(-9f, 9f);
            float z = Random.Range(5f, 14f);
            tree.transform.position = new Vector3(x, 1, z);
            tree.transform.localScale = new Vector3(0.5f, 2, 0.5f);
            SetColor(tree, new Color(0.4f, 0.2f, 0)); // Brown trunk
        }

        Debug.Log("B3TR Environment Generated!");
    }

    static void SetColor(GameObject go, Color c)
    {
        var renderer = go.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            renderer.sharedMaterial.color = c;
        }
    }
}
