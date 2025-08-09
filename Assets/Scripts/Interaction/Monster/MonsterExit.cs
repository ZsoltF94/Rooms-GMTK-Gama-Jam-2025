using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterExit : MonoBehaviour
{
    [SerializeField] private string targetScene;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] GameObject player;

    MonsterMovement monsterMovement;

    void Start()
    {
        monsterMovement = GetComponent<MonsterMovement>();
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && monsterMovement.currentState == MonsterMovement.State.ChasePlayer)
        {
            StartCoroutine(HitPlayer());
            GameManager.Instance.spawnPosition = spawnPosition;
            GameManager.Instance.currentTime = new System.DateTime(1, 1, 1, 7, 0, 0);
            SceneTransitionManager.Instance.TransitionToScene(targetScene);

            // reset SceneState
            GameManager.Instance.ResetAllSceneStates();

        }
    }

    IEnumerator HitPlayer()
    {
        int loops = 5;
        for (int i = 0; i <= loops; i++)
        {
            DialogManager.Instance.EndDialog();
            SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
            Color tempColor = playerRenderer.color;
            tempColor.a = 0;
            playerRenderer.color = tempColor;
            yield return new WaitForSeconds(0.2f);

            tempColor.a = 1f;
            playerRenderer.color = tempColor;
            yield return new WaitForSeconds(0.2f);

        }

    }



}
