using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDrop : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject[] drops;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(DropItem());
        }
    }

    private IEnumerator DropItem()
    {
        anim.SetTrigger("Open");
        yield return new WaitForSeconds(1);
        anim.enabled = false;
        Vector2 vector = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1);
        Instantiate(drops[Random.Range(0, drops.Length)], vector,Quaternion.identity);
        Destroy(this.gameObject);
    }

}
