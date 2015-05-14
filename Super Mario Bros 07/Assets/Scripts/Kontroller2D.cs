using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Kontroller2D : MonoBehaviour {

	public static LayerMask kollisjonMaske; 

	const float skinBredde = .015f;
	public int horizontalRayTeller = 4;
	public int verticalRayTeller = 4;

	float horizontalRayPlass;
	float verticalRayPlass;

	BoxCollider2D kollisjon;
	RaycastOrigins raycastOrigins; 
	public KollisjonInfo kollisjoner;

    public static Kontroller2D instance;


	void Start () {
        kollisjonMaske.value = 512;
        Debug.Log(kollisjonMaske);
		kollisjon = GetComponent<BoxCollider2D> ();
		KalkulereRayPlass ();
	}

    void Update()
    {
        if (EnemyAI.playerDead)
        {
            gameObject.layer = 0;
        }
    }

	public void Move(Vector3 hastighet) {
		UpdateRaycastOrigins ();
		kollisjoner.Reset (); 

		if (hastighet.x != 0) {
			HorizontalKollisjoner (ref hastighet); 
		}
		if (hastighet.y != 0) {
			VerticalKollisjoner (ref hastighet);
		}
		transform.Translate (hastighet);
     
	}
	void HorizontalKollisjoner(ref Vector3 hastighet) {
		float retningX = Mathf.Sign (hastighet.x);
		float rayLengde = Mathf.Abs (hastighet.x) + skinBredde; 
		
		for (int i = 0; i < horizontalRayTeller; i++) {
			Vector2 rayOrigin = (retningX == -1)?raycastOrigins.bottomLeft:raycastOrigins.bottomRight;
			rayOrigin += Vector2.up * (horizontalRayPlass * i);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * retningX, rayLengde, kollisjonMaske);

			Debug.DrawRay(rayOrigin, Vector2.right * retningX * rayLengde, Color.red);

			if (hit){

				hastighet.x = (hit.distance - skinBredde) * retningX; 
				rayLengde = hit.distance; 

				kollisjoner.venstre = retningX == -1; 
				kollisjoner.høyre = retningX == 1; 
			}
		}

	}

	void VerticalKollisjoner(ref Vector3 hastighet) {
		float retningY = Mathf.Sign (hastighet.y);
		float rayLengde = Mathf.Abs (hastighet.y) + skinBredde;

        for (int i = 0; i < verticalRayTeller; i++)
        {
            Vector2 rayOrigin = (retningY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRayPlass * i + hastighet.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * retningY, rayLengde, kollisjonMaske);

            Debug.DrawRay(rayOrigin, Vector2.up * retningY * rayLengde, Color.red);

            if (hit)
            {
                hastighet.y = (hit.distance - skinBredde) * retningY;
                rayLengde = hit.distance;

                kollisjoner.under = retningY == -1;
                kollisjoner.over = retningY == 1;
            }

        }
	}


	void UpdateRaycastOrigins() {
		Bounds bounds = kollisjon.bounds; 
		bounds.Expand (skinBredde * -2); 

		raycastOrigins.bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2 (bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2 (bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2 (bounds.max.x, bounds.max.y);
	}

	void KalkulereRayPlass() {
		Bounds bounds = kollisjon.bounds; 
		bounds.Expand (skinBredde * -2);

		horizontalRayTeller = Mathf.Clamp (horizontalRayTeller, 2, int.MaxValue);
		verticalRayTeller = Mathf.Clamp (verticalRayTeller, 2, int.MaxValue);

		horizontalRayPlass = bounds.size.y / (horizontalRayTeller - 1); 
		verticalRayPlass = bounds.size.x / (verticalRayTeller - 1); 
	}

	struct RaycastOrigins {
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight; 
	}
	public struct KollisjonInfo {
		public bool over, under;
		public bool venstre, høyre;

		public void Reset () {
			over = under = false;
			venstre = høyre = false;
		}
	}
}
