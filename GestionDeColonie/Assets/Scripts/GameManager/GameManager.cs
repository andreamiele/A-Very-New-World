using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int mobCount;
    public GameObject woodText;
    public GameObject cobbleText;
    public GameObject ironText;
    public static GameManager instance;
    public GameObject GUIPlayer;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Game Manager is null");
            }
            return instance;
        }

    }

    private void Start()
    {
        InvokeRepeating("spawn", 2, 20);
        InvokeRepeating("TimeIsRunningNow", 200, 60);
    }
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        experienceSlider.value = experience;
        experienceSlider.maxValue = maxExperience;
        woodText.GetComponent<TextMeshProUGUI>(). text = wood.ToString();
        cobbleText.GetComponent<TextMeshProUGUI>().text = cobble.ToString();
        ironText.GetComponent<TextMeshProUGUI>().text = iron.ToString();

        GameObject[] gameObjectList = GameObject.FindGameObjectsWithTag("player");
        settlers = TabToList(gameObjectList);

    }

    public Tilemap collision;
    public Tilemap floor;

    // Ressources
    //
    public List<Sprite> playerSprites;
    public List<Sprite> building;
    public List<Sprite> ff;
    public List<int> xpTable;
    public List<int> fff;

    // References

    public Player player;
    public FloatingTextManager floatingTextManager;

    public List<GameObject> settlers= new List<GameObject>();
    public Player justClickedPlayer;
    public List<Player> mobilisedSettlers = new List<Player>();

    ////
    ///

    // Logic level
    public int wood;
    public int cobble;
    public int iron;
    public int food;
    /// etc..
    private int experience=5;
    public Slider experienceSlider;
    private int maxExperience = 50;


    // Logic max level
    public int woodMax;
    public int cobbleMax;
    public int ironMax;
    public int mobCap;

    public List<GameObject> mobs = new List<GameObject>();


    private List<GameObject> TabToList(GameObject[] tab)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i<tab.Length; i++)
        {
            list.Add(tab[i]);
        }
        return list;
    }

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Save state
    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += wood.ToString() + "|";
        s += experience.ToString() + "|";
        s += cobble.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        iron = int.Parse(data[0]);
        wood = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        cobble = int.Parse(data[3]);
    }

    public void spawn()
    {
        if (mobCount < mobCap)
        {
            Vector3Int sizes = collision.size;
            float x = Random.Range(1f, sizes.x - 1);
            float y = Random.Range(1f, sizes.y - 1);
            int x1 = (int)Mathf.Ceil(x);
            int y1 = (int)Mathf.Ceil(y);

            TileBase tile = floor.GetTile(new Vector3Int(x1, y1, 0));
            string tileName = tile.name;

            TileBase tile2 = collision.GetTile(new Vector3Int(x1, y1, 0));

            while (tileName != "herbeModele" && tile2 != null)
            {
                x = Random.Range(1f, sizes.x - 1);
                y = Random.Range(1f, sizes.y - 1);
                x1 = (int)Mathf.Ceil(x);
                y1 = (int)Mathf.Ceil(y);

                tile = floor.GetTile(new Vector3Int(x1, y1, 0));
                tileName = tile.name;
                tile2 = collision.GetTile(new Vector3Int(x1, y1, 0));

            }
            float a =  x   * 0.16f;
            float b = y * 0.16f;
            Instantiate(mobs[0], new Vector3(a, b, 0), Quaternion.identity);
            Instantiate(mobs[1], new Vector3(a, b, 0), Quaternion.identity);
            mobCount++;
        }
    }



    protected void TimeIsRunningNow() // Update every matters when time is running. It can be like updating the food stock of the colony, updating the tiredness of the colons ...
    {
        int nbSettlers = settlers.Count;
        food -= nbSettlers * 3;
        for (int i =0; i <= settlers.Count; i++)
        {
            Player p = settlers[i].GetComponent<Player>();
            p.tiredness *= 0.95;
        }
    }
}

