using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IUniverse
{
	int GetUniverseID();
	void SetUniverse(int id);
	List<ISolarSystem> getSystems();
	void LoadSystem(int SystemId);
	void GenerateUniverse();
}

