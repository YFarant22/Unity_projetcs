using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField]private GameObject startline;
    public hud_updates hud;

    public int life = 2;
    private float speed;
    private float rotateSpeed = 0.4f;
    
    // Update is called once per frame
    void Update()
    {
        float deltatime = Time.deltaTime;
        float inputX = 0f;
        float inputZ = 0f;
        
        if (Input.GetKey("space")) {
            speed = 15f;
        } else {
            speed = 5f;
        }

        if (Input.GetKey("w")) {
            inputX = speed * deltatime;
        } else if (Input.GetKey("s")) {
            inputX =  speed * deltatime * -1;
        }
        
        if (Input.GetKey("d")) {
            inputZ = -rotateSpeed;
        } else if (Input.GetKey("a"))
        {
            inputZ = rotateSpeed;
        }
        
        transform.Translate(inputX, 0f, 0f);
        transform.Rotate(0f, 0f, inputZ);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid"))
        {
            reset_pos();
            if (life <= 0)
            {
                hud.game_over_display();
            }
            else
            {
                life -= 1;
                hud.update_life_hud();
            }
            
        } else if (other.CompareTag("Finish")) 
        {
            hud.win_display();    
        }
       
    }

    public void reset_pos()
    {
        transform.position = startline.transform.position;
    }
}

