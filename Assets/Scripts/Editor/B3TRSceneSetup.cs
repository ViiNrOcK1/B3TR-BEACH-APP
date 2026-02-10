using UnityEngine;
using UnityEditor;

public class B3TRSceneSetup : EditorWindow
{
    [MenuItem("B3TR/Generate Game Environment")]
    public static void GenerateEnvironment()
    {
        GameObject root = new GameObject("B3TR_Environment");

        // Load the actual material assets we just made
        Material matOcean = AssetDatabase.LoadAssetAtPath<Material>("Assets/Materials/Ocean.mat");
        Material matSand = AssetDatabase.LoadAssetAtPath<Material>("Assets/Materials/Sand.mat");
        Material matRiver = AssetDatabase.LoadAssetAtPath<Material>("Assets/Materials/River.mat");
        Material matGrass = AssetDatabase.LoadAssetAtPath<Material>("Assets/Materials/Grass.mat");
        Material matTree = AssetDatabase.LoadAssetAtPath<Material>("Assets/Materials/TreeTrunk.mat");

        // Ocean
        GameObject ocean = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ocean.name = "Ocean";
        ocean.transform.parent = root.transform;
        ocean.transform.localScale = new Vector3(20, 1, 20);
        ocean.transform.position = new Vector3(0, -0.5f, 0);
        SetMat(ocean, matOcean);

        // Beach
        GameObject beach = GameObject.CreatePrimitive(PrimitiveType.Cube);
        beach.name = "Beach_Zone";
        beach.transform.parent = root.transform;
        beach.transform.localScale = new Vector3(20, 1, 10);
        beach.transform.position = new Vector3(0, 0, -10);
        SetMat(beach, matSand);

        // River
        GameObject river = GameObject.CreatePrimitive(PrimitiveType.Cube);
        river.name = "River_Zone";
        river.transform.parent = root.transform;
        river.transform.localScale = new Vector3(4, 0.8f, 20);
        river.transform.position = new Vector3(10, -0.1f, 0);
        SetMat(river, matRiver);

        // Forest
        GameObject forest = GameObject.CreatePrimitive(PrimitiveType.Cube);
        forest.name = "Forest_Ground";
        forest.transform.parent = root.transform;
        forest.transform.localScale = new Vector3(20, 1, 10);
        forest.transform.position = new Vector3(0, 0, 10);
        SetMat(forest, matGrass);

        // Trees
        for (int i = 0; i < 10; i++)
        {
            GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            tree.name = $"Tree_{i}";
            tree.transform.parent = forest.transform;
            float x = Random.Range(-9f, 9f);
            float z = Random.Range(5f, 14f);
            tree.transform.position = new Vector3(x, 1, z);
            tree.transform.localScale = new Vector3(0.5f, 2, 0.5f);
            SetMat(tree, matTree);
        }

        Debug.Log("B3TR Environment Generated with Fixed Materials!");
    }

    static void SetMat(GameObject go, Material mat)
    {
        var renderer = go.GetComponent<Renderer>();
        if (renderer != null && mat != null)
        {
            renderer.sharedMaterial = mat;
        }
    }
}
