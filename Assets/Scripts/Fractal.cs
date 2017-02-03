using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {
    //Assign Mesh and Mesh Material
	public Mesh mesh;
    public Material material;
    //Limit the amount of fractals added and keep track of the current amount
    public int maxDepth;
    private int depth;
    //Childscale is used to change the size of each child incrimentally
    public float childScale;

    //Change the scale over time
    private Vector3 currentScale = new Vector3(1, 1, 1);
    public float scaleProgress;

   // private Vector3 FinalScale = new Vector3(15, 15, 15);
    private float scaleX = 15f;
    private float scaleY = 15f;
    private float scaleZ = 15f;

    private float TimeScale = 1f;
    //look for the enemyPrefab
    public GameObject enemyPrefab;

    private Material[] materials;
    //This will help reenable Dynamic Batching

    //ColorAttempt
   

    private void InitializeMaterials()
    {
        materials = new Material[maxDepth + 1];
        for (int i = 0; i <= maxDepth; i++)
        {
            float t = i / (maxDepth - 1f);
            t *= t;
            materials[i] = new Material(material);
            materials[i].color = Color.Lerp(Color.white, Color.cyan, (float)i / maxDepth);
        }
        materials[maxDepth].color = Color.red;
    }
    //This is determining the various speed elements of the fractal
    public float maxRotationSpeed;
    private float rotationSpeed;
    //This is determining the twist of the fractal
    public float maxTwist;

    private void Start()
    {
       
        //This is calling the rotation speed
        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);
       // transform.localScale = Vector3.Lerp(currentScale, FinalScale, scaleProgress);

        if (materials == null)
        {
            InitializeMaterials();
        }
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = materials[depth];
        gameObject.AddComponent<BoxCollider>();
        gameObject.layer= LayerMask.NameToLayer("Fractal");
        //gameObject.AddComponent<EnemyAttack>();
        
        //gameObject.AddComponent<FacePlayer>();
        if (depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }
    }
 
    //These static arrays will help us organize some specific settings
    private static Vector3[] childDirections =
    {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };

    private static Quaternion[] childOrientations =
    {
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f)
    };

    private static Vector3[] childGrow =
    {
        
    };

    public float spawnProbability;

    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < childDirections.Length; i++)
        {
            if (Random.value < spawnProbability)
            {
                //This will let them spawn over time
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                //(this) only really used when passing a reference to the object intself
                //the Vector3.up.right lets us generate the children with Vector3 coordinates in mind
                //The Quaternions will reorient the fractals to the angles specified
                new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);

                //new GameObject("Weapon Child").AddComponent<EnemySpawner>();
                this.gameObject.tag = "Fractal";
                //GameObject enemyPrefab = Resources.Load("Enemy") as GameObject;
                //Instantiate(enemyPrefab, transform.position + new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0), Quaternion.identity);

                //enemyPrefab.transform.parent = gameObject.transform;

                //GameObject instance = Instantiate(Resources.Load("enemy", typeof(GameObject))) as GameObject;

            }
        }
    } 

    //Give the children a mesh, material maxDepth and depth Same as the parent
    //the quaternion at the end will ensure that the children will follow the same orientation changes
    private void Initialize(Fractal parent, int childIndex)
    {
        //Make sure all changes to the parent carry to the child down here!
        mesh = parent.mesh;
        materials = parent.materials;
        maxDepth = parent.maxDepth;
        maxTwist = parent.maxTwist;
        //FinalScale = parent.FinalScale;

        currentScale = parent.currentScale;
        //FinalScale = parent.FinalScale;
        //This is will let the children rotate
        maxRotationSpeed = parent.maxRotationSpeed;
        //This will copy the parents spawn probability
        spawnProbability = parent.spawnProbability;
        //this will add onto the depth counter +1 until it hits the maxDepth
        depth = parent.depth + 1;
        //we need to tell what the childScale is before it is placed under the parent in heirarchy
        childScale = parent.childScale;
        //transform the children under the parent in the heirarchy
        transform.parent = parent.transform;
        //these are used to transform the children based on the childScale Scale UP and then Upward in space
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
        //this will transform the children to the "orientation"
        transform.localRotation = childOrientations[childIndex];
        //ScaleChildrenover time BROKEN
        
        // gameObject.AddComponent<GrowOverTime>();



    }
    private void Update()
    {
        //This is rotation all objects
        transform.Rotate(0f, 30f * Time.deltaTime, 0f);
    }

   

}
