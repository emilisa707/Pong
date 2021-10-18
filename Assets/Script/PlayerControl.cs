using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton = KeyCode.W; //tombol untuk menggerakan ke atas
    public KeyCode downButton = KeyCode.S; //tombol untuk menggerakan ke bawah 

    public float speed = 10.0f; //kecepatan gerak
    public float yBoundary = 9.0f; //batas atas dan bawah scene

    private Rigidbody2D rigidBody2D; //rigidbody2d raket ini 

    private ContactPoint2D lastContactPoint; //Titik tumbukan terakhir dengan bola, untuk menampilkan variabel2 fisika terkait tumbukan tersebut

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>(); //memuat rigidBody2D
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidBody2D.velocity; //kecepatan raket sekarang

        if(Input.GetKey(upButton)) //jika tombol ke atas di tekan
        {
            velocity.y = speed; //beri kecepatan ke komponen y
        }

        else if(Input.GetKey(downButton)) //jika tombol kebawah
        {
            velocity.y = -speed; //beri kecepatan ke komponen -y
        }

        else
        {
            velocity.y = 0.0f; //diam 
        }

        rigidBody2D.velocity = velocity; //masukkan kembali kecepatannya ke rigidBody2D

        Vector3 position = transform.position; //mendapatkan posisi raket sekarang

        if(position.y > yBoundary) //jika posisi raket melewati batas
        {
            position.y = yBoundary; //kembalikan ke batas atas tersebut
        }
        else if(position.y < -yBoundary) //jika posisi raket melewati batas bawah 
        {
            position.y = -yBoundary; //kembalikan ke batas atas tersebut
        }

        transform.position = position; //masukan kembali posisinya ke transform
    }

    public void IncrementScore()
    {
        score++; //menaikkan skor sebanyak 1 poin
    }

    public void ResetScore()
    {
        score = 0; //mengembalikan skor menjadi 0
    }

    public int Score
    {
        get { return score; } //mendapatkan nilai skor
    }

    public ContactPoint2D LastContactPoint //untuk mengakses informasi titik kontak dari kelas lain
    {
        get { return lastContactPoint; }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.name.Equals("Ball")) //ketika terjadi tumbukan dengan bole
        {
            lastContactPoint = collision.GetContact(0); //rekam titik kontaknya.
        }
    }
}
