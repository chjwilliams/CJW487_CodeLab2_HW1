using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected int BOTTOM_OF_SCREEN = -7;
    [SerializeField] protected int TOP_OF_SCREEN = 7;
    [SerializeField] protected int RIGHT_OF_SCREEN = 8;
    private const string SPRITE_TIMER = "SpriteTimer";

    public KeyCode spawnKey;

    [SerializeField] private Sprite[] _sprites;
    public Sprite[] Sprites
    {
        get { return _sprites; }
    }

    [SerializeField] private float _cooldown;
    public float Cooldown
    {
        get { return _cooldown; }
    }

    [SerializeField] private NumberGenerator _numGenerator;
    public NumberGenerator NumGenerator
    {
        get { return _numGenerator; }
    }

    [SerializeField] private List<GameObject> _orbs;
    public List<GameObject> Orbs
    {
        get { return _orbs; }
    }

    private Score _score;

    // Use this for initialization
    void Start ()
    {
        spawnKey = KeyCode.Space;
        _cooldown = 1;
        _numGenerator = GetComponent<NumberGenerator>();
        _orbs = new List<GameObject>();
        _score = GameObject.Find("Score").GetComponent<Score>();
    }

    protected virtual void MakeSprite(int spriteIndex)
    {
        GameObject gameobjSprite = new GameObject();
        gameobjSprite.transform.position = transform.position;
        SpriteRenderer renderer = gameobjSprite.AddComponent<SpriteRenderer>();
        renderer.sprite = Sprites[spriteIndex];
        gameobjSprite.AddComponent<CircleCollider2D>();
        gameobjSprite.AddComponent<Rigidbody2D>();
        gameobjSprite.GetComponent<Rigidbody2D>().gravityScale = 0;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), gameobjSprite.GetComponent<Collider2D>());
        Orbs.Add(gameobjSprite);
    }
	
	// Update is called once per frame
	void Update ()
    {
        _score.UpdateScore(Orbs.Count);
        if (Input.GetKeyDown(spawnKey))
        {
            int spriteIndex = NumGenerator.Next();

            MakeSprite(spriteIndex);
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            for (int i = 0; i < Orbs.Count; i++)
            {
                Orbs[i].GetComponent<Rigidbody2D>().gravityScale = 2.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            for (int i = 0; i < Orbs.Count; i++)
            {
                Orbs[i].GetComponent<Rigidbody2D>().gravityScale = -2.0f;
            }
        }


    }

    private void LateUpdate()
    {
        for (int i = 0; i < Orbs.Count; i++)
        {
            if(Orbs[i].transform.position.y < BOTTOM_OF_SCREEN)
            {
                
                Destroy(Orbs[i]);
                Orbs.Remove(Orbs[i]);
            }
            else if (Orbs[i].transform.position.y > TOP_OF_SCREEN)
            {

                Destroy(Orbs[i]);
                Orbs.Remove(Orbs[i]);
            }
        }
    }
}
