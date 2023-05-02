using System;
using System.IO;
using UnityEngine;

/// <summary>
/// Receives hits from the collisions and writes to a file. The file is then used by a 
/// Python script to pass the hits to an Influx database.
/// </summary>
public static class WriteReadTrackingHits
{
    /// <summary>
    /// Called when there is a collision in the tracking simulation.
    /// </summary>
    public static void WriteHitsToFile(string hit)
    {
		DateTime date = DateTime.Today;  // Create new files once every day
		string file = Application.persistentDataPath + $"/{date}_hits.txt";
        bool append = true;
        StreamWriter writer = new StreamWriter(file, append);
        writer.WriteLine(hit);
        writer.Close();
    }

    /// <summary>
    /// Read the data from a file
    /// </summary>
    public static void ReadFromFile()
    {
		string file = Application.persistentDataPath + "/dataFile.txt";
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            Debug.Log(line);
        }
    }
}
