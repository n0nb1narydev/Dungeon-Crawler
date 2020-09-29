using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] healthSprites;
    [SerializeField]
    private Image healthImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateLives(int lives)
    {
        healthImage.sprite = healthSprites[lives];
    }
}
