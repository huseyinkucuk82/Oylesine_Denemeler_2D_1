using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float y_Hiz = 10f;
    const float x_Hiz = 10000f;
    const float m_ZiplamaGucu = 200f;
    bool m_Zeminde = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMove=Input.GetAxis("Horizontal");
        float jumpMove = Input.GetAxis("Jump");
        float yMove = Input.GetAxis("Debug Vertical");
        Debug.Log(jumpMove);
        // transform.Translate(new Vector2(xMove * m_Hiz * Time.deltaTime, 0), Space.World);
        transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(xMove * x_Hiz * Time.deltaTime, 0));
        transform.Translate(new Vector2(0, yMove * y_Hiz * Time.deltaTime), Space.World);
        //transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpMove * m_ZiplamaGucu ));
        if (jumpMove > 0 && m_Zeminde)
        {
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, m_ZiplamaGucu));
            m_Zeminde = false;
        }
    }
    public bool Zeminde 
    { 
        get
        {
            return m_Zeminde;
        }
        set
        {
            m_Zeminde = value;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zemin")
            this.Zeminde = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zemin")
            this.Zeminde = false;
    }

}
