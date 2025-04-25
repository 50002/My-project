using UnityEngine;

public class LiikuEteenpäin : MonoBehaviour
{
    public float speed = 40f; //Asettaa nopeuden
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate forward direction based on the y-axis rotation
        Vector3 forwardDirection = new Vector3(Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad), 0, Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad)); // MAth sin ja cos laskevat suunnan tavalla mikä ottaa huomioon vain y akselin rotaation

        // Move the object forward in the calculated direction
        transform.Translate(forwardDirection * speed * Time.deltaTime, Space.World); //liikkuu eteenpäin
    }
}
