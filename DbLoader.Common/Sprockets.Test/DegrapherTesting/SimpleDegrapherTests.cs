﻿/***********************************************************************************
 * Copyright 2017  David Garcia
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * *********************************************************************************/

using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprockets.LargeGraph.Serialization;

namespace Sprockets.Test.DegrapherTesting {
    [TestClass]
    public class SimpleDegrapherTests {
        [TestMethod]
        public void CanDegraphXElement() {
            var xmlDegrapher = new SimpleDegrapher {CustomerEnumerator = SimpleDegrapher.XElementDegrapher};

            var a = new XElement("root");
            var b = new XElement("child");
            b.Value = "hello world";
            a.Add(b);

            xmlDegrapher.LoadObject(a);
            xmlDegrapher.Pump();
            xmlDegrapher.Pump();

            var stringContent = xmlDegrapher.KnowledgeBase.SelectMany(m => m).OfType<string>().ToArray();

            Assert.IsTrue(stringContent.Contains("hello world"));
        }
    }

    
}