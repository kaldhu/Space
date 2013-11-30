using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Universe : MonoBehaviour ,IUniverse{

	private int m_UniverseId;
	private List<ISolarSystem> m_Systems;
	public GameObject g_SolarSystem;

	public int GetUniverseID()
	{
		return m_UniverseId;
	}

	public void SetUniverse(int id)
	{
		m_UniverseId = id;
	}

	public List<ISolarSystem> getSystems()
	{
		return m_Systems;
	}

	public void LoadSystem(int SystemId)
	{
		GameObject newSystem;

		//newSystem = Instantiate(g_SolarSystem, transform.position, transform.rotation) as GameObject;

		//newSystem.GetComponent<ISolarSystem>().GenerateSystem(m_Systems[SystemId]);
	}

	public void GenerateUniverse()
	{
		//TODO randomly generate the universe for each play through.
		//ISolarSystem system = new ISolarSystem();

	}
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start () {
	
	}

	void Update () {
	
	}
}
