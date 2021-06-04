using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestProject1
    {
        static Analytics disk_price;
        [ClassInitialize]
        static public void Init(TestContext tc)
        {
            disk_price = new Analytics();
        }


        //Проверка на размер Роли
        [TestMethod]
        public void CheckRole()
        {
            Assert.IsTrue(disk_price.CheckRole(2));
        }

        //Проверка на нулевую Роль
        [TestMethod]
        public void RoleNotNull()
        {
            Assert.AreEqual(disk_price.RoleNotNull(-12), "Роль не может быть меньше или равна нулю!!!");
        }
    }
}






  