using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour {

    public Sprite[] leafSprite;
    public GameObject leafheart;
    public RectTransform thisRect;
    public GameObject[] allHearts;

    float lastHealth;

    // storage for instantiation.
    GameObject heart;
    Image heartImage;
    RectTransform rec;
    Vector3 position;
    int dimension = 100;
    int halfDim;
    float scale;
    int ptr;
    float difference;

    public float currentWidth;

    // Use this for initialization
    void Start () {
        lastHealth = Variables.MaxHealth;
        halfDim = dimension / 2;
        allHearts = new GameObject[Mathf.CeilToInt(Variables.MaxHealth)];

	    for (int i=0; i< Variables.MaxHealth; i++)
        {
            heartAdder(i);
        }
        thisRect = this.GetComponent<RectTransform>();
        position = thisRect.anchoredPosition3D;

        scale = thisRect.localScale.x;
        ReCenter();
	}
	
	// Update is called once per frame
	void Update () {
        if (Variables.Health < 0f) return;
        if (lastHealth > Variables.Health)
        {
            removeHeart();
        } else if (lastHealth < Variables.Health)
        {
            addHeart();
        }

        lastHealth = Variables.Health;
	}

    public void removeHeart()
    {
        // add a consistency checker later
        ptr = Mathf.CeilToInt(Variables.Health);
        difference = lastHealth - Variables.Health;
        for (int i=0; i<difference; i++)
        {
            heart = allHearts[ptr+i];
            heart.transform.parent = null;
            GameObject.Destroy(heart.gameObject);
            allHearts[ptr+i] = null;
        }
        
    }

    public void addHeart()
    {
        ptr = Mathf.CeilToInt(Variables.Health) - 1;

        difference = Variables.Health - lastHealth;
        for (int i = 0; i < difference; i++)
        {
            heartAdder(i);
        }
    }

    void heartAdder(int ptr)
    {
        heart = GameObject.Instantiate(leafheart) as GameObject;
        heartImage = heart.GetComponent<Image>() as Image;
        heartImage.sprite = leafSprite[Variables.GREEN];
        heart.transform.parent = this.transform;
        rec = heart.GetComponent<RectTransform>();
        rec.sizeDelta = new Vector2(dimension, dimension);
        rec.anchoredPosition3D = new Vector3(ptr * (dimension - 15) + halfDim, -halfDim, 0);
        rec.localScale = new Vector3(1, 1, 1);
        allHearts[ptr] = heart;
    }

    void ReCenter()
    {
        currentWidth = (scale * (dimension - 15) * Mathf.CeilToInt(Variables.Health)) + halfDim;
        thisRect.anchoredPosition3D = new Vector3(position.x - (currentWidth / 2), position.y, position.z);
    }
}
