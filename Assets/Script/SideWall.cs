using UnityEngine;


public class SideWall : MonoBehaviour
{
    public PlayerControl player; //pemain yang akan bertambah skornya jika bola menyentuh dinding ini 
    [SerializeField] private GameManager gameManager;
    

    void OnTriggerEnter2D(Collider2D anotherCollider) //dipanggil ketika objek lain ber-collider bersentuhan dengan dinding
    {
        if(anotherCollider.name == "Ball") //jika objek tersebut bernama Ball
        {
            player.IncrementScore(); //tambahkan skor ke pemain 

            if(player.Score < gameManager.maxScore) //jika skor pemain belum mencapai skor maksimal 
            {
                anotherCollider.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
