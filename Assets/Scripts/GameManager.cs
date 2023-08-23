using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 목적: 게임의 상태(Ready, Start, GameOver)를 구별하고, 게임의 시작과 끝을 TextUI로 표현하고 싶다.
// 필요속성: 게임상태 열거형 변수, TextUI

// 목적2: 2초 후 게임이 Ready 상태에서 Start 상태로 변경되며 게임이 시작된다. 

// 목적3: 플레이어의 hp가 0보다 작으면 상태텍스트와 상태를 GameOver로 바꿔주고
// 필요속성3: hp가 들어있는 playerMove

// 목적4: 플레이어의 hp가 0 이하라면, 플레이어의 애니메이션을 멈춘다.
// 필요속성: 플레이어의 애니메이터 컴포넌트
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // 필요속성: 게임상태 열거형 변수, TextUI
    public enum GameState
    {
        Ready,
        Start,
        GameOver
    }

    public GameState state = GameState.Ready;
    public TMP_Text stateText;

    // 필요속성3: hp가 들어있는 playerMove
    PlayerMove player;

    // 필요속성: 플레이어의 애니메이터 컴포넌트
    Animator animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stateText.text = "Ready";
        stateText.color = new Color32(255, 185, 0, 255);

        StartCoroutine(GameStart());

        player = GameObject.Find("Player").GetComponent<PlayerMove>();

        animator = player.GetComponentInChildren<Animator>();
    }

    // 목적2: 2초 후 게임이 Ready 상태에서 Start 상태(초록색)로 변경되며 게임이 시작된다. 
    IEnumerator GameStart()
    {
        // 2초를 기다린다.
        yield return new WaitForSeconds(2);

        stateText.text = "Game Start";
        stateText.color = new Color32(0, 255, 0, 255);

        // 0.5초를 기다린다.
        yield return new WaitForSeconds(0.5f);

        // 상태 text 비활성
        stateText.gameObject.SetActive(false);

        // 상태 변경
        state = GameState.Start;
    }

    // 목적3: 플레이어의 hp가 0보다 작으면 상태텍스트와 상태를 GameOver로 바꿔주고
    void CheckGameOver()
    {
        if(player.hp <= 0)
        {
            // 목적4: 플레이어의 hp가 0 이하라면, 플레이어의 애니메이션을 멈춘다.
            animator.SetFloat("MoveMotion", 0f);

            // 상태 텍스트 ON
            stateText.gameObject.SetActive(true);

            // 상태 텍스트를 GameOver로 변경
            stateText.text = "Game Over";

            // 상태 텍스트의 컬러를 빨간색으로 변경
            stateText.color = new Color32(255, 0, 0, 255);

            state = GameState.GameOver;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
    }
}
