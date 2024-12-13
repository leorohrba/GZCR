using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public GameObject prefabTank;
    public GameObject prefabJet;
    public GameObject prefabMecha;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("MenuManager initialized and persisted.");
        }
        else
        {
            Destroy(gameObject);
        }

        Debug.Log("Prefab Tank: " + (prefabTank != null ? prefabTank.name : "null"));
        Debug.Log("Prefab Jet: " + (prefabJet != null ? prefabJet.name : "null"));
        Debug.Log("Prefab Mecha: " + (prefabMecha != null ? prefabMecha.name : "null"));
    }

    public void OnTankButtonClicked()
    {
        if (prefabTank == null)
        {
            Debug.LogError("prefabTank is null in OnTankButtonClicked.");
            return;
        }

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null in OnTankButtonClicked.");
            return;
        }

        // Set the selected prefab in GameManager
        GameManager.Instance.selectedPrefab = prefabTank;
        PlayerPrefs.SetString("SelectedPrefab", "Tank");

        // Load the level scene
        SceneManager.LoadScene("LevelScene");
    }

    public void OnJetButtonClicked()
    {
        if (prefabJet == null)
        {
            Debug.LogError("prefabJet is null in OnJetButtonClicked.");
            return;
        }

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null in OnJetButtonClicked.");
            return;
        }

        // Set the selected prefab in GameManager
        GameManager.Instance.selectedPrefab = prefabJet;
        
        PlayerPrefs.SetString("SelectedPrefab", "Jet");

        // Load the level scene
        SceneManager.LoadScene("LevelScene");
    }

    public void OnMechaButtonClicked()
    {
        if (prefabMecha == null)
        {
            Debug.LogError("prefabMecha is null in OnMechaButtonClicked.");
            return;
        }

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null in OnMechaButtonClicked.");
            return;
        }

        // Set the selected prefab in GameManager
        GameManager.Instance.selectedPrefab = prefabMecha;
        
        PlayerPrefs.SetString("SelectedPrefab", "Mecha");

        // Load the level scene
        SceneManager.LoadScene("LevelScene");
    }
}