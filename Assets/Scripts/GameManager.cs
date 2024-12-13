using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject selectedPrefab;
    public GameObject prefabTank;
    public GameObject prefabJet;
    public GameObject prefabMecha;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
            Debug.Log("GameManager initialized and persisted.");
        }
        else
        {
            // If an instance already exists, destroy the new one
            Destroy(gameObject);
        }

        // Load default selected prefab if not already set
        if (selectedPrefab == null)
        {
            LoadSelectedPrefabFromPrefs();
        }
    }

    private void LoadSelectedPrefabFromPrefs()
    {
        string selectedPrefabName = PlayerPrefs.GetString("SelectedPrefab", "");
        if (selectedPrefabName == "Tank")
        {
            selectedPrefab = prefabTank;
        }
        else if (selectedPrefabName == "Jet")
        {
            selectedPrefab = prefabJet;
        }
        else if (selectedPrefabName == "Mecha")
        {
            selectedPrefab = prefabMecha;
        }
        else
        {
            // Set a default prefab if none is selected
            selectedPrefab = prefabTank;
            PlayerPrefs.SetString("SelectedPrefab", "Tank");
        }
    }

    public void SelectPrefab(GameObject prefab)
    {
        Debug.Log("Selected Prefab: " + prefab.name);
        selectedPrefab = prefab;
        PlayerPrefs.SetString("SelectedPrefab", prefab.name);
        SceneManager.LoadScene("LevelScene");
    }
}