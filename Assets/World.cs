using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    private GameObject[,] tablero;
    int largoFila = 3;

    // Start is called before the first frame update
    void Start()
    {
        int distZ = 10;
        tablero = new GameObject[largoFila, largoFila];

        for ( int i = 0; i < largoFila; i++)
        {

            for (int j = 0; j < largoFila; j++)
            {
                tablero[i, j] = GameObject.CreatePrimitive(PrimitiveType.Quad);
                tablero[i, j].transform.position = new Vector3(((largoFila * i)- largoFila), largoFila - j*largoFila, distZ);
                tablero[i, j].tag = "W";
                tablero[i, j].transform.localScale *= 2;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        bool wP1 = false;
        bool wP2 = false;

        int cP1 = 0;
        int cP2 = 0;
        //check diagonal i-d
        for (int i = 0; i < largoFila; i++)
        {
  

     

                if (tablero[i, i].tag == "X")
                {
                    cP1++;
                }
                else if (tablero[i, i].tag == "O")
                {
                    cP2++;
                }

            

            if (cP1 == 3 && cP2 != 3)
            {
                wP1 = true;

            }
            else if (cP2 == 3 && cP1 != 3)
            {
                wP2 = true;

            }
            else if (cP2 == 3 && cP1 == 3)
            {
                wP1 = false;
                wP2 = false;

            }



        }

        //check diagonal d-i

        cP1 = 0;
        cP2 = 0;
        for (int i = 0; i < largoFila; i++)
        {
          

            for (int j = 0; j < largoFila; j++)
            {
                if ((i + j) % largoFila == 2)
                {

                    if (tablero[i, j].tag == "X")
                    {
                        cP1++;
                    }
                    else if (tablero[i, j].tag == "O")
                    {
                        cP2++;
                    }
                }
            }

            if (cP1 == 3 && cP2 != 3)
            {
                wP1 = true;

            }
            else if (cP2 == 3 && cP1 != 3)
            {
                wP2 = true;

            }
            else if (cP2 == 3 && cP1 == 3)
            {
                wP1 = false;
                wP2 = false;

            }



        }

        //check columnas
        for (int i = 0; i < largoFila; i++)
        {
             cP1 = 0;
             cP2 = 0;

            for (int j = 0; j < largoFila; j++){

                if (tablero[i, j].tag == "X")
                {
                    cP1++;
                }
                else if (tablero[i, j].tag == "O")
                {
                    cP2++;
                }

            }

            if (cP1 == 3 && cP2 != 3)
            {
                wP1 = true;
               
            }
            else if(cP2 == 3 && cP1 != 3)
            {
                wP2 = true;

            }
            else if (cP2 == 3 && cP1 == 3)
            {
                wP1 = false;
                wP2 = false;

            }



        }


        //check filas
        for (int i = 0; i < largoFila; i++)
        {
             cP1 = 0;
             cP2 = 0;

            for (int j = 0; j < largoFila; j++)
            {

                if (tablero[j,i].tag == "X")
                {
                    cP1++;
                }
                else if (tablero[j, i].tag == "O")
                {
                    cP2++;
                }

            }

            if (cP1 == 3 && cP2 != 3)
            {
                wP1 = true;

            }
            else if (cP2 == 3 && cP1 != 3)
            {
                wP2 = true;

            }
            else if (cP2 == 3 && cP1 == 3)
            {
                wP1 = false;
                wP2 = false;

            }



        }

        if (wP1)
        {
            Debug.Log("P1 ganó!");
            Application.LoadLevel(Application.loadedLevel);

        }
        else if (wP2)
        {
            Debug.Log("P2 ganó!");
            Application.LoadLevel(Application.loadedLevel);


        }
        else
        {
            Debug.Log("Nadie ganó!");

        }


    }

   
}
