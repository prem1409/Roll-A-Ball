using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text CountText;
    public Text WinText;
    public AudioSource coin;
    
    public float spheresize=0.2f;
    public int sphereinrow=5;

    // public float thrust;
    // Update is called once per frame
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        count=0;
        SetScore();
        WinText.text="";
        coin=GetComponent<AudioSource>();
        
        
    }
    void FixedUpdate()
    {
        float moveHorizontal =Input.GetAxis("Horizontal");
        float moveVertical =Input.GetAxis("Vertical");
        Vector3 movement=new Vector3(moveHorizontal,0.0f,moveVertical);

        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            coin.Play();
            count+=1;
            SetScore();
        }
        if(other.gameObject.CompareTag ("Walls"))
        {
            
            explode();
            CountText.text="";
            WinText.text="Your score was "+count.ToString() +".You Lose! :'( Please try again!";
            
            // crash.Play();

        }
        

    }
    void explode(){
        gameObject.SetActive(false);
        for (int x=0;x<sphereinrow;x++){
            for (int y=0;y<sphereinrow;y++){
                for (int z=0;z<sphereinrow;z++){
                    CreatePiece(x,y,z);
                }
            }
        }
    }
    void CreatePiece(int x,int y,int z){
        GameObject piece=GameObject.CreatePrimitive(PrimitiveType.Sphere);
        piece.transform.position=transform.position+new Vector3(spheresize*x,0,spheresize*z);
        piece.transform.localScale=new Vector3(spheresize,spheresize,spheresize);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass=spheresize;
    }
    void SetScore(){
        CountText.text="Your score is : "+count.ToString();
        if(count>=12){
            WinText.text="You win!!!!Your score is : "+count.ToString();
            CountText.text="";
        }
    }
}
// Destroy(other.gameObject)