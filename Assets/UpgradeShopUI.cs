using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShopUI : MonoBehaviour
{
    public static UpgradeShopUI Instance;
    public Button BuyChickenPen;
    public Button BuyCowPen;
    public Button BuyCowMale;
    public Button BuyCowFemale;
    public Button BuyChickenMale;
    public Button BuyChickenFemale;
    public Button SellCowMale;
    public Button SellCowFemale;
    public Button SellChickenMale;
    public Button SellChickenFemale;
    public Image DisableBuyCowPen;
    public Image DisableBuyChickenPen;
    public Image DisableSellCowMale;
    public Image DisableSellCowFemale;
    public Image DisableSellChickenMale;
    public Image DisableSellChickenFemale;
    public Image DisableBuyCow;
    public Image DisableBuyChicken;
    public Image DisableBuyCowMale;
    public Image DisableBuyCowFemale;
    public Image DisableBuyChickenMale;
    public Image DisableBuyChickenFemale;

    List<Chicken> ChickenListMale = new List<Chicken>();
    List<Chicken> ChickenListFemale = new List<Chicken>();
    List<Cow> CowListMale = new List<Cow>();
    List<Cow> CowListFemale = new List<Cow>();
    Vector3 positionChicken = new Vector3Int(-15, 9, 0);
    Vector3 positionCow = new Vector3Int(15, 9, 0);

    
    public Chicken maleChicken;
    public Chicken femaleChicken;
    public Cow maleCow;
    public Cow femaleCow;


    private int breedingChickenStartDay = -1; // Tracks the day when breeding starts
    private int breedingCowStartDay = -1; // Tracks the day when breeding starts
    private const float breedingChickenPeriod = 5f; // Breeding period in days
    private const float breedingCowPeriod = 20f; // Breeding period in days
    private bool breedingChickenActive = false; // Flag to check if breeding is in progress
    private bool breedingCowActive = false;
    public bool chickenPenBought = false;
    private bool cowPenBought = false;
    private void Awake()
    {
        ChickenListMale.Clear();
        ChickenListFemale.Clear();
        CowListMale.Clear();
        CowListFemale.Clear();

            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
 

    }

    private void Start()
    {

        UpdateUI();

        BuyChickenPen.onClick.AddListener(BuyPenChicken);
        BuyCowPen.onClick.AddListener(BuyPenCow);
        BuyChickenMale.onClick.AddListener(BuyMaleChicken);
        BuyChickenFemale.onClick.AddListener(BuyFemaleChicken);
        SellChickenMale.onClick.AddListener(SellMaleChicken);
        SellChickenFemale.onClick.AddListener(SellFemaleChicken);

        BuyCowMale.onClick.AddListener(BuyMaleCow);
        BuyCowFemale.onClick.AddListener(BuyFemaleCow);
        SellCowMale.onClick.AddListener(SellMaleCow);
        SellCowFemale.onClick.AddListener(SellFemaleCow);
    }



    private void Update()
    {
        UpdateUI();
        CheckChickenBreedingConditions();
        CheckCowBreedingConditions();
    }




    private void CheckChickenBreedingConditions()
    {
        // Check if there is at least 1 male and 2 females
        int maleCount = ChickenListMale.Count;
        int femaleCount = ChickenListFemale.Count;

        if (maleCount >= 1 && femaleCount >= 2)
        {
            if (!breedingChickenActive)
            {
                // Start breeding process
                breedingChickenActive = true;
                breedingChickenStartDay = GameManager.Instance.dayTimeController.days;
            }

            // Calculate the number of possible breedings based on the 2:1 ratio
            int breedablePairs = Mathf.Min(maleCount, femaleCount / 2); // 2 females per male

            // Check if 5 days have passed and breed based on the available ratio
            if (breedingChickenActive && GameManager.Instance.dayTimeController.days >= breedingChickenStartDay + 5)
            {
                for (int i = 0; i < breedablePairs; i++)
                {
                    BreedChicken(); // Breed multiple times based on the available ratio
                }
                breedingChickenActive = false; // Reset breeding state
            }
        }
        else
        {
            // Reset breeding state if conditions are no longer valid
            breedingChickenActive = false;
            breedingChickenStartDay = -1;
        }
    }


    private void CheckCowBreedingConditions()
    {
        // Check if there is at least 1 male and 2 females
        int maleCount = CowListMale.Count;
        int femaleCount = CowListFemale.Count;

        if (maleCount >= 1 && femaleCount >= 1)
        {
            if (!breedingCowActive)
            {
                // Start breeding process
                breedingCowActive = true;
                breedingCowStartDay = GameManager.Instance.dayTimeController.days;
            }

            // Calculate the number of possible breedings based on the 2:1 ratio
            int breedablePairs = Mathf.Min(maleCount, femaleCount / 2); // 2 females per male

            // Check if 5 days have passed and breed based on the available ratio
            if (breedingCowActive && GameManager.Instance.dayTimeController.days >= breedingCowStartDay + 5)
            {
                for (int i = 0; i < breedablePairs; i++)
                {
                    BreedCow(); // Breed multiple times based on the available ratio
                }
                breedingCowActive = false; // Reset breeding state
            }
        }
        else
        {
            // Reset breeding state if conditions are no longer valid
            breedingCowActive = false;
            breedingCowStartDay = -1;
        }
    }

    private void BreedChicken()
    {
        Debug.Log("Breeding successful! A new chicken is born.");
        int randomAction = Random.Range(0, 2); // Randomly choose male or female chicken

        if (randomAction == 0)
        {
            var newChicken = Instantiate(femaleChicken, positionChicken, Quaternion.identity);
            ChickenListFemale.Add(newChicken);
        }
        else
        {
            var newChicken = Instantiate(maleChicken, positionChicken, Quaternion.identity);
            ChickenListMale.Add(newChicken);
        }

        // Reset breeding day to allow for another cycle
        breedingChickenStartDay = -1;
    }

    private void BreedCow()
    {
        Debug.Log("Breeding successful! A new chicken is born.");
        int randomAction = Random.Range(0, 2); // Randomly choose male or female chicken

        if (randomAction == 0)
        {
            var newCow = Instantiate(femaleCow, positionCow, Quaternion.identity);
            CowListFemale.Add(newCow);
        }
        else
        {
            var newCow = Instantiate(maleCow, positionCow, Quaternion.identity);
            CowListMale.Add(newCow);
        }

        // Reset breeding day to allow for another cycle
        breedingCowStartDay = -1;
    }


    private void UpdateUI()
    {
        var playerCredit = GameManager.Instance.player.credit;

        DisableBuyChickenPen.enabled = chickenPenBought || playerCredit < 1000;

  
        DisableBuyCowPen.enabled = cowPenBought || playerCredit < 3000;

      
        DisableBuyChicken.enabled = !chickenPenBought;
        DisableBuyChickenMale.enabled = !chickenPenBought || playerCredit < 500;
        DisableBuyChickenFemale.enabled = !chickenPenBought || playerCredit < 500;

        DisableSellChickenMale.enabled = ChickenListMale.Count == 0;
        DisableSellChickenFemale.enabled = ChickenListFemale.Count == 0;


        DisableBuyCow.enabled = !cowPenBought;
        DisableBuyCowMale.enabled = !cowPenBought || playerCredit < 1000;
        DisableBuyCowFemale.enabled = !cowPenBought || playerCredit < 1000;

        DisableSellCowMale.enabled = CowListMale.Count == 0;
        DisableSellCowFemale.enabled = CowListFemale.Count == 0;

    }



    private void BuyPenChicken()
    {
        if (GameManager.Instance.player.credit >= 1000)
        {
            GameManager.Instance.tileManager.ChickenPenBought();
            GameManager.Instance.player.credit -= 1000;
            chickenPenBought = true;
            UpdateUI();
        }
    }

    private void BuyPenCow()
    {
        if (GameManager.Instance.player.credit >= 3000)
        {
            GameManager.Instance.tileManager.CowPenBought();
            GameManager.Instance.player.credit -= 3000;
            cowPenBought = true;
            UpdateUI();
        }
    }

    private void BuyMaleChicken()
    {
        if (GameManager.Instance.player.credit >= 500)
        {
            GameManager.Instance.player.credit -= 500;
            var newChicken = Instantiate(maleChicken, positionChicken, Quaternion.identity);
            ChickenListMale.Add(newChicken);
            UpdateUI();
        }
    }

    private void BuyFemaleChicken()
    {
        if (GameManager.Instance.player.credit >= 500)
        {
            GameManager.Instance.player.credit -= 500;
            var newChicken = Instantiate(femaleChicken, positionChicken, Quaternion.identity);
            ChickenListFemale.Add(newChicken);
            UpdateUI();
        }
    }

    private void SellMaleChicken()
    {
        if (ChickenListMale.Count > 0)
        {
            var chickenToSell = ChickenListMale[0];
            ChickenListMale.Remove(chickenToSell);
            Destroy(chickenToSell.gameObject);
            GameManager.Instance.player.credit += 450; // Example sell value
            UpdateUI();
        }
    }

    private void SellFemaleChicken()
    {
        if (ChickenListFemale.Count > 0)
        {
            var chickenToSell = ChickenListFemale[0];
            ChickenListFemale.Remove(chickenToSell);
            Destroy(chickenToSell.gameObject);
            GameManager.Instance.player.credit += 450; // Example sell value
            UpdateUI();
        }
    }

    private void BuyMaleCow()
    {
        if (GameManager.Instance.player.credit >= 1000)
        {
            GameManager.Instance.player.credit -= 1000;
            var newCow = Instantiate(maleCow, positionCow, Quaternion.identity);
            CowListMale.Add(newCow);
            UpdateUI();
        }
    }

    private void BuyFemaleCow()
    {
        if (GameManager.Instance.player.credit >= 1000)
        {
            GameManager.Instance.player.credit -= 1000;
            var newCow = Instantiate(femaleCow, positionCow, Quaternion.identity);
            CowListFemale.Add(newCow);
            UpdateUI();
        }
    }

    private void SellMaleCow()
    {
        if (CowListMale.Count > 0)
        {
            var cowToSell = CowListMale[0];
            CowListMale.Remove(cowToSell);
            Destroy(cowToSell.gameObject);
            GameManager.Instance.player.credit += 750; // Example sell value
            UpdateUI();
        }
    }

    private void SellFemaleCow()
    {
        if (CowListFemale.Count > 0)
        {
            var cowToSell = CowListFemale[0];
            CowListFemale.Remove(cowToSell);
            Destroy(cowToSell.gameObject);
            GameManager.Instance.player.credit += 750; // Example sell value
            UpdateUI();
        }
    }
}
