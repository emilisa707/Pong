using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D; //rigidbody 2d bola 
    private Vector2 trajectoryOrigin; //titik asal lintasan bola saat ini 

    public float xInitialForce; //besarnya gaya awal yang diberikan untuk mendorong bola
    public float yInitialForce; //besarnya gaya awal yang diberikan untuk mendorong bola
    
    void Start()
    {
        trajectoryOrigin = transform.position; //nilai awal variabel ini sesuai lokasi bola

        rigidBody2D = GetComponent<Rigidbody2D>(); //mengambil rigidbody2d
        RestartGame(); //memulai game 
    }

    void ResetBall()
    {
        transform.position = Vector2.zero; //reset posisi menjadi (0,0)

        rigidBody2D.velocity = Vector2.zero; //reset kecepatan menjadi (0.0)
    }
    
    void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce); //menentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yYinitialForce secara random
        //float yRandomInitialForce = 100;
        float randomDirection = Random.Range(0, 2); //menentukan nilai acak antara 0 dan 2

        if(randomDirection < 1.0f)
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce)); //jika dibawah 1 maka bola ke arah kiri
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce)); //jika tidak bola ke arah kanan 
        }
    }

    void RestartGame()
    {
        ResetBall(); //kembalikan bola ke posisi semula

        Invoke("PushBall", 2); //setelah 2 detik, berikan gaya ke bola 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position; //ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; } //untuk mengakses informasi titik asal lintasan
    }
}
