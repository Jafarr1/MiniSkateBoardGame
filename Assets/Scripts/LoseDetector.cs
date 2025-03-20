using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseDetector : MonoBehaviour
{
[SerializeField] float loadDelay = 0.5f;
[SerializeField] ParticleSystem crashEffect;
[SerializeField] AudioClip loseSFX;

private bool canSound = true;


 private void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Ground" && canSound) {
        canSound = false;
        FindObjectOfType<PlayerRotateController>().DisableControls();
        crashEffect.Play();
        GetComponent<AudioSource>().PlayOneShot(loseSFX);
Invoke("ReloadScene", loadDelay);
    }
}
 private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
   
 }
