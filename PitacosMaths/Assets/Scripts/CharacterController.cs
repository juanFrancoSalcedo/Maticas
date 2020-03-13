using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    private SpriteRenderer renderSprite;
    public Sprite xSprite;
    private Sprite ySprite;
    [SerializeField] private GridManger grid;

    
    void Start()
    {
        renderSprite = GetComponent<SpriteRenderer>();
        ySprite = renderSprite.sprite;
        transform.position = new Vector3(grid.playerX,grid.playerY,transform.position.z);
    }

    private void Update()
    {

    }

    public IEnumerator Move()
    {
        while (transform.position != new Vector3(grid.targetX,grid.targetY,0))
        {
            if (grid.targetX != (int)transform.position.x)
            {
                int dif = (grid.targetX > (int)transform.position.x) ? 1 : -1;

                renderSprite.sprite = xSprite;
                renderSprite.flipX = (dif > 0) ? false : true;
                transform.Translate(dif, 0, 0);

            }
            else if (grid.targetY != (int)transform.position.y)
            {
                    int dif = (grid.targetY > (int)transform.position.y) ? 1 : -1;

                    renderSprite.sprite = ySprite;
                    renderSprite.flipY = (dif > 0) ? true : false;
                    transform.Translate(0, dif, 0);


            }

            yield return new WaitForSeconds(0.3f);
        }
    }


}
