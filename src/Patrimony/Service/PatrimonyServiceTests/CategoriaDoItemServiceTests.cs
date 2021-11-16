using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGP.Model.Entity;
using SGP.Patrimony.Service.PatrimonyService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGP.Patrimony.Service.PatrimonyService.Tests
{
    [TestClass()]
    public class CategoriaDoItemServiceTests
    {
        //    [TestMethod()]
        //    public void DeleteTest()
        //    {



        //    }

        [TestMethod()]
        public void CreateTest()
        {
            string Nome = "Impressora";

            CategoriaDoItem categoria = new CategoriaDoItem(Nome);

            Assert.IsTrue(categoria != null);
        }
    }
}