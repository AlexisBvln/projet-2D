using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




	 * START
	 *****************************************************************************/



        // Affiche les Objets du niveau
        chargeLevel();


	 * UPDATE
	 *****************************************************************************/


	 * AUTRES FONCTIONS
	 *****************************************************************************/




	 * COORDONNEES LEVEL
	 *****************************************************************************/
<<<<<<< HEAD
	void chargeLevel(){
		switch (Global.levelActive) {
		case 1:
			Instantiate (piecePrefab.transform, new Vector3((float)-270,(float)-157, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)-1, (float)-141, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)293, (float)-203, 0), Quaternion.identity);
			Instantiate (poubellePrefab.transform, new Vector3((float)400, (float)-240.6, 0), Quaternion.Euler(new Vector3(0,0,80)));
			Instantiate (canonPrefab.transform, new Vector3((float)-500, (float)-238, 0), Quaternion.identity);
			Global.canonAngleMin = -10;
			Global.canonAngleMax = 90;
			break;
		case 2:
			Instantiate (piecePrefab.transform, new Vector3((float)-270,(float)95, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)-1, (float)200, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)293, (float)-23, 0), Quaternion.identity);
			Instantiate (poubellePrefab.transform, new Vector3((float)400, (float)-236.6, 0), Quaternion.identity);
			Instantiate (canonPrefab.transform, new Vector3((float)-500, (float)-238, 0), Quaternion.identity);
			Global.canonAngleMin = -10;
			Global.canonAngleMax = 90;
			break;
		case 3:
			Instantiate (piecePrefab.transform, new Vector3((float)-189,(float)47, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)94, (float)-212, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)314, (float)-114, 0), Quaternion.identity);
			Instantiate (poubellePrefab.transform, new Vector3((float)400, (float)-236.6, 0), Quaternion.identity);
			Instantiate (canonPrefab.transform, new Vector3((float)-460, (float)-238, 0), Quaternion.identity);
			Global.canonAngleMin = -10;
			Global.canonAngleMax = 90;
			break;
		case 4:
			Instantiate (piecePrefab.transform, new Vector3((float)-327,(float)47, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)-1, (float)200, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)314, (float)-51, 0), Quaternion.identity);
			Instantiate (grueOnPrefab.transform, new Vector3((float)-101, (float)-120.4, 0), Quaternion.identity);
			Instantiate (grueOnPrefab.transform, new Vector3((float)12.9,(float)41.3, 0), Quaternion.Euler(new Vector3(0,0,90)));
			Instantiate (grueOnPrefab.transform, new Vector3((float)126.9,(float)-120.4, 0), Quaternion.identity);
			Instantiate (poubellePrefab.transform, new Vector3((float)400, (float)-236.6, 0), Quaternion.identity);
			Instantiate (canonPrefab.transform, new Vector3((float)-500, (float)-238, 0), Quaternion.identity);
			Global.canonAngleMin = -10;
			Global.canonAngleMax = 90;
			break;
		case 5:
			Instantiate (piecePrefab.transform, new Vector3((float)450,(float)-5, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)120, (float)1, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)40, (float)-135, 0), Quaternion.identity);
			Instantiate (grueOnPrefab.transform, new Vector3((float)431,(float)-69, 0), Quaternion.Euler(new Vector3(0,0,-53)));
			Instantiate (canonPrefab.transform, new Vector3((float)-460, (float)-238, 0), Quaternion.identity);
			Instantiate (poubellePrefab.transform, new Vector3((float)20, (float)-236.5, 0), Quaternion.identity);
			Global.canonAngleMin = -10;
			Global.canonAngleMax = 90;
			break;
		case 6:
			Instantiate (piecePrefab.transform, new Vector3((float)-211,(float)167, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)0, (float)0, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)243, (float)-81, 0), Quaternion.identity);
			Instantiate (grueOnPrefab.transform, new Vector3((float)-101, (float)-120.4, 0), Quaternion.identity);
			Instantiate (grueOnPrefab.transform, new Vector3((float)13,(float)-100, 0), Quaternion.Euler(new Vector3(0,0,90)));
			Instantiate (grueOnPrefab.transform, new Vector3((float)126.9,(float)-120.4, 0), Quaternion.identity);;
			Instantiate (canonPrefab.transform, new Vector3((float)-460, (float)-238, 0), Quaternion.identity);
			Instantiate (poubellePrefab.transform, new Vector3((float)271, (float)-236.5, 0), Quaternion.identity);
			Global.canonAngleMin = -10;
			Global.canonAngleMax = 90;
			break;
		case 7:
			Instantiate (piecePrefab.transform, new Vector3((float)-37,(float)24, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)60, (float)-193, 0), Quaternion.identity);
			Instantiate (piecePrefab.transform, new Vector3((float)243, (float)-81, 0), Quaternion.identity);
			Instantiate (grueOnPrefab.transform, new Vector3((float)-227, (float)-119, 0), Quaternion.identity);
			Instantiate (grue2OnPrefab.transform, new Vector3((float)-132.7,(float)-5.5, 0), Quaternion.Euler(new Vector3(0,0,90)));
			Instantiate (grue2OnPrefab.transform, new Vector3((float)174,(float)-188, 0), Quaternion.identity);
			Instantiate (canonPrefab.transform, new Vector3((float)-500, (float)-236.6, 0), Quaternion.identity);
			Instantiate (poubellePrefab.transform, new Vector3((float)271, (float)-237, 0), Quaternion.identity);
			Global.canonAngleMin = -10;
			Global.canonAngleMax = 90;
			break;
        case 8:
            Instantiate(piecePrefab.transform, new Vector3((float)500, (float)24, 0), Quaternion.identity);
            Instantiate(piecePrefab.transform, new Vector3((float)60, (float)-193, 0), Quaternion.identity);
            Instantiate(piecePrefab.transform, new Vector3((float)243, (float)-81, 0), Quaternion.identity);
            Instantiate(grueOnPrefab.transform, new Vector3((float)-227, (float)-119, 0), Quaternion.identity);
            Instantiate(grue2OnPrefab.transform, new Vector3((float)-132.7, (float)-5.5, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
            Instantiate(grue2OnPrefab.transform, new Vector3((float)174, (float)-188, 0), Quaternion.identity);
            Instantiate(canonPrefab.transform, new Vector3((float)-500, (float)-236.6, 0), Quaternion.identity);
            Instantiate(poubellePrefab.transform, new Vector3((float)271, (float)-237, 0), Quaternion.identity);
            Global.canonAngleMin = -10;
            Global.canonAngleMax = 90;
            break;
        default:
			break;
		}
	}
=======
>>>>>>> 6dc7d2ed54b0cbbd401807f0513c6f0f19c26416

}
