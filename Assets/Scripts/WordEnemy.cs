using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordEnemy : EnemyObject
{
    public string[] words;

    private void Start()
    {
        string word = words[Random.Range(0, words.Length)];
        GetComponent<TextMesh>().text = word;
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.size = new Vector2(word.Length * 0.388f, collider.size.y);
        collider.offset = new Vector2(collider.size.x / 2f, collider.offset.y);
    }
}
