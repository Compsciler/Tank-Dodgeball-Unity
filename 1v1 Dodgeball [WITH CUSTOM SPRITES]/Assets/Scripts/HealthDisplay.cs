using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthDisplay : MonoBehaviour {

    public string bulletTag;
    public int health;
    // public float increaseSize

    public Text display;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == bulletTag)
        {
            health -= 1;
            // transform.localScale += new Vector3(increaseSize, increaseSize, increaseSize);
            Destroy(collision.gameObject);

            if (health == 0)
            {
                display.text = "RIP";
            }

            display.text = "HEALTH: " + health;

            /*
            public UnityEngine.UI.Text myText;
            // Get index of character.
            int charIndex = myText.text.IndexOf("S");
            // Replace text with color value for character.
            myText.text = myText.text.Replace(myText.text[charIndex].ToString(), "<color=#000000>" + myText.text[charIndex].ToString() + "</color>");
            */
        }
    }
}
