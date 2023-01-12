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









        /*
        //Check if grayscale
        if ((Mathf.Abs(redVal - greenVal) < 25 && Mathf.Abs(redVal - blueVal) < 25) || (Mathf.Abs(redVal - greenVal) < 25 && Mathf.Abs(greenVal - blueVal) < 25) || (Mathf.Abs(redVal - blueVal) < 25 && Mathf.Abs(greenVal - blueVal) < 25))
        {
            //Check which value is in the middle
            int midVal = 0;
            if ((redVal < greenVal && redVal > blueVal) || (redVal > greenVal && redVal < blueVal) || (redVal == greenVal))
            {
                midVal = redVal;
            }
            else if ((greenVal < redVal && greenVal > blueVal) || (greenVal > redVal && greenVal < blueVal) || (greenVal == blueVal))
            {
                midVal = greenVal;
            }
            else if ((blueVal < redVal && blueVal > greenVal) || (blueVal > redVal && blueVal < greenVal) || (blueVal == redVal))
            {
                midVal = blueVal;
            }

            //Determine color based on the middle value only
            if (midVal < 26)
            {
                textChange.text = "Black";
            }
            else if (midVal < 77)
            {
                textChange.text = "Mine Shaft";
            }
            else if (midVal < 128)
            {
                textChange.text = "Gray";
            }
            else if (midVal < 179)
            {
                textChange.text = "Silver";
            }
            else if (midVal < 230)
            {
                textChange.text = "Dragon's Tooth";
            }
            else if (midVal <= 255)
            {
                textChange.text = "White";
            }

        }
        //Check if cyan 00ffff
        else if ((Mathf.Abs(redVal - greenVal) >= 25 || Mathf.Abs(redVal - blueVal) >= 25) && Mathf.Abs(greenVal - blueVal) < 25 && redVal < greenVal && redVal < blueVal)
        {
            //Find the middle of the 2 values
            int midVal = 0;
            if (greenVal < blueVal)
            {
                midVal = (blueVal - greenVal) / 2 + greenVal;
            }
            else if (blueVal < greenVal)
            {
                midVal = (greenVal - blueVal) / 2 + blueVal;
            }
            else
            {
                midVal = greenVal;
            }

            //Determine color based on the middle and red value
            int compVal = redVal;
            if (midVal < 26)
            {
                if (redVal <= 26)
                {
                    textChange.text = "Black";
                }
            }
            else if (midVal < 77)
            {
                if (redVal <= 77)
                {
                    textChange.text = "Deep Teal";
                }

            }
            else if (midVal < 128)
            {
                if (redVal < 26)
                {
                    textChange.text = "Casal";
                }
                else if (redVal <= 128)
                {
                    textChange.text = "Teal";
                }
            }
            else if (midVal < 179)
            {
                if (redVal < 26)
                {
                    textChange.text = "Cyan Berry";
                }
                else if (redVal < 77)
                {
                    textChange.text = "Chill";
                }
                else if (redVal <= 179)
                {
                    textChange.text = "Patina";
                }
            }
            else if (midVal < 230)
            {
                if (redVal < 26)
                {
                    textChange.text = "Dragon’s Egg";
                }
                else if (redVal < 77)
                {
                    textChange.text = "Pelorous";
                }
                else if (redVal < 128)
                {
                    textChange.text = "Fountain";
                }
                else if (redVal <= 230)
                {
                    textChange.text = "Mist";
                }
            }
            else if (midVal <= 255)
            {
                if (redVal < 26)
                {
                    textChange.text = "Cyan";
                }
                else if (redVal < 77)
                {
                    textChange.text = "Turquoise";
                }
                else if (redVal < 128)
                {
                    textChange.text = "Aquamarine";
                }
                else if (redVal < 179)
                {
                    textChange.text = "Blizzard";
                }
                else if (redVal <= 255)
                {
                    textChange.text = "Sky Blue";
                }
            }
        }
        //Check if magenta ff00ff
        else if ((Mathf.Abs(greenVal - redVal) >= 25 || Mathf.Abs(greenVal - blueVal) >= 25) && Mathf.Abs(redVal - blueVal) < 25 && greenVal < redVal && greenVal < blueVal)
        {
            //Find the middle of the 2 values
            int midVal = 0;
            if (redVal < blueVal)
            {
                midVal = (blueVal - redVal) / 2 + redVal;
            }
            else if (blueVal < redVal)
            {
                midVal = (redVal - blueVal) / 2 + blueVal;
            }
            else
            {
                midVal = redVal;
            }

            //Determine color based on the middle and red value
            int compVal = greenVal;
            if (midVal < 26)
            {
                if (compVal <= 26)
                {
                    textChange.text = "Black";
                }
            }
            else if (midVal < 77)
            {
                if (compVal <= 77)
                {
                    textChange.text = "Wine";
                }

            }
            else if (midVal < 128)
            {
                if (compVal < 26)
                {
                    textChange.text = "Eggplant";
                }
                else if (compVal <= 128)
                {
                    textChange.text = "Cosmic";
                }
            }
            else if (midVal < 179)
            {
                if (compVal < 26)
                {
                    textChange.text = "Purple Berry";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Plum";
                }
                else if (compVal <= 179)
                {
                    textChange.text = "Strikemaster";
                }
            }
            else if (midVal < 230)
            {
                if (compVal < 26)
                {
                    textChange.text = "Dragon’s Horn";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Cerise";
                }
                else if (compVal < 128)
                {
                    textChange.text = "Fuchsia";
                }
                else if (compVal <= 230)
                {
                    textChange.text = "Lilac";
                }
            }
            else if (midVal <= 255)
            {
                if (compVal < 26)
                {
                    textChange.text = "Magenta";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Orchid";
                }
                else if (compVal < 128)
                {
                    textChange.text = "Flamingo";
                }
                else if (compVal < 179)
                {
                    textChange.text = "Lavender";
                }
                else if (compVal <= 255)
                {
                    textChange.text = "Lace";
                }
            }
        }
        //Check if yellow ffff00
        else if ((Mathf.Abs(blueVal - redVal) >= 25 || Mathf.Abs(blueVal - greenVal) >= 25) && Mathf.Abs(redVal - greenVal) < 25 && blueVal < redVal && blueVal < greenVal)
        {
            //Find the middle of the 2 values
            int midVal = 0;
            if (redVal < greenVal)
            {
                midVal = (greenVal - redVal) / 2 + redVal;
            }
            else if (greenVal < redVal)
            {
                midVal = (redVal - greenVal) / 2 + greenVal;
            }
            else
            {
                midVal = redVal;
            }

            //Determine color based on the middle and red value
            int compVal = blueVal;
            if (midVal < 26)
            {
                if (compVal <= 26)
                {
                    textChange.text = "Black";
                }
            }
            else if (midVal < 77)
            {
                if (compVal <= 77)
                {
                    textChange.text = "Woodrush";
                }

            }
            else if (midVal < 128)
            {
                if (compVal < 26)
                {
                    textChange.text = "Olive";
                }
                else if (compVal <= 128)
                {
                    textChange.text = "Fern Frond";
                }
            }
            else if (midVal < 179)
            {
                if (compVal < 26)
                {
                    textChange.text = "Yellow Berry";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Sycamore";
                }
                else if (compVal <= 179)
                {
                    textChange.text = "Avocado";
                }
            }
            else if (midVal < 230)
            {
                if (compVal < 26)
                {
                    textChange.text = "Dragon’s Eye";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Pear";
                }
                else if (compVal < 128)
                {
                    textChange.text = "Laser";
                }
                else if (compVal <= 230)
                {
                    textChange.text = "Glade";
                }
            }
            else if (midVal <= 255)
            {
                if (compVal < 26)
                {
                    textChange.text = "Yellow";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Golden";
                }
                else if (compVal < 128)
                {
                    textChange.text = "Lemon";
                }
                else if (compVal < 179)
                {
                    textChange.text = "Canary";
                }
                else if (compVal <= 255)
                {
                    textChange.text = "Cream";
                }
            }
        }
        //Check if blue 0000ff
        else if (Mathf.Abs(blueVal - redVal) >= 25 && Mathf.Abs(blueVal - greenVal) >= 25 && blueVal > redVal && blueVal > greenVal)
        {
            
            //Find the middle of the 2 values that are not main color
            int compVal = 0;
            if (redVal < greenVal)
            {
                compVal = (greenVal - redVal) / 2 + redVal;
            }
            else if (greenVal < redVal)
            {
                compVal = (redVal - greenVal) / 2 + greenVal;
            }
            else
            {
                compVal = redVal;
            }

            //Determine color based on the middle and red value
            int midVal = blueVal;
            if (midVal < 26)
            {
                if (compVal <= 26)
                {
                    textChange.text = "Black";
                }
            }
            else if (midVal < 77)
            {
                if (compVal <= 77)
                {
                    textChange.text = "Zodiac";
                }

            }
            else if (midVal < 128)
            {
                if (compVal < 26)
                {
                    textChange.text = "Navy";
                }
                else if (compVal <= 128)
                {
                    textChange.text = "Rhino";
                }
            }
            else if (midVal < 179)
            {
                if (compVal < 26)
                {
                    textChange.text = "Blue Berry";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Sapphire";
                }
                else if (compVal <= 179)
                {
                    textChange.text = "Butterfly";
                }
            }
            else if (midVal < 230)
            {
                if (compVal < 26)
                {
                    textChange.text = "Dragon’s Breath";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Indigo";
                }
                else if (compVal < 128)
                {
                    textChange.text = "Blue Marguerite";
                }
                else if (compVal <= 230)
                {
                    textChange.text = "Bluebell";
                }
            }
            else if (midVal <= 255)
            {
                if (compVal < 26)
                {
                    textChange.text = "Blue";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Blue Ribbon";
                }
                else if (compVal < 128)
                {
                    textChange.text = "Cornflower";
                }
                else if (compVal < 179)
                {
                    textChange.text = "Port";
                }
                else if (compVal <= 255)
                {
                    textChange.text = "Periwinkle";
                }
            }
        }
        //Check if green 00ff00
        else if (Mathf.Abs(greenVal - redVal) >= 25 && Mathf.Abs(greenVal - blueVal) >= 25 && greenVal > redVal && greenVal > blueVal)
        {
            //Find the middle of the 2 values that are not main color
            int compVal = 0;
            if (redVal < blueVal)
            {
                compVal = (blueVal - redVal) / 2 + redVal;
            }
            else if (blueVal < redVal)
            {
                compVal = (redVal - blueVal) / 2 + blueVal;
            }
            else
            {
                compVal = redVal;
            }

            //Determine color based on the middle and red value
            int midVal = greenVal;
            if (midVal < 26)
            {
                if (compVal <= 26)
                {
                    textChange.text = "Black";
                }
            }
            else if (midVal < 77)
            {
                if (compVal <= 77)
                {
                    textChange.text = "Deep Fir";
                }
            }
            else if (midVal < 128)
            {
                if (compVal < 26)
                {
                    textChange.text = "Jewel";
                }
                else if (compVal <= 128)
                {
                    textChange.text = "Pea";
                }
            }
            else if (midVal < 179)
            {
                if (compVal < 26)
                {
                    textChange.text = "Green Berry";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Forest";
                }
                else if (compVal <= 179)
                {
                    textChange.text = "Highland";
                }
            }
            else if (midVal < 230)
            {
                if (compVal < 26)
                {
                    textChange.text = "Dragon’s Scale";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Apple";
                }
                else if (compVal < 128)
                {
                    textChange.text = "Emerald";
                }
                else if (compVal < 230)
                {
                    textChange.text = "Dusty Green";
                }
            }
            else if (midVal <= 255)
            {
                if (compVal < 26)
                {
                    textChange.text = "Green";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Malachite";
                }
                else if (compVal < 128)
                {
                    textChange.text = "Lime";
                }
                else if (compVal < 179)
                {
                    textChange.text = "Mint";
                }
                else if (compVal <= 255)
                {
                    textChange.text = "Snowy Mint";
                }
            }
        }
        //Check if red ff0000
        else if (Mathf.Abs(redVal - greenVal) >= 25 && Mathf.Abs(redVal - blueVal) >= 25 && redVal > blueVal && redVal > greenVal)
        {
            //Find the middle of the 2 values that are not main color
            int compVal = 0;
            if (greenVal < blueVal)
            {
                compVal = (blueVal - greenVal) / 2 + greenVal;
            }
            else if (blueVal < greenVal)
            {
                compVal = (greenVal - blueVal) / 2 + blueVal;
            }
            else
            {
                compVal = greenVal;
            }

            //Determine color based on the middle and red value
            int midVal = redVal;
            if (midVal < 26)
            {
                if (compVal <= 26)
                {
                    textChange.text = "Black";
                }
            }
            else if (midVal < 77)
            {
                if (compVal <= 77)
                {
                    textChange.text = "Coffee";
                }

            }
            else if (midVal < 128)
            {
                if (compVal < 26)
                {
                    textChange.text = "Maroon";
                }
                else if (compVal <= 128)
                {
                    textChange.text = "Buccaneer";
                }
            }
            else if (midVal < 179)
            {
                if (compVal < 26)
                {
                    textChange.text = "Red Berry";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Burnt Umber";
                }
                else if (compVal <= 179)
                {
                    textChange.text = "Copper Rose";
                }
            }
            else if (midVal < 230)
            {
                if (compVal < 26)
                {
                    textChange.text = "Dragon’s Blood";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Cardinal";
                }
                else if (compVal < 128)
                {
                    textChange.text = "Chestnut Rose";
                }
                else if (compVal <= 230)
                {
                    textChange.text = "Clam";
                }
            }
            else if (midVal <= 255)
            {
                if (compVal < 26)
                {
                    textChange.text = "Red";
                }
                else if (compVal < 77)
                {
                    textChange.text = "Coral";
                }
                else if (compVal < 128)
                {
                    textChange.text = "Bittersweet";
                }
                else if (compVal < 179)
                {
                    textChange.text = "Tangerine";
                }
                else if (compVal <= 255)
                {
                    textChange.text = "Pink";
                }
            }
        }
        */
    }
}
