using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject winObj;
    public GameObject loseObj;
    public GameObject player;
    public GameObject enemyManager;

    public int targetScore; // Ŀ�����

    public Text targetText;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("TargetScore"))
            targetScore = PlayerPrefs.GetInt("TargetScore");
        else
            targetScore = 0;
    }
    private void Start()
    {
        targetText.text = "Ŀ�������"+targetScore.ToString();
        winObj.SetActive(false);
        loseObj.SetActive(false);
    }
    private void Update()
    {
        int score = UIManager.instance.score;
        if (score >= targetScore && PlayerHealth.isWin)
        {
            Debug.Log("��Ϸʤ��");
            saveCareerProgress();
            winObj.SetActive(true);
            player.SetActive(false);
            enemyManager.SetActive(false);
        }
        else if(!PlayerHealth.isWin)
        {
            Debug.Log("��Ϸʧ�ܣ�");
            loseObj.SetActive(true);
            player.SetActive(false);
            enemyManager.SetActive(false);
        }
    }
    public void saveCareerProgress()
    {

        int currentLevelID = PlayerPrefs.GetInt("currentLevelID");

        int userLevelAdvance = PlayerPrefs.GetInt("userLevelAdvance");

        if (userLevelAdvance < currentLevelID)
        {
            userLevelAdvance++;
            PlayerPrefs.SetInt("userLevelAdvance", userLevelAdvance);
        }
    }
    public void BackLevel()
    {
        SceneManager.LoadScene("Level");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
