using UnityEngine;
using UnityEditor;

public class B3TRMaterialFixer : EditorWindow
{
    [MenuItem("B3TR/Fix Materials (Run This First!)")]
    public static void CreateAssetMaterials()
    {
        if (!AssetDatabase.IsValidFolder("Assets/Materials"))
        {
            AssetDatabase.CreateFolder("Assets", "Materials");
        }

        // Create specific materials with the Universal Render Pipeline shader
        CreateMaterial("Ocean", new Color(0, 0.5f, 1f, 0.8f));
        CreateMaterial("River", new Color(0, 0.3f, 0.8f));
        CreateMaterial("Sand", new Color(1f, 0.9f, 0.6f));
        CreateMaterial("Grass", new Color(0.1f, 0.6f, 0.2f));
        CreateMaterial("TreeTrunk", new Color(0.4f, 0.2f, 0));

        Debug.Log("✅ Materials Created in Assets/Materials!");
    }

    static void CreateMaterial(string name, Color color)
    {
        // Try to find the URP shader, fallback to Standard if missing
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");
        if (!shader) shader = Shader.Find("Standard");

        Material mat = new Material(shader);
        mat.color = color;
        
        string path = $"Assets/Materials/{name}.mat";
        AssetDatabase.CreateAsset(mat, path);
    }
}
