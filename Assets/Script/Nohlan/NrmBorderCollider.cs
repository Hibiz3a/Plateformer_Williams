using System.Collections.Generic;
using UnityEngine;

public class NrmBorderCollider : MonoBehaviour {

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        PolygonCollider2D polygonCollider = gameObject.AddComponent<PolygonCollider2D>();

        // Récupère le nombre de formes physiques du sprite
        int shapeCount = spriteRenderer.sprite.GetPhysicsShapeCount();
        polygonCollider.pathCount = shapeCount;

        for (int i = 0; i < shapeCount; i++)
        {
            List<Vector2> path = new List<Vector2>();  // Créer une nouvelle liste pour chaque forme
            spriteRenderer.sprite.GetPhysicsShape(i, path);
            polygonCollider.SetPath(i, path.ToArray());
        }
    }


}
