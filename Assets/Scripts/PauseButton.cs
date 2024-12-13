using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseButton; // Reference to the PauseButton GameObject
    public GameObject buttonsPanel; // Reference to the Buttons panel (Resume, Tank, Jet, Mecha)
    public Button tankButton;
    public Button jetButton;
    public Button mechaButton;
    public Button resumeButton;

    private void Start()
    {
        // Ensure the pause menu is hidden at the start
        buttonsPanel.SetActive(false);

        // Add listeners to the buttons
        if (pauseButton != null) pauseButton.GetComponent<Button>().onClick.AddListener(OnPauseButtonClicked);
        if (resumeButton != null) resumeButton.onClick.AddListener(OnResumeButtonClicked);
        if (tankButton != null) tankButton.onClick.AddListener(MenuManager.Instance.OnTankButtonClicked);
        if (jetButton != null) jetButton.onClick.AddListener(MenuManager.Instance.OnJetButtonClicked);
        if (mechaButton != null) mechaButton.onClick.AddListener(MenuManager.Instance.OnMechaButtonClicked);
    }

    public void OnPauseButtonClicked()
    {
        // Pause the game
        Time.timeScale = 0f;

        // Hide the pause button
        pauseButton.SetActive(false);

        // Show the buttons panel (Resume, Tank, Jet, Mecha)
        buttonsPanel.SetActive(true);
    }

    public void OnResumeButtonClicked()
    {
        // Resume the game
        Time.timeScale = 1f;

        // Show the pause button
        pauseButton.SetActive(true);

        // Hide the buttons panel (Resume, Tank, Jet, Mecha)
        buttonsPanel.SetActive(false);
    }
}