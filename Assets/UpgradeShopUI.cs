//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class UpgradeShopUI : MonoBehaviour
//{
//    public Button BuyChickenPen;
//    public Button BuyCowPen;
//    public Button BuyCowMale;
//    public Button BuyCowFemale;
//    public Button BuyChickenMale;
//    public Button BuyChickenFemale;
//    public Button SellCowMale;
//    public Button SellCowFemale;
//    public Button SellChickenMale;
//    public Button SellChickenFemale;
//    public Image DisableBuyCowPen;
//    public Image DisableBuyChickenPen;
//    public Image DisableSellCowMale;
//    public Image DisableSellCowFemale;
//    public Image DisableSellChickenMale;
//    public Image DisableSellChickenFemale;
//    public Image DisableBuyCow;
//    public Image DisableBuyChicken;
//    public Image DisableBuyCowMale;
//    public Image DisableBuyCowFemale;
//    public Image DisableBuyChickenMale;
//    public Image DisableBuyChickenFemale;

//    List<Chicken> ChickenListMale = new List<Chicken>();
//    List<Chicken> ChickenListFemale = new List<Chicken>();
//    List<Cow> CowListMale = new List<Cow>();
//    List<Cow> CowListFemale = new List<Cow>();

//    public Chicken maleChicken;
//    public Chicken femaleChicken;
//    public Cow maleCow;
//    public Cow femaleCow;

//    public bool chickenPenBought = false;

//    private void Awake()
//    {
//        ChickenListMale.Clear();
//        ChickenListFemale.Clear();
//        CowListMale.Clear();
//        CowListFemale.Clear();

//    }

//    void Update()
//    {
//        if(GameManager.Instance.player.credit >= 100)
//        {
//           DisableBuyChickenPen.enabled = false;
//        }
//        else
//        {
//            DisableBuyChickenPen.enabled = true;
//        }
//        if (GameManager.Instance.player.credit >= 300)
//        {
//            DisableBuyCowPen.enabled = false;
//        }
//        else
//        {
//            DisableBuyCowPen.enabled = true;
//        }

//        if (DisableBuyChicken.enabled == false)
//        {
//            if (GameManager.Instance.player.credit >= 50)
//            {
//                DisableBuyChickenMale.enabled = false;
//                DisableBuyChickenFemale.enabled = false;
//            }
//            else
//            {
//                DisableBuyChickenMale.enabled = true;
//                DisableBuyChickenFemale.enabled = true;
//            }

//            if (ChickenListFemale.Count == 0)
//            {
//                DisableSellChickenFemale.enabled = true;
//            }
//            else
//            {
//                DisableSellChickenFemale.enabled = false;
//            }

//            if (ChickenListMale.Count == 0)
//            {
//                DisableSellChickenMale.enabled = true;
//            }
//            else
//            {
//                DisableSellChickenMale.enabled = false;
//            }

//        }
//        if (DisableBuyCow.enabled == false)
//        {
//            if (GameManager.Instance.player.credit >= 100)
//            {

//            }
//        }


//        BuyChickenPen.onClick.AddListener(BuyPenChick);
//        BuyCowPen.onClick.AddListener(BuyPenCow);
        
        
//        BuyCowMale.onClick.AddListener(BuyMaleCow);
//        BuyCowFemale.onClick.AddListener(BuyFemaleCow);


//        BuyChickenMale.onClick.AddListener(BuyMaleChicken);
//        BuyChickenFemale.onClick.AddListener(BuyFemaleChicken);


//        SellCowMale.onClick.AddListener(BuyPenCow);
//        SellCowFemale.onClick.AddListener(BuyPenCow);

//        SellChickenMale.onClick.AddListener(BuyPenCow);
//        SellChickenFemale.onClick.AddListener(BuyPenCow);
//    }

//    //void BuyPenChick()
//    //{
//    //    if (GameManager.Instance.player.credit >= 100)
//    //    {
//    //        GameManager.Instance.tileManager.ChickenPenBought();
//    //        GameManager.Instance.player.credit -= 100;
//    //        DisableBuyChicken.enabled = false;
//    //        chickenPenBought = true;
//    //    }


//    //}

//    void BuyPenCow()
//    {

//    }

//    void BuyMaleChicken()
//    {
//        GameManager.Instance.player.credit -= 50;
//        ChickenListMale.Add(maleChicken);
//    }
//    void BuyFemaleChicken()
//    {

//    }
//    void BuyMaleCow()
//    {


//    }
//    void BuyFemaleCow()
//    {


//    }

//}
