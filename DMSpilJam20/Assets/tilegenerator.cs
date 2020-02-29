using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tilegenerator : MonoBehaviour
{
    public Tilemap MyTileMap;
    public RuleTile WallTile;

    //public (int x, int y) lastplacedTile;
    public int TotaltPlacedTiles = 0;
    // Start is called before the first frame update

    int iterations = 0;

    public (int x, int y, Dictions last) lastplacedTile;

    private void Start()
    {
        lastplacedTile = (0, 0, Dictions.None);
    }

    void FixedUpdate()
    {

        try
        {
            if (iterations < 200)
            {


                //for (int i = 0; i < 20; i++)
                //{

                //    for (int j = 0; j < 20; j++)
                //    {
                //        if(Random.Range(0f,1f) < 0.5)
                //        {


                //            MyTileMap.SetTile(new Vector3Int(i, j, 0), WallTile);
                //        }

                //    }

                //}


                (int placedx, int placedy, Dictions placedic) PlaceTitle(TileBase ToPlace, (int x, int y, Dictions Last) LastPlaced, Tilemap tilemap, Dictions diction)
                {


                    (int newX, int newY) Calc((int x, int y) cords)
                    {
                        int newX = cords.x;
                        int newY = cords.y;

                        switch (diction)
                        {

                            case Dictions.Up:

                                newY = cords.y + 1;
                                break;
                            case Dictions.Left:

                                newX = cords.x - 1;
                                break;
                            case Dictions.Right:

                                newX = cords.x + 1;
                                break;
                            case Dictions.Down:

                                newY = cords.y - 1;
                                break;

                            default:
                                break;
                        }
                        return (newX, newY);
                    }



                    (int newX, int newY) NewTilePlacement = Calc((LastPlaced.x, LastPlaced.y));

                    while (tilemap.HasTile(new Vector3Int(NewTilePlacement.newX, NewTilePlacement.newY, 0)))
                    {

                        Dictions newdiction = (Dictions)Random.Range(0, 4);

                        while (newdiction == diction)
                        {
                            newdiction = (Dictions)Random.Range(0, 4);
                            
                        }

                        diction = newdiction;

  NewTilePlacement = Calc(NewTilePlacement);
                    }

                    tilemap.SetTile(new Vector3Int(NewTilePlacement.newX, NewTilePlacement.newY, 0), ToPlace);

                    return (NewTilePlacement.newX, NewTilePlacement.newY, diction);
                }





                //for (int i = 0; i < 500; i++)
                //{
                Dictions next = (Dictions)Random.Range(0, 4);

                while (lastplacedTile.last == next)
                {
                    next = (Dictions)Random.Range(0, 4);
                    print(next);
                }


                for (int i = 0; i < Random.Range(2, 6); i++)
                {
                    lastplacedTile = PlaceTitle(WallTile, lastplacedTile, MyTileMap, next);
                }
                //}

                iterations++;
                print(iterations);
            }
        }
        catch (System.Exception ex)
        {

            throw ex;
        }

        
    }

    public enum Dictions
    {
        Up,
        Left,
        Right,
        Down,
        None,
    }

}
