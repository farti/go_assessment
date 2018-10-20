using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// This test evaluates the 
    /// </summary>
    public class XmlReadingTest : ITest
    {
        public string Name { get { return "XML Reading Test"; } }

        public void Run()
        {
            var xmlData = Resources.SamplePoints;

            // TODO: 
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z

            PrintOverview(xmlData);
        }

        private void PrintOverview(string xml)
        {
            XDocument doc = XDocument.Parse(xml);

            var temperatures = doc
                .Descendants("param")
                .Where(g => g.Attribute("name").Value == "temperature")
                .Select(x => XmlConvert.ToDouble(x.Value))
                .ToList();
            
            var phs = doc
                .Descendants("param")
                .Where(g => g.Attribute("name").Value == "pH")
                .Select(x => XmlConvert.ToDouble(x.Value))
                .ToList();

            var chlorides = doc
                .Descendants("param")
                .Where(g => g.Attribute("name").Value == "Chloride")
                .Select(x => XmlConvert.ToDouble(x.Value))
                .ToList();

            var phosphates = doc
                .Descendants("param")
                .Where(g => g.Attribute("name").Value == "Phosphate")
                .Select(x => XmlConvert.ToDouble(x.Value))
                .ToList();

            var nitrates = doc
                .Descendants("param")
                .Where(g => g.Attribute("name").Value == "Nitrate")
                .Select(x => XmlConvert.ToDouble(x.Value))
                .ToList();

            Console.WriteLine("parameter     LOW AVG  MAX");
            Console.WriteLine($"temperature {temperatures.Min()}  {Math.Round(temperatures.Average(),2)}    {temperatures.Max()}");
            Console.WriteLine($"pHs         {phs.Min()}  {Math.Round(phs.Average(),2)}    {phs.Max()}");
            Console.WriteLine($"chlorides   {chlorides.Min()}  {chlorides.Average()}     {chlorides.Max()}");
            Console.WriteLine($"phosphates  {phosphates.Min()}  {phosphates.Average()}    {phosphates.Max()}");
            Console.WriteLine($"nitrates    {nitrates.Min()} {nitrates.Average()}     {nitrates.Max()}");

        }
    }
}
