using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class DistanceToPlayer: MonoBehaviour
	{
		[SerializeField] private GameObject playerObj;
		private Transform player;

		public float distance {  get; private set; }
		public Vector3 direction { get; private set; }
		private void Awake() 
		{
		playerObj = GameObject.FindGameObjectWithTag("Player");
		player = playerObj.transform;
		}
		private void Start()
		{
			distance = Mathf.Infinity;
		}
		private void Update()
	{
		if (!playerObj.IsUnityNull())
		{
			direction = (player.position - transform.position).normalized;
			distance = Vector3.Distance(transform.position, player.position);
			
		}
	}
	
	}
