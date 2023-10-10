using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class hud_updates : MonoBehaviour
{
    public Button RetryBut;
    public GameObject Panel;
    public TMP_Text lifes;
    public TMP_Text lose;
    public TMP_Text win;
    public Spaceship player;
    
    // Start is called before the first frame update
    void Start()
    {
        lifes.text = $"Lifes: {player.life}";
        Panel.SetActive(false);
        lose.enabled = false;
        win.enabled = false;
        RetryBut.clicked += OnClick;
    }

    public void update_life_hud()
    {
        lifes.text = $"Lifes: {player.life}";
    }
    
    public void game_over_display()
    {
        Panel.SetActive(true);
        lose.enabled = true;
    }
    
    public void win_display()
    {
        
        Panel.SetActive(true);
        win.enabled = true;
    }
    
    void OnClick()
    {
        player.life = 2;
        win.enabled = false;
        lose.enabled = false;
        Panel.SetActive(false);
    }
}
