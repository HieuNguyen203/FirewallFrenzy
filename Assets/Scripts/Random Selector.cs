using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelector : MonoBehaviour
{
    public FireBatch[] batches;
    private List<int> availableIndices = new List<int>(); // Stores available indices
    private float nextBatchTime;
    private float waitTime = 2f;

    void Start()
    {
        // Initialize availableIndices with all indices
        for (int i = 0; i < batches.Length; i++)
        {
            availableIndices.Add(i);
        }
        nextBatchTime = 0;
    }

    private void Update()
    {
        if (Time.time >= nextBatchTime) // Check if it's time for the next batch
        {
            int current = GetRandomIndex();
            if (current == -1) // Check if a valid batch index was obtained
            {
                RefillAvailableIndices();
                current = GetRandomIndex();
            }

            Instantiate(batches[current]);
            nextBatchTime = Time.time + batches[current].duration + waitTime; // Schedule the next batch
        }
    }

    public int GetRandomIndex()
    {
        if (availableIndices.Count == 0)
        {
            Debug.LogWarning("No more batches available to choose from!");
            return -1; // Or throw an exception if preferred
        }

        int randomIndex = availableIndices[UnityEngine.Random.Range(0, availableIndices.Count)];
        availableIndices.Remove(randomIndex);
        return randomIndex;
    }

    private void RefillAvailableIndices()
    {
        availableIndices.Clear(); // Clear the list of used indices
        for (int i = 0; i < batches.Length; i++)
        {
            availableIndices.Add(i); // Repopulate with all indices
        }
    }
}
