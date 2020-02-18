using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interact : MonoBehaviour
{
    
    [SerializeField] BlackHelmPickedUp blackHelm;
    [SerializeField] KeysPickedUp keyPickedUp;

    [SerializeField] Vector3 rayOrigin = new Vector3 (0f, 0f, 0f);

    [SerializeField] AudioClip keysSound;

    public TextMeshProUGUI interactText;

    [SerializeField] EnemyRessurrect[] enemyRessurrect;

    Ray ray;

    WallMover wallMover;
    WallMoverTrigger wallMoverTrigger;

    Inventory inventory;

    Opener chest;

    // Start is called before the first frame update
    void Start()
    {
        wallMover = GameObject.FindObjectOfType<WallMover>();
        wallMoverTrigger = GameObject.FindObjectOfType<WallMoverTrigger>();

        inventory = GetComponent<Inventory>();

        chest = GameObject.FindObjectOfType<Opener>();

        enemyRessurrect = GameObject.FindObjectsOfType<EnemyRessurrect>();

        interactText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(rayOrigin);
        Debug.DrawRay(ray.origin, ray.direction * 2, Color.yellow);

        RaycastHit hit;
        bool hastHit = Physics.Raycast(ray, out hit);
        if (hastHit)
        {
            interactText.enabled = false;
            if (hit.collider.gameObject.GetComponent<BlackHelmPickedUp>())
            {
                interactText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print(hit.collider.gameObject.name);
                    Destroy(blackHelm.gameObject);
                    inventory.blackHelmPickedUp = true;
                    wallMover.slider.enabled = true;
                    wallMover.move = false;
                    RessurrectEnemies();
                    Destroy(wallMoverTrigger.gameObject);
                }
            }

            if (hit.collider.gameObject.GetComponent<KeysPickedUp>())
            {
                interactText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    AudioSource.PlayClipAtPoint(keysSound, gameObject.transform.position);
                    Destroy(keyPickedUp.gameObject);
                    inventory.keysPickedUp = true;
                }
            }

            if (hit.collider.gameObject.GetComponent<Opener>())
            {
                interactText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    chest.ChestOpener();
                }
            }

            if (hit.collider.CompareTag("Neutral"))
            {
                interactText.enabled = false;
            }

        }
    }

    void RessurrectEnemies()
    {
        enemyRessurrect[0].Ressurrect();
        enemyRessurrect[1].Ressurrect();
        enemyRessurrect[2].Ressurrect();
        enemyRessurrect[3].Ressurrect();
        enemyRessurrect[4].Ressurrect();
        enemyRessurrect[5].Ressurrect();
        enemyRessurrect[6].Ressurrect();
        enemyRessurrect[7].Ressurrect();
    }

}
