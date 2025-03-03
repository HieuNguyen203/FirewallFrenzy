using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI heartNumber;
    [SerializeField] protected GameObject panel;
    [SerializeField] private RandomSelector selector;
    [SerializeField] private GameObject shield;

    public int startPlayerLife = 3;
    private int currentLife;
    private Animator ani;

    private void Start()
    {
        heartNumber.text = startPlayerLife.ToString();
        currentLife = startPlayerLife;
        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            if (currentLife < 1)
            {
                ShowPanel();
                Destroy(shield);
                Destroy(gameObject);
                //set the highest score value
                if(PlayerPrefs.GetInt("HighestScore") < HighScore.score)
                    PlayerPrefs.SetInt("HighestScore", HighScore.score);
            }
            else
            {
                DecreseLife();
                ani.SetTrigger("TakeDamage");
                CameraController.ShakeScreen();
            }
        }
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
        selector.enabled = false;
        Time.timeScale = 0f;
    }

    public void IncreaseLife()
    {
        currentLife += 1;
        heartNumber.text = currentLife.ToString();
    }

    public void DecreseLife()
    {
        currentLife -= 1;
        heartNumber.text = currentLife.ToString();
    }
}
