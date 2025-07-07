using System.Runtime.InteropServices;
using UnityEngine;
using TMPro; // สำคัญมาก!

public class PlayerScore : MonoBehaviour
{
    private int Coin = 0; // ตัวแปรเก็บคะแนน
    public Transform startPoint; // ตำแหน่งเริ่มต้น

    public TextMeshProUGUI coinText; // UI Text ที่จะแสดงคะแนน

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin++; // เพิ่มคะแนน
            coinText.text = "Coin: " + Coin.ToString(); // อัพเดต UI Text
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Star"))
        {
            Coin += 5; // เพิ่มคะแนนเมื่อชน
            coinText.text = "Coin: " + Coin.ToString(); // อัพเดต UI Text
            Destroy(other.gameObject);

            transform.position = startPoint.position; // รีเซ็ตตำแหน่งของ Player

        }
        else if (other.CompareTag("End"))
        {
            Coin -= 3; // ลดคะแนนเมื่อชน
            coinText.text = "Coin: " + Coin.ToString(); // อัพเดต UI Text
            // Destroy(other.gameObject);
        }
        
    }
}
