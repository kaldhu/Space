using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour, ICelestial
{
	public int m_PlanetID=0;	

	public int GetCelestialID()
	{
		return m_PlanetID;
	}

	public void SetCelestialID(int id)
	{
		m_PlanetID = id;
	}

	public void SetGravityWell(int size)
	{		
		transform.Find("GravityWell").GetComponent<CircleCollider2D>().radius = size;
	}

	public void GenerateCelestial(ICelestial celestial)
	{

	}

	public void ApproachCelestial()
	{

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
