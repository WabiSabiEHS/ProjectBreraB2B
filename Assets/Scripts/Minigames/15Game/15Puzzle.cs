using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle15 : MonoBehaviour, IPointerDownHandler
{
	public int ID;

	private void Awake()
	{
		GetComponent<BoxCollider2D> ().enabled = true;
	}

	void ReplaceBlocks(int x, int y, int XX, int YY)
	{
		Game15Controller.grid[x,y].transform.position = Game15Controller.position[XX,YY];
		Game15Controller.grid[XX,YY] = Game15Controller.grid[x,y];
		Game15Controller.grid[x,y] = null;
		Game15Controller.GameFinish();
	}

    public void OnPointerDown(PointerEventData eventData)
    {
		for(int y = 0; y < 4; y++)
		{
			for(int x = 0; x < 4; x++)
			{
				if(Game15Controller.grid[x,y])
				{
					if(Game15Controller.grid[x,y].GetComponent<Puzzle15>().ID == ID)
					{
						if(x > 0 && Game15Controller.grid[x-1,y] == null)
						{
							ReplaceBlocks(x,y,x-1,y);
							return;
						}

						else if(x < 3 && Game15Controller.grid[x+1,y] == null)
						{
							ReplaceBlocks(x,y,x+1,y);
							return;
						}
					}
				}

				if(Game15Controller.grid[x,y])
				{
					if(Game15Controller.grid[x,y].GetComponent<Puzzle15>().ID == ID)
					{
						if(y > 0 && Game15Controller.grid[x,y-1] == null)
						{
							ReplaceBlocks(x,y,x,y-1);
							return;
						}

						else if(y < 3 && Game15Controller.grid[x,y+1] == null)
						{
							ReplaceBlocks(x,y,x,y+1);
							return;
						}
					}
				}
			}
		}
    }
}
