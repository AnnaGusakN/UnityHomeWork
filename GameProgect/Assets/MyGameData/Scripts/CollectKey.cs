using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    [SerializeField] private int _healing = 30;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ITakeHealing>().Healing(_healing);
            Destroy(gameObject);
        }
    }
}
