using System.Collections.Generic;
using System.Diagnostics;
using Lib.LINQ.DataManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.LINQ.Data__Test_
{
    [TestClass]
    public class ListManagerModuleTest
    {
        private ListManager _listManager;

        [TestInitialize]
        public void StartUp()
        {
            _listManager = new ListManager();
        }
        
        [TestMethod]
        public void Test_ListManager_ReturnGeneratedUsersList_NotNull()
        {
            var list = ListManager.ReturningGeneratedUsersList();
            list.ForEach(c =>Debug.Print($"\tUser:\n{c.Name}\n{c.Age}\n{c.Id}")); 
            Assert.IsNotNull(list);
        }
                
        [TestMethod]
        public void Test_ListManager_ReturnGeneratedStringsList_NotNull() 
        { 
            var List = _listManager.ReturnGeneratedStringsList(); 
            List.ForEach(c =>Debug.Print(c)); 
            Assert.IsNotNull(List);
        }
        
        [TestMethod] 
        public void Test_List_SetListByArray() 
        { 
            var List = new ListManager().SetStringListByArray(new[] {"str1", "str2"}); 
            Assert.IsNotNull(List); 
            Assert.IsTrue(List.Count > 0);
        }

        [TestMethod]
        public void Test_List_SetListByList()
        {
            var stringList = new List<string>(){"newstr1", "newstr2"};
            var expectedList = _listManager.SetStringListByList(stringList);
            Assert.IsTrue(expectedList.Count > 0);
        }
    }
}