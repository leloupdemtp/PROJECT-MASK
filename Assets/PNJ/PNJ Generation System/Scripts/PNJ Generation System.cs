using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PNJGenerationSystem : MonoBehaviour
{
    [Header("PNJ Normaux")]
    [SerializeField] private GameObject normalPNJPrefab;
    [SerializeField] private int numberOfPNJ;
    [SerializeField] private List<Vector2> spawnPositions = new List<Vector2>();

    [Header("PNJ Tueur")]
    [SerializeField] private GameObject killerPrefab;

    // Variables globales pour le tueur unique
    private static bool killerSpawned = false; // pour éviter de spawn plusieurs tueurs
    private static int totalPNJCount = 0;      // total de PNJ sur tous les générateurs
    private static int killerGlobalIndex = -1; // index du PNJ tueur parmi tous les PNJ
    private static int runningIndex = 0;       // compteur global de PNJ générés

    private void Start()
    {
        // Si le tueur n'est pas encore choisi, on le choisit parmi tous les PNJ
        if (!killerSpawned)
        {
            // compter le nombre total de PNJ de tous les générateurs
            PNJGenerationSystem[] spawners = FindObjectsOfType<PNJGenerationSystem>();
            totalPNJCount = 0;
            foreach (var spawner in spawners)
                totalPNJCount += spawner.numberOfPNJ;

            killerGlobalIndex = Random.Range(0, totalPNJCount);
        }

        GeneratePNJ();
    }

    public void GeneratePNJ()
    {
        if (numberOfPNJ <= 0 || spawnPositions.Count == 0) return;

        // Récupérer l'instance de RandomDialogueAssigner
        RandomDialogueAssigner dialogueManager = RandomDialogueAssigner.Instance;
        if (dialogueManager == null)
        {
            dialogueManager = FindObjectOfType<RandomDialogueAssigner>();
            if (dialogueManager != null)
                RandomDialogueAssigner.Instance = dialogueManager;
            else
                Debug.LogError("Pas de RandomDialogueAssigner trouvé sur la scène !");
        }

        for (int i = 0; i < numberOfPNJ; i++)
        {
            int r = Random.Range(0, spawnPositions.Count);

            GameObject prefabToSpawn = normalPNJPrefab;

            // Si c'est le PNJ choisi comme tueur
            if (!killerSpawned && runningIndex == killerGlobalIndex)
            {
                prefabToSpawn = killerPrefab;
                killerSpawned = true;
            }

            GameObject s = Instantiate(prefabToSpawn, spawnPositions[r], Quaternion.identity, transform);
            spawnPositions.RemoveAt(r); // pour éviter de spawn deux PNJ au même endroit

            // Masque aléatoire pour tous les PNJ
            MaskGeneration maskGen = s.GetComponentInChildren<MaskGeneration>();
            if (maskGen != null)
                maskGen.GenerateRandom();

            // Assignation du dialogue
            OpenDialogue dialogue = s.GetComponentInChildren<OpenDialogue>();
            if (dialogue != null && dialogueManager != null)
            {
                string assignedDialogue = dialogueManager.AssignDialogueToPNJ();
                dialogue.SetDialogue(assignedDialogue);
            }

            runningIndex++; // incrément du compteur global
        }
    }
}
