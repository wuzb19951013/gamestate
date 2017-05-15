using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Windows.UI.Notifications;
using System.Threading.Tasks;

namespace gamestate
{
    class showTile
    {

        static public void showInfo(string type, string info1, string info2)
        {
                Windows.Data.Xml.Dom.XmlDocument d = new Windows.Data.Xml.Dom.XmlDocument();
                d.LoadXml(File.ReadAllText("tile.xml"));
                var eles = d.GetElementsByTagName("text");
                for (int i = 0; i < eles.Length; i += 3)
                {
                    var ele = eles[i] as Windows.Data.Xml.Dom.XmlElement;
                    ele.InnerText = type;
                    ele = eles[i + 1] as Windows.Data.Xml.Dom.XmlElement;
                    ele.InnerText = info1;
                    ele = eles[i + 2] as Windows.Data.Xml.Dom.XmlElement;
                    ele.InnerText = info2;
                }

                // perform update
                var updator = TileUpdateManager.CreateTileUpdaterForApplication();
                var notification = new TileNotification(d);
                updator.Update(notification);
        }
    }
}
