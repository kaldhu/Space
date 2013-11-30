using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SolarSystem : MonoBehaviour, ISolarSystem {

	private int m_SystemID;
	private List<ICelestial> m_CelestialList;
	private List<int> m_Pathways;
	public CircleCollider2D g_Planet_1;	
	public CircleCollider2D g_Planet_2;	

	//TODO add a public constructor from instance that uses the private SolarSystem

	public int GetSystemID()
	{
		return m_SystemID;
	}

	public void SetSystemID(int id)
	{
		m_SystemID = id;
	}

	public List<ICelestial> getCelestials()
	{
		return m_CelestialList;
	}
	
	public void GenerateSystem(ISolarSystem system)
	{
		m_CelestialList.AddRange( system.getCelestials());
		m_Pathways.AddRange( system.GetPathWays());
	}

	public void LoadCelestial(int celestialId, float x, float y, float z)
	{
		GameObject newCelestial;
		switch(celestialId)
		{
			case 0:
				Instantiate(g_Planet_1, new Vector3(x,y,z), Quaternion.identity);
			//newCelestial.GetComponent<ICelestial>().GenerateCelestial(m_CelestialList[celestialId]);
				break;
			case 1:
				//newCelestial= Instantiate(g_Planet_2, new Vector3(x,y,z), Quaternion.identity);
			//newCelestial.GetComponent<ICelestial>().GenerateCelestial(m_CelestialList[celestialId]);
				break;
			default:
				break;
		}
	}
	
	public int[] GetPathWays()
	{
		return m_Pathways.ToArray();

	}

	public void CreatePathWay(int id)
	{
		if(!m_Pathways.Contains(id))
			m_Pathways.Add(id);
	}

	public void RemovePathWay(int id)
	{
		if(!m_Pathways.Contains(id))
			m_Pathways.Add(id);
	}

	void Awake() 
	{
		DontDestroyOnLoad(transform.gameObject);
		m_CelestialList = new List<ICelestial>();
		m_Pathways = new List<int>();
		
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
