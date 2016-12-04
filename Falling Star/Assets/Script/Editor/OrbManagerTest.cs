using NUnit.Framework;
using NSubstitute;
using UnityEngine;

[TestFixture]
public class OrbManagerTest {

    [TestFixtureSetUp]
    public void Init()
    {
        orbManager = ob.AddComponent<OrbManager>();
        PlayerPrefs.SetInt("OrbPoint", 0);

    }

    GameObject ob = new GameObject("OrbManagerObject");
    OrbManager orbManager;
   

    [Test]
    public void Toplam_Orb_Skoru_Ekle([NUnit.Framework.Range(0, 20)] int Orb)
    {
             
        int expected = orbManager.getTotalOrb + Orb;

        int result = orbManager.AddTotalOrb(Orb);

        Assert.AreEqual(expected, result);
        Assert.AreEqual(result, orbManager.getTotalOrb);
    }

    [Test]
    public void Toplam_Orb_Harca([NUnit.Framework.Range(1,20)] int SpendOrb)
    {

        orbManager.AddTotalOrb(SpendOrb);
        int expected = orbManager.getTotalOrb - SpendOrb;

        bool result = orbManager.SpendTotalOrb(SpendOrb);

        Assert.IsTrue(result);
        Assert.AreEqual(expected, orbManager.getTotalOrb);
    }

    [Test]
    public void Toplam_Orb_Harcandıgında_Negatif_Olmamali([NUnit.Framework.Range(1, 20)] int SpendOrb)
    {

        PlayerPrefs.SetInt("OrbPoint", 0);
       

        bool result = orbManager.SpendTotalOrb(SpendOrb);

        Assert.IsFalse(result);
        Assert.AreEqual(0, orbManager.getTotalOrb);
    }

    [Test]
    public void Orb_Ekle()
    {
        int orbScore = 1;
        int expected = orbManager.getOrb + orbScore;

        int result = orbManager.AddOrb(orbScore);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Toplam_Orb_Sayısını_Güncelle()
    {
        int orbScore = 20;       
        orbManager.AddOrb(orbScore);
        int expected = orbManager.getTotalOrb + orbManager.getOrb;

        orbManager.UpdateTotalOrb();

        Assert.AreEqual(expected, orbManager.getTotalOrb);
    }

}
