using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject tankPrefab;
    public GameObject jetPrefab;
    public GameObject mechaPrefab;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LevelScene")
        {

            // Resume the game
            Time.timeScale = 1f;
            string selectedPrefabName = PlayerPrefs.GetString("SelectedPrefab", "");
            Debug.Log("Selected Prefab: " + selectedPrefabName);

            GameObject instantiatedPrefab = null;

            if (selectedPrefabName == "Tank")
            {
                instantiatedPrefab = Instantiate(tankPrefab, Vector3.zero, Quaternion.identity);
                instantiatedPrefab.name = "Tank(Clone)"; // Set a custom name
            }
            else if (selectedPrefabName == "Jet")
            {
                instantiatedPrefab = Instantiate(jetPrefab, Vector3.zero, Quaternion.identity);
                instantiatedPrefab.name = "Jet(Clone)"; // Set a custom name
            }
            else if (selectedPrefabName == "Mecha")
            {
                instantiatedPrefab = Instantiate(mechaPrefab, Vector3.zero, Quaternion.identity);
                instantiatedPrefab.name = "Mecha(Clone)"; // Set a custom name
            }
            else
            {
                Debug.LogError("No valid prefab selected.");
            }

            // Optionally, you can perform further actions with the instantiatedPrefab
            if (instantiatedPrefab != null)
            {
                Debug.Log("Instantiated Prefab: " + instantiatedPrefab.name);
            }
        }
    }
}