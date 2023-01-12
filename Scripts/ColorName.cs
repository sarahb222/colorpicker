using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorName : RandomConverter
{
    public Slider red;
    public Image redI;
    public Slider green;
    public Image greenI;
    public Slider blue;
    public Image blueI;
    public GameObject gameObject;
    public TMP_InputField colorChosen;
    public TextMeshProUGUI textChange;

    private string[] colorListNums;
    private string[] colorListNames;


    // Start is called before the first frame update
    void Start()
    {
        colorListNums = new string[] { "#FFFFFF", "#CCCCCC", "#999999", "#666666", "#333333", "#000000", "#00FFFF", "#33FFFF", "#66FFFF", "#99FFFF", "#CCFFFF", "#00CCCC", "#33CCCC", "#66CCCC", "#99CCCC", "#009999", "#339999", "#669999", "#006666", "#336666", "#003333", "#FF00FF", "#FF33FF", "#FF66FF", "#FF99FF", "#FFCCFF", "#CC00CC", "#CC33CC", "#CC66CC", "#CC99CC", "#990099", "#993399", "#996699", "#660066", "#663366", "#330033", "#FFFF00", "#FFFF33", "#FFFF66", "#FFFF99", "#FFFFCC", "#CCCC00", "#CCCC33", "#CCCC66", "#CCCC99", "#999900", "#999933", "#999966", "#666600", "#666633", "#333300", "#0000FF", "#3333FF", "#6666FF", "#9999FF", "#CCCCFF", "#0000CC", "#3333CC", "#6666CC", "#9999CC", "#000099", "#333399", "#666699", "#000066", "#333366", "#000033", "#00FF00", "#33FF33", "#66FF66", "#99FF99", "#CCFFCC", "#00CC00", "#33CC33", "#66CC66", "#99CC99", "#009900", "#339933", "#669966", "#006600", "#336633", "#003300", "#FF0000", "#FF3333", "#FF6666", "#FF9999", "#FFCCCC", "#CC0000", "#CC3333", "#CC6666", "#CC9999", "#990000", "#993333", "#996666", "#660000", "#663333", "#330000" };
        colorListNames = new string[] { "White", "Dragon’s Tooth", "Silver", "Gray", "Mine Shaft", "Black", "Cyan", "Turquoise", "Aquamarine", "Blizzard", "Sky Blue", "Dragon’s Egg", "Pelorous", "Fountain", "Mist", "Cyan Berry", "Chill", "Patina", "Teal", "Casal", "Deep Teal", "Magenta", "Orchid", "Flamingo", "Lavender", "Lace", "Dragon’s Horn", "Cerise", "Fuchsia", "Lilac", "Purple Berry", "Plum", "Strikemaster", "Eggplant", "Cosmic", "Wine", "Yellow", "Golden", "Lemon", "Canary", "Cream", "Dragon’s Eye", "Pear", "Laser", "Glade", "Yellow Berry", "Sycamore", "Avocado", "Olive", "Fern Frond", "Woodrush", "Blue", "Blue Ribbon", "Cornflower", "Port", "Periwinkle", "Dragon’s Breath", "Indigo", "Blue Marguerite", "Bluebell", "Blue Berry", "Sapphire", "Butterfly", "Navy", "Rhino", "Zodiac", "Green", "Malachite", "Lime", "Mint", "Snowy Mint", "Dragon’s Scale", "Apple", "Emerald", "Dusty Green", "Green Berry", "Forest", "Highland", "Jewel", "Pea", "Deep Fir", "Red", "Coral", "Bittersweet", "Tangerine", "Pink", "Dragon’s Blood", "Cardinal", "Chestnut Rose", "Clam", "Red Berry", "Burnt Umber", "Copper Rose", "Maroon", "Buccaneer", "Coffee" };

        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        red.value = color.r*255;
        green.value = color.g*255;
        blue.value = color.b*255;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        colorChosen.text = '#' + ColorUtility.ToHtmlStringRGB(gameObject.GetComponent<SpriteRenderer>().color);
        textChange.text = colorChosen.text;

        DisplayColorName(colorChosen.text);
    }

    public void OnEdit()
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color.r = red.value/255;
        color.g = green.value/255;
        color.b = blue.value/255;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        colorChosen.text = '#' + ColorUtility.ToHtmlStringRGB(gameObject.GetComponent<SpriteRenderer>().color);
        textChange.text = colorChosen.text;

        redI.GetComponent<Image>().color = new Color(color.r, 0, 0);
        greenI.GetComponent<Image>().color = new Color(0, color.g, 0);
        blueI.GetComponent<Image>().color = new Color(0, 0, color.b);

        DisplayColorName(colorChosen.text);
    }

    public void onTyping()
    {
        Color newCol;
        if (colorChosen.text.Length == 7 && ColorUtility.TryParseHtmlString(colorChosen.text, out newCol))
        {
            red.value = newCol.r*255;
            green.value = newCol.g*255;
            blue.value = newCol.b*255;
            redI.GetComponent<Image>().color = new Color(newCol.r, 0, 0);
            greenI.GetComponent<Image>().color = new Color(0, newCol.g, 0);
            blueI.GetComponent<Image>().color = new Color(0, 0, newCol.b);

            DisplayColorName(colorChosen.text);
        }

    }

    //Display the name of the color
    public void DisplayColorName(string colorText)
    {
        int redVal = 16 * ConvertToInt(colorText[1]) + ConvertToInt(colorText[2]);
        int greenVal = 16 * ConvertToInt(colorText[3]) + ConvertToInt(colorText[4]);
        int blueVal = 16 * ConvertToInt(colorText[5]) + ConvertToInt(colorText[6]);


        int closestIndex = 0;
        int closest = 100000000;
        int temp = 0;
        for(int i = 0; i < colorListNums.Length; i++)
        {
            temp = 0;
            temp = Mathf.Abs(redVal - (16 * ConvertToInt(colorListNums[i][1]) + ConvertToInt(colorListNums[i][2])));
            temp = temp + Mathf.Abs(greenVal - (16 * ConvertToInt(colorListNums[i][3]) + ConvertToInt(colorListNums[i][4])));
            temp = temp + Mathf.Abs(blueVal - (16 * ConvertToInt(colorListNums[i][5]) + ConvertToInt(colorListNums[i][6])));
            if(temp < closest)
            {
                closest = temp;
                closestIndex = i;
            }
        }

        textChange.text = colorListNames[closestIndex];
    }
}
