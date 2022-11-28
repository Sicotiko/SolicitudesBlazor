using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.Shared.Utilities
{
    public static class Nodos
    {
        public static HtmlNode GetNode(HtmlNode htmlNode, string TagName, string AttributeName, string AttributeValue)
        {
            try
            {
                return htmlNode.SelectSingleNode($".//{TagName}[@{AttributeName}='{AttributeValue}']");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Hubo un error en la busqueda, intentelo nuevamente");
            }
        }
        public static HtmlNode GetNode(HtmlNode htmlNode, string TagName, string AttributeName)
        {
            try
            {
               return htmlNode.SelectSingleNode($".//{TagName}[@{AttributeName}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Hubo un error en la busqueda, intentelo nuevamente");
            }
        }
        public static HtmlNode GetNode(HtmlNode htmlNode, string TagName)
        {
            try
            {
                return htmlNode.SelectSingleNode($".//{TagName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Hubo un error en la busqueda, intentelo nuevamente");
            }
        }
        public static HtmlNodeCollection GetNodes(HtmlNode htmlNode, string TagName, string AttributeName, string AttributeValue)
        {
            try
            {
                return htmlNode.SelectNodes($".//{TagName}[@{AttributeName}='{AttributeValue}']");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Hubo un error en la busqueda, intentelo nuevamente");
            }
        }
        public static HtmlNodeCollection GetNodes(HtmlNode htmlNode, string TagName, string AttributeName)
        {
            try
            {
                return htmlNode.SelectNodes($".//{TagName}[@{AttributeName}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Hubo un error en la busqueda, intentelo nuevamente");
            }
        }
        public static HtmlNodeCollection GetNodes(HtmlNode htmlNode, string TagName)
        {
            try
            {
                return htmlNode.SelectNodes($".//{TagName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Hubo un error en la busqueda, intentelo nuevamente");
            }
        }

    }
}
