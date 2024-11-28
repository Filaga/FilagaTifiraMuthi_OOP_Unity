using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI enemyText;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private HealthComponent player;
    [SerializeField] private CombatManager wave;


    void Start()
    {
        player = FindObjectOfType<HealthComponent>();
        wave = FindObjectOfType<CombatManager>();
        if (player != null)
        {
            UpdateHealthUI();
        }
        if (wave != null)
        {
            UpdateWaveNumber();
            UpdateEnemyNumber();
            UpdatePointNumber();
        }
    }

    void Update()
    {
        if (player != null)
        {
            UpdateHealthUI();
        }
        else{
            healthText.text = "0";
        }
        if (wave != null)
        {
            UpdateWaveNumber();
            UpdateEnemyNumber();
            UpdatePointNumber();
        }
    }

    private void UpdateHealthUI()
    {
        if (player != null)
        {
            healthText.text = player.Health.ToString("0");
        }
        
    }

    public void UpdateWaveNumber()
    {
        waveText.text = wave.waveNumber.ToString();
    }

    public void UpdateEnemyNumber()
    {
        enemyText.text = wave.totalEnemies.ToString();
    }

    public void UpdatePointNumber()
    {
        pointText.text = wave.point.ToString();
    }
}
