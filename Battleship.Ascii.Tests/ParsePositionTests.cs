
namespace Battleship.Ascii.Tests
{
   using Battleship.GameController.Contracts;
   using Microsoft.VisualStudio.TestTools.UnitTesting;
   using System.Diagnostics;


   [TestClass]
   public class ParsePositionTests
   {
      [TestMethod]
      public void ParseLetterNumber()
      {
         var actual = Program.ParsePosition("A1");

         var expected = new Position(Letters.A, 1);

         Assert.AreEqual(expected, actual);
      }
   }

   [TestClass]
   public class ShipIsHitTest
   {
      [TestMethod]
      public void TestShipIsHit()
      {
         Debug.WriteLine("Running tests in Battleship.Ascii.Tests.ShipIsHitTest.TestShipIsHit");

         var ship = new Ship("Patrol Boat", 2);
         ship.AddPosition("A1");
         ship.AddPosition("A2");

         var (isHit, destroyed) = ship.IsHit("A1");
         ///Console.WriteLine($"ship.IsPlaced: {ship.IsPlaced}");
         Assert.IsTrue(isHit);
         Assert.IsFalse(destroyed);
         (isHit, destroyed) = ship.IsHit("A2");
         Assert.IsTrue(isHit);
         Assert.IsTrue(destroyed);
      }
   }
}
