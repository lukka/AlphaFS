/*  Copyright (C) 2008-2018 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy 
 *  of this software and associated documentation files (the "Software"), to deal 
 *  in the Software without restriction, including without limitation the rights 
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 *  copies of the Software, and to permit persons to whom the Software is 
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in 
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 *  THE SOFTWARE. 
 */

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alphaleonis.Win32.Network;

namespace AlphaFS.UnitTest
{
   public partial class EnumerationTest
   {
      [TestMethod]
      public void AlphaFS_Host_EnumerateNetworkConnections_Local_Success()
      {
         UnitTestConstants.PrintUnitTestHeader(false);


         var networkConnectionCount = 0;

         foreach (var networkConnection in Host.EnumerateNetworkConnections().OrderBy(networkConnection => networkConnection.NetworkInfo.Name))
         {
            Console.WriteLine("\n#{0:000}\tNetwork: [{1}]", ++networkConnectionCount, networkConnection.NetworkInfo.Name);


            UnitTestConstants.Dump(networkConnection, -21);

            UnitTestConstants.Dump(networkConnection.NetworkInfo, -21, true);

            UnitTestConstants.Dump(networkConnection.NetworkInterface, -20, true);


            Console.WriteLine();
         }


         if (networkConnectionCount == 0)
            Assert.Inconclusive("No network connections enumerated, but it is expected.");
      }
   }
}
