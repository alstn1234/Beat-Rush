using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Managers : MonoBehaviour
{
    #region Singleton

    private static Managers _instance;
    private static bool _initialized;

    public static Managers Instance
    {
        get
        {
            if (!_initialized)
            {
                _initialized = true;
                Init();
            }
            return _instance;
        }
    }
    protected static void Init()
    {
        if (_instance == null)
        {
            _instance = (Managers)FindObjectOfType(typeof(Managers));

            if (_instance == null)
            {
                GameObject gameObject = new GameObject { name = "@Managers" };
                if (gameObject.GetComponent<Managers>() == null)
                {
                    _instance = gameObject.AddComponent<Managers>();
                }
                DontDestroyOnLoad(gameObject);
            }
        }
    }
    #endregion
    #region Fields
    private UIManager _ui = new();
    private GameManager _game = new();
    private ResourceManager _resource = new();
    private ObjectPool _pool = new();
    [SerializeField] public GameObject ClearPanel;
    [SerializeField] public TextMeshProUGUI ClearScore;
    [SerializeField] public TextMeshProUGUI ScoreText;
    [SerializeField] public TextMeshProUGUI ComboText;
    [SerializeField] public Player player;
    [SerializeField] public Image HpBar;
    [SerializeField] public Image SkillBar;
    private float maxskill;
    public float currentHealth;
    public float currentskill;
    public static UIManager UI => Instance?._ui;
    public static GameManager Game => Instance?._game;
    public static ResourceManager Resource => Instance?._resource;
    public static ObjectPool Pool
    {
        get { return Instance._pool; }
        set { Instance._pool = value; }
    }
    private void Start()
    {
        maxskill = 100.0f;
        //currentHealth = player.Data.StateData.Health;
        //currentskill = 0.0f;
    }
    private void Update()
    {
        ScoreText.text = Game.Score.ToString();
        ComboText.text = Game.Combo.ToString();
        HpBar.fillAmount = (float)player.CurrentStateData.Health / player.Data.StateData.Health;
        SkillBar.fillAmount = (float)player.CurrentStateData.SkillGauge / maxskill;
    }
    public void SetClearPanel()
    {
        ClearPanel.SetActive(true);
        ClearScore.text = Game.Score.ToString();
        Time.timeScale = 0f;
    }
    #endregion
}
