using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목적: 폭탄이 물체에 부딪히면 이펙트 만들고 파괴된다.
// 필요속성: 폭발 이펙트
public class BombAction : MonoBehaviour
{
    // 필요속성: 폭발 이펙트
    public GameObject bombEffect;

    // 목적: 폭탄이 물체에 부딪히면 이펙트 만들고 파괴된다.
    private void OnCollisionEnter(Collision collision)
    {
        // 이펙트를 만든다.
        GameObject bombEffGO = Instantiate(bombEffect);

        // 이펙트의 위치를 나(폭탄)의 위치로 위치시켜준다.
        bombEffGO.transform.position = transform.position;

        // 나(폭탄)을 제거한다.
        Destroy(gameObject);
    }
}
