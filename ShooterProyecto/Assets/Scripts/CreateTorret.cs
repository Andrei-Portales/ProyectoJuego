using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTorret : MonoBehaviour
{
    public GameObject player;
    public GameObject turret;
    public Image imageToFill;


    public float waitingTime = 5.0f;
    public float creationTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(creationTime >= 1.0f)
            {
                if (GameObject.FindGameObjectWithTag("Turret"))
                {
                    Debug.Log("Ya");
                }
                else
                {
                    Instantiate(turret, new Vector3(player.transform.position.x - 7, player.transform.position.y-1, player.transform.position.z +5), Quaternion.identity);
                }
            }

        }


        // Destruir el Turret despues de 15 secs de vida

        // Tiempo necesario para poder crear un Turret
        creationTime += 1.0f / waitingTime * Time.deltaTime;

        imageToFill.fillAmount = creationTime;


        
    }

}
