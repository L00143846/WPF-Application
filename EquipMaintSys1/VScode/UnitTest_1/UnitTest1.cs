using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest_1;
using EquipMaintSys1;
using System.Windows;
using System.Data;

namespace UnitTest_1
{
    [TestClass]
    public class UnitTest1
    {

        MainWindow mw = new MainWindow();

        [TestMethod]

        #region REGION -- TestMethod1() -- Test if variable holds correct value after button click
        public void TestMethod1()
        {
            // Test if variable holds correct value after button click
            // FAULT TAB -- Update a Fault Button should set int fauB = 2

            // arrange
            int expected = 2;

            // act
            int actual = mw.fauB;

            // assert
            Assert.AreEqual(expected, actual, 0.001, "Error: INT variable not set to expected value.");

        }// END TestMethod1()
        #endregion REGION -- TestMethod1() -- Test if variable holds correct value after button click

        #region REGION -- TestMethod2() -- Test data returned from database (Epuiptment Names)
        public void TestMethod2()
        {
            // Test if Combo box is populated with correct returned data from database
            // arrange
            DataTable expected = new DataTable();
            expected.Rows.Add("Beam Saw");
            expected.Rows.Add("CNC");
            expected.Rows.Add("Sander");

            // act
            DataTable actual = mw.GetEquipmentNames();

            // assert
            Assert.AreEqual(expected, actual, "Error: data returned from Equiptment table incorrect.");

        }// END TestMethod2()
        #endregion REGION -- TestMethod2() -- Test data returned from database (Epuiptment Names)




    }// END class
}// END namespace
