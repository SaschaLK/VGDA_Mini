using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobManager : MonoBehaviour {

    public static MobManager instance;

    public Transform playerPos;
    public GameObject[] mobs;
    private List<GameObject> mobList = new List<GameObject>();
    public int mobCount;
    public float spawnDelay;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        LoadMobs();
        StartCoroutine(SpawnMob());
    }

    private void LoadMobs() {
        for (int i = 0; i < mobCount; i++) {
            mobList.Add(GameObject.Instantiate(mobs[0]));
            mobList[i].SetActive(false);
        }
    }

    public static Transform GetPlayerPosition() {
        return instance.playerPos;
    }

    private IEnumerator SpawnMob() {
        if(this.transform != null) {
            foreach (GameObject mob in mobList) {
                if (!mob.activeSelf) {
                    mob.transform.position = this.transform.position;
                    mob.SetActive(true);
                    yield return new WaitForSecondsRealtime(spawnDelay);
                }
            }
        }
        else {
            StopAllCoroutines();
        }
    }
}
