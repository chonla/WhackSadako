using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    private int score = 0;
    private bool isPlayerWin = false;
    
    public int winningScore = 500;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerWin) return;
        if (!Input.GetMouseButtonUp(0)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            var mole = hit.transform.GetComponent<Mole>();
            if (!mole.IsAlive()) return;
            
            mole.Dead();
            score += 100;
            scoreText.text = $"Score: {score}";

            if (!score.Equals(winningScore)) return;
            
            isPlayerWin = true;
            StartCoroutine(nameof(WinGame));
        }
    }
    
    private IEnumerator WinGame()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("WinningScene");
    }

}
