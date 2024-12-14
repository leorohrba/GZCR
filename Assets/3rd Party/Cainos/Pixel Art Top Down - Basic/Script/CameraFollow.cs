using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//let camera follow target
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 1.0f;

    private Vector3 offset;
    private Vector3 targetPos;

    private void Start()
    {
        // Try to get the target at the start (in case it exists already)
        FindTarget();

        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    private void Update()
    {
        if (target == null) return;

        targetPos = target.position + offset;

        // Optional: Clamp camera position to keep it within certain bounds
        targetPos.x = Mathf.Clamp(targetPos.x, -10f, 10f); // Example bounds for x-axis
        targetPos.y = Mathf.Clamp(targetPos.y, -10f, 10f); // Example bounds for y-axis

        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }


private void FindTarget()
{
    // Search for the game object with the "Player" tag
    GameObject player = GameObject.FindGameObjectWithTag("Player");

    if (player != null)
    {
        // Set the target to the player
        target = player.transform;
    }
    else
    {
        Debug.LogError("No game object found with the 'Player' tag.");
    }
}

}
