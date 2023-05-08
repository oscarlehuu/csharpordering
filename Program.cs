﻿// - The XML file configures how we arrange and merchandise our products within our site.

// - The TXT file is simply a list of SKUs from our site.

// The challenge is to determine the "primary" category for each SKU using C#. 
// return a CSV file with the `SKU` in the first column and the `category_id` in the second. 
// And, of course, the code to do the work.

// You'll notice in the XML many `category` elements such as this: `<category id="836" name="Farm Party" primary="ANF.*FP$" authority="6">`.

// You'll need to find all `category` elements with a `primary` attribute 
// and turn the value of this attribute into a `Regex` (and when you do you need to anchor the pattern to the start of the string). 
// Some of the `primary` attributes contain comma separated regexes, so first you need to split out the individual regexes and treat them as 
//if there are multiple `primary` attributes for the `category`. 
//You'll need to grab the `authority` attribute and treat this as a `double`. 
//If a `category` element doesn't have an `authority` attribute then use `5.0` as the default. 
//If the `name` attribute of the `category` element starts with `* ` (asterisk + space) then you need to subtract `2.5` from the authority value.

// You then need to match each sku against the generated regex and return only the matches that have the highest authority value. 
//There should only be a single match that has the highest authority value for each SKU. 
//If you don't then either your code or mine has a bug.

// Ignore SKUs that start with `SHIP`.

using System;
using System.Numerics;
using System.Xml;
using System.Xml.XPath;
using Newtonsoft.Json;

class test {
    public void openXML() {
        XmlDocument myDoc = new XmlDocument();
        myDoc.Load("ordering23.xml");
        string jsonText = JsonCovert.SerializeXmlNode(myDoc);
        Console.WriteLine(jsonText);
        // XmlNodeList rankNodes = myDoc.SelectNodes("/ordering/categories/rank");
        // XmlNode categoryNode = myDoc.SelectSingleNode("category[@id='1']");
        // if(categoryNode != null) {
        //     XmlNodeList childNodes = categoryNode.SelectNodes(".//*");
        //     foreach (XmlNode childNode in childNodes) {
        //         Console.WriteLine("Node Name: " + childNode.Name);
        //         Console.WriteLine("Node Value: " + childNode.InnerText);
        //     }
        // } else {
        //     Console.WriteLine("No category element found with ID=1");
        // }
    }
    public static void Main(String[] args) {
        test t = new test();
        t.openXML();
    }
}