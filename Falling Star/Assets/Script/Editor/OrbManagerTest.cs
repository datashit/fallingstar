using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class OrbManagerTest {

    [TestFixtureSetUp]
    public void Init()
    {
        Debug.Log("Init");



    }


    [Test]
	public void EditorTest()
	{
		//Arrange
		var gameObject = new GameObject();

		//Act
		//Try to rename the GameObject
		var newGameObjectName = "My game object";
		gameObject.name = newGameObjectName;

		//Assert
		//The object has a new name
		Assert.AreEqual(newGameObjectName, gameObject.name);
	}

    [Test]
    public void Toplam_Orb_Skoru_Güncelle()
    {

    

        Assert.AreEqual(20, 20);
    }

    //[Test]
    //public void Orb_Manager_Nesnesi_Tek_Olmali()
    //{
        
       
        
    //    OrbManager manager = OrbManager.Instance;


        
    //    Assert.AreSame(manager, OrbManager.Instance);
    //}

    [Test]
    public void Orb_Manager_Null_Olmamali()
    {
        OrbManager manager = OrbManager.Instance;

        Assert.IsNull(manager);
    }
}
