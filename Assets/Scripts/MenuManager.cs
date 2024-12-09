using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject prefabTank;
    public GameObject prefabJet;
    public GameObject prefabMecha;

    public void OnTankButtonClicked()
    {
        // Set the selected prefab in GameManager
        GameManager.Instance.selectedPrefab = prefabTank;
        PlayerPrefs.SetString("SelectedPrefab", "Tank");

        // Load the level scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelScene");
    }

    public void OnJetButtonClicked()
    {
        // Set the selected prefab in GameManager
        GameManager.Instance.selectedPrefab = prefabJet;
        
        PlayerPrefs.SetString("SelectedPrefab", "Jet");

        // Load the level scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelScene");
    }

    public void OnMechaButtonClicked()
    {
        // Set the selected prefab in GameManager
        GameManager.Instance.selectedPrefab = prefabMecha;
        
        PlayerPrefs.SetString("SelectedPrefab", "Mecha");

        // Load the level scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelScene");
    }
}


