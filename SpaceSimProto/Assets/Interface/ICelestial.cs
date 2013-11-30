using UnityEngine;
using System.Collections;

public interface ICelestial
{
	int GetCelestialID();
	void SetCelestialID(int id);
	void SetGravityWell(int size);
	void GenerateCelestial(ICelestial celestial);
	/* TODO
	 * Occupied Planets = landing on surface and opening options for trade, manufacturing, ship setup
	 * Occupied Stations = Docking and opening options for trade, manufacturing, ship setup
	 * Unoccupied Planets = Approach surface and opens options for scanning and mining
	 * Unoccupied Stations = Dock and opens options for searching and salvage
	 * GateWays = approach gate and opens options to move to new system
	 * Other Celestials = to be determined
	 */
	void ApproachCelestial();
}
