using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{

    private Swipe _swipeEffect;
    private GameObject _firstItem;
    [SerializeField] private GameObject redImage;
    [SerializeField] private GameObject greenImage;

    public delegate void OnMovedToFront();
    public static event OnMovedToFront onMovedToFront;


    // Start is called before the first frame update
    void Start()
    {
        _swipeEffect = FindObjectOfType<Swipe>();
        _firstItem = _swipeEffect.gameObject;
        _swipeEffect.itemMoved += ItemMovedFront;
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if(_firstItem != null)
        {
            float distanceMoved = _firstItem.transform.localPosition.x;
            
            if(Mathf.Abs(distanceMoved) > 0)
            {
                float step = Mathf.SmoothStep(0.8f, 1, Mathf.Abs(distanceMoved)/(Screen.width/2));
                transform.localScale = new Vector3(step, step, step);
            }
        }
    }

    void ItemMovedFront()
    {
        onMovedToFront?.Invoke();
        
        Swipe swipe = gameObject.AddComponent<Swipe>();
        swipe.setRedGreenImages(redImage, greenImage);
        if(Switch.Instance.GetIsRecipeSelected())
        {
            Instantiatior.setRecipeIndex(Instantiatior.nextRecipeIndex);
        }
        else
        {
            Instantiatior.setRestaurantIndex(Instantiatior.nextRestaurantIndex);
        }
        
        Destroy(this);
    }
}
