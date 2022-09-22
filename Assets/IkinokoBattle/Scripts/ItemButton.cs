using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static Item;

[RequireComponent(typeof(Button))]
public class ItemButton : MonoBehaviour
{
    // Start is called before the first frame update

    public OwnedItemsData.OwnedItem OwnedItem
    {
        get { return _ownedItem; }
        set
        {
            _ownedItem = value;

            var isEmpty = null == _ownedItem;
            Image.gameObject.SetActive(!isEmpty);
            number.gameObject.SetActive(!isEmpty);
            _button.interactable = !isEmpty;
            if (!isEmpty)
            {
                Image.sprite = itemSprites.First(x => x.itemType == _ownedItem.Type) . sprite;

                number.text = "" + _ownedItem.Number;
            }
        }
    }

    [SerializeField] private ItemTypeSpriteMap[] itemSprites;
    [SerializeField] private Image Image;
    [SerializeField] private Text number;

    private Button _button;
    private OwnedItemsData.OwnedItem _ownedItem;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {

    }

    [Serializable]
    public class ItemTypeSpriteMap
    {
        public Item.ItemType itemType;
        public Sprite sprite;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
