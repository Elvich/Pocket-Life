using UnityEngine;

[CreateAssetMenu(fileName = "Themes", menuName = "Theme")]
public class Themes : ScriptableObject
{
    public EThemes theme;
    
    [Space, Header("Colors")]
    public Color BackgroundColor;
    public Color TextColor;
    public Color AccentColor;
    public Color SpecialСColor;
    
    [Space, Header("Background")]
    public Sprite BackgroundImage;
}
