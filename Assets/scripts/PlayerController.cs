using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 10;
    public Vector2 scaleChange = new Vector2(1f, 1f); 
    public int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 0.1f * horizontal * Time.deltaTime * speed;
        position.y = position.y + 0.1f * vertical * Time.deltaTime * speed;
        
        rigidbody2d.MovePosition(position);
    }
    private void MakeScore()
    {
        score++;
        scoreText.text = score.ToString();
        
        
    }

    public void ChangeScale()
    {
        Vector3 local = transform.localScale;
        transform.localScale += new Vector3(0.3f, 0.3f, 0f);
        MakeScore();
    }
}
