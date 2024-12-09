using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject selectedPrefab;

    private void Awake()
    {
        // If there is no instance, initialize it and set it to not destroy on load
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
            // Debug.Log("GameManager initialized and persisted.");
        }
        // else if (Instance != this)
        // {
        //     // Destroy duplicate instances
        //     Debug.Log("Duplicate GameManager detected and destroyed.");
        //     Destroy(gameObject); // Destroy duplicate GameManager
        // }
    }



    public void SelectPrefab(GameObject prefab)
    {
        // Debug.Log("Selected Prefab: " + prefab.name);
        selectedPrefab = prefab;
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelScene");
    }

}
