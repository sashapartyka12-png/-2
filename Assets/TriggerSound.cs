using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isInsideTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isInsideTrigger)
        {
            audioSource.Play();
            isInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInsideTrigger = false;
        }
    }
}