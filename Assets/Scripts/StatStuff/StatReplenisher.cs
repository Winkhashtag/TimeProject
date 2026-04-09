using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class StatReplenisher : Interactable
{
    [Header("Settings")]
    public string statName;
    public float replenishAmount = 50f;
    public float holdDuration = 3f;
    public KeyCode holdKey = KeyCode.E;

    [Header("UI")]
    public GameObject buttonIcon;
    public Image holdFillImage;

    private float holdTimer = 0f;
    private bool isHolding = false;
    public bool isActive = false;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip replenishSound;

    public override void Interact()
    {
        isActive = true;
        buttonIcon.SetActive(true);
    }

    void Update()
    {
        if (!isActive)
            return;

        if (Input.GetKey(holdKey))
        {
            isHolding = true;
            holdTimer += Time.deltaTime;
            holdFillImage.fillAmount = holdTimer / holdDuration;

            if (holdTimer >= holdDuration)
            {
                CompleteReplenish();
            }
        }
        else if (isHolding)
        {
            isHolding = false;
            holdTimer = 0f;
            holdFillImage.fillAmount = 0f;
        }
    }

    void CompleteReplenish()
    {
        PlayerStats.ins.ReplenishStat(statName, replenishAmount);
   
        if (audioSource != null && replenishSound != null)
        {
            audioSource.PlayOneShot(replenishSound);
        }

        holdTimer = 0f;
        holdFillImage.fillAmount = 0f;
        isActive = false;
        buttonIcon.SetActive(false);
        this.enabled = false;
    }
    public void Close()
    {
        isActive = false;
        isHolding = false;
        holdTimer = 0f;
        holdFillImage.fillAmount = 0f;
        buttonIcon.SetActive(false);
        this.enabled = false;
    }



}
