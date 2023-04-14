using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image healthBar;
    public Player player;
    public double hpProgress = 100f;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<Player>();
    }


    private void Update()
    {
        healthBar.fillAmount = player.hp / player.maxHP;
    }

    void myAnimationMethod()
    {
        float nowHP = player.hp; //�� ������ ������, ��������� ����� �������� ��������, �� ��� ���
        hpProgress += (nowHP - hpProgress) / 5;
    }
}
