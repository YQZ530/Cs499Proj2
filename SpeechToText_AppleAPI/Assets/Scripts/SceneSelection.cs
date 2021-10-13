using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSelection : MonoBehaviour
{
  
        public GUIStyle BedroomStyle;
        public GUIStyle galleryStyle;
        

        public int Width;
        public int Height;
        public int wunit;
        public int hunit;

        public Texture2D bed;
        public Texture2D gallery;
       

        public Font Starker;
        Rect bedRect;
        Rect galleryRect;
     


        void Awake()
        {
            Width = Screen.width;
            Height = Screen.height;
            wunit = Width / 3;
            hunit = Height / 3;
        

            bedRect = new Rect(30, 150, 600, 360);
            galleryRect = new Rect(30 + wunit, 150, 600, 360);
           
        
            BedroomStyle = new GUIStyle();
            BedroomStyle.font = Starker;
            BedroomStyle.fontSize = 80;
            BedroomStyle.alignment = TextAnchor.MiddleCenter;
            BedroomStyle.normal.textColor = Color.black;
            BedroomStyle.normal.background = bed;
            BedroomStyle.fixedWidth = 600;
            BedroomStyle.fixedHeight = 360;
            BedroomStyle.contentOffset = new Vector2(0, 152f);

            galleryStyle = new GUIStyle();
            galleryStyle.font = Starker;
            galleryStyle.fontSize = 80;
            galleryStyle.alignment = TextAnchor.MiddleCenter;
            galleryStyle.normal.textColor = Color.black;
            galleryStyle.normal.background = gallery;
            galleryStyle.fixedWidth = 600;
            galleryStyle.fixedHeight = 360;
            galleryStyle.contentOffset = new Vector2(0, 152f);

          

        }
        void OnGUI()
        {

         
            if (GUI.Button(bedRect, "Scene1", BedroomStyle))
            {
           // Debug.Log("scene1");
                SceneManager.LoadScene("ExtraCredit2", LoadSceneMode.Single);
            }

            else if (GUI.Button(galleryRect, "Scene2", galleryStyle))
            {
            //Debug.Log("scene2");
                 SceneManager.LoadScene("ExtraCredit3", LoadSceneMode.Single);
            }

          
            //else if (GUI.Button(Exit, "Exit", ExitStyle))
            //{
            //    Application.Quit();
            //}


        }
    }

