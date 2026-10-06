using UnityEngine;
using System.Collections;

public class GameUtils : MonoBehaviour
{
    private static GameUtils instance;

    public static GameUtils Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("GameUtils");
                instance = obj.AddComponent<GameUtils>();
                DontDestroyOnLoad(obj);
            }

            return instance;
        }
    }

    private void Awake()
    {
        // 如果你手动挂了 GameUtils，也能正常工作
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static void Delay(float delay, System.Action action)
    {
        Instance.StartCoroutine(DelayCoroutine(delay, action));
    }

    private static IEnumerator DelayCoroutine(
        float delay,
        System.Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}