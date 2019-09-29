using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public static int numOfActiveQuests = 0;
    public float newQuestDelay;

    public static List<Quests> questsAvailable;
    private int maxNumberOfQuests;
    private float delayCount;

    // Start is called before the first frame update
    void Start() {
        questsAvailable = new List<Quests>();
        GetComponentsInChildren<Quests>(true, questsAvailable);
        maxNumberOfQuests = questsAvailable.Count;
        print("Quantidade de possíveis quests: " + maxNumberOfQuests);
    }

    void FixedUpdate() {
        delayCount += Time.deltaTime;
        if (delayCount >= newQuestDelay) {
            CreateNewQuest();
            delayCount = 0.0f;
        }
    }

    public void CreateNewQuest() {
        if (questsAvailable.Count <= 0) // Nao ha mais missoes para serem distribuidas
            return;

        //print("Ativando uma nova quest!");
        Quests quest = questsAvailable[RandNum()];
        quest.enabled = true;
        questsAvailable.Remove(quest);
    }

    private int RandNum() {
        return Random.Range(0, questsAvailable.Count);
    }
}