using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranIMove : MonoBehaviour
{
    public float speed;

    private int backUp;

    public Vector3 newPosition;

    // Start is called before the first frame update
    void Awake()
    {
        backUp = 60;
        float time = Random.Range(30f, 120f);
        Invoke("itemSlide", time); 
    }

    //This is a function to create random movement for items
    public void itemSlide()
    {
        float rTimer;
        float ranX;
        float ranZ;

        //Set the new timer to random
        rTimer = Random.Range(30, 120);
        ranX = Random.Range(-5, 5);
        ranZ = Random.Range(-5, 5);

        newPosition = new Vector3 (transform.position.x + ranX, transform.position.y, transform.position.z + ranZ);

        //Call hte Coroutine
        StartCoroutine(move());
        

        //Invoke this again some random time from now
        Invoke("itemSlide", rTimer);
    }

    IEnumerator move()
    {
        //Use an if statement to check if the object has moved completely or not
        while (transform.position!=newPosition && backUp > 0)
        {
            //move this object to the selected spot
            this.transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
            backUp--;

            yield return new WaitForSeconds(.05f);
        }

        //End Coroutine
        backUp = 30;
        StopCoroutine(move());

    }
}
