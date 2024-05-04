using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixControler : MonoBehaviour
{
    private Vector2 lastTapPosition;//esta es la última position de la pantalla
    private Vector3 startPosition;//esta es la posicióndel Helix


    public Transform topTransform;
    public Transform goalTransform;
    public GameObject helixLevelPrefab;

    public List<Stage> allStages = new List<Stage>();
    public float helixDistance;

    private List<GameObject> spawnedLevels = new List<GameObject>();

    private void Awake()
    {
        startPosition = transform.localEulerAngles;//Cual es la posición inical del HElix
        helixDistance = topTransform.localPosition.y - (goalTransform.localPosition.y + .1f);
        LoadStage(0);
    }


    // Start is called before the first frame update
   // void Start()
   // {
       // startPosition = transform.localEulerAngles;//Cual es la posición inical del HElix
   // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))//Si pulsamos el botón uzq del boton o presionamos con el dedo
        {
            Vector2 currentTapPosition = Input.mousePosition; //cual es la psoition actual de la pantalla y se iguala a pla psoition del mausae
            if (lastTapPosition==Vector2.zero) //O si no tocamos la pantalla
            {
                lastTapPosition = currentTapPosition; //Esta será la posición actual
            }
            float distance = lastTapPosition.x - currentTapPosition.x;
            lastTapPosition = currentTapPosition;

            transform.Rotate(Vector3.up * distance);
        }
        if (Input.GetMouseButtonUp(0)) //para indicar cuando movemos el dedo de la pantalla
        {
            lastTapPosition = Vector2.zero;
        }
    }


    public void LoadStage(int stageNumber)
    {
        Stage stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count - 1)];

        if (stage==null)
        {
            Debug.Log("No has definido Stages");
            return;
        }

        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;
        FindObjectOfType<BallController>().GetComponent<Renderer>().material.color = allStages[stageNumber].stageBallColor;
        transform.localEulerAngles = startPosition;

        foreach (GameObject go in spawnedLevels)
        {
            Destroy(go);
        }

        float levelDistance = helixDistance / stage.levels.Count;
        float spawnPostY = topTransform.localPosition.y;

        for (int i = 0; i < stage.levels.Count; i++)
        {
            spawnPostY -= levelDistance;
            GameObject level = Instantiate(helixLevelPrefab, transform);
            level.transform.localPosition = new Vector3(0, spawnPostY, 0);

            spawnedLevels.Add(level);


            int partsToDisable = 12 - stage.levels[i].partCount;
            List<GameObject> disableParts = new List<GameObject>();

            while (disableParts.Count<partsToDisable)
            {
                GameObject randomPart = level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;
                if (!disableParts.Contains(randomPart))
                {
                    randomPart.SetActive(false);
                    disableParts.Add(randomPart);
                }
            }


            List<GameObject> leftParts = new List<GameObject>();

            foreach (Transform t in level.transform)
            {
                t.GetComponent<Renderer>().material.color = allStages[stageNumber].stageLevelPartColor;
                if (t.gameObject.activeInHierarchy)
                {
                    leftParts.Add(t.gameObject);
                }
            }

            List<GameObject> deathparts = new List<GameObject>();


            while (deathparts.Count < stage.levels[i].deathPartCount && leftParts.Count > 0)
            {
                GameObject randomPart = leftParts[Random.Range(0, leftParts.Count)];
                leftParts.Remove(randomPart);
                randomPart.gameObject.AddComponent<DeathPart>();
                deathparts.Add(randomPart);
            }



        }
    }


}
