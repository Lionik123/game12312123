using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Image EHPBar;
    public EnemyInteraction enemy;

    private void Start()
    {
        EHPBar = GetComponent<Image>();
        enemy = FindObjectOfType<EnemyInteraction>();
    }
    private void Update()
    {
        EHPBar.fillAmount = enemy.hp / enemy.maxHP;
    }
}
