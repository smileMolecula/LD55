using System;
using UnityEngine;

public class FieldOfView : MonoBehaviour {

    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    [Range(0,360)]
    [SerializeField] private float angleView;
    [SerializeField] private float viewDistance;
    [SerializeField] private LayerMask targetMask;
    private Vector3 origin;
    private float startingAngle;
    private Vector3 dirToTarget;
    private Vector3 direction;
    public Action seePlayer;
    private void Start() {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        // fov = 90f;
        // viewDistance = 50f;
        // origin = Vector3.zero;
    }
    // private void FindVisibleTargets()
	// {
	// 	// this.target = null;
	// 	Collider2D[] array = Physics2D.OverlapCircleAll(origin, viewDistance, targetMask);

	// 	for (int i = 0; i < array.Length; i++)
	// 	{
	// 		dirToTarget = (array[i].transform.position - origin).normalized;
    //         Debug.DrawLine(origin, dirToTarget);
	// 		if (Vector3.Angle(direction, dirToTarget) < angleView / 2f + 5f)
	// 		{
	// 			seePlayer?.Invoke();
	// 		}
	// 	}
	// }
    private void LateUpdate() {
        // FindVisibleTargets();
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = angleView / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++) {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null) {
                // No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            } else {
                // Hit object
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0) {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);
    }
    public static Vector3 GetVectorFromAngle(float angle) {
            float angleRad = angle * (Mathf.PI/180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }
    public void SetOrigin(Vector3 origin) {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection) {
        direction = aimDirection;
        startingAngle = GetAngleFromVectorFloat(aimDirection) + angleView / 2f;
    }
    public static float GetAngleFromVectorFloat(Vector3 dir) {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;

            return n;
        }
    public void SetFoV(float fov) {
        this.angleView = fov;
    }

    public void SetViewDistance(float viewDistance) {
        this.viewDistance = viewDistance;
    }

}
