using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

    public static int numOfActiveQuests = 0;
    public float newQuestDelay;

    public Text uiTextReference;
    public static List<string> activeQuestsDescription;

    public static List<Quests> questsAvailable;
    private int maxNumberOfQuests;
    private float delayCount;


    private void Awake() {
        activeQuestsDescription = new List<string>();
        questsAvailable = new List<Quests>();
    }
    // Start is called before the first frame update
    void Start() {
        GetComponentsInChildren<Quests>(true, questsAvailable);
        maxNumberOfQuests = questsAvailable.Count;
        print("Quantidade de possíveis quests: " + maxNumberOfQuests);
    }

    void FixedUpdate() {
        if (questsAvailable.Count <= 0) // Nao ha mais missoes para serem distribuidas
            return;

        delayCount += Time.deltaTime;
        if (delayCount >= newQuestDelay) {
            CreateNewQuest();
            delayCount = 0.0f;
        }
        DisplayCurrentQuests();
    }

    public void CreateNewQuest() {
        //print("Ativando uma nova quest!");
        Quests quest = questsAvailable[RandNum()];
        quest.enabled = true;
        questsAvailable.Remove(quest);
    }

    private int RandNum() {
        return Random.Range(0, questsAvailable.Count);
    }

    public void DisplayCurrentQuests() {
        string txt = "Você precisa realizar as seguintes tarefas:\n";
        foreach (string s in activeQuestsDescription)
            txt += s + "\n";
        uiTextReference.text = txt;
    }
}