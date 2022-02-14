using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    [SerializeField] private Spider spider = default;

    public void Fire()
    {
        spider.Attack();
    }
}
