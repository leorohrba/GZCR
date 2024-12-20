using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseButton; // Reference to the PauseButton GameObject
    public GameObject buttonsPanel; // Reference to the Buttons panel (Resume, Tank, Jet, Mecha)
    public GameObject tankButton; // Ensure this is a GameObject reference
    public GameObject jetButton; // Ensure this is a GameObject reference
    public GameObject mechaButton; // Ensure this is a GameObject reference
    public GameObject resumeButton; // Ensure this is a GameObject reference

    private void Start()
    {
        // Ensure the pause menu is hidden at the start
        if (buttonsPanel != null) buttonsPanel.SetActive(false);

        // Add listeners to the buttons
        if (pauseButton != null) pauseButton.GetComponent<Button>().onClick.AddListener(OnPauseButtonClicked);
        if (resumeButton != null) resumeButton.GetComponent<Button>().onClick.AddListener(OnResumeButtonClicked);
        if (tankButton != null) tankButton.GetComponent<Button>().onClick.AddListener(MenuManager.Instance.OnTankButtonClicked);
        if (jetButton != null) jetButton.GetComponent<Button>().onClick.AddListener(MenuManager.Instance.OnJetButtonClicked);
        if (mechaButton != null) mechaButton.GetComponent<Button>().onClick.AddListener(MenuManager.Instance.OnMechaButtonClicked);

        // Ensure the pause button is visible and the resume button is hidden at the start
        if (pauseButton != null) pauseButton.SetActive(true);
        if (resumeButton != null) resumeButton.SetActive(false);
    }

    public void OnPauseButtonClicked()
    {
        // Pause: PauseButton
        // Method: OnPauseButtonClicked
        // Description: Pauses the game and shows the pause menu

        // Pause the game
        Time.timeScale = 0f;

        // Hide the pause button
        if (pauseButton != null) pauseButton.SetActive(false);

        // Show the buttons panel (Resume, Tank, Jet, Mecha)
        if (buttonsPanel != null) buttonsPanel.SetActive(true);

        // Show the resume button
        if (resumeButton != null) resumeButton.SetActive(true);
    }

    public void OnResumeButtonClicked()
    {
        // ClassName: PauseButton
        // Method: OnResumeButtonClicked
        // Description: Resumes the game and hides the pause menu

        // Resume the game
        Time.timeScale = 1f;

        // Show the pause button
        if (pauseButton != null) pauseButton.SetActive(true);

        // Hide the buttons panel (Resume, Tank, Jet, Mecha)
        if (buttonsPanel != null) buttonsPanel.SetActive(false);

        // Hide the resume button
        if (resumeButton != null) resumeButton.SetActive(false);
    }
}