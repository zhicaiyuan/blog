
using UnityEngine;
public enum ItemType 
{
    Material,
    Equipment
}


[CreateAssetMenu(fileName ="新物品信息",menuName ="物品")]
public class ItemData : ScriptableObject
{
    public ItemType itemtype;
    public string itemname;
    public Sprite icon;

    [UnityEngine.Range(0,100)]
    public float dropchance;//定义物品组件
}
