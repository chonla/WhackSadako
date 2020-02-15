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
        if (isPlayerWin)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green, 0.5f);

                if (hit.transform.GetComponent<Mole>().IsAlive())
                {
                    hit.transform.GetComponent<Mole>().Dead();
                    score += 100;
                    scoreText.text = $"Score: {score}";


                    Debug.Log($"current score {score}");

                    if (score == winningScore)
                    {
                        isPlayerWin = true;
                        Debug.Log("game ends");

                        StartCoroutine(nameof(WinGame));
                    }
                }
                    
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction*100, Color.red, 0.5f);
            }
            
        }
    }
    
    private IEnumerator WinGame()
    {
        yield return new WaitForSeconds(.5f);
        
        SceneManager.LoadScene("WinningScene");
    }

}
