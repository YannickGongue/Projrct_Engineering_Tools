using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.DatabaseManager
{
   public class DBName
   {
        //Tabelle User
        public string StrTBL_User = "Users";
        public string strId = "Id";
        public string strEmail = "Email";
        public string StrPasswort = "Passwort";

        //Tabelle Informationsdaten
        public string strTBL_StudentsInfo = "StudentInformations";
        public string strName = "Name";
        public string strVorname = "Vorname";
        public string strStadt = "Stadt";
        public string strPostleitzahl = "Postleitzahl";
        public string strStraße = "Straße";
        public string strNummer = "Straßenummer";
        public string strDatum = "Datum";
        public string strLand = "Land";
        public string strImageId = "ImageId";
        public string strFileName = "FileName";
        public string strContentType = "ContentType";
        public string strImageData = "ImageData";

        //Tabelle Berufserfahrung
        public string strTBL_Beruf = "StudentWorkInfo";
        public string strAufgabe = "Aufgabe";
        public string strTitel = "Titel";
        public string strSkills = "Skills";
        public string strFirma = "Firma";
        public string strStartDatum = "StartDatum";
        public string strEndDatum = "EndDatum";
        public string strStandOrt = "Standort";
        public string strOrtsTyp = "OrtsTyp";
        public string strArbeitArt = "ArbeitsArt";

    }
}
