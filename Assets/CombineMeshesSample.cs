using UnityEngine;

public class CombineMeshesSample : MonoBehaviour {

	void Start () {
		MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
		MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
		if (CheckSameMaterial (meshRenderers) == true) {
			CombineInstance[] combine = new CombineInstance[meshFilters.Length];
			int i = 0;
			while (i < meshFilters.Length) {
				combine[i].mesh = meshFilters [i].sharedMesh;
				combine[i].transform = meshFilters [i].transform.localToWorldMatrix;
				meshFilters[i].gameObject.SetActive (false);
				i++;
			}
			MeshFilter meshfilter 
				= gameObject.AddComponent<MeshFilter> () as MeshFilter;
			MeshRenderer meshrenderer 
				= gameObject.AddComponent<MeshRenderer> () as MeshRenderer;
			meshrenderer.sharedMaterial = meshRenderers [0].sharedMaterial;
			meshfilter.mesh = new Mesh ();
			meshfilter.mesh.CombineMeshes (combine);
			transform.gameObject.SetActive (true);	
		}
	}

	bool CheckSameMaterial(MeshRenderer[] meshRenderers) {
		Material mtrl = meshRenderers[0].sharedMaterial;
		int i = 0;
		for( i=1; i<meshRenderers.Length; i++) {
			if (mtrl != meshRenderers [i].sharedMaterial)
				return false;
		}
		return true;
	}
}
