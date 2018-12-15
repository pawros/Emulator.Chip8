using System;
using System.Linq;
using System.Reflection;
using Emulator.Chip8.Instructions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Emulator.Chip8.Tests
{
    [TestClass]
    public class InterpreterTests
    {
        [TestMethod]
        public void AllInstructionsHaveUniqueAttributeValue()
        {
            var attributesValues = typeof(Interpreter)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.GetCustomAttributes().OfType<InstructionAttribute>().Any())
                .Select(a => ((InstructionAttribute) a.GetCustomAttribute(typeof(InstructionAttribute))).OpcodeKey)
                .ToList();

            var areUnique = attributesValues.Distinct().Count() == attributesValues.Count();
            Assert.IsTrue(areUnique, "All instructions should have unique attribute value");
        } 
    }
}
