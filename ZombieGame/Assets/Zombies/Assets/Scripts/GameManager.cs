using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject selectedZombie;
    public GameObject[] zombies;
    public Vector3 selectedSize;
    private InputAction next, prev, jump;
    public Vector3 pushForce;
    public TMP_Text timerText;
    private float timer;
    private int selectedIndex;
    public TMP_Text coinText;
    private int coinCount = 0;
    public GameObject losePanel;
    public float fallHeight = -5f;
    private bool hasLost = false;
    void Start()
    {
        next = InputSystem.actions.FindAction("NextZombie");
        prev = InputSystem.actions.FindAction("PrevZombie");
        jump = InputSystem.actions.FindAction("Jump");
        SelectZombie(0);
    }

    // Update is called once per frame
    void SelectZombie(int index)
    {
        if (selectedZombie != null)
        {
            selectedZombie.transform.localScale = Vector3.one;
            
        }
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
        Debug.Log("selected:" + selectedZombie);
    }

    public void AddCoin()
    {
        coinCount++;
        coinText.text = "Coins: " + coinCount;
    }
    private void Update()
    {
        if (next.WasPressedThisFrame())
        {
            Debug.Log("next");
            selectedIndex++;
            if (selectedIndex >= zombies.Length)
                selectedIndex = 0;
            SelectZombie(selectedIndex);
        }
        if (prev.WasPressedThisFrame())
        {
            Debug.Log("prev");
            selectedIndex--;
            if (selectedIndex < 0)
                selectedIndex = zombies.Length -1;
            SelectZombie(selectedIndex);
        }
        if (jump.WasPressedThisFrame())
        {
            Debug.Log("jump");
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            if(rb != null)
                rb.AddForce(pushForce);

        }
        timer += Time.deltaTime;
        timerText.text = "Timer: " + timer.ToString("F1") + "s";
        for (int i = 0; i < zombies.Length; i++)
        {
            if (!hasLost && zombies[i].transform.position.y < fallHeight)
            {
                hasLost = true;
                LoseGame();
            }
        }
    }
    void LoseGame()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // unfreeze game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
