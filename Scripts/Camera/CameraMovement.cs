using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    Vector3 startRotation = new Vector3(3.77f ,3.246f,0.214f);
    Vector3 rotation = new Vector3(16f ,3.246f,0.214f); 
    Vector3 startPos = new Vector3(-0.87f, 8.07f, -17.74f);
    Vector3 offset = new Vector3(0, 3, -8);
    
    void Start()
    {
        transform.position = startPos;
    }


    void FixedUpdate()
    {
        if (GamePlayManager.instance.inAir)
        {
            Vector3 temp = new Vector3(0, 0, 0);
            switch (GamePlayManager.instance.alivePlayersCount)
            {
                case 1:
                    temp = GamePlayManager.instance.players[2].transform.position;
                    break;
                case 2:
                    temp = GamePlayManager.instance.players[1].transform.position;
                    break;
                case 3:
                    temp = GamePlayManager.instance.players[0].transform.position;
                    break;
            }
            temp += offset;
            transform.position = temp;
            transform.rotation = Quaternion.Euler(rotation);
        }
        else
        {
            transform.rotation = Quaternion.Euler(startRotation);
            transform.position = startPos;
        }
    }
}