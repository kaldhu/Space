using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ISolarSystem
{
	int GetSystemID();
	void SetSystemID(int id);
	List<ICelestial> getCelestials();
	void GenerateSystem(ISolarSystem system);
	void LoadCelestial(int celestialId,float x, float y, float z);
	
	int[] GetPathWays();
	void CreatePathWay(int id);
	void RemovePathWay(int id);
}

