/************************************************************************
 * 
 * The MIT License (MIT)
 * 
 * Copyright (c) 2025 - Christian Falch
 * 
 * Permission is hereby granted, free of charge, to any person obtaining 
 * a copy of this software and associated documentation files (the 
 * "Software"), to deal in the Software without restriction, including 
 * without limitation the rights to use, copy, modify, merge, publish, 
 * distribute, sublicense, and/or sell copies of the Software, and to 
 * permit persons to whom the Software is furnished to do so, subject 
 * to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be 
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
 * CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
 * TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.Maui.Controls;

namespace MauiLab
{
    /// <summary>
    /// Font awesome label.
    /// </summary>
    public class FontAwesomeIcon : Label
    {

        private static string FieldName(string cssName)
        {
            if (string.IsNullOrEmpty(cssName))
            {
                return "";
            }

            string result = "FA";

            // split in groups
            var parts = cssName.Split('-', '_');
            var ma = false;

            // skip optional "fa"
            if (parts[0] == "fa" || parts[0] == "ma")
            {
                if (parts[0] == "ma")
                    ma = true;

                parts = parts.Skip(1).ToArray();
            }

            if (ma)
                result = "MA";

            // make first letters upper case
            foreach (var p in parts)
            {
                var np = char.ToUpper(p[0]) + p.Substring(1);
                result += np;
            }

            return result;
        }

        public static string[] GetIconByCSSName(string cssName)
        {
            if (string.IsNullOrEmpty(cssName))
            {
                return null;
            }

            try
            {
                if (cssName.Contains(" "))
                {
                    var parts = cssName.Split(' ');
                    if (parts[0] == "far" || parts[0] == "fal")
                    {
                        // regular or light (TODO: add light font to project and use suffix -l)
                        cssName = parts[1] + "-o";
                    }
                    else
                    {
                        // solid or brand
                        cssName = parts[1];
                    }
                }

                var fieldName = FieldName(cssName);
                var field = typeof(FontAwesomeIcon).GetRuntimeField(fieldName);
                var icon = field.GetValue(null) as string[];

                return icon;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Something went wrong when getting icon: " + cssName + " - " + e.Message);
            }

            return null;
        }

        #region Icon Constants

        // extracted from icons.json by the ParseFontAwesome program (in Tools)
        // Font Awesome 5.9.0
        public static string[] FA500px = { "\uf26e", "fab" };
        public static string[] FAAbacus = { "\uf640", "fa" };
        public static string[] FAAbacusO = { "\uf640", "far" };
        public static string[] FAAccessibleIcon = { "\uf368", "fab" };
        public static string[] FAAccusoft = { "\uf369", "fab" };
        public static string[] FAAcorn = { "\uf6ae", "fa" };
        public static string[] FAAcornO = { "\uf6ae", "far" };
        public static string[] FAAcquisitionsIncorporated = { "\uf6af", "fab" };
        public static string[] FAAd = { "\uf641", "fa" };
        public static string[] FAAdO = { "\uf641", "far" };
        public static string[] FAAddressBook = { "\uf2b9", "fa" };
        public static string[] FAAddressBookO = { "\uf2b9", "far" };
        public static string[] FAAddressCard = { "\uf2bb", "fa" };
        public static string[] FAAddressCardO = { "\uf2bb", "far" };
        public static string[] FAAdjust = { "\uf042", "fa" };
        public static string[] FAAdjustO = { "\uf042", "far" };
        public static string[] FAAdn = { "\uf170", "fab" };
        public static string[] FAAdobe = { "\uf778", "fab" };
        public static string[] FAAdversal = { "\uf36a", "fab" };
        public static string[] FAAffiliatetheme = { "\uf36b", "fab" };
        public static string[] FAAirFreshener = { "\uf5d0", "fa" };
        public static string[] FAAirFreshenerO = { "\uf5d0", "far" };
        public static string[] FAAirbnb = { "\uf834", "fab" };
        public static string[] FAAlarmClock = { "\uf34e", "fa" };
        public static string[] FAAlarmClockO = { "\uf34e", "far" };
        public static string[] FAAlarmExclamation = { "\uf843", "fa" };
        public static string[] FAAlarmExclamationO = { "\uf843", "far" };
        public static string[] FAAlarmPlus = { "\uf844", "fa" };
        public static string[] FAAlarmPlusO = { "\uf844", "far" };
        public static string[] FAAlarmSnooze = { "\uf845", "fa" };
        public static string[] FAAlarmSnoozeO = { "\uf845", "far" };
        public static string[] FAAlgolia = { "\uf36c", "fab" };
        public static string[] FAAlicorn = { "\uf6b0", "fa" };
        public static string[] FAAlicornO = { "\uf6b0", "far" };
        public static string[] FAAlignCenter = { "\uf037", "fa" };
        public static string[] FAAlignCenterO = { "\uf037", "far" };
        public static string[] FAAlignJustify = { "\uf039", "fa" };
        public static string[] FAAlignJustifyO = { "\uf039", "far" };
        public static string[] FAAlignLeft = { "\uf036", "fa" };
        public static string[] FAAlignLeftO = { "\uf036", "far" };
        public static string[] FAAlignRight = { "\uf038", "fa" };
        public static string[] FAAlignRightO = { "\uf038", "far" };
        public static string[] FAAlignSlash = { "\uf846", "fa" };
        public static string[] FAAlignSlashO = { "\uf846", "far" };
        public static string[] FAAlipay = { "\uf642", "fab" };
        public static string[] FAAllergies = { "\uf461", "fa" };
        public static string[] FAAllergiesO = { "\uf461", "far" };
        public static string[] FAAmazon = { "\uf270", "fab" };
        public static string[] FAAmazonPay = { "\uf42c", "fab" };
        public static string[] FAAmbulance = { "\uf0f9", "fa" };
        public static string[] FAAmbulanceO = { "\uf0f9", "far" };
        public static string[] FAAmericanSignLanguageInterpreting = { "\uf2a3", "fa" };
        public static string[] FAAmericanSignLanguageInterpretingO = { "\uf2a3", "far" };
        public static string[] FAAmilia = { "\uf36d", "fab" };
        public static string[] FAAnalytics = { "\uf643", "fa" };
        public static string[] FAAnalyticsO = { "\uf643", "far" };
        public static string[] FAAnchor = { "\uf13d", "fa" };
        public static string[] FAAnchorO = { "\uf13d", "far" };
        public static string[] FAAndroid = { "\uf17b", "fab" };
        public static string[] FAAngel = { "\uf779", "fa" };
        public static string[] FAAngelO = { "\uf779", "far" };
        public static string[] FAAngellist = { "\uf209", "fab" };
        public static string[] FAAngleDoubleDown = { "\uf103", "fa" };
        public static string[] FAAngleDoubleDownO = { "\uf103", "far" };
        public static string[] FAAngleDoubleLeft = { "\uf100", "fa" };
        public static string[] FAAngleDoubleLeftO = { "\uf100", "far" };
        public static string[] FAAngleDoubleRight = { "\uf101", "fa" };
        public static string[] FAAngleDoubleRightO = { "\uf101", "far" };
        public static string[] FAAngleDoubleUp = { "\uf102", "fa" };
        public static string[] FAAngleDoubleUpO = { "\uf102", "far" };
        public static string[] FAAngleDown = { "\uf107", "fa" };
        public static string[] FAAngleDownO = { "\uf107", "far" };
        public static string[] FAAngleLeft = { "\uf104", "fa" };
        public static string[] FAAngleLeftO = { "\uf104", "far" };
        public static string[] FAAngleRight = { "\uf105", "fa" };
        public static string[] FAAngleRightO = { "\uf105", "far" };
        public static string[] FAAngleUp = { "\uf106", "fa" };
        public static string[] FAAngleUpO = { "\uf106", "far" };
        public static string[] FAAngry = { "\uf556", "fa" };
        public static string[] FAAngryO = { "\uf556", "far" };
        public static string[] FAAngrycreative = { "\uf36e", "fab" };
        public static string[] FAAngular = { "\uf420", "fab" };
        public static string[] FAAnkh = { "\uf644", "fa" };
        public static string[] FAAnkhO = { "\uf644", "far" };
        public static string[] FAAppStore = { "\uf36f", "fab" };
        public static string[] FAAppStoreIos = { "\uf370", "fab" };
        public static string[] FAApper = { "\uf371", "fab" };
        public static string[] FAApple = { "\uf179", "fab" };
        public static string[] FAAppleAlt = { "\uf5d1", "fa" };
        public static string[] FAAppleAltO = { "\uf5d1", "far" };
        public static string[] FAAppleCrate = { "\uf6b1", "fa" };
        public static string[] FAAppleCrateO = { "\uf6b1", "far" };
        public static string[] FAApplePay = { "\uf415", "fab" };
        public static string[] FAArchive = { "\uf187", "fa" };
        public static string[] FAArchiveO = { "\uf187", "far" };
        public static string[] FAArchway = { "\uf557", "fa" };
        public static string[] FAArchwayO = { "\uf557", "far" };
        public static string[] FAArrowAltCircleDown = { "\uf358", "fa" };
        public static string[] FAArrowAltCircleDownO = { "\uf358", "far" };
        public static string[] FAArrowAltCircleLeft = { "\uf359", "fa" };
        public static string[] FAArrowAltCircleLeftO = { "\uf359", "far" };
        public static string[] FAArrowAltCircleRight = { "\uf35a", "fa" };
        public static string[] FAArrowAltCircleRightO = { "\uf35a", "far" };
        public static string[] FAArrowAltCircleUp = { "\uf35b", "fa" };
        public static string[] FAArrowAltCircleUpO = { "\uf35b", "far" };
        public static string[] FAArrowAltDown = { "\uf354", "fa" };
        public static string[] FAArrowAltDownO = { "\uf354", "far" };
        public static string[] FAArrowAltFromBottom = { "\uf346", "fa" };
        public static string[] FAArrowAltFromBottomO = { "\uf346", "far" };
        public static string[] FAArrowAltFromLeft = { "\uf347", "fa" };
        public static string[] FAArrowAltFromLeftO = { "\uf347", "far" };
        public static string[] FAArrowAltFromRight = { "\uf348", "fa" };
        public static string[] FAArrowAltFromRightO = { "\uf348", "far" };
        public static string[] FAArrowAltFromTop = { "\uf349", "fa" };
        public static string[] FAArrowAltFromTopO = { "\uf349", "far" };
        public static string[] FAArrowAltLeft = { "\uf355", "fa" };
        public static string[] FAArrowAltLeftO = { "\uf355", "far" };
        public static string[] FAArrowAltRight = { "\uf356", "fa" };
        public static string[] FAArrowAltRightO = { "\uf356", "far" };
        public static string[] FAArrowAltSquareDown = { "\uf350", "fa" };
        public static string[] FAArrowAltSquareDownO = { "\uf350", "far" };
        public static string[] FAArrowAltSquareLeft = { "\uf351", "fa" };
        public static string[] FAArrowAltSquareLeftO = { "\uf351", "far" };
        public static string[] FAArrowAltSquareRight = { "\uf352", "fa" };
        public static string[] FAArrowAltSquareRightO = { "\uf352", "far" };
        public static string[] FAArrowAltSquareUp = { "\uf353", "fa" };
        public static string[] FAArrowAltSquareUpO = { "\uf353", "far" };
        public static string[] FAArrowAltToBottom = { "\uf34a", "fa" };
        public static string[] FAArrowAltToBottomO = { "\uf34a", "far" };
        public static string[] FAArrowAltToLeft = { "\uf34b", "fa" };
        public static string[] FAArrowAltToLeftO = { "\uf34b", "far" };
        public static string[] FAArrowAltToRight = { "\uf34c", "fa" };
        public static string[] FAArrowAltToRightO = { "\uf34c", "far" };
        public static string[] FAArrowAltToTop = { "\uf34d", "fa" };
        public static string[] FAArrowAltToTopO = { "\uf34d", "far" };
        public static string[] FAArrowAltUp = { "\uf357", "fa" };
        public static string[] FAArrowAltUpO = { "\uf357", "far" };
        public static string[] FAArrowCircleDown = { "\uf0ab", "fa" };
        public static string[] FAArrowCircleDownO = { "\uf0ab", "far" };
        public static string[] FAArrowCircleLeft = { "\uf0a8", "fa" };
        public static string[] FAArrowCircleLeftO = { "\uf0a8", "far" };
        public static string[] FAArrowCircleRight = { "\uf0a9", "fa" };
        public static string[] FAArrowCircleRightO = { "\uf0a9", "far" };
        public static string[] FAArrowCircleUp = { "\uf0aa", "fa" };
        public static string[] FAArrowCircleUpO = { "\uf0aa", "far" };
        public static string[] FAArrowDown = { "\uf063", "fa" };
        public static string[] FAArrowDownO = { "\uf063", "far" };
        public static string[] FAArrowFromBottom = { "\uf342", "fa" };
        public static string[] FAArrowFromBottomO = { "\uf342", "far" };
        public static string[] FAArrowFromLeft = { "\uf343", "fa" };
        public static string[] FAArrowFromLeftO = { "\uf343", "far" };
        public static string[] FAArrowFromRight = { "\uf344", "fa" };
        public static string[] FAArrowFromRightO = { "\uf344", "far" };
        public static string[] FAArrowFromTop = { "\uf345", "fa" };
        public static string[] FAArrowFromTopO = { "\uf345", "far" };
        public static string[] FAArrowLeft = { "\uf060", "fa" };
        public static string[] FAArrowLeftO = { "\uf060", "far" };
        public static string[] FAArrowRight = { "\uf061", "fa" };
        public static string[] FAArrowRightO = { "\uf061", "far" };
        public static string[] FAArrowSquareDown = { "\uf339", "fa" };
        public static string[] FAArrowSquareDownO = { "\uf339", "far" };
        public static string[] FAArrowSquareLeft = { "\uf33a", "fa" };
        public static string[] FAArrowSquareLeftO = { "\uf33a", "far" };
        public static string[] FAArrowSquareRight = { "\uf33b", "fa" };
        public static string[] FAArrowSquareRightO = { "\uf33b", "far" };
        public static string[] FAArrowSquareUp = { "\uf33c", "fa" };
        public static string[] FAArrowSquareUpO = { "\uf33c", "far" };
        public static string[] FAArrowToBottom = { "\uf33d", "fa" };
        public static string[] FAArrowToBottomO = { "\uf33d", "far" };
        public static string[] FAArrowToLeft = { "\uf33e", "fa" };
        public static string[] FAArrowToLeftO = { "\uf33e", "far" };
        public static string[] FAArrowToRight = { "\uf340", "fa" };
        public static string[] FAArrowToRightO = { "\uf340", "far" };
        public static string[] FAArrowToTop = { "\uf341", "fa" };
        public static string[] FAArrowToTopO = { "\uf341", "far" };
        public static string[] FAArrowUp = { "\uf062", "fa" };
        public static string[] FAArrowUpO = { "\uf062", "far" };
        public static string[] FAArrows = { "\uf047", "fa" };
        public static string[] FAArrowsO = { "\uf047", "far" };
        public static string[] FAArrowsAlt = { "\uf0b2", "fa" };
        public static string[] FAArrowsAltO = { "\uf0b2", "far" };
        public static string[] FAArrowsAltH = { "\uf337", "fa" };
        public static string[] FAArrowsAltHO = { "\uf337", "far" };
        public static string[] FAArrowsAltV = { "\uf338", "fa" };
        public static string[] FAArrowsAltVO = { "\uf338", "far" };
        public static string[] FAArrowsH = { "\uf07e", "fa" };
        public static string[] FAArrowsHO = { "\uf07e", "far" };
        public static string[] FAArrowsV = { "\uf07d", "fa" };
        public static string[] FAArrowsVO = { "\uf07d", "far" };
        public static string[] FAArtstation = { "\uf77a", "fab" };
        public static string[] FAAssistiveListeningSystems = { "\uf2a2", "fa" };
        public static string[] FAAssistiveListeningSystemsO = { "\uf2a2", "far" };
        public static string[] FAAsterisk = { "\uf069", "fa" };
        public static string[] FAAsteriskO = { "\uf069", "far" };
        public static string[] FAAsymmetrik = { "\uf372", "fab" };
        public static string[] FAAt = { "\uf1fa", "fa" };
        public static string[] FAAtO = { "\uf1fa", "far" };
        public static string[] FAAtlas = { "\uf558", "fa" };
        public static string[] FAAtlasO = { "\uf558", "far" };
        public static string[] FAAtlassian = { "\uf77b", "fab" };
        public static string[] FAAtom = { "\uf5d2", "fa" };
        public static string[] FAAtomO = { "\uf5d2", "far" };
        public static string[] FAAtomAlt = { "\uf5d3", "fa" };
        public static string[] FAAtomAltO = { "\uf5d3", "far" };
        public static string[] FAAudible = { "\uf373", "fab" };
        public static string[] FAAudioDescription = { "\uf29e", "fa" };
        public static string[] FAAudioDescriptionO = { "\uf29e", "far" };
        public static string[] FAAutoprefixer = { "\uf41c", "fab" };
        public static string[] FAAvianex = { "\uf374", "fab" };
        public static string[] FAAviato = { "\uf421", "fab" };
        public static string[] FAAward = { "\uf559", "fa" };
        public static string[] FAAwardO = { "\uf559", "far" };
        public static string[] FAAws = { "\uf375", "fab" };
        public static string[] FAAxe = { "\uf6b2", "fa" };
        public static string[] FAAxeO = { "\uf6b2", "far" };
        public static string[] FAAxeBattle = { "\uf6b3", "fa" };
        public static string[] FAAxeBattleO = { "\uf6b3", "far" };
        public static string[] FABaby = { "\uf77c", "fa" };
        public static string[] FABabyO = { "\uf77c", "far" };
        public static string[] FABabyCarriage = { "\uf77d", "fa" };
        public static string[] FABabyCarriageO = { "\uf77d", "far" };
        public static string[] FABackpack = { "\uf5d4", "fa" };
        public static string[] FABackpackO = { "\uf5d4", "far" };
        public static string[] FABackspace = { "\uf55a", "fa" };
        public static string[] FABackspaceO = { "\uf55a", "far" };
        public static string[] FABackward = { "\uf04a", "fa" };
        public static string[] FABackwardO = { "\uf04a", "far" };
        public static string[] FABacon = { "\uf7e5", "fa" };
        public static string[] FABaconO = { "\uf7e5", "far" };
        public static string[] FABadge = { "\uf335", "fa" };
        public static string[] FABadgeO = { "\uf335", "far" };
        public static string[] FABadgeCheck = { "\uf336", "fa" };
        public static string[] FABadgeCheckO = { "\uf336", "far" };
        public static string[] FABadgeDollar = { "\uf645", "fa" };
        public static string[] FABadgeDollarO = { "\uf645", "far" };
        public static string[] FABadgePercent = { "\uf646", "fa" };
        public static string[] FABadgePercentO = { "\uf646", "far" };
        public static string[] FABadgerHoney = { "\uf6b4", "fa" };
        public static string[] FABadgerHoneyO = { "\uf6b4", "far" };
        public static string[] FABagsShopping = { "\uf847", "fa" };
        public static string[] FABagsShoppingO = { "\uf847", "far" };
        public static string[] FABalanceScale = { "\uf24e", "fa" };
        public static string[] FABalanceScaleO = { "\uf24e", "far" };
        public static string[] FABalanceScaleLeft = { "\uf515", "fa" };
        public static string[] FABalanceScaleLeftO = { "\uf515", "far" };
        public static string[] FABalanceScaleRight = { "\uf516", "fa" };
        public static string[] FABalanceScaleRightO = { "\uf516", "far" };
        public static string[] FABallPile = { "\uf77e", "fa" };
        public static string[] FABallPileO = { "\uf77e", "far" };
        public static string[] FABallot = { "\uf732", "fa" };
        public static string[] FABallotO = { "\uf732", "far" };
        public static string[] FABallotCheck = { "\uf733", "fa" };
        public static string[] FABallotCheckO = { "\uf733", "far" };
        public static string[] FABan = { "\uf05e", "fa" };
        public static string[] FABanO = { "\uf05e", "far" };
        public static string[] FABandAid = { "\uf462", "fa" };
        public static string[] FABandAidO = { "\uf462", "far" };
        public static string[] FABandcamp = { "\uf2d5", "fab" };
        public static string[] FABarcode = { "\uf02a", "fa" };
        public static string[] FABarcodeO = { "\uf02a", "far" };
        public static string[] FABarcodeAlt = { "\uf463", "fa" };
        public static string[] FABarcodeAltO = { "\uf463", "far" };
        public static string[] FABarcodeRead = { "\uf464", "fa" };
        public static string[] FABarcodeReadO = { "\uf464", "far" };
        public static string[] FABarcodeScan = { "\uf465", "fa" };
        public static string[] FABarcodeScanO = { "\uf465", "far" };
        public static string[] FABars = { "\uf0c9", "fa" };
        public static string[] FABarsO = { "\uf0c9", "far" };
        public static string[] FABaseball = { "\uf432", "fa" };
        public static string[] FABaseballO = { "\uf432", "far" };
        public static string[] FABaseballBall = { "\uf433", "fa" };
        public static string[] FABaseballBallO = { "\uf433", "far" };
        public static string[] FABasketballBall = { "\uf434", "fa" };
        public static string[] FABasketballBallO = { "\uf434", "far" };
        public static string[] FABasketballHoop = { "\uf435", "fa" };
        public static string[] FABasketballHoopO = { "\uf435", "far" };
        public static string[] FABat = { "\uf6b5", "fa" };
        public static string[] FABatO = { "\uf6b5", "far" };
        public static string[] FABath = { "\uf2cd", "fa" };
        public static string[] FABathO = { "\uf2cd", "far" };
        public static string[] FABatteryBolt = { "\uf376", "fa" };
        public static string[] FABatteryBoltO = { "\uf376", "far" };
        public static string[] FABatteryEmpty = { "\uf244", "fa" };
        public static string[] FABatteryEmptyO = { "\uf244", "far" };
        public static string[] FABatteryFull = { "\uf240", "fa" };
        public static string[] FABatteryFullO = { "\uf240", "far" };
        public static string[] FABatteryHalf = { "\uf242", "fa" };
        public static string[] FABatteryHalfO = { "\uf242", "far" };
        public static string[] FABatteryQuarter = { "\uf243", "fa" };
        public static string[] FABatteryQuarterO = { "\uf243", "far" };
        public static string[] FABatterySlash = { "\uf377", "fa" };
        public static string[] FABatterySlashO = { "\uf377", "far" };
        public static string[] FABatteryThreeQuarters = { "\uf241", "fa" };
        public static string[] FABatteryThreeQuartersO = { "\uf241", "far" };
        public static string[] FABattleNet = { "\uf835", "fab" };
        public static string[] FABed = { "\uf236", "fa" };
        public static string[] FABedO = { "\uf236", "far" };
        public static string[] FABeer = { "\uf0fc", "fa" };
        public static string[] FABeerO = { "\uf0fc", "far" };
        public static string[] FABehance = { "\uf1b4", "fab" };
        public static string[] FABehanceSquare = { "\uf1b5", "fab" };
        public static string[] FABell = { "\uf0f3", "fa" };
        public static string[] FABellO = { "\uf0f3", "far" };
        public static string[] FABellExclamation = { "\uf848", "fa" };
        public static string[] FABellExclamationO = { "\uf848", "far" };
        public static string[] FABellPlus = { "\uf849", "fa" };
        public static string[] FABellPlusO = { "\uf849", "far" };
        public static string[] FABellSchool = { "\uf5d5", "fa" };
        public static string[] FABellSchoolO = { "\uf5d5", "far" };
        public static string[] FABellSchoolSlash = { "\uf5d6", "fa" };
        public static string[] FABellSchoolSlashO = { "\uf5d6", "far" };
        public static string[] FABellSlash = { "\uf1f6", "fa" };
        public static string[] FABellSlashO = { "\uf1f6", "far" };
        public static string[] FABells = { "\uf77f", "fa" };
        public static string[] FABellsO = { "\uf77f", "far" };
        public static string[] FABezierCurve = { "\uf55b", "fa" };
        public static string[] FABezierCurveO = { "\uf55b", "far" };
        public static string[] FABible = { "\uf647", "fa" };
        public static string[] FABibleO = { "\uf647", "far" };
        public static string[] FABicycle = { "\uf206", "fa" };
        public static string[] FABicycleO = { "\uf206", "far" };
        public static string[] FABiking = { "\uf84a", "fa" };
        public static string[] FABikingO = { "\uf84a", "far" };
        public static string[] FABikingMountain = { "\uf84b", "fa" };
        public static string[] FABikingMountainO = { "\uf84b", "far" };
        public static string[] FABimobject = { "\uf378", "fab" };
        public static string[] FABinoculars = { "\uf1e5", "fa" };
        public static string[] FABinocularsO = { "\uf1e5", "far" };
        public static string[] FABiohazard = { "\uf780", "fa" };
        public static string[] FABiohazardO = { "\uf780", "far" };
        public static string[] FABirthdayCake = { "\uf1fd", "fa" };
        public static string[] FABirthdayCakeO = { "\uf1fd", "far" };
        public static string[] FABitbucket = { "\uf171", "fab" };
        public static string[] FABitcoin = { "\uf379", "fab" };
        public static string[] FABity = { "\uf37a", "fab" };
        public static string[] FABlackTie = { "\uf27e", "fab" };
        public static string[] FABlackberry = { "\uf37b", "fab" };
        public static string[] FABlanket = { "\uf498", "fa" };
        public static string[] FABlanketO = { "\uf498", "far" };
        public static string[] FABlender = { "\uf517", "fa" };
        public static string[] FABlenderO = { "\uf517", "far" };
        public static string[] FABlenderPhone = { "\uf6b6", "fa" };
        public static string[] FABlenderPhoneO = { "\uf6b6", "far" };
        public static string[] FABlind = { "\uf29d", "fa" };
        public static string[] FABlindO = { "\uf29d", "far" };
        public static string[] FABlog = { "\uf781", "fa" };
        public static string[] FABlogO = { "\uf781", "far" };
        public static string[] FABlogger = { "\uf37c", "fab" };
        public static string[] FABloggerB = { "\uf37d", "fab" };
        public static string[] FABluetooth = { "\uf293", "fab" };
        public static string[] FABluetoothB = { "\uf294", "fab" };
        public static string[] FABold = { "\uf032", "fa" };
        public static string[] FABoldO = { "\uf032", "far" };
        public static string[] FABolt = { "\uf0e7", "fa" };
        public static string[] FABoltO = { "\uf0e7", "far" };
        public static string[] FABomb = { "\uf1e2", "fa" };
        public static string[] FABombO = { "\uf1e2", "far" };
        public static string[] FABone = { "\uf5d7", "fa" };
        public static string[] FABoneO = { "\uf5d7", "far" };
        public static string[] FABoneBreak = { "\uf5d8", "fa" };
        public static string[] FABoneBreakO = { "\uf5d8", "far" };
        public static string[] FABong = { "\uf55c", "fa" };
        public static string[] FABongO = { "\uf55c", "far" };
        public static string[] FABook = { "\uf02d", "fa" };
        public static string[] FABookO = { "\uf02d", "far" };
        public static string[] FABookAlt = { "\uf5d9", "fa" };
        public static string[] FABookAltO = { "\uf5d9", "far" };
        public static string[] FABookDead = { "\uf6b7", "fa" };
        public static string[] FABookDeadO = { "\uf6b7", "far" };
        public static string[] FABookHeart = { "\uf499", "fa" };
        public static string[] FABookHeartO = { "\uf499", "far" };
        public static string[] FABookMedical = { "\uf7e6", "fa" };
        public static string[] FABookMedicalO = { "\uf7e6", "far" };
        public static string[] FABookOpen = { "\uf518", "fa" };
        public static string[] FABookOpenO = { "\uf518", "far" };
        public static string[] FABookReader = { "\uf5da", "fa" };
        public static string[] FABookReaderO = { "\uf5da", "far" };
        public static string[] FABookSpells = { "\uf6b8", "fa" };
        public static string[] FABookSpellsO = { "\uf6b8", "far" };
        public static string[] FABookUser = { "\uf7e7", "fa" };
        public static string[] FABookUserO = { "\uf7e7", "far" };
        public static string[] FABookmark = { "\uf02e", "fa" };
        public static string[] FABookmarkO = { "\uf02e", "far" };
        public static string[] FABooks = { "\uf5db", "fa" };
        public static string[] FABooksO = { "\uf5db", "far" };
        public static string[] FABooksMedical = { "\uf7e8", "fa" };
        public static string[] FABooksMedicalO = { "\uf7e8", "far" };
        public static string[] FABoot = { "\uf782", "fa" };
        public static string[] FABootO = { "\uf782", "far" };
        public static string[] FABoothCurtain = { "\uf734", "fa" };
        public static string[] FABoothCurtainO = { "\uf734", "far" };
        public static string[] FABootstrap = { "\uf836", "fab" };
        public static string[] FABorderAll = { "\uf84c", "fa" };
        public static string[] FABorderAllO = { "\uf84c", "far" };
        public static string[] FABorderBottom = { "\uf84d", "fa" };
        public static string[] FABorderBottomO = { "\uf84d", "far" };
        public static string[] FABorderInner = { "\uf84e", "fa" };
        public static string[] FABorderInnerO = { "\uf84e", "far" };
        public static string[] FABorderLeft = { "\uf84f", "fa" };
        public static string[] FABorderLeftO = { "\uf84f", "far" };
        public static string[] FABorderNone = { "\uf850", "fa" };
        public static string[] FABorderNoneO = { "\uf850", "far" };
        public static string[] FABorderOuter = { "\uf851", "fa" };
        public static string[] FABorderOuterO = { "\uf851", "far" };
        public static string[] FABorderRight = { "\uf852", "fa" };
        public static string[] FABorderRightO = { "\uf852", "far" };
        public static string[] FABorderStyle = { "\uf853", "fa" };
        public static string[] FABorderStyleO = { "\uf853", "far" };
        public static string[] FABorderStyleAlt = { "\uf854", "fa" };
        public static string[] FABorderStyleAltO = { "\uf854", "far" };
        public static string[] FABorderTop = { "\uf855", "fa" };
        public static string[] FABorderTopO = { "\uf855", "far" };
        public static string[] FABowArrow = { "\uf6b9", "fa" };
        public static string[] FABowArrowO = { "\uf6b9", "far" };
        public static string[] FABowlingBall = { "\uf436", "fa" };
        public static string[] FABowlingBallO = { "\uf436", "far" };
        public static string[] FABowlingPins = { "\uf437", "fa" };
        public static string[] FABowlingPinsO = { "\uf437", "far" };
        public static string[] FABox = { "\uf466", "fa" };
        public static string[] FABoxO = { "\uf466", "far" };
        public static string[] FABoxAlt = { "\uf49a", "fa" };
        public static string[] FABoxAltO = { "\uf49a", "far" };
        public static string[] FABoxBallot = { "\uf735", "fa" };
        public static string[] FABoxBallotO = { "\uf735", "far" };
        public static string[] FABoxCheck = { "\uf467", "fa" };
        public static string[] FABoxCheckO = { "\uf467", "far" };
        public static string[] FABoxFragile = { "\uf49b", "fa" };
        public static string[] FABoxFragileO = { "\uf49b", "far" };
        public static string[] FABoxFull = { "\uf49c", "fa" };
        public static string[] FABoxFullO = { "\uf49c", "far" };
        public static string[] FABoxHeart = { "\uf49d", "fa" };
        public static string[] FABoxHeartO = { "\uf49d", "far" };
        public static string[] FABoxOpen = { "\uf49e", "fa" };
        public static string[] FABoxOpenO = { "\uf49e", "far" };
        public static string[] FABoxUp = { "\uf49f", "fa" };
        public static string[] FABoxUpO = { "\uf49f", "far" };
        public static string[] FABoxUsd = { "\uf4a0", "fa" };
        public static string[] FABoxUsdO = { "\uf4a0", "far" };
        public static string[] FABoxes = { "\uf468", "fa" };
        public static string[] FABoxesO = { "\uf468", "far" };
        public static string[] FABoxesAlt = { "\uf4a1", "fa" };
        public static string[] FABoxesAltO = { "\uf4a1", "far" };
        public static string[] FABoxingGlove = { "\uf438", "fa" };
        public static string[] FABoxingGloveO = { "\uf438", "far" };
        public static string[] FABrackets = { "\uf7e9", "fa" };
        public static string[] FABracketsO = { "\uf7e9", "far" };
        public static string[] FABracketsCurly = { "\uf7ea", "fa" };
        public static string[] FABracketsCurlyO = { "\uf7ea", "far" };
        public static string[] FABraille = { "\uf2a1", "fa" };
        public static string[] FABrailleO = { "\uf2a1", "far" };
        public static string[] FABrain = { "\uf5dc", "fa" };
        public static string[] FABrainO = { "\uf5dc", "far" };
        public static string[] FABreadLoaf = { "\uf7eb", "fa" };
        public static string[] FABreadLoafO = { "\uf7eb", "far" };
        public static string[] FABreadSlice = { "\uf7ec", "fa" };
        public static string[] FABreadSliceO = { "\uf7ec", "far" };
        public static string[] FABriefcase = { "\uf0b1", "fa" };
        public static string[] FABriefcaseO = { "\uf0b1", "far" };
        public static string[] FABriefcaseMedical = { "\uf469", "fa" };
        public static string[] FABriefcaseMedicalO = { "\uf469", "far" };
        public static string[] FABringForward = { "\uf856", "fa" };
        public static string[] FABringForwardO = { "\uf856", "far" };
        public static string[] FABringFront = { "\uf857", "fa" };
        public static string[] FABringFrontO = { "\uf857", "far" };
        public static string[] FABroadcastTower = { "\uf519", "fa" };
        public static string[] FABroadcastTowerO = { "\uf519", "far" };
        public static string[] FABroom = { "\uf51a", "fa" };
        public static string[] FABroomO = { "\uf51a", "far" };
        public static string[] FABrowser = { "\uf37e", "fa" };
        public static string[] FABrowserO = { "\uf37e", "far" };
        public static string[] FABrush = { "\uf55d", "fa" };
        public static string[] FABrushO = { "\uf55d", "far" };
        public static string[] FABtc = { "\uf15a", "fab" };
        public static string[] FABuffer = { "\uf837", "fab" };
        public static string[] FABug = { "\uf188", "fa" };
        public static string[] FABugO = { "\uf188", "far" };
        public static string[] FABuilding = { "\uf1ad", "fa" };
        public static string[] FABuildingO = { "\uf1ad", "far" };
        public static string[] FABullhorn = { "\uf0a1", "fa" };
        public static string[] FABullhornO = { "\uf0a1", "far" };
        public static string[] FABullseye = { "\uf140", "fa" };
        public static string[] FABullseyeO = { "\uf140", "far" };
        public static string[] FABullseyeArrow = { "\uf648", "fa" };
        public static string[] FABullseyeArrowO = { "\uf648", "far" };
        public static string[] FABullseyePointer = { "\uf649", "fa" };
        public static string[] FABullseyePointerO = { "\uf649", "far" };
        public static string[] FABurgerSoda = { "\uf858", "fa" };
        public static string[] FABurgerSodaO = { "\uf858", "far" };
        public static string[] FABurn = { "\uf46a", "fa" };
        public static string[] FABurnO = { "\uf46a", "far" };
        public static string[] FABuromobelexperte = { "\uf37f", "fab" };
        public static string[] FABurrito = { "\uf7ed", "fa" };
        public static string[] FABurritoO = { "\uf7ed", "far" };
        public static string[] FABus = { "\uf207", "fa" };
        public static string[] FABusO = { "\uf207", "far" };
        public static string[] FABusAlt = { "\uf55e", "fa" };
        public static string[] FABusAltO = { "\uf55e", "far" };
        public static string[] FABusSchool = { "\uf5dd", "fa" };
        public static string[] FABusSchoolO = { "\uf5dd", "far" };
        public static string[] FABusinessTime = { "\uf64a", "fa" };
        public static string[] FABusinessTimeO = { "\uf64a", "far" };
        public static string[] FABuysellads = { "\uf20d", "fab" };
        public static string[] FACabinetFiling = { "\uf64b", "fa" };
        public static string[] FACabinetFilingO = { "\uf64b", "far" };
        public static string[] FACalculator = { "\uf1ec", "fa" };
        public static string[] FACalculatorO = { "\uf1ec", "far" };
        public static string[] FACalculatorAlt = { "\uf64c", "fa" };
        public static string[] FACalculatorAltO = { "\uf64c", "far" };
        public static string[] FACalendar = { "\uf133", "fa" };
        public static string[] FACalendarO = { "\uf133", "far" };
        public static string[] FACalendarAlt = { "\uf073", "fa" };
        public static string[] FACalendarAltO = { "\uf073", "far" };
        public static string[] FACalendarCheck = { "\uf274", "fa" };
        public static string[] FACalendarCheckO = { "\uf274", "far" };
        public static string[] FACalendarDay = { "\uf783", "fa" };
        public static string[] FACalendarDayO = { "\uf783", "far" };
        public static string[] FACalendarEdit = { "\uf333", "fa" };
        public static string[] FACalendarEditO = { "\uf333", "far" };
        public static string[] FACalendarExclamation = { "\uf334", "fa" };
        public static string[] FACalendarExclamationO = { "\uf334", "far" };
        public static string[] FACalendarMinus = { "\uf272", "fa" };
        public static string[] FACalendarMinusO = { "\uf272", "far" };
        public static string[] FACalendarPlus = { "\uf271", "fa" };
        public static string[] FACalendarPlusO = { "\uf271", "far" };
        public static string[] FACalendarStar = { "\uf736", "fa" };
        public static string[] FACalendarStarO = { "\uf736", "far" };
        public static string[] FACalendarTimes = { "\uf273", "fa" };
        public static string[] FACalendarTimesO = { "\uf273", "far" };
        public static string[] FACalendarWeek = { "\uf784", "fa" };
        public static string[] FACalendarWeekO = { "\uf784", "far" };
        public static string[] FACamera = { "\uf030", "fa" };
        public static string[] FACameraO = { "\uf030", "far" };
        public static string[] FACameraAlt = { "\uf332", "fa" };
        public static string[] FACameraAltO = { "\uf332", "far" };
        public static string[] FACameraRetro = { "\uf083", "fa" };
        public static string[] FACameraRetroO = { "\uf083", "far" };
        public static string[] FACampfire = { "\uf6ba", "fa" };
        public static string[] FACampfireO = { "\uf6ba", "far" };
        public static string[] FACampground = { "\uf6bb", "fa" };
        public static string[] FACampgroundO = { "\uf6bb", "far" };
        public static string[] FACanadianMapleLeaf = { "\uf785", "fab" };
        public static string[] FACandleHolder = { "\uf6bc", "fa" };
        public static string[] FACandleHolderO = { "\uf6bc", "far" };
        public static string[] FACandyCane = { "\uf786", "fa" };
        public static string[] FACandyCaneO = { "\uf786", "far" };
        public static string[] FACandyCorn = { "\uf6bd", "fa" };
        public static string[] FACandyCornO = { "\uf6bd", "far" };
        public static string[] FACannabis = { "\uf55f", "fa" };
        public static string[] FACannabisO = { "\uf55f", "far" };
        public static string[] FACapsules = { "\uf46b", "fa" };
        public static string[] FACapsulesO = { "\uf46b", "far" };
        public static string[] FACar = { "\uf1b9", "fa" };
        public static string[] FACarO = { "\uf1b9", "far" };
        public static string[] FACarAlt = { "\uf5de", "fa" };
        public static string[] FACarAltO = { "\uf5de", "far" };
        public static string[] FACarBattery = { "\uf5df", "fa" };
        public static string[] FACarBatteryO = { "\uf5df", "far" };
        public static string[] FACarBuilding = { "\uf859", "fa" };
        public static string[] FACarBuildingO = { "\uf859", "far" };
        public static string[] FACarBump = { "\uf5e0", "fa" };
        public static string[] FACarBumpO = { "\uf5e0", "far" };
        public static string[] FACarBus = { "\uf85a", "fa" };
        public static string[] FACarBusO = { "\uf85a", "far" };
        public static string[] FACarCrash = { "\uf5e1", "fa" };
        public static string[] FACarCrashO = { "\uf5e1", "far" };
        public static string[] FACarGarage = { "\uf5e2", "fa" };
        public static string[] FACarGarageO = { "\uf5e2", "far" };
        public static string[] FACarMechanic = { "\uf5e3", "fa" };
        public static string[] FACarMechanicO = { "\uf5e3", "far" };
        public static string[] FACarSide = { "\uf5e4", "fa" };
        public static string[] FACarSideO = { "\uf5e4", "far" };
        public static string[] FACarTilt = { "\uf5e5", "fa" };
        public static string[] FACarTiltO = { "\uf5e5", "far" };
        public static string[] FACarWash = { "\uf5e6", "fa" };
        public static string[] FACarWashO = { "\uf5e6", "far" };
        public static string[] FACaretCircleDown = { "\uf32d", "fa" };
        public static string[] FACaretCircleDownO = { "\uf32d", "far" };
        public static string[] FACaretCircleLeft = { "\uf32e", "fa" };
        public static string[] FACaretCircleLeftO = { "\uf32e", "far" };
        public static string[] FACaretCircleRight = { "\uf330", "fa" };
        public static string[] FACaretCircleRightO = { "\uf330", "far" };
        public static string[] FACaretCircleUp = { "\uf331", "fa" };
        public static string[] FACaretCircleUpO = { "\uf331", "far" };
        public static string[] FACaretDown = { "\uf0d7", "fa" };
        public static string[] FACaretDownO = { "\uf0d7", "far" };
        public static string[] FACaretLeft = { "\uf0d9", "fa" };
        public static string[] FACaretLeftO = { "\uf0d9", "far" };
        public static string[] FACaretRight = { "\uf0da", "fa" };
        public static string[] FACaretRightO = { "\uf0da", "far" };
        public static string[] FACaretSquareDown = { "\uf150", "fa" };
        public static string[] FACaretSquareDownO = { "\uf150", "far" };
        public static string[] FACaretSquareLeft = { "\uf191", "fa" };
        public static string[] FACaretSquareLeftO = { "\uf191", "far" };
        public static string[] FACaretSquareRight = { "\uf152", "fa" };
        public static string[] FACaretSquareRightO = { "\uf152", "far" };
        public static string[] FACaretSquareUp = { "\uf151", "fa" };
        public static string[] FACaretSquareUpO = { "\uf151", "far" };
        public static string[] FACaretUp = { "\uf0d8", "fa" };
        public static string[] FACaretUpO = { "\uf0d8", "far" };
        public static string[] FACarrot = { "\uf787", "fa" };
        public static string[] FACarrotO = { "\uf787", "far" };
        public static string[] FACars = { "\uf85b", "fa" };
        public static string[] FACarsO = { "\uf85b", "far" };
        public static string[] FACartArrowDown = { "\uf218", "fa" };
        public static string[] FACartArrowDownO = { "\uf218", "far" };
        public static string[] FACartPlus = { "\uf217", "fa" };
        public static string[] FACartPlusO = { "\uf217", "far" };
        public static string[] FACashRegister = { "\uf788", "fa" };
        public static string[] FACashRegisterO = { "\uf788", "far" };
        public static string[] FACat = { "\uf6be", "fa" };
        public static string[] FACatO = { "\uf6be", "far" };
        public static string[] FACauldron = { "\uf6bf", "fa" };
        public static string[] FACauldronO = { "\uf6bf", "far" };
        public static string[] FACcAmazonPay = { "\uf42d", "fab" };
        public static string[] FACcAmex = { "\uf1f3", "fab" };
        public static string[] FACcApplePay = { "\uf416", "fab" };
        public static string[] FACcDinersClub = { "\uf24c", "fab" };
        public static string[] FACcDiscover = { "\uf1f2", "fab" };
        public static string[] FACcJcb = { "\uf24b", "fab" };
        public static string[] FACcMastercard = { "\uf1f1", "fab" };
        public static string[] FACcPaypal = { "\uf1f4", "fab" };
        public static string[] FACcStripe = { "\uf1f5", "fab" };
        public static string[] FACcVisa = { "\uf1f0", "fab" };
        public static string[] FACentercode = { "\uf380", "fab" };
        public static string[] FACentos = { "\uf789", "fab" };
        public static string[] FACertificate = { "\uf0a3", "fa" };
        public static string[] FACertificateO = { "\uf0a3", "far" };
        public static string[] FAChair = { "\uf6c0", "fa" };
        public static string[] FAChairO = { "\uf6c0", "far" };
        public static string[] FAChairOffice = { "\uf6c1", "fa" };
        public static string[] FAChairOfficeO = { "\uf6c1", "far" };
        public static string[] FAChalkboard = { "\uf51b", "fa" };
        public static string[] FAChalkboardO = { "\uf51b", "far" };
        public static string[] FAChalkboardTeacher = { "\uf51c", "fa" };
        public static string[] FAChalkboardTeacherO = { "\uf51c", "far" };
        public static string[] FAChargingStation = { "\uf5e7", "fa" };
        public static string[] FAChargingStationO = { "\uf5e7", "far" };
        public static string[] FAChartArea = { "\uf1fe", "fa" };
        public static string[] FAChartAreaO = { "\uf1fe", "far" };
        public static string[] FAChartBar = { "\uf080", "fa" };
        public static string[] FAChartBarO = { "\uf080", "far" };
        public static string[] FAChartLine = { "\uf201", "fa" };
        public static string[] FAChartLineO = { "\uf201", "far" };
        public static string[] FAChartLineDown = { "\uf64d", "fa" };
        public static string[] FAChartLineDownO = { "\uf64d", "far" };
        public static string[] FAChartNetwork = { "\uf78a", "fa" };
        public static string[] FAChartNetworkO = { "\uf78a", "far" };
        public static string[] FAChartPie = { "\uf200", "fa" };
        public static string[] FAChartPieO = { "\uf200", "far" };
        public static string[] FAChartPieAlt = { "\uf64e", "fa" };
        public static string[] FAChartPieAltO = { "\uf64e", "far" };
        public static string[] FAChartScatter = { "\uf7ee", "fa" };
        public static string[] FAChartScatterO = { "\uf7ee", "far" };
        public static string[] FACheck = { "\uf00c", "fa" };
        public static string[] FACheckO = { "\uf00c", "far" };
        public static string[] FACheckCircle = { "\uf058", "fa" };
        public static string[] FACheckCircleO = { "\uf058", "far" };
        public static string[] FACheckDouble = { "\uf560", "fa" };
        public static string[] FACheckDoubleO = { "\uf560", "far" };
        public static string[] FACheckSquare = { "\uf14a", "fa" };
        public static string[] FACheckSquareO = { "\uf14a", "far" };
        public static string[] FACheese = { "\uf7ef", "fa" };
        public static string[] FACheeseO = { "\uf7ef", "far" };
        public static string[] FACheeseSwiss = { "\uf7f0", "fa" };
        public static string[] FACheeseSwissO = { "\uf7f0", "far" };
        public static string[] FACheeseburger = { "\uf7f1", "fa" };
        public static string[] FACheeseburgerO = { "\uf7f1", "far" };
        public static string[] FAChess = { "\uf439", "fa" };
        public static string[] FAChessO = { "\uf439", "far" };
        public static string[] FAChessBishop = { "\uf43a", "fa" };
        public static string[] FAChessBishopO = { "\uf43a", "far" };
        public static string[] FAChessBishopAlt = { "\uf43b", "fa" };
        public static string[] FAChessBishopAltO = { "\uf43b", "far" };
        public static string[] FAChessBoard = { "\uf43c", "fa" };
        public static string[] FAChessBoardO = { "\uf43c", "far" };
        public static string[] FAChessClock = { "\uf43d", "fa" };
        public static string[] FAChessClockO = { "\uf43d", "far" };
        public static string[] FAChessClockAlt = { "\uf43e", "fa" };
        public static string[] FAChessClockAltO = { "\uf43e", "far" };
        public static string[] FAChessKing = { "\uf43f", "fa" };
        public static string[] FAChessKingO = { "\uf43f", "far" };
        public static string[] FAChessKingAlt = { "\uf440", "fa" };
        public static string[] FAChessKingAltO = { "\uf440", "far" };
        public static string[] FAChessKnight = { "\uf441", "fa" };
        public static string[] FAChessKnightO = { "\uf441", "far" };
        public static string[] FAChessKnightAlt = { "\uf442", "fa" };
        public static string[] FAChessKnightAltO = { "\uf442", "far" };
        public static string[] FAChessPawn = { "\uf443", "fa" };
        public static string[] FAChessPawnO = { "\uf443", "far" };
        public static string[] FAChessPawnAlt = { "\uf444", "fa" };
        public static string[] FAChessPawnAltO = { "\uf444", "far" };
        public static string[] FAChessQueen = { "\uf445", "fa" };
        public static string[] FAChessQueenO = { "\uf445", "far" };
        public static string[] FAChessQueenAlt = { "\uf446", "fa" };
        public static string[] FAChessQueenAltO = { "\uf446", "far" };
        public static string[] FAChessRook = { "\uf447", "fa" };
        public static string[] FAChessRookO = { "\uf447", "far" };
        public static string[] FAChessRookAlt = { "\uf448", "fa" };
        public static string[] FAChessRookAltO = { "\uf448", "far" };
        public static string[] FAChevronCircleDown = { "\uf13a", "fa" };
        public static string[] FAChevronCircleDownO = { "\uf13a", "far" };
        public static string[] FAChevronCircleLeft = { "\uf137", "fa" };
        public static string[] FAChevronCircleLeftO = { "\uf137", "far" };
        public static string[] FAChevronCircleRight = { "\uf138", "fa" };
        public static string[] FAChevronCircleRightO = { "\uf138", "far" };
        public static string[] FAChevronCircleUp = { "\uf139", "fa" };
        public static string[] FAChevronCircleUpO = { "\uf139", "far" };
        public static string[] FAChevronDoubleDown = { "\uf322", "fa" };
        public static string[] FAChevronDoubleDownO = { "\uf322", "far" };
        public static string[] FAChevronDoubleLeft = { "\uf323", "fa" };
        public static string[] FAChevronDoubleLeftO = { "\uf323", "far" };
        public static string[] FAChevronDoubleRight = { "\uf324", "fa" };
        public static string[] FAChevronDoubleRightO = { "\uf324", "far" };
        public static string[] FAChevronDoubleUp = { "\uf325", "fa" };
        public static string[] FAChevronDoubleUpO = { "\uf325", "far" };
        public static string[] FAChevronDown = { "\uf078", "fa" };
        public static string[] FAChevronDownO = { "\uf078", "far" };
        public static string[] FAChevronLeft = { "\uf053", "fa" };
        public static string[] FAChevronLeftO = { "\uf053", "far" };
        public static string[] FAChevronRight = { "\uf054", "fa" };
        public static string[] FAChevronRightO = { "\uf054", "far" };
        public static string[] FAChevronSquareDown = { "\uf329", "fa" };
        public static string[] FAChevronSquareDownO = { "\uf329", "far" };
        public static string[] FAChevronSquareLeft = { "\uf32a", "fa" };
        public static string[] FAChevronSquareLeftO = { "\uf32a", "far" };
        public static string[] FAChevronSquareRight = { "\uf32b", "fa" };
        public static string[] FAChevronSquareRightO = { "\uf32b", "far" };
        public static string[] FAChevronSquareUp = { "\uf32c", "fa" };
        public static string[] FAChevronSquareUpO = { "\uf32c", "far" };
        public static string[] FAChevronUp = { "\uf077", "fa" };
        public static string[] FAChevronUpO = { "\uf077", "far" };
        public static string[] FAChild = { "\uf1ae", "fa" };
        public static string[] FAChildO = { "\uf1ae", "far" };
        public static string[] FAChimney = { "\uf78b", "fa" };
        public static string[] FAChimneyO = { "\uf78b", "far" };
        public static string[] FAChrome = { "\uf268", "fab" };
        public static string[] FAChromecast = { "\uf838", "fab" };
        public static string[] FAChurch = { "\uf51d", "fa" };
        public static string[] FAChurchO = { "\uf51d", "far" };
        public static string[] FACircle = { "\uf111", "fa" };
        public static string[] FACircleO = { "\uf111", "far" };
        public static string[] FACircleNotch = { "\uf1ce", "fa" };
        public static string[] FACircleNotchO = { "\uf1ce", "far" };
        public static string[] FACity = { "\uf64f", "fa" };
        public static string[] FACityO = { "\uf64f", "far" };
        public static string[] FAClawMarks = { "\uf6c2", "fa" };
        public static string[] FAClawMarksO = { "\uf6c2", "far" };
        public static string[] FAClinicMedical = { "\uf7f2", "fa" };
        public static string[] FAClinicMedicalO = { "\uf7f2", "far" };
        public static string[] FAClipboard = { "\uf328", "fa" };
        public static string[] FAClipboardO = { "\uf328", "far" };
        public static string[] FAClipboardCheck = { "\uf46c", "fa" };
        public static string[] FAClipboardCheckO = { "\uf46c", "far" };
        public static string[] FAClipboardList = { "\uf46d", "fa" };
        public static string[] FAClipboardListO = { "\uf46d", "far" };
        public static string[] FAClipboardListCheck = { "\uf737", "fa" };
        public static string[] FAClipboardListCheckO = { "\uf737", "far" };
        public static string[] FAClipboardPrescription = { "\uf5e8", "fa" };
        public static string[] FAClipboardPrescriptionO = { "\uf5e8", "far" };
        public static string[] FAClipboardUser = { "\uf7f3", "fa" };
        public static string[] FAClipboardUserO = { "\uf7f3", "far" };
        public static string[] FAClock = { "\uf017", "fa" };
        public static string[] FAClockO = { "\uf017", "far" };
        public static string[] FAClone = { "\uf24d", "fa" };
        public static string[] FACloneO = { "\uf24d", "far" };
        public static string[] FAClosedCaptioning = { "\uf20a", "fa" };
        public static string[] FAClosedCaptioningO = { "\uf20a", "far" };
        public static string[] FACloud = { "\uf0c2", "fa" };
        public static string[] FACloudO = { "\uf0c2", "far" };
        public static string[] FACloudDownload = { "\uf0ed", "fa" };
        public static string[] FACloudDownloadO = { "\uf0ed", "far" };
        public static string[] FACloudDownloadAlt = { "\uf381", "fa" };
        public static string[] FACloudDownloadAltO = { "\uf381", "far" };
        public static string[] FACloudDrizzle = { "\uf738", "fa" };
        public static string[] FACloudDrizzleO = { "\uf738", "far" };
        public static string[] FACloudHail = { "\uf739", "fa" };
        public static string[] FACloudHailO = { "\uf739", "far" };
        public static string[] FACloudHailMixed = { "\uf73a", "fa" };
        public static string[] FACloudHailMixedO = { "\uf73a", "far" };
        public static string[] FACloudMeatball = { "\uf73b", "fa" };
        public static string[] FACloudMeatballO = { "\uf73b", "far" };
        public static string[] FACloudMoon = { "\uf6c3", "fa" };
        public static string[] FACloudMoonO = { "\uf6c3", "far" };
        public static string[] FACloudMoonRain = { "\uf73c", "fa" };
        public static string[] FACloudMoonRainO = { "\uf73c", "far" };
        public static string[] FACloudRain = { "\uf73d", "fa" };
        public static string[] FACloudRainO = { "\uf73d", "far" };
        public static string[] FACloudRainbow = { "\uf73e", "fa" };
        public static string[] FACloudRainbowO = { "\uf73e", "far" };
        public static string[] FACloudShowers = { "\uf73f", "fa" };
        public static string[] FACloudShowersO = { "\uf73f", "far" };
        public static string[] FACloudShowersHeavy = { "\uf740", "fa" };
        public static string[] FACloudShowersHeavyO = { "\uf740", "far" };
        public static string[] FACloudSleet = { "\uf741", "fa" };
        public static string[] FACloudSleetO = { "\uf741", "far" };
        public static string[] FACloudSnow = { "\uf742", "fa" };
        public static string[] FACloudSnowO = { "\uf742", "far" };
        public static string[] FACloudSun = { "\uf6c4", "fa" };
        public static string[] FACloudSunO = { "\uf6c4", "far" };
        public static string[] FACloudSunRain = { "\uf743", "fa" };
        public static string[] FACloudSunRainO = { "\uf743", "far" };
        public static string[] FACloudUpload = { "\uf0ee", "fa" };
        public static string[] FACloudUploadO = { "\uf0ee", "far" };
        public static string[] FACloudUploadAlt = { "\uf382", "fa" };
        public static string[] FACloudUploadAltO = { "\uf382", "far" };
        public static string[] FAClouds = { "\uf744", "fa" };
        public static string[] FACloudsO = { "\uf744", "far" };
        public static string[] FACloudsMoon = { "\uf745", "fa" };
        public static string[] FACloudsMoonO = { "\uf745", "far" };
        public static string[] FACloudsSun = { "\uf746", "fa" };
        public static string[] FACloudsSunO = { "\uf746", "far" };
        public static string[] FACloudscale = { "\uf383", "fab" };
        public static string[] FACloudsmith = { "\uf384", "fab" };
        public static string[] FACloudversify = { "\uf385", "fab" };
        public static string[] FAClub = { "\uf327", "fa" };
        public static string[] FAClubO = { "\uf327", "far" };
        public static string[] FACocktail = { "\uf561", "fa" };
        public static string[] FACocktailO = { "\uf561", "far" };
        public static string[] FACode = { "\uf121", "fa" };
        public static string[] FACodeO = { "\uf121", "far" };
        public static string[] FACodeBranch = { "\uf126", "fa" };
        public static string[] FACodeBranchO = { "\uf126", "far" };
        public static string[] FACodeCommit = { "\uf386", "fa" };
        public static string[] FACodeCommitO = { "\uf386", "far" };
        public static string[] FACodeMerge = { "\uf387", "fa" };
        public static string[] FACodeMergeO = { "\uf387", "far" };
        public static string[] FACodepen = { "\uf1cb", "fab" };
        public static string[] FACodiepie = { "\uf284", "fab" };
        public static string[] FACoffee = { "\uf0f4", "fa" };
        public static string[] FACoffeeO = { "\uf0f4", "far" };
        public static string[] FACoffeeTogo = { "\uf6c5", "fa" };
        public static string[] FACoffeeTogoO = { "\uf6c5", "far" };
        public static string[] FACoffin = { "\uf6c6", "fa" };
        public static string[] FACoffinO = { "\uf6c6", "far" };
        public static string[] FACog = { "\uf013", "fa" };
        public static string[] FACogO = { "\uf013", "far" };
        public static string[] FACogs = { "\uf085", "fa" };
        public static string[] FACogsO = { "\uf085", "far" };
        public static string[] FACoin = { "\uf85c", "fa" };
        public static string[] FACoinO = { "\uf85c", "far" };
        public static string[] FACoins = { "\uf51e", "fa" };
        public static string[] FACoinsO = { "\uf51e", "far" };
        public static string[] FAColumns = { "\uf0db", "fa" };
        public static string[] FAColumnsO = { "\uf0db", "far" };
        public static string[] FAComment = { "\uf075", "fa" };
        public static string[] FACommentO = { "\uf075", "far" };
        public static string[] FACommentAlt = { "\uf27a", "fa" };
        public static string[] FACommentAltO = { "\uf27a", "far" };
        public static string[] FACommentAltCheck = { "\uf4a2", "fa" };
        public static string[] FACommentAltCheckO = { "\uf4a2", "far" };
        public static string[] FACommentAltDollar = { "\uf650", "fa" };
        public static string[] FACommentAltDollarO = { "\uf650", "far" };
        public static string[] FACommentAltDots = { "\uf4a3", "fa" };
        public static string[] FACommentAltDotsO = { "\uf4a3", "far" };
        public static string[] FACommentAltEdit = { "\uf4a4", "fa" };
        public static string[] FACommentAltEditO = { "\uf4a4", "far" };
        public static string[] FACommentAltExclamation = { "\uf4a5", "fa" };
        public static string[] FACommentAltExclamationO = { "\uf4a5", "far" };
        public static string[] FACommentAltLines = { "\uf4a6", "fa" };
        public static string[] FACommentAltLinesO = { "\uf4a6", "far" };
        public static string[] FACommentAltMedical = { "\uf7f4", "fa" };
        public static string[] FACommentAltMedicalO = { "\uf7f4", "far" };
        public static string[] FACommentAltMinus = { "\uf4a7", "fa" };
        public static string[] FACommentAltMinusO = { "\uf4a7", "far" };
        public static string[] FACommentAltPlus = { "\uf4a8", "fa" };
        public static string[] FACommentAltPlusO = { "\uf4a8", "far" };
        public static string[] FACommentAltSlash = { "\uf4a9", "fa" };
        public static string[] FACommentAltSlashO = { "\uf4a9", "far" };
        public static string[] FACommentAltSmile = { "\uf4aa", "fa" };
        public static string[] FACommentAltSmileO = { "\uf4aa", "far" };
        public static string[] FACommentAltTimes = { "\uf4ab", "fa" };
        public static string[] FACommentAltTimesO = { "\uf4ab", "far" };
        public static string[] FACommentCheck = { "\uf4ac", "fa" };
        public static string[] FACommentCheckO = { "\uf4ac", "far" };
        public static string[] FACommentDollar = { "\uf651", "fa" };
        public static string[] FACommentDollarO = { "\uf651", "far" };
        public static string[] FACommentDots = { "\uf4ad", "fa" };
        public static string[] FACommentDotsO = { "\uf4ad", "far" };
        public static string[] FACommentEdit = { "\uf4ae", "fa" };
        public static string[] FACommentEditO = { "\uf4ae", "far" };
        public static string[] FACommentExclamation = { "\uf4af", "fa" };
        public static string[] FACommentExclamationO = { "\uf4af", "far" };
        public static string[] FACommentLines = { "\uf4b0", "fa" };
        public static string[] FACommentLinesO = { "\uf4b0", "far" };
        public static string[] FACommentMedical = { "\uf7f5", "fa" };
        public static string[] FACommentMedicalO = { "\uf7f5", "far" };
        public static string[] FACommentMinus = { "\uf4b1", "fa" };
        public static string[] FACommentMinusO = { "\uf4b1", "far" };
        public static string[] FACommentPlus = { "\uf4b2", "fa" };
        public static string[] FACommentPlusO = { "\uf4b2", "far" };
        public static string[] FACommentSlash = { "\uf4b3", "fa" };
        public static string[] FACommentSlashO = { "\uf4b3", "far" };
        public static string[] FACommentSmile = { "\uf4b4", "fa" };
        public static string[] FACommentSmileO = { "\uf4b4", "far" };
        public static string[] FACommentTimes = { "\uf4b5", "fa" };
        public static string[] FACommentTimesO = { "\uf4b5", "far" };
        public static string[] FAComments = { "\uf086", "fa" };
        public static string[] FACommentsO = { "\uf086", "far" };
        public static string[] FACommentsAlt = { "\uf4b6", "fa" };
        public static string[] FACommentsAltO = { "\uf4b6", "far" };
        public static string[] FACommentsAltDollar = { "\uf652", "fa" };
        public static string[] FACommentsAltDollarO = { "\uf652", "far" };
        public static string[] FACommentsDollar = { "\uf653", "fa" };
        public static string[] FACommentsDollarO = { "\uf653", "far" };
        public static string[] FACompactDisc = { "\uf51f", "fa" };
        public static string[] FACompactDiscO = { "\uf51f", "far" };
        public static string[] FACompass = { "\uf14e", "fa" };
        public static string[] FACompassO = { "\uf14e", "far" };
        public static string[] FACompassSlash = { "\uf5e9", "fa" };
        public static string[] FACompassSlashO = { "\uf5e9", "far" };
        public static string[] FACompress = { "\uf066", "fa" };
        public static string[] FACompressO = { "\uf066", "far" };
        public static string[] FACompressAlt = { "\uf422", "fa" };
        public static string[] FACompressAltO = { "\uf422", "far" };
        public static string[] FACompressArrowsAlt = { "\uf78c", "fa" };
        public static string[] FACompressArrowsAltO = { "\uf78c", "far" };
        public static string[] FACompressWide = { "\uf326", "fa" };
        public static string[] FACompressWideO = { "\uf326", "far" };
        public static string[] FAConciergeBell = { "\uf562", "fa" };
        public static string[] FAConciergeBellO = { "\uf562", "far" };
        public static string[] FAConfluence = { "\uf78d", "fab" };
        public static string[] FAConnectdevelop = { "\uf20e", "fab" };
        public static string[] FAConstruction = { "\uf85d", "fa" };
        public static string[] FAConstructionO = { "\uf85d", "far" };
        public static string[] FAContainerStorage = { "\uf4b7", "fa" };
        public static string[] FAContainerStorageO = { "\uf4b7", "far" };
        public static string[] FAContao = { "\uf26d", "fab" };
        public static string[] FAConveyorBelt = { "\uf46e", "fa" };
        public static string[] FAConveyorBeltO = { "\uf46e", "far" };
        public static string[] FAConveyorBeltAlt = { "\uf46f", "fa" };
        public static string[] FAConveyorBeltAltO = { "\uf46f", "far" };
        public static string[] FACookie = { "\uf563", "fa" };
        public static string[] FACookieO = { "\uf563", "far" };
        public static string[] FACookieBite = { "\uf564", "fa" };
        public static string[] FACookieBiteO = { "\uf564", "far" };
        public static string[] FACopy = { "\uf0c5", "fa" };
        public static string[] FACopyO = { "\uf0c5", "far" };
        public static string[] FACopyright = { "\uf1f9", "fa" };
        public static string[] FACopyrightO = { "\uf1f9", "far" };
        public static string[] FACorn = { "\uf6c7", "fa" };
        public static string[] FACornO = { "\uf6c7", "far" };
        public static string[] FACouch = { "\uf4b8", "fa" };
        public static string[] FACouchO = { "\uf4b8", "far" };
        public static string[] FACow = { "\uf6c8", "fa" };
        public static string[] FACowO = { "\uf6c8", "far" };
        public static string[] FACpanel = { "\uf388", "fab" };
        public static string[] FACreativeCommons = { "\uf25e", "fab" };
        public static string[] FACreativeCommonsBy = { "\uf4e7", "fab" };
        public static string[] FACreativeCommonsNc = { "\uf4e8", "fab" };
        public static string[] FACreativeCommonsNcEu = { "\uf4e9", "fab" };
        public static string[] FACreativeCommonsNcJp = { "\uf4ea", "fab" };
        public static string[] FACreativeCommonsNd = { "\uf4eb", "fab" };
        public static string[] FACreativeCommonsPd = { "\uf4ec", "fab" };
        public static string[] FACreativeCommonsPdAlt = { "\uf4ed", "fab" };
        public static string[] FACreativeCommonsRemix = { "\uf4ee", "fab" };
        public static string[] FACreativeCommonsSa = { "\uf4ef", "fab" };
        public static string[] FACreativeCommonsSampling = { "\uf4f0", "fab" };
        public static string[] FACreativeCommonsSamplingPlus = { "\uf4f1", "fab" };
        public static string[] FACreativeCommonsShare = { "\uf4f2", "fab" };
        public static string[] FACreativeCommonsZero = { "\uf4f3", "fab" };
        public static string[] FACreditCard = { "\uf09d", "fa" };
        public static string[] FACreditCardO = { "\uf09d", "far" };
        public static string[] FACreditCardBlank = { "\uf389", "fa" };
        public static string[] FACreditCardBlankO = { "\uf389", "far" };
        public static string[] FACreditCardFront = { "\uf38a", "fa" };
        public static string[] FACreditCardFrontO = { "\uf38a", "far" };
        public static string[] FACricket = { "\uf449", "fa" };
        public static string[] FACricketO = { "\uf449", "far" };
        public static string[] FACriticalRole = { "\uf6c9", "fab" };
        public static string[] FACroissant = { "\uf7f6", "fa" };
        public static string[] FACroissantO = { "\uf7f6", "far" };
        public static string[] FACrop = { "\uf125", "fa" };
        public static string[] FACropO = { "\uf125", "far" };
        public static string[] FACropAlt = { "\uf565", "fa" };
        public static string[] FACropAltO = { "\uf565", "far" };
        public static string[] FACross = { "\uf654", "fa" };
        public static string[] FACrossO = { "\uf654", "far" };
        public static string[] FACrosshairs = { "\uf05b", "fa" };
        public static string[] FACrosshairsO = { "\uf05b", "far" };
        public static string[] FACrow = { "\uf520", "fa" };
        public static string[] FACrowO = { "\uf520", "far" };
        public static string[] FACrown = { "\uf521", "fa" };
        public static string[] FACrownO = { "\uf521", "far" };
        public static string[] FACrutch = { "\uf7f7", "fa" };
        public static string[] FACrutchO = { "\uf7f7", "far" };
        public static string[] FACrutches = { "\uf7f8", "fa" };
        public static string[] FACrutchesO = { "\uf7f8", "far" };
        public static string[] FACss3 = { "\uf13c", "fab" };
        public static string[] FACss3Alt = { "\uf38b", "fab" };
        public static string[] FACube = { "\uf1b2", "fa" };
        public static string[] FACubeO = { "\uf1b2", "far" };
        public static string[] FACubes = { "\uf1b3", "fa" };
        public static string[] FACubesO = { "\uf1b3", "far" };
        public static string[] FACurling = { "\uf44a", "fa" };
        public static string[] FACurlingO = { "\uf44a", "far" };
        public static string[] FACut = { "\uf0c4", "fa" };
        public static string[] FACutO = { "\uf0c4", "far" };
        public static string[] FACuttlefish = { "\uf38c", "fab" };
        public static string[] FADAndD = { "\uf38d", "fab" };
        public static string[] FADAndDBeyond = { "\uf6ca", "fab" };
        public static string[] FADagger = { "\uf6cb", "fa" };
        public static string[] FADaggerO = { "\uf6cb", "far" };
        public static string[] FADashcube = { "\uf210", "fab" };
        public static string[] FADatabase = { "\uf1c0", "fa" };
        public static string[] FADatabaseO = { "\uf1c0", "far" };
        public static string[] FADeaf = { "\uf2a4", "fa" };
        public static string[] FADeafO = { "\uf2a4", "far" };
        public static string[] FADebug = { "\uf7f9", "fa" };
        public static string[] FADebugO = { "\uf7f9", "far" };
        public static string[] FADeer = { "\uf78e", "fa" };
        public static string[] FADeerO = { "\uf78e", "far" };
        public static string[] FADeerRudolph = { "\uf78f", "fa" };
        public static string[] FADeerRudolphO = { "\uf78f", "far" };
        public static string[] FADelicious = { "\uf1a5", "fab" };
        public static string[] FADemocrat = { "\uf747", "fa" };
        public static string[] FADemocratO = { "\uf747", "far" };
        public static string[] FADeploydog = { "\uf38e", "fab" };
        public static string[] FADeskpro = { "\uf38f", "fab" };
        public static string[] FADesktop = { "\uf108", "fa" };
        public static string[] FADesktopO = { "\uf108", "far" };
        public static string[] FADesktopAlt = { "\uf390", "fa" };
        public static string[] FADesktopAltO = { "\uf390", "far" };
        public static string[] FADev = { "\uf6cc", "fab" };
        public static string[] FADeviantart = { "\uf1bd", "fab" };
        public static string[] FADewpoint = { "\uf748", "fa" };
        public static string[] FADewpointO = { "\uf748", "far" };
        public static string[] FADharmachakra = { "\uf655", "fa" };
        public static string[] FADharmachakraO = { "\uf655", "far" };
        public static string[] FADhl = { "\uf790", "fab" };
        public static string[] FADiagnoses = { "\uf470", "fa" };
        public static string[] FADiagnosesO = { "\uf470", "far" };
        public static string[] FADiamond = { "\uf219", "fa" };
        public static string[] FADiamondO = { "\uf219", "far" };
        public static string[] FADiaspora = { "\uf791", "fab" };
        public static string[] FADice = { "\uf522", "fa" };
        public static string[] FADiceO = { "\uf522", "far" };
        public static string[] FADiceD10 = { "\uf6cd", "fa" };
        public static string[] FADiceD10O = { "\uf6cd", "far" };
        public static string[] FADiceD12 = { "\uf6ce", "fa" };
        public static string[] FADiceD12O = { "\uf6ce", "far" };
        public static string[] FADiceD20 = { "\uf6cf", "fa" };
        public static string[] FADiceD20O = { "\uf6cf", "far" };
        public static string[] FADiceD4 = { "\uf6d0", "fa" };
        public static string[] FADiceD4O = { "\uf6d0", "far" };
        public static string[] FADiceD6 = { "\uf6d1", "fa" };
        public static string[] FADiceD6O = { "\uf6d1", "far" };
        public static string[] FADiceD8 = { "\uf6d2", "fa" };
        public static string[] FADiceD8O = { "\uf6d2", "far" };
        public static string[] FADiceFive = { "\uf523", "fa" };
        public static string[] FADiceFiveO = { "\uf523", "far" };
        public static string[] FADiceFour = { "\uf524", "fa" };
        public static string[] FADiceFourO = { "\uf524", "far" };
        public static string[] FADiceOne = { "\uf525", "fa" };
        public static string[] FADiceOneO = { "\uf525", "far" };
        public static string[] FADiceSix = { "\uf526", "fa" };
        public static string[] FADiceSixO = { "\uf526", "far" };
        public static string[] FADiceThree = { "\uf527", "fa" };
        public static string[] FADiceThreeO = { "\uf527", "far" };
        public static string[] FADiceTwo = { "\uf528", "fa" };
        public static string[] FADiceTwoO = { "\uf528", "far" };
        public static string[] FADigg = { "\uf1a6", "fab" };
        public static string[] FADigging = { "\uf85e", "fa" };
        public static string[] FADiggingO = { "\uf85e", "far" };
        public static string[] FADigitalOcean = { "\uf391", "fab" };
        public static string[] FADigitalTachograph = { "\uf566", "fa" };
        public static string[] FADigitalTachographO = { "\uf566", "far" };
        public static string[] FADiploma = { "\uf5ea", "fa" };
        public static string[] FADiplomaO = { "\uf5ea", "far" };
        public static string[] FADirections = { "\uf5eb", "fa" };
        public static string[] FADirectionsO = { "\uf5eb", "far" };
        public static string[] FADiscord = { "\uf392", "fab" };
        public static string[] FADiscourse = { "\uf393", "fab" };
        public static string[] FADisease = { "\uf7fa", "fa" };
        public static string[] FADiseaseO = { "\uf7fa", "far" };
        public static string[] FADivide = { "\uf529", "fa" };
        public static string[] FADivideO = { "\uf529", "far" };
        public static string[] FADizzy = { "\uf567", "fa" };
        public static string[] FADizzyO = { "\uf567", "far" };
        public static string[] FADna = { "\uf471", "fa" };
        public static string[] FADnaO = { "\uf471", "far" };
        public static string[] FADoNotEnter = { "\uf5ec", "fa" };
        public static string[] FADoNotEnterO = { "\uf5ec", "far" };
        public static string[] FADochub = { "\uf394", "fab" };
        public static string[] FADocker = { "\uf395", "fab" };
        public static string[] FADog = { "\uf6d3", "fa" };
        public static string[] FADogO = { "\uf6d3", "far" };
        public static string[] FADogLeashed = { "\uf6d4", "fa" };
        public static string[] FADogLeashedO = { "\uf6d4", "far" };
        public static string[] FADollarSign = { "\uf155", "fa" };
        public static string[] FADollarSignO = { "\uf155", "far" };
        public static string[] FADolly = { "\uf472", "fa" };
        public static string[] FADollyO = { "\uf472", "far" };
        public static string[] FADollyEmpty = { "\uf473", "fa" };
        public static string[] FADollyEmptyO = { "\uf473", "far" };
        public static string[] FADollyFlatbed = { "\uf474", "fa" };
        public static string[] FADollyFlatbedO = { "\uf474", "far" };
        public static string[] FADollyFlatbedAlt = { "\uf475", "fa" };
        public static string[] FADollyFlatbedAltO = { "\uf475", "far" };
        public static string[] FADollyFlatbedEmpty = { "\uf476", "fa" };
        public static string[] FADollyFlatbedEmptyO = { "\uf476", "far" };
        public static string[] FADonate = { "\uf4b9", "fa" };
        public static string[] FADonateO = { "\uf4b9", "far" };
        public static string[] FADoorClosed = { "\uf52a", "fa" };
        public static string[] FADoorClosedO = { "\uf52a", "far" };
        public static string[] FADoorOpen = { "\uf52b", "fa" };
        public static string[] FADoorOpenO = { "\uf52b", "far" };
        public static string[] FADotCircle = { "\uf192", "fa" };
        public static string[] FADotCircleO = { "\uf192", "far" };
        public static string[] FADove = { "\uf4ba", "fa" };
        public static string[] FADoveO = { "\uf4ba", "far" };
        public static string[] FADownload = { "\uf019", "fa" };
        public static string[] FADownloadO = { "\uf019", "far" };
        public static string[] FADraft2digital = { "\uf396", "fab" };
        public static string[] FADraftingCompass = { "\uf568", "fa" };
        public static string[] FADraftingCompassO = { "\uf568", "far" };
        public static string[] FADragon = { "\uf6d5", "fa" };
        public static string[] FADragonO = { "\uf6d5", "far" };
        public static string[] FADrawCircle = { "\uf5ed", "fa" };
        public static string[] FADrawCircleO = { "\uf5ed", "far" };
        public static string[] FADrawPolygon = { "\uf5ee", "fa" };
        public static string[] FADrawPolygonO = { "\uf5ee", "far" };
        public static string[] FADrawSquare = { "\uf5ef", "fa" };
        public static string[] FADrawSquareO = { "\uf5ef", "far" };
        public static string[] FADreidel = { "\uf792", "fa" };
        public static string[] FADreidelO = { "\uf792", "far" };
        public static string[] FADribbble = { "\uf17d", "fab" };
        public static string[] FADribbbleSquare = { "\uf397", "fab" };
        public static string[] FADrone = { "\uf85f", "fa" };
        public static string[] FADroneO = { "\uf85f", "far" };
        public static string[] FADroneAlt = { "\uf860", "fa" };
        public static string[] FADroneAltO = { "\uf860", "far" };
        public static string[] FADropbox = { "\uf16b", "fab" };
        public static string[] FADrum = { "\uf569", "fa" };
        public static string[] FADrumO = { "\uf569", "far" };
        public static string[] FADrumSteelpan = { "\uf56a", "fa" };
        public static string[] FADrumSteelpanO = { "\uf56a", "far" };
        public static string[] FADrumstick = { "\uf6d6", "fa" };
        public static string[] FADrumstickO = { "\uf6d6", "far" };
        public static string[] FADrumstickBite = { "\uf6d7", "fa" };
        public static string[] FADrumstickBiteO = { "\uf6d7", "far" };
        public static string[] FADrupal = { "\uf1a9", "fab" };
        public static string[] FADryer = { "\uf861", "fa" };
        public static string[] FADryerO = { "\uf861", "far" };
        public static string[] FADryerAlt = { "\uf862", "fa" };
        public static string[] FADryerAltO = { "\uf862", "far" };
        public static string[] FADuck = { "\uf6d8", "fa" };
        public static string[] FADuckO = { "\uf6d8", "far" };
        public static string[] FADumbbell = { "\uf44b", "fa" };
        public static string[] FADumbbellO = { "\uf44b", "far" };
        public static string[] FADumpster = { "\uf793", "fa" };
        public static string[] FADumpsterO = { "\uf793", "far" };
        public static string[] FADumpsterFire = { "\uf794", "fa" };
        public static string[] FADumpsterFireO = { "\uf794", "far" };
        public static string[] FADungeon = { "\uf6d9", "fa" };
        public static string[] FADungeonO = { "\uf6d9", "far" };
        public static string[] FADyalog = { "\uf399", "fab" };
        public static string[] FAEar = { "\uf5f0", "fa" };
        public static string[] FAEarO = { "\uf5f0", "far" };
        public static string[] FAEarMuffs = { "\uf795", "fa" };
        public static string[] FAEarMuffsO = { "\uf795", "far" };
        public static string[] FAEarlybirds = { "\uf39a", "fab" };
        public static string[] FAEbay = { "\uf4f4", "fab" };
        public static string[] FAEclipse = { "\uf749", "fa" };
        public static string[] FAEclipseO = { "\uf749", "far" };
        public static string[] FAEclipseAlt = { "\uf74a", "fa" };
        public static string[] FAEclipseAltO = { "\uf74a", "far" };
        public static string[] FAEdge = { "\uf282", "fab" };
        public static string[] FAEdit = { "\uf044", "fa" };
        public static string[] FAEditO = { "\uf044", "far" };
        public static string[] FAEgg = { "\uf7fb", "fa" };
        public static string[] FAEggO = { "\uf7fb", "far" };
        public static string[] FAEggFried = { "\uf7fc", "fa" };
        public static string[] FAEggFriedO = { "\uf7fc", "far" };
        public static string[] FAEject = { "\uf052", "fa" };
        public static string[] FAEjectO = { "\uf052", "far" };
        public static string[] FAElementor = { "\uf430", "fab" };
        public static string[] FAElephant = { "\uf6da", "fa" };
        public static string[] FAElephantO = { "\uf6da", "far" };
        public static string[] FAEllipsisH = { "\uf141", "fa" };
        public static string[] FAEllipsisHO = { "\uf141", "far" };
        public static string[] FAEllipsisHAlt = { "\uf39b", "fa" };
        public static string[] FAEllipsisHAltO = { "\uf39b", "far" };
        public static string[] FAEllipsisV = { "\uf142", "fa" };
        public static string[] FAEllipsisVO = { "\uf142", "far" };
        public static string[] FAEllipsisVAlt = { "\uf39c", "fa" };
        public static string[] FAEllipsisVAltO = { "\uf39c", "far" };
        public static string[] FAEllo = { "\uf5f1", "fab" };
        public static string[] FAEmber = { "\uf423", "fab" };
        public static string[] FAEmpire = { "\uf1d1", "fab" };
        public static string[] FAEmptySet = { "\uf656", "fa" };
        public static string[] FAEmptySetO = { "\uf656", "far" };
        public static string[] FAEngineWarning = { "\uf5f2", "fa" };
        public static string[] FAEngineWarningO = { "\uf5f2", "far" };
        public static string[] FAEnvelope = { "\uf0e0", "fa" };
        public static string[] FAEnvelopeO = { "\uf0e0", "far" };
        public static string[] FAEnvelopeOpen = { "\uf2b6", "fa" };
        public static string[] FAEnvelopeOpenO = { "\uf2b6", "far" };
        public static string[] FAEnvelopeOpenDollar = { "\uf657", "fa" };
        public static string[] FAEnvelopeOpenDollarO = { "\uf657", "far" };
        public static string[] FAEnvelopeOpenText = { "\uf658", "fa" };
        public static string[] FAEnvelopeOpenTextO = { "\uf658", "far" };
        public static string[] FAEnvelopeSquare = { "\uf199", "fa" };
        public static string[] FAEnvelopeSquareO = { "\uf199", "far" };
        public static string[] FAEnvira = { "\uf299", "fab" };
        public static string[] FAEquals = { "\uf52c", "fa" };
        public static string[] FAEqualsO = { "\uf52c", "far" };
        public static string[] FAEraser = { "\uf12d", "fa" };
        public static string[] FAEraserO = { "\uf12d", "far" };
        public static string[] FAErlang = { "\uf39d", "fab" };
        public static string[] FAEthereum = { "\uf42e", "fab" };
        public static string[] FAEthernet = { "\uf796", "fa" };
        public static string[] FAEthernetO = { "\uf796", "far" };
        public static string[] FAEtsy = { "\uf2d7", "fab" };
        public static string[] FAEuroSign = { "\uf153", "fa" };
        public static string[] FAEuroSignO = { "\uf153", "far" };
        public static string[] FAEvernote = { "\uf839", "fab" };
        public static string[] FAExchange = { "\uf0ec", "fa" };
        public static string[] FAExchangeO = { "\uf0ec", "far" };
        public static string[] FAExchangeAlt = { "\uf362", "fa" };
        public static string[] FAExchangeAltO = { "\uf362", "far" };
        public static string[] FAExclamation = { "\uf12a", "fa" };
        public static string[] FAExclamationO = { "\uf12a", "far" };
        public static string[] FAExclamationCircle = { "\uf06a", "fa" };
        public static string[] FAExclamationCircleO = { "\uf06a", "far" };
        public static string[] FAExclamationSquare = { "\uf321", "fa" };
        public static string[] FAExclamationSquareO = { "\uf321", "far" };
        public static string[] FAExclamationTriangle = { "\uf071", "fa" };
        public static string[] FAExclamationTriangleO = { "\uf071", "far" };
        public static string[] FAExpand = { "\uf065", "fa" };
        public static string[] FAExpandO = { "\uf065", "far" };
        public static string[] FAExpandAlt = { "\uf424", "fa" };
        public static string[] FAExpandAltO = { "\uf424", "far" };
        public static string[] FAExpandArrows = { "\uf31d", "fa" };
        public static string[] FAExpandArrowsO = { "\uf31d", "far" };
        public static string[] FAExpandArrowsAlt = { "\uf31e", "fa" };
        public static string[] FAExpandArrowsAltO = { "\uf31e", "far" };
        public static string[] FAExpandWide = { "\uf320", "fa" };
        public static string[] FAExpandWideO = { "\uf320", "far" };
        public static string[] FAExpeditedssl = { "\uf23e", "fab" };
        public static string[] FAExternalLink = { "\uf08e", "fa" };
        public static string[] FAExternalLinkO = { "\uf08e", "far" };
        public static string[] FAExternalLinkAlt = { "\uf35d", "fa" };
        public static string[] FAExternalLinkAltO = { "\uf35d", "far" };
        public static string[] FAExternalLinkSquare = { "\uf14c", "fa" };
        public static string[] FAExternalLinkSquareO = { "\uf14c", "far" };
        public static string[] FAExternalLinkSquareAlt = { "\uf360", "fa" };
        public static string[] FAExternalLinkSquareAltO = { "\uf360", "far" };
        public static string[] FAEye = { "\uf06e", "fa" };
        public static string[] FAEyeO = { "\uf06e", "far" };
        public static string[] FAEyeDropper = { "\uf1fb", "fa" };
        public static string[] FAEyeDropperO = { "\uf1fb", "far" };
        public static string[] FAEyeEvil = { "\uf6db", "fa" };
        public static string[] FAEyeEvilO = { "\uf6db", "far" };
        public static string[] FAEyeSlash = { "\uf070", "fa" };
        public static string[] FAEyeSlashO = { "\uf070", "far" };
        public static string[] FAFacebook = { "\uf09a", "fab" };
        public static string[] FAFacebookF = { "\uf39e", "fab" };
        public static string[] FAFacebookMessenger = { "\uf39f", "fab" };
        public static string[] FAFacebookSquare = { "\uf082", "fab" };
        public static string[] FAFan = { "\uf863", "fa" };
        public static string[] FAFanO = { "\uf863", "far" };
        public static string[] FAFantasyFlightGames = { "\uf6dc", "fab" };
        public static string[] FAFarm = { "\uf864", "fa" };
        public static string[] FAFarmO = { "\uf864", "far" };
        public static string[] FAFastBackward = { "\uf049", "fa" };
        public static string[] FAFastBackwardO = { "\uf049", "far" };
        public static string[] FAFastForward = { "\uf050", "fa" };
        public static string[] FAFastForwardO = { "\uf050", "far" };
        public static string[] FAFax = { "\uf1ac", "fa" };
        public static string[] FAFaxO = { "\uf1ac", "far" };
        public static string[] FAFeather = { "\uf52d", "fa" };
        public static string[] FAFeatherO = { "\uf52d", "far" };
        public static string[] FAFeatherAlt = { "\uf56b", "fa" };
        public static string[] FAFeatherAltO = { "\uf56b", "far" };
        public static string[] FAFedex = { "\uf797", "fab" };
        public static string[] FAFedora = { "\uf798", "fab" };
        public static string[] FAFemale = { "\uf182", "fa" };
        public static string[] FAFemaleO = { "\uf182", "far" };
        public static string[] FAFieldHockey = { "\uf44c", "fa" };
        public static string[] FAFieldHockeyO = { "\uf44c", "far" };
        public static string[] FAFighterJet = { "\uf0fb", "fa" };
        public static string[] FAFighterJetO = { "\uf0fb", "far" };
        public static string[] FAFigma = { "\uf799", "fab" };
        public static string[] FAFile = { "\uf15b", "fa" };
        public static string[] FAFileO = { "\uf15b", "far" };
        public static string[] FAFileAlt = { "\uf15c", "fa" };
        public static string[] FAFileAltO = { "\uf15c", "far" };
        public static string[] FAFileArchive = { "\uf1c6", "fa" };
        public static string[] FAFileArchiveO = { "\uf1c6", "far" };
        public static string[] FAFileAudio = { "\uf1c7", "fa" };
        public static string[] FAFileAudioO = { "\uf1c7", "far" };
        public static string[] FAFileCertificate = { "\uf5f3", "fa" };
        public static string[] FAFileCertificateO = { "\uf5f3", "far" };
        public static string[] FAFileChartLine = { "\uf659", "fa" };
        public static string[] FAFileChartLineO = { "\uf659", "far" };
        public static string[] FAFileChartPie = { "\uf65a", "fa" };
        public static string[] FAFileChartPieO = { "\uf65a", "far" };
        public static string[] FAFileCheck = { "\uf316", "fa" };
        public static string[] FAFileCheckO = { "\uf316", "far" };
        public static string[] FAFileCode = { "\uf1c9", "fa" };
        public static string[] FAFileCodeO = { "\uf1c9", "far" };
        public static string[] FAFileContract = { "\uf56c", "fa" };
        public static string[] FAFileContractO = { "\uf56c", "far" };
        public static string[] FAFileCsv = { "\uf6dd", "fa" };
        public static string[] FAFileCsvO = { "\uf6dd", "far" };
        public static string[] FAFileDownload = { "\uf56d", "fa" };
        public static string[] FAFileDownloadO = { "\uf56d", "far" };
        public static string[] FAFileEdit = { "\uf31c", "fa" };
        public static string[] FAFileEditO = { "\uf31c", "far" };
        public static string[] FAFileExcel = { "\uf1c3", "fa" };
        public static string[] FAFileExcelO = { "\uf1c3", "far" };
        public static string[] FAFileExclamation = { "\uf31a", "fa" };
        public static string[] FAFileExclamationO = { "\uf31a", "far" };
        public static string[] FAFileExport = { "\uf56e", "fa" };
        public static string[] FAFileExportO = { "\uf56e", "far" };
        public static string[] FAFileImage = { "\uf1c5", "fa" };
        public static string[] FAFileImageO = { "\uf1c5", "far" };
        public static string[] FAFileImport = { "\uf56f", "fa" };
        public static string[] FAFileImportO = { "\uf56f", "far" };
        public static string[] FAFileInvoice = { "\uf570", "fa" };
        public static string[] FAFileInvoiceO = { "\uf570", "far" };
        public static string[] FAFileInvoiceDollar = { "\uf571", "fa" };
        public static string[] FAFileInvoiceDollarO = { "\uf571", "far" };
        public static string[] FAFileMedical = { "\uf477", "fa" };
        public static string[] FAFileMedicalO = { "\uf477", "far" };
        public static string[] FAFileMedicalAlt = { "\uf478", "fa" };
        public static string[] FAFileMedicalAltO = { "\uf478", "far" };
        public static string[] FAFileMinus = { "\uf318", "fa" };
        public static string[] FAFileMinusO = { "\uf318", "far" };
        public static string[] FAFilePdf = { "\uf1c1", "fa" };
        public static string[] FAFilePdfO = { "\uf1c1", "far" };
        public static string[] FAFilePlus = { "\uf319", "fa" };
        public static string[] FAFilePlusO = { "\uf319", "far" };
        public static string[] FAFilePowerpoint = { "\uf1c4", "fa" };
        public static string[] FAFilePowerpointO = { "\uf1c4", "far" };
        public static string[] FAFilePrescription = { "\uf572", "fa" };
        public static string[] FAFilePrescriptionO = { "\uf572", "far" };
        public static string[] FAFileSearch = { "\uf865", "fa" };
        public static string[] FAFileSearchO = { "\uf865", "far" };
        public static string[] FAFileSignature = { "\uf573", "fa" };
        public static string[] FAFileSignatureO = { "\uf573", "far" };
        public static string[] FAFileSpreadsheet = { "\uf65b", "fa" };
        public static string[] FAFileSpreadsheetO = { "\uf65b", "far" };
        public static string[] FAFileTimes = { "\uf317", "fa" };
        public static string[] FAFileTimesO = { "\uf317", "far" };
        public static string[] FAFileUpload = { "\uf574", "fa" };
        public static string[] FAFileUploadO = { "\uf574", "far" };
        public static string[] FAFileUser = { "\uf65c", "fa" };
        public static string[] FAFileUserO = { "\uf65c", "far" };
        public static string[] FAFileVideo = { "\uf1c8", "fa" };
        public static string[] FAFileVideoO = { "\uf1c8", "far" };
        public static string[] FAFileWord = { "\uf1c2", "fa" };
        public static string[] FAFileWordO = { "\uf1c2", "far" };
        public static string[] FAFilesMedical = { "\uf7fd", "fa" };
        public static string[] FAFilesMedicalO = { "\uf7fd", "far" };
        public static string[] FAFill = { "\uf575", "fa" };
        public static string[] FAFillO = { "\uf575", "far" };
        public static string[] FAFillDrip = { "\uf576", "fa" };
        public static string[] FAFillDripO = { "\uf576", "far" };
        public static string[] FAFilm = { "\uf008", "fa" };
        public static string[] FAFilmO = { "\uf008", "far" };
        public static string[] FAFilmAlt = { "\uf3a0", "fa" };
        public static string[] FAFilmAltO = { "\uf3a0", "far" };
        public static string[] FAFilter = { "\uf0b0", "fa" };
        public static string[] FAFilterO = { "\uf0b0", "far" };
        public static string[] FAFingerprint = { "\uf577", "fa" };
        public static string[] FAFingerprintO = { "\uf577", "far" };
        public static string[] FAFire = { "\uf06d", "fa" };
        public static string[] FAFireO = { "\uf06d", "far" };
        public static string[] FAFireAlt = { "\uf7e4", "fa" };
        public static string[] FAFireAltO = { "\uf7e4", "far" };
        public static string[] FAFireExtinguisher = { "\uf134", "fa" };
        public static string[] FAFireExtinguisherO = { "\uf134", "far" };
        public static string[] FAFireSmoke = { "\uf74b", "fa" };
        public static string[] FAFireSmokeO = { "\uf74b", "far" };
        public static string[] FAFirefox = { "\uf269", "fab" };
        public static string[] FAFireplace = { "\uf79a", "fa" };
        public static string[] FAFireplaceO = { "\uf79a", "far" };
        public static string[] FAFirstAid = { "\uf479", "fa" };
        public static string[] FAFirstAidO = { "\uf479", "far" };
        public static string[] FAFirstOrder = { "\uf2b0", "fab" };
        public static string[] FAFirstOrderAlt = { "\uf50a", "fab" };
        public static string[] FAFirstdraft = { "\uf3a1", "fab" };
        public static string[] FAFish = { "\uf578", "fa" };
        public static string[] FAFishO = { "\uf578", "far" };
        public static string[] FAFishCooked = { "\uf7fe", "fa" };
        public static string[] FAFishCookedO = { "\uf7fe", "far" };
        public static string[] FAFistRaised = { "\uf6de", "fa" };
        public static string[] FAFistRaisedO = { "\uf6de", "far" };
        public static string[] FAFlag = { "\uf024", "fa" };
        public static string[] FAFlagO = { "\uf024", "far" };
        public static string[] FAFlagAlt = { "\uf74c", "fa" };
        public static string[] FAFlagAltO = { "\uf74c", "far" };
        public static string[] FAFlagCheckered = { "\uf11e", "fa" };
        public static string[] FAFlagCheckeredO = { "\uf11e", "far" };
        public static string[] FAFlagUsa = { "\uf74d", "fa" };
        public static string[] FAFlagUsaO = { "\uf74d", "far" };
        public static string[] FAFlame = { "\uf6df", "fa" };
        public static string[] FAFlameO = { "\uf6df", "far" };
        public static string[] FAFlask = { "\uf0c3", "fa" };
        public static string[] FAFlaskO = { "\uf0c3", "far" };
        public static string[] FAFlaskPoison = { "\uf6e0", "fa" };
        public static string[] FAFlaskPoisonO = { "\uf6e0", "far" };
        public static string[] FAFlaskPotion = { "\uf6e1", "fa" };
        public static string[] FAFlaskPotionO = { "\uf6e1", "far" };
        public static string[] FAFlickr = { "\uf16e", "fab" };
        public static string[] FAFlipboard = { "\uf44d", "fab" };
        public static string[] FAFlower = { "\uf7ff", "fa" };
        public static string[] FAFlowerO = { "\uf7ff", "far" };
        public static string[] FAFlowerDaffodil = { "\uf800", "fa" };
        public static string[] FAFlowerDaffodilO = { "\uf800", "far" };
        public static string[] FAFlowerTulip = { "\uf801", "fa" };
        public static string[] FAFlowerTulipO = { "\uf801", "far" };
        public static string[] FAFlushed = { "\uf579", "fa" };
        public static string[] FAFlushedO = { "\uf579", "far" };
        public static string[] FAFly = { "\uf417", "fab" };
        public static string[] FAFog = { "\uf74e", "fa" };
        public static string[] FAFogO = { "\uf74e", "far" };
        public static string[] FAFolder = { "\uf07b", "fa" };
        public static string[] FAFolderO = { "\uf07b", "far" };
        public static string[] FAFolderMinus = { "\uf65d", "fa" };
        public static string[] FAFolderMinusO = { "\uf65d", "far" };
        public static string[] FAFolderOpen = { "\uf07c", "fa" };
        public static string[] FAFolderOpenO = { "\uf07c", "far" };
        public static string[] FAFolderPlus = { "\uf65e", "fa" };
        public static string[] FAFolderPlusO = { "\uf65e", "far" };
        public static string[] FAFolderTimes = { "\uf65f", "fa" };
        public static string[] FAFolderTimesO = { "\uf65f", "far" };
        public static string[] FAFolderTree = { "\uf802", "fa" };
        public static string[] FAFolderTreeO = { "\uf802", "far" };
        public static string[] FAFolders = { "\uf660", "fa" };
        public static string[] FAFoldersO = { "\uf660", "far" };
        public static string[] FAFont = { "\uf031", "fa" };
        public static string[] FAFontO = { "\uf031", "far" };
        public static string[] FAFontAwesome = { "\uf2b4", "fab" };
        public static string[] FAFontAwesomeAlt = { "\uf35c", "fab" };
        public static string[] FAFontAwesomeFlag = { "\uf425", "fab" };
        public static string[] FAFontAwesomeLogoFull = { "\uf4e6", "fab" };
        public static string[] FAFontAwesomeLogoFullO = { "\uf4e6", "far" };
        public static string[] FAFontCase = { "\uf866", "fa" };
        public static string[] FAFontCaseO = { "\uf866", "far" };
        public static string[] FAFonticons = { "\uf280", "fab" };
        public static string[] FAFonticonsFi = { "\uf3a2", "fab" };
        public static string[] FAFootballBall = { "\uf44e", "fa" };
        public static string[] FAFootballBallO = { "\uf44e", "far" };
        public static string[] FAFootballHelmet = { "\uf44f", "fa" };
        public static string[] FAFootballHelmetO = { "\uf44f", "far" };
        public static string[] FAForklift = { "\uf47a", "fa" };
        public static string[] FAForkliftO = { "\uf47a", "far" };
        public static string[] FAFortAwesome = { "\uf286", "fab" };
        public static string[] FAFortAwesomeAlt = { "\uf3a3", "fab" };
        public static string[] FAForumbee = { "\uf211", "fab" };
        public static string[] FAForward = { "\uf04e", "fa" };
        public static string[] FAForwardO = { "\uf04e", "far" };
        public static string[] FAFoursquare = { "\uf180", "fab" };
        public static string[] FAFragile = { "\uf4bb", "fa" };
        public static string[] FAFragileO = { "\uf4bb", "far" };
        public static string[] FAFreeCodeCamp = { "\uf2c5", "fab" };
        public static string[] FAFreebsd = { "\uf3a4", "fab" };
        public static string[] FAFrenchFries = { "\uf803", "fa" };
        public static string[] FAFrenchFriesO = { "\uf803", "far" };
        public static string[] FAFrog = { "\uf52e", "fa" };
        public static string[] FAFrogO = { "\uf52e", "far" };
        public static string[] FAFrostyHead = { "\uf79b", "fa" };
        public static string[] FAFrostyHeadO = { "\uf79b", "far" };
        public static string[] FAFrown = { "\uf119", "fa" };
        public static string[] FAFrownO = { "\uf119", "far" };
        public static string[] FAFrownOpen = { "\uf57a", "fa" };
        public static string[] FAFrownOpenO = { "\uf57a", "far" };
        public static string[] FAFulcrum = { "\uf50b", "fab" };
        public static string[] FAFunction = { "\uf661", "fa" };
        public static string[] FAFunctionO = { "\uf661", "far" };
        public static string[] FAFunnelDollar = { "\uf662", "fa" };
        public static string[] FAFunnelDollarO = { "\uf662", "far" };
        public static string[] FAFutbol = { "\uf1e3", "fa" };
        public static string[] FAFutbolO = { "\uf1e3", "far" };
        public static string[] FAGalacticRepublic = { "\uf50c", "fab" };
        public static string[] FAGalacticSenate = { "\uf50d", "fab" };
        public static string[] FAGameBoard = { "\uf867", "fa" };
        public static string[] FAGameBoardO = { "\uf867", "far" };
        public static string[] FAGameBoardAlt = { "\uf868", "fa" };
        public static string[] FAGameBoardAltO = { "\uf868", "far" };
        public static string[] FAGamepad = { "\uf11b", "fa" };
        public static string[] FAGamepadO = { "\uf11b", "far" };
        public static string[] FAGasPump = { "\uf52f", "fa" };
        public static string[] FAGasPumpO = { "\uf52f", "far" };
        public static string[] FAGasPumpSlash = { "\uf5f4", "fa" };
        public static string[] FAGasPumpSlashO = { "\uf5f4", "far" };
        public static string[] FAGavel = { "\uf0e3", "fa" };
        public static string[] FAGavelO = { "\uf0e3", "far" };
        public static string[] FAGem = { "\uf3a5", "fa" };
        public static string[] FAGemO = { "\uf3a5", "far" };
        public static string[] FAGenderless = { "\uf22d", "fa" };
        public static string[] FAGenderlessO = { "\uf22d", "far" };
        public static string[] FAGetPocket = { "\uf265", "fab" };
        public static string[] FAGg = { "\uf260", "fab" };
        public static string[] FAGgCircle = { "\uf261", "fab" };
        public static string[] FAGhost = { "\uf6e2", "fa" };
        public static string[] FAGhostO = { "\uf6e2", "far" };
        public static string[] FAGift = { "\uf06b", "fa" };
        public static string[] FAGiftO = { "\uf06b", "far" };
        public static string[] FAGiftCard = { "\uf663", "fa" };
        public static string[] FAGiftCardO = { "\uf663", "far" };
        public static string[] FAGifts = { "\uf79c", "fa" };
        public static string[] FAGiftsO = { "\uf79c", "far" };
        public static string[] FAGingerbreadMan = { "\uf79d", "fa" };
        public static string[] FAGingerbreadManO = { "\uf79d", "far" };
        public static string[] FAGit = { "\uf1d3", "fab" };
        public static string[] FAGitAlt = { "\uf841", "fab" };
        public static string[] FAGitSquare = { "\uf1d2", "fab" };
        public static string[] FAGithub = { "\uf09b", "fab" };
        public static string[] FAGithubAlt = { "\uf113", "fab" };
        public static string[] FAGithubSquare = { "\uf092", "fab" };
        public static string[] FAGitkraken = { "\uf3a6", "fab" };
        public static string[] FAGitlab = { "\uf296", "fab" };
        public static string[] FAGitter = { "\uf426", "fab" };
        public static string[] FAGlass = { "\uf804", "fa" };
        public static string[] FAGlassO = { "\uf804", "far" };
        public static string[] FAGlassChampagne = { "\uf79e", "fa" };
        public static string[] FAGlassChampagneO = { "\uf79e", "far" };
        public static string[] FAGlassCheers = { "\uf79f", "fa" };
        public static string[] FAGlassCheersO = { "\uf79f", "far" };
        public static string[] FAGlassCitrus = { "\uf869", "fa" };
        public static string[] FAGlassCitrusO = { "\uf869", "far" };
        public static string[] FAGlassMartini = { "\uf000", "fa" };
        public static string[] FAGlassMartiniO = { "\uf000", "far" };
        public static string[] FAGlassMartiniAlt = { "\uf57b", "fa" };
        public static string[] FAGlassMartiniAltO = { "\uf57b", "far" };
        public static string[] FAGlassWhiskey = { "\uf7a0", "fa" };
        public static string[] FAGlassWhiskeyO = { "\uf7a0", "far" };
        public static string[] FAGlassWhiskeyRocks = { "\uf7a1", "fa" };
        public static string[] FAGlassWhiskeyRocksO = { "\uf7a1", "far" };
        public static string[] FAGlasses = { "\uf530", "fa" };
        public static string[] FAGlassesO = { "\uf530", "far" };
        public static string[] FAGlassesAlt = { "\uf5f5", "fa" };
        public static string[] FAGlassesAltO = { "\uf5f5", "far" };
        public static string[] FAGlide = { "\uf2a5", "fab" };
        public static string[] FAGlideG = { "\uf2a6", "fab" };
        public static string[] FAGlobe = { "\uf0ac", "fa" };
        public static string[] FAGlobeO = { "\uf0ac", "far" };
        public static string[] FAGlobeAfrica = { "\uf57c", "fa" };
        public static string[] FAGlobeAfricaO = { "\uf57c", "far" };
        public static string[] FAGlobeAmericas = { "\uf57d", "fa" };
        public static string[] FAGlobeAmericasO = { "\uf57d", "far" };
        public static string[] FAGlobeAsia = { "\uf57e", "fa" };
        public static string[] FAGlobeAsiaO = { "\uf57e", "far" };
        public static string[] FAGlobeEurope = { "\uf7a2", "fa" };
        public static string[] FAGlobeEuropeO = { "\uf7a2", "far" };
        public static string[] FAGlobeSnow = { "\uf7a3", "fa" };
        public static string[] FAGlobeSnowO = { "\uf7a3", "far" };
        public static string[] FAGlobeStand = { "\uf5f6", "fa" };
        public static string[] FAGlobeStandO = { "\uf5f6", "far" };
        public static string[] FAGofore = { "\uf3a7", "fab" };
        public static string[] FAGolfBall = { "\uf450", "fa" };
        public static string[] FAGolfBallO = { "\uf450", "far" };
        public static string[] FAGolfClub = { "\uf451", "fa" };
        public static string[] FAGolfClubO = { "\uf451", "far" };
        public static string[] FAGoodreads = { "\uf3a8", "fab" };
        public static string[] FAGoodreadsG = { "\uf3a9", "fab" };
        public static string[] FAGoogle = { "\uf1a0", "fab" };
        public static string[] FAGoogleDrive = { "\uf3aa", "fab" };
        public static string[] FAGooglePlay = { "\uf3ab", "fab" };
        public static string[] FAGooglePlus = { "\uf2b3", "fab" };
        public static string[] FAGooglePlusG = { "\uf0d5", "fab" };
        public static string[] FAGooglePlusSquare = { "\uf0d4", "fab" };
        public static string[] FAGoogleWallet = { "\uf1ee", "fab" };
        public static string[] FAGopuram = { "\uf664", "fa" };
        public static string[] FAGopuramO = { "\uf664", "far" };
        public static string[] FAGraduationCap = { "\uf19d", "fa" };
        public static string[] FAGraduationCapO = { "\uf19d", "far" };
        public static string[] FAGratipay = { "\uf184", "fab" };
        public static string[] FAGrav = { "\uf2d6", "fab" };
        public static string[] FAGreaterThan = { "\uf531", "fa" };
        public static string[] FAGreaterThanO = { "\uf531", "far" };
        public static string[] FAGreaterThanEqual = { "\uf532", "fa" };
        public static string[] FAGreaterThanEqualO = { "\uf532", "far" };
        public static string[] FAGrimace = { "\uf57f", "fa" };
        public static string[] FAGrimaceO = { "\uf57f", "far" };
        public static string[] FAGrin = { "\uf580", "fa" };
        public static string[] FAGrinO = { "\uf580", "far" };
        public static string[] FAGrinAlt = { "\uf581", "fa" };
        public static string[] FAGrinAltO = { "\uf581", "far" };
        public static string[] FAGrinBeam = { "\uf582", "fa" };
        public static string[] FAGrinBeamO = { "\uf582", "far" };
        public static string[] FAGrinBeamSweat = { "\uf583", "fa" };
        public static string[] FAGrinBeamSweatO = { "\uf583", "far" };
        public static string[] FAGrinHearts = { "\uf584", "fa" };
        public static string[] FAGrinHeartsO = { "\uf584", "far" };
        public static string[] FAGrinSquint = { "\uf585", "fa" };
        public static string[] FAGrinSquintO = { "\uf585", "far" };
        public static string[] FAGrinSquintTears = { "\uf586", "fa" };
        public static string[] FAGrinSquintTearsO = { "\uf586", "far" };
        public static string[] FAGrinStars = { "\uf587", "fa" };
        public static string[] FAGrinStarsO = { "\uf587", "far" };
        public static string[] FAGrinTears = { "\uf588", "fa" };
        public static string[] FAGrinTearsO = { "\uf588", "far" };
        public static string[] FAGrinTongue = { "\uf589", "fa" };
        public static string[] FAGrinTongueO = { "\uf589", "far" };
        public static string[] FAGrinTongueSquint = { "\uf58a", "fa" };
        public static string[] FAGrinTongueSquintO = { "\uf58a", "far" };
        public static string[] FAGrinTongueWink = { "\uf58b", "fa" };
        public static string[] FAGrinTongueWinkO = { "\uf58b", "far" };
        public static string[] FAGrinWink = { "\uf58c", "fa" };
        public static string[] FAGrinWinkO = { "\uf58c", "far" };
        public static string[] FAGripHorizontal = { "\uf58d", "fa" };
        public static string[] FAGripHorizontalO = { "\uf58d", "far" };
        public static string[] FAGripLines = { "\uf7a4", "fa" };
        public static string[] FAGripLinesO = { "\uf7a4", "far" };
        public static string[] FAGripLinesVertical = { "\uf7a5", "fa" };
        public static string[] FAGripLinesVerticalO = { "\uf7a5", "far" };
        public static string[] FAGripVertical = { "\uf58e", "fa" };
        public static string[] FAGripVerticalO = { "\uf58e", "far" };
        public static string[] FAGripfire = { "\uf3ac", "fab" };
        public static string[] FAGrunt = { "\uf3ad", "fab" };
        public static string[] FAGuitar = { "\uf7a6", "fa" };
        public static string[] FAGuitarO = { "\uf7a6", "far" };
        public static string[] FAGulp = { "\uf3ae", "fab" };
        public static string[] FAHSquare = { "\uf0fd", "fa" };
        public static string[] FAHSquareO = { "\uf0fd", "far" };
        public static string[] FAH1 = { "\uf313", "fa" };
        public static string[] FAH1O = { "\uf313", "far" };
        public static string[] FAH2 = { "\uf314", "fa" };
        public static string[] FAH2O = { "\uf314", "far" };
        public static string[] FAH3 = { "\uf315", "fa" };
        public static string[] FAH3O = { "\uf315", "far" };
        public static string[] FAH4 = { "\uf86a", "fa" };
        public static string[] FAH4O = { "\uf86a", "far" };
        public static string[] FAHackerNews = { "\uf1d4", "fab" };
        public static string[] FAHackerNewsSquare = { "\uf3af", "fab" };
        public static string[] FAHackerrank = { "\uf5f7", "fab" };
        public static string[] FAHamburger = { "\uf805", "fa" };
        public static string[] FAHamburgerO = { "\uf805", "far" };
        public static string[] FAHammer = { "\uf6e3", "fa" };
        public static string[] FAHammerO = { "\uf6e3", "far" };
        public static string[] FAHammerWar = { "\uf6e4", "fa" };
        public static string[] FAHammerWarO = { "\uf6e4", "far" };
        public static string[] FAHamsa = { "\uf665", "fa" };
        public static string[] FAHamsaO = { "\uf665", "far" };
        public static string[] FAHandHeart = { "\uf4bc", "fa" };
        public static string[] FAHandHeartO = { "\uf4bc", "far" };
        public static string[] FAHandHolding = { "\uf4bd", "fa" };
        public static string[] FAHandHoldingO = { "\uf4bd", "far" };
        public static string[] FAHandHoldingBox = { "\uf47b", "fa" };
        public static string[] FAHandHoldingBoxO = { "\uf47b", "far" };
        public static string[] FAHandHoldingHeart = { "\uf4be", "fa" };
        public static string[] FAHandHoldingHeartO = { "\uf4be", "far" };
        public static string[] FAHandHoldingMagic = { "\uf6e5", "fa" };
        public static string[] FAHandHoldingMagicO = { "\uf6e5", "far" };
        public static string[] FAHandHoldingSeedling = { "\uf4bf", "fa" };
        public static string[] FAHandHoldingSeedlingO = { "\uf4bf", "far" };
        public static string[] FAHandHoldingUsd = { "\uf4c0", "fa" };
        public static string[] FAHandHoldingUsdO = { "\uf4c0", "far" };
        public static string[] FAHandHoldingWater = { "\uf4c1", "fa" };
        public static string[] FAHandHoldingWaterO = { "\uf4c1", "far" };
        public static string[] FAHandLizard = { "\uf258", "fa" };
        public static string[] FAHandLizardO = { "\uf258", "far" };
        public static string[] FAHandMiddleFinger = { "\uf806", "fa" };
        public static string[] FAHandMiddleFingerO = { "\uf806", "far" };
        public static string[] FAHandPaper = { "\uf256", "fa" };
        public static string[] FAHandPaperO = { "\uf256", "far" };
        public static string[] FAHandPeace = { "\uf25b", "fa" };
        public static string[] FAHandPeaceO = { "\uf25b", "far" };
        public static string[] FAHandPointDown = { "\uf0a7", "fa" };
        public static string[] FAHandPointDownO = { "\uf0a7", "far" };
        public static string[] FAHandPointLeft = { "\uf0a5", "fa" };
        public static string[] FAHandPointLeftO = { "\uf0a5", "far" };
        public static string[] FAHandPointRight = { "\uf0a4", "fa" };
        public static string[] FAHandPointRightO = { "\uf0a4", "far" };
        public static string[] FAHandPointUp = { "\uf0a6", "fa" };
        public static string[] FAHandPointUpO = { "\uf0a6", "far" };
        public static string[] FAHandPointer = { "\uf25a", "fa" };
        public static string[] FAHandPointerO = { "\uf25a", "far" };
        public static string[] FAHandReceiving = { "\uf47c", "fa" };
        public static string[] FAHandReceivingO = { "\uf47c", "far" };
        public static string[] FAHandRock = { "\uf255", "fa" };
        public static string[] FAHandRockO = { "\uf255", "far" };
        public static string[] FAHandScissors = { "\uf257", "fa" };
        public static string[] FAHandScissorsO = { "\uf257", "far" };
        public static string[] FAHandSpock = { "\uf259", "fa" };
        public static string[] FAHandSpockO = { "\uf259", "far" };
        public static string[] FAHands = { "\uf4c2", "fa" };
        public static string[] FAHandsO = { "\uf4c2", "far" };
        public static string[] FAHandsHeart = { "\uf4c3", "fa" };
        public static string[] FAHandsHeartO = { "\uf4c3", "far" };
        public static string[] FAHandsHelping = { "\uf4c4", "fa" };
        public static string[] FAHandsHelpingO = { "\uf4c4", "far" };
        public static string[] FAHandsUsd = { "\uf4c5", "fa" };
        public static string[] FAHandsUsdO = { "\uf4c5", "far" };
        public static string[] FAHandshake = { "\uf2b5", "fa" };
        public static string[] FAHandshakeO = { "\uf2b5", "far" };
        public static string[] FAHandshakeAlt = { "\uf4c6", "fa" };
        public static string[] FAHandshakeAltO = { "\uf4c6", "far" };
        public static string[] FAHanukiah = { "\uf6e6", "fa" };
        public static string[] FAHanukiahO = { "\uf6e6", "far" };
        public static string[] FAHardHat = { "\uf807", "fa" };
        public static string[] FAHardHatO = { "\uf807", "far" };
        public static string[] FAHashtag = { "\uf292", "fa" };
        public static string[] FAHashtagO = { "\uf292", "far" };
        public static string[] FAHatChef = { "\uf86b", "fa" };
        public static string[] FAHatChefO = { "\uf86b", "far" };
        public static string[] FAHatSanta = { "\uf7a7", "fa" };
        public static string[] FAHatSantaO = { "\uf7a7", "far" };
        public static string[] FAHatWinter = { "\uf7a8", "fa" };
        public static string[] FAHatWinterO = { "\uf7a8", "far" };
        public static string[] FAHatWitch = { "\uf6e7", "fa" };
        public static string[] FAHatWitchO = { "\uf6e7", "far" };
        public static string[] FAHatWizard = { "\uf6e8", "fa" };
        public static string[] FAHatWizardO = { "\uf6e8", "far" };
        public static string[] FAHaykal = { "\uf666", "fa" };
        public static string[] FAHaykalO = { "\uf666", "far" };
        public static string[] FAHdd = { "\uf0a0", "fa" };
        public static string[] FAHddO = { "\uf0a0", "far" };
        public static string[] FAHeadSide = { "\uf6e9", "fa" };
        public static string[] FAHeadSideO = { "\uf6e9", "far" };
        public static string[] FAHeadSideBrain = { "\uf808", "fa" };
        public static string[] FAHeadSideBrainO = { "\uf808", "far" };
        public static string[] FAHeadSideMedical = { "\uf809", "fa" };
        public static string[] FAHeadSideMedicalO = { "\uf809", "far" };
        public static string[] FAHeadVr = { "\uf6ea", "fa" };
        public static string[] FAHeadVrO = { "\uf6ea", "far" };
        public static string[] FAHeading = { "\uf1dc", "fa" };
        public static string[] FAHeadingO = { "\uf1dc", "far" };
        public static string[] FAHeadphones = { "\uf025", "fa" };
        public static string[] FAHeadphonesO = { "\uf025", "far" };
        public static string[] FAHeadphonesAlt = { "\uf58f", "fa" };
        public static string[] FAHeadphonesAltO = { "\uf58f", "far" };
        public static string[] FAHeadset = { "\uf590", "fa" };
        public static string[] FAHeadsetO = { "\uf590", "far" };
        public static string[] FAHeart = { "\uf004", "fa" };
        public static string[] FAHeartO = { "\uf004", "far" };
        public static string[] FAHeartBroken = { "\uf7a9", "fa" };
        public static string[] FAHeartBrokenO = { "\uf7a9", "far" };
        public static string[] FAHeartCircle = { "\uf4c7", "fa" };
        public static string[] FAHeartCircleO = { "\uf4c7", "far" };
        public static string[] FAHeartRate = { "\uf5f8", "fa" };
        public static string[] FAHeartRateO = { "\uf5f8", "far" };
        public static string[] FAHeartSquare = { "\uf4c8", "fa" };
        public static string[] FAHeartSquareO = { "\uf4c8", "far" };
        public static string[] FAHeartbeat = { "\uf21e", "fa" };
        public static string[] FAHeartbeatO = { "\uf21e", "far" };
        public static string[] FAHelicopter = { "\uf533", "fa" };
        public static string[] FAHelicopterO = { "\uf533", "far" };
        public static string[] FAHelmetBattle = { "\uf6eb", "fa" };
        public static string[] FAHelmetBattleO = { "\uf6eb", "far" };
        public static string[] FAHexagon = { "\uf312", "fa" };
        public static string[] FAHexagonO = { "\uf312", "far" };
        public static string[] FAHighlighter = { "\uf591", "fa" };
        public static string[] FAHighlighterO = { "\uf591", "far" };
        public static string[] FAHiking = { "\uf6ec", "fa" };
        public static string[] FAHikingO = { "\uf6ec", "far" };
        public static string[] FAHippo = { "\uf6ed", "fa" };
        public static string[] FAHippoO = { "\uf6ed", "far" };
        public static string[] FAHips = { "\uf452", "fab" };
        public static string[] FAHireAHelper = { "\uf3b0", "fab" };
        public static string[] FAHistory = { "\uf1da", "fa" };
        public static string[] FAHistoryO = { "\uf1da", "far" };
        public static string[] FAHockeyMask = { "\uf6ee", "fa" };
        public static string[] FAHockeyMaskO = { "\uf6ee", "far" };
        public static string[] FAHockeyPuck = { "\uf453", "fa" };
        public static string[] FAHockeyPuckO = { "\uf453", "far" };
        public static string[] FAHockeySticks = { "\uf454", "fa" };
        public static string[] FAHockeySticksO = { "\uf454", "far" };
        public static string[] FAHollyBerry = { "\uf7aa", "fa" };
        public static string[] FAHollyBerryO = { "\uf7aa", "far" };
        public static string[] FAHome = { "\uf015", "fa" };
        public static string[] FAHomeO = { "\uf015", "far" };
        public static string[] FAHomeAlt = { "\uf80a", "fa" };
        public static string[] FAHomeAltO = { "\uf80a", "far" };
        public static string[] FAHomeHeart = { "\uf4c9", "fa" };
        public static string[] FAHomeHeartO = { "\uf4c9", "far" };
        public static string[] FAHomeLg = { "\uf80b", "fa" };
        public static string[] FAHomeLgO = { "\uf80b", "far" };
        public static string[] FAHomeLgAlt = { "\uf80c", "fa" };
        public static string[] FAHomeLgAltO = { "\uf80c", "far" };
        public static string[] FAHoodCloak = { "\uf6ef", "fa" };
        public static string[] FAHoodCloakO = { "\uf6ef", "far" };
        public static string[] FAHooli = { "\uf427", "fab" };
        public static string[] FAHorizontalRule = { "\uf86c", "fa" };
        public static string[] FAHorizontalRuleO = { "\uf86c", "far" };
        public static string[] FAHornbill = { "\uf592", "fab" };
        public static string[] FAHorse = { "\uf6f0", "fa" };
        public static string[] FAHorseO = { "\uf6f0", "far" };
        public static string[] FAHorseHead = { "\uf7ab", "fa" };
        public static string[] FAHorseHeadO = { "\uf7ab", "far" };
        public static string[] FAHospital = { "\uf0f8", "fa" };
        public static string[] FAHospitalO = { "\uf0f8", "far" };
        public static string[] FAHospitalAlt = { "\uf47d", "fa" };
        public static string[] FAHospitalAltO = { "\uf47d", "far" };
        public static string[] FAHospitalSymbol = { "\uf47e", "fa" };
        public static string[] FAHospitalSymbolO = { "\uf47e", "far" };
        public static string[] FAHospitalUser = { "\uf80d", "fa" };
        public static string[] FAHospitalUserO = { "\uf80d", "far" };
        public static string[] FAHospitals = { "\uf80e", "fa" };
        public static string[] FAHospitalsO = { "\uf80e", "far" };
        public static string[] FAHotTub = { "\uf593", "fa" };
        public static string[] FAHotTubO = { "\uf593", "far" };
        public static string[] FAHotdog = { "\uf80f", "fa" };
        public static string[] FAHotdogO = { "\uf80f", "far" };
        public static string[] FAHotel = { "\uf594", "fa" };
        public static string[] FAHotelO = { "\uf594", "far" };
        public static string[] FAHotjar = { "\uf3b1", "fab" };
        public static string[] FAHourglass = { "\uf254", "fa" };
        public static string[] FAHourglassO = { "\uf254", "far" };
        public static string[] FAHourglassEnd = { "\uf253", "fa" };
        public static string[] FAHourglassEndO = { "\uf253", "far" };
        public static string[] FAHourglassHalf = { "\uf252", "fa" };
        public static string[] FAHourglassHalfO = { "\uf252", "far" };
        public static string[] FAHourglassStart = { "\uf251", "fa" };
        public static string[] FAHourglassStartO = { "\uf251", "far" };
        public static string[] FAHouseDamage = { "\uf6f1", "fa" };
        public static string[] FAHouseDamageO = { "\uf6f1", "far" };
        public static string[] FAHouseFlood = { "\uf74f", "fa" };
        public static string[] FAHouseFloodO = { "\uf74f", "far" };
        public static string[] FAHouzz = { "\uf27c", "fab" };
        public static string[] FAHryvnia = { "\uf6f2", "fa" };
        public static string[] FAHryvniaO = { "\uf6f2", "far" };
        public static string[] FAHtml5 = { "\uf13b", "fab" };
        public static string[] FAHubspot = { "\uf3b2", "fab" };
        public static string[] FAHumidity = { "\uf750", "fa" };
        public static string[] FAHumidityO = { "\uf750", "far" };
        public static string[] FAHurricane = { "\uf751", "fa" };
        public static string[] FAHurricaneO = { "\uf751", "far" };
        public static string[] FAICursor = { "\uf246", "fa" };
        public static string[] FAICursorO = { "\uf246", "far" };
        public static string[] FAIceCream = { "\uf810", "fa" };
        public static string[] FAIceCreamO = { "\uf810", "far" };
        public static string[] FAIceSkate = { "\uf7ac", "fa" };
        public static string[] FAIceSkateO = { "\uf7ac", "far" };
        public static string[] FAIcicles = { "\uf7ad", "fa" };
        public static string[] FAIciclesO = { "\uf7ad", "far" };
        public static string[] FAIcons = { "\uf86d", "fa" };
        public static string[] FAIconsO = { "\uf86d", "far" };
        public static string[] FAIconsAlt = { "\uf86e", "fa" };
        public static string[] FAIconsAltO = { "\uf86e", "far" };
        public static string[] FAIdBadge = { "\uf2c1", "fa" };
        public static string[] FAIdBadgeO = { "\uf2c1", "far" };
        public static string[] FAIdCard = { "\uf2c2", "fa" };
        public static string[] FAIdCardO = { "\uf2c2", "far" };
        public static string[] FAIdCardAlt = { "\uf47f", "fa" };
        public static string[] FAIdCardAltO = { "\uf47f", "far" };
        public static string[] FAIgloo = { "\uf7ae", "fa" };
        public static string[] FAIglooO = { "\uf7ae", "far" };
        public static string[] FAImage = { "\uf03e", "fa" };
        public static string[] FAImageO = { "\uf03e", "far" };
        public static string[] FAImages = { "\uf302", "fa" };
        public static string[] FAImagesO = { "\uf302", "far" };
        public static string[] FAImdb = { "\uf2d8", "fab" };
        public static string[] FAInbox = { "\uf01c", "fa" };
        public static string[] FAInboxO = { "\uf01c", "far" };
        public static string[] FAInboxIn = { "\uf310", "fa" };
        public static string[] FAInboxInO = { "\uf310", "far" };
        public static string[] FAInboxOut = { "\uf311", "fa" };
        public static string[] FAInboxOutO = { "\uf311", "far" };
        public static string[] FAIndent = { "\uf03c", "fa" };
        public static string[] FAIndentO = { "\uf03c", "far" };
        public static string[] FAIndustry = { "\uf275", "fa" };
        public static string[] FAIndustryO = { "\uf275", "far" };
        public static string[] FAIndustryAlt = { "\uf3b3", "fa" };
        public static string[] FAIndustryAltO = { "\uf3b3", "far" };
        public static string[] FAInfinity = { "\uf534", "fa" };
        public static string[] FAInfinityO = { "\uf534", "far" };
        public static string[] FAInfo = { "\uf129", "fa" };
        public static string[] FAInfoO = { "\uf129", "far" };
        public static string[] FAInfoCircle = { "\uf05a", "fa" };
        public static string[] FAInfoCircleO = { "\uf05a", "far" };
        public static string[] FAInfoSquare = { "\uf30f", "fa" };
        public static string[] FAInfoSquareO = { "\uf30f", "far" };
        public static string[] FAInhaler = { "\uf5f9", "fa" };
        public static string[] FAInhalerO = { "\uf5f9", "far" };
        public static string[] FAInstagram = { "\uf16d", "fab" };
        public static string[] FAIntegral = { "\uf667", "fa" };
        public static string[] FAIntegralO = { "\uf667", "far" };
        public static string[] FAIntercom = { "\uf7af", "fab" };
        public static string[] FAInternetExplorer = { "\uf26b", "fab" };
        public static string[] FAIntersection = { "\uf668", "fa" };
        public static string[] FAIntersectionO = { "\uf668", "far" };
        public static string[] FAInventory = { "\uf480", "fa" };
        public static string[] FAInventoryO = { "\uf480", "far" };
        public static string[] FAInvision = { "\uf7b0", "fab" };
        public static string[] FAIoxhost = { "\uf208", "fab" };
        public static string[] FAIslandTropical = { "\uf811", "fa" };
        public static string[] FAIslandTropicalO = { "\uf811", "far" };
        public static string[] FAItalic = { "\uf033", "fa" };
        public static string[] FAItalicO = { "\uf033", "far" };
        public static string[] FAItchIo = { "\uf83a", "fab" };
        public static string[] FAItunes = { "\uf3b4", "fab" };
        public static string[] FAItunesNote = { "\uf3b5", "fab" };
        public static string[] FAJackOLantern = { "\uf30e", "fa" };
        public static string[] FAJackOLanternO = { "\uf30e", "far" };
        public static string[] FAJava = { "\uf4e4", "fab" };
        public static string[] FAJedi = { "\uf669", "fa" };
        public static string[] FAJediO = { "\uf669", "far" };
        public static string[] FAJediOrder = { "\uf50e", "fab" };
        public static string[] FAJenkins = { "\uf3b6", "fab" };
        public static string[] FAJira = { "\uf7b1", "fab" };
        public static string[] FAJoget = { "\uf3b7", "fab" };
        public static string[] FAJoint = { "\uf595", "fa" };
        public static string[] FAJointO = { "\uf595", "far" };
        public static string[] FAJoomla = { "\uf1aa", "fab" };
        public static string[] FAJournalWhills = { "\uf66a", "fa" };
        public static string[] FAJournalWhillsO = { "\uf66a", "far" };
        public static string[] FAJs = { "\uf3b8", "fab" };
        public static string[] FAJsSquare = { "\uf3b9", "fab" };
        public static string[] FAJsfiddle = { "\uf1cc", "fab" };
        public static string[] FAKaaba = { "\uf66b", "fa" };
        public static string[] FAKaabaO = { "\uf66b", "far" };
        public static string[] FAKaggle = { "\uf5fa", "fab" };
        public static string[] FAKerning = { "\uf86f", "fa" };
        public static string[] FAKerningO = { "\uf86f", "far" };
        public static string[] FAKey = { "\uf084", "fa" };
        public static string[] FAKeyO = { "\uf084", "far" };
        public static string[] FAKeySkeleton = { "\uf6f3", "fa" };
        public static string[] FAKeySkeletonO = { "\uf6f3", "far" };
        public static string[] FAKeybase = { "\uf4f5", "fab" };
        public static string[] FAKeyboard = { "\uf11c", "fa" };
        public static string[] FAKeyboardO = { "\uf11c", "far" };
        public static string[] FAKeycdn = { "\uf3ba", "fab" };
        public static string[] FAKeynote = { "\uf66c", "fa" };
        public static string[] FAKeynoteO = { "\uf66c", "far" };
        public static string[] FAKhanda = { "\uf66d", "fa" };
        public static string[] FAKhandaO = { "\uf66d", "far" };
        public static string[] FAKickstarter = { "\uf3bb", "fab" };
        public static string[] FAKickstarterK = { "\uf3bc", "fab" };
        public static string[] FAKidneys = { "\uf5fb", "fa" };
        public static string[] FAKidneysO = { "\uf5fb", "far" };
        public static string[] FAKiss = { "\uf596", "fa" };
        public static string[] FAKissO = { "\uf596", "far" };
        public static string[] FAKissBeam = { "\uf597", "fa" };
        public static string[] FAKissBeamO = { "\uf597", "far" };
        public static string[] FAKissWinkHeart = { "\uf598", "fa" };
        public static string[] FAKissWinkHeartO = { "\uf598", "far" };
        public static string[] FAKite = { "\uf6f4", "fa" };
        public static string[] FAKiteO = { "\uf6f4", "far" };
        public static string[] FAKiwiBird = { "\uf535", "fa" };
        public static string[] FAKiwiBirdO = { "\uf535", "far" };
        public static string[] FAKnifeKitchen = { "\uf6f5", "fa" };
        public static string[] FAKnifeKitchenO = { "\uf6f5", "far" };
        public static string[] FAKorvue = { "\uf42f", "fab" };
        public static string[] FALambda = { "\uf66e", "fa" };
        public static string[] FALambdaO = { "\uf66e", "far" };
        public static string[] FALamp = { "\uf4ca", "fa" };
        public static string[] FALampO = { "\uf4ca", "far" };
        public static string[] FALandmark = { "\uf66f", "fa" };
        public static string[] FALandmarkO = { "\uf66f", "far" };
        public static string[] FALandmarkAlt = { "\uf752", "fa" };
        public static string[] FALandmarkAltO = { "\uf752", "far" };
        public static string[] FALanguage = { "\uf1ab", "fa" };
        public static string[] FALanguageO = { "\uf1ab", "far" };
        public static string[] FALaptop = { "\uf109", "fa" };
        public static string[] FALaptopO = { "\uf109", "far" };
        public static string[] FALaptopCode = { "\uf5fc", "fa" };
        public static string[] FALaptopCodeO = { "\uf5fc", "far" };
        public static string[] FALaptopMedical = { "\uf812", "fa" };
        public static string[] FALaptopMedicalO = { "\uf812", "far" };
        public static string[] FALaravel = { "\uf3bd", "fab" };
        public static string[] FALastfm = { "\uf202", "fab" };
        public static string[] FALastfmSquare = { "\uf203", "fab" };
        public static string[] FALaugh = { "\uf599", "fa" };
        public static string[] FALaughO = { "\uf599", "far" };
        public static string[] FALaughBeam = { "\uf59a", "fa" };
        public static string[] FALaughBeamO = { "\uf59a", "far" };
        public static string[] FALaughSquint = { "\uf59b", "fa" };
        public static string[] FALaughSquintO = { "\uf59b", "far" };
        public static string[] FALaughWink = { "\uf59c", "fa" };
        public static string[] FALaughWinkO = { "\uf59c", "far" };
        public static string[] FALayerGroup = { "\uf5fd", "fa" };
        public static string[] FALayerGroupO = { "\uf5fd", "far" };
        public static string[] FALayerMinus = { "\uf5fe", "fa" };
        public static string[] FALayerMinusO = { "\uf5fe", "far" };
        public static string[] FALayerPlus = { "\uf5ff", "fa" };
        public static string[] FALayerPlusO = { "\uf5ff", "far" };
        public static string[] FALeaf = { "\uf06c", "fa" };
        public static string[] FALeafO = { "\uf06c", "far" };
        public static string[] FALeafHeart = { "\uf4cb", "fa" };
        public static string[] FALeafHeartO = { "\uf4cb", "far" };
        public static string[] FALeafMaple = { "\uf6f6", "fa" };
        public static string[] FALeafMapleO = { "\uf6f6", "far" };
        public static string[] FALeafOak = { "\uf6f7", "fa" };
        public static string[] FALeafOakO = { "\uf6f7", "far" };
        public static string[] FALeanpub = { "\uf212", "fab" };
        public static string[] FALemon = { "\uf094", "fa" };
        public static string[] FALemonO = { "\uf094", "far" };
        public static string[] FALess = { "\uf41d", "fab" };
        public static string[] FALessThan = { "\uf536", "fa" };
        public static string[] FALessThanO = { "\uf536", "far" };
        public static string[] FALessThanEqual = { "\uf537", "fa" };
        public static string[] FALessThanEqualO = { "\uf537", "far" };
        public static string[] FALevelDown = { "\uf149", "fa" };
        public static string[] FALevelDownO = { "\uf149", "far" };
        public static string[] FALevelDownAlt = { "\uf3be", "fa" };
        public static string[] FALevelDownAltO = { "\uf3be", "far" };
        public static string[] FALevelUp = { "\uf148", "fa" };
        public static string[] FALevelUpO = { "\uf148", "far" };
        public static string[] FALevelUpAlt = { "\uf3bf", "fa" };
        public static string[] FALevelUpAltO = { "\uf3bf", "far" };
        public static string[] FALifeRing = { "\uf1cd", "fa" };
        public static string[] FALifeRingO = { "\uf1cd", "far" };
        public static string[] FALightbulb = { "\uf0eb", "fa" };
        public static string[] FALightbulbO = { "\uf0eb", "far" };
        public static string[] FALightbulbDollar = { "\uf670", "fa" };
        public static string[] FALightbulbDollarO = { "\uf670", "far" };
        public static string[] FALightbulbExclamation = { "\uf671", "fa" };
        public static string[] FALightbulbExclamationO = { "\uf671", "far" };
        public static string[] FALightbulbOn = { "\uf672", "fa" };
        public static string[] FALightbulbOnO = { "\uf672", "far" };
        public static string[] FALightbulbSlash = { "\uf673", "fa" };
        public static string[] FALightbulbSlashO = { "\uf673", "far" };
        public static string[] FALightsHoliday = { "\uf7b2", "fa" };
        public static string[] FALightsHolidayO = { "\uf7b2", "far" };
        public static string[] FALine = { "\uf3c0", "fab" };
        public static string[] FALineColumns = { "\uf870", "fa" };
        public static string[] FALineColumnsO = { "\uf870", "far" };
        public static string[] FALineHeight = { "\uf871", "fa" };
        public static string[] FALineHeightO = { "\uf871", "far" };
        public static string[] FALink = { "\uf0c1", "fa" };
        public static string[] FALinkO = { "\uf0c1", "far" };
        public static string[] FALinkedin = { "\uf08c", "fab" };
        public static string[] FALinkedinIn = { "\uf0e1", "fab" };
        public static string[] FALinode = { "\uf2b8", "fab" };
        public static string[] FALinux = { "\uf17c", "fab" };
        public static string[] FALips = { "\uf600", "fa" };
        public static string[] FALipsO = { "\uf600", "far" };
        public static string[] FALiraSign = { "\uf195", "fa" };
        public static string[] FALiraSignO = { "\uf195", "far" };
        public static string[] FAList = { "\uf03a", "fa" };
        public static string[] FAListO = { "\uf03a", "far" };
        public static string[] FAListAlt = { "\uf022", "fa" };
        public static string[] FAListAltO = { "\uf022", "far" };
        public static string[] FAListOl = { "\uf0cb", "fa" };
        public static string[] FAListOlO = { "\uf0cb", "far" };
        public static string[] FAListUl = { "\uf0ca", "fa" };
        public static string[] FAListUlO = { "\uf0ca", "far" };
        public static string[] FALocation = { "\uf601", "fa" };
        public static string[] FALocationO = { "\uf601", "far" };
        public static string[] FALocationArrow = { "\uf124", "fa" };
        public static string[] FALocationArrowO = { "\uf124", "far" };
        public static string[] FALocationCircle = { "\uf602", "fa" };
        public static string[] FALocationCircleO = { "\uf602", "far" };
        public static string[] FALocationSlash = { "\uf603", "fa" };
        public static string[] FALocationSlashO = { "\uf603", "far" };
        public static string[] FALock = { "\uf023", "fa" };
        public static string[] FALockO = { "\uf023", "far" };
        public static string[] FALockAlt = { "\uf30d", "fa" };
        public static string[] FALockAltO = { "\uf30d", "far" };
        public static string[] FALockOpen = { "\uf3c1", "fa" };
        public static string[] FALockOpenO = { "\uf3c1", "far" };
        public static string[] FALockOpenAlt = { "\uf3c2", "fa" };
        public static string[] FALockOpenAltO = { "\uf3c2", "far" };
        public static string[] FALongArrowAltDown = { "\uf309", "fa" };
        public static string[] FALongArrowAltDownO = { "\uf309", "far" };
        public static string[] FALongArrowAltLeft = { "\uf30a", "fa" };
        public static string[] FALongArrowAltLeftO = { "\uf30a", "far" };
        public static string[] FALongArrowAltRight = { "\uf30b", "fa" };
        public static string[] FALongArrowAltRightO = { "\uf30b", "far" };
        public static string[] FALongArrowAltUp = { "\uf30c", "fa" };
        public static string[] FALongArrowAltUpO = { "\uf30c", "far" };
        public static string[] FALongArrowDown = { "\uf175", "fa" };
        public static string[] FALongArrowDownO = { "\uf175", "far" };
        public static string[] FALongArrowLeft = { "\uf177", "fa" };
        public static string[] FALongArrowLeftO = { "\uf177", "far" };
        public static string[] FALongArrowRight = { "\uf178", "fa" };
        public static string[] FALongArrowRightO = { "\uf178", "far" };
        public static string[] FALongArrowUp = { "\uf176", "fa" };
        public static string[] FALongArrowUpO = { "\uf176", "far" };
        public static string[] FALoveseat = { "\uf4cc", "fa" };
        public static string[] FALoveseatO = { "\uf4cc", "far" };
        public static string[] FALowVision = { "\uf2a8", "fa" };
        public static string[] FALowVisionO = { "\uf2a8", "far" };
        public static string[] FALuchador = { "\uf455", "fa" };
        public static string[] FALuchadorO = { "\uf455", "far" };
        public static string[] FALuggageCart = { "\uf59d", "fa" };
        public static string[] FALuggageCartO = { "\uf59d", "far" };
        public static string[] FALungs = { "\uf604", "fa" };
        public static string[] FALungsO = { "\uf604", "far" };
        public static string[] FALyft = { "\uf3c3", "fab" };
        public static string[] FAMace = { "\uf6f8", "fa" };
        public static string[] FAMaceO = { "\uf6f8", "far" };
        public static string[] FAMagento = { "\uf3c4", "fab" };
        public static string[] FAMagic = { "\uf0d0", "fa" };
        public static string[] FAMagicO = { "\uf0d0", "far" };
        public static string[] FAMagnet = { "\uf076", "fa" };
        public static string[] FAMagnetO = { "\uf076", "far" };
        public static string[] FAMailBulk = { "\uf674", "fa" };
        public static string[] FAMailBulkO = { "\uf674", "far" };
        public static string[] FAMailbox = { "\uf813", "fa" };
        public static string[] FAMailboxO = { "\uf813", "far" };
        public static string[] FAMailchimp = { "\uf59e", "fab" };
        public static string[] FAMale = { "\uf183", "fa" };
        public static string[] FAMaleO = { "\uf183", "far" };
        public static string[] FAMandalorian = { "\uf50f", "fab" };
        public static string[] FAMandolin = { "\uf6f9", "fa" };
        public static string[] FAMandolinO = { "\uf6f9", "far" };
        public static string[] FAMap = { "\uf279", "fa" };
        public static string[] FAMapO = { "\uf279", "far" };
        public static string[] FAMapMarked = { "\uf59f", "fa" };
        public static string[] FAMapMarkedO = { "\uf59f", "far" };
        public static string[] FAMapMarkedAlt = { "\uf5a0", "fa" };
        public static string[] FAMapMarkedAltO = { "\uf5a0", "far" };
        public static string[] FAMapMarker = { "\uf041", "fa" };
        public static string[] FAMapMarkerO = { "\uf041", "far" };
        public static string[] FAMapMarkerAlt = { "\uf3c5", "fa" };
        public static string[] FAMapMarkerAltO = { "\uf3c5", "far" };
        public static string[] FAMapMarkerAltSlash = { "\uf605", "fa" };
        public static string[] FAMapMarkerAltSlashO = { "\uf605", "far" };
        public static string[] FAMapMarkerCheck = { "\uf606", "fa" };
        public static string[] FAMapMarkerCheckO = { "\uf606", "far" };
        public static string[] FAMapMarkerEdit = { "\uf607", "fa" };
        public static string[] FAMapMarkerEditO = { "\uf607", "far" };
        public static string[] FAMapMarkerExclamation = { "\uf608", "fa" };
        public static string[] FAMapMarkerExclamationO = { "\uf608", "far" };
        public static string[] FAMapMarkerMinus = { "\uf609", "fa" };
        public static string[] FAMapMarkerMinusO = { "\uf609", "far" };
        public static string[] FAMapMarkerPlus = { "\uf60a", "fa" };
        public static string[] FAMapMarkerPlusO = { "\uf60a", "far" };
        public static string[] FAMapMarkerQuestion = { "\uf60b", "fa" };
        public static string[] FAMapMarkerQuestionO = { "\uf60b", "far" };
        public static string[] FAMapMarkerSlash = { "\uf60c", "fa" };
        public static string[] FAMapMarkerSlashO = { "\uf60c", "far" };
        public static string[] FAMapMarkerSmile = { "\uf60d", "fa" };
        public static string[] FAMapMarkerSmileO = { "\uf60d", "far" };
        public static string[] FAMapMarkerTimes = { "\uf60e", "fa" };
        public static string[] FAMapMarkerTimesO = { "\uf60e", "far" };
        public static string[] FAMapPin = { "\uf276", "fa" };
        public static string[] FAMapPinO = { "\uf276", "far" };
        public static string[] FAMapSigns = { "\uf277", "fa" };
        public static string[] FAMapSignsO = { "\uf277", "far" };
        public static string[] FAMarkdown = { "\uf60f", "fab" };
        public static string[] FAMarker = { "\uf5a1", "fa" };
        public static string[] FAMarkerO = { "\uf5a1", "far" };
        public static string[] FAMars = { "\uf222", "fa" };
        public static string[] FAMarsO = { "\uf222", "far" };
        public static string[] FAMarsDouble = { "\uf227", "fa" };
        public static string[] FAMarsDoubleO = { "\uf227", "far" };
        public static string[] FAMarsStroke = { "\uf229", "fa" };
        public static string[] FAMarsStrokeO = { "\uf229", "far" };
        public static string[] FAMarsStrokeH = { "\uf22b", "fa" };
        public static string[] FAMarsStrokeHO = { "\uf22b", "far" };
        public static string[] FAMarsStrokeV = { "\uf22a", "fa" };
        public static string[] FAMarsStrokeVO = { "\uf22a", "far" };
        public static string[] FAMask = { "\uf6fa", "fa" };
        public static string[] FAMaskO = { "\uf6fa", "far" };
        public static string[] FAMastodon = { "\uf4f6", "fab" };
        public static string[] FAMaxcdn = { "\uf136", "fab" };
        public static string[] FAMeat = { "\uf814", "fa" };
        public static string[] FAMeatO = { "\uf814", "far" };
        public static string[] FAMedal = { "\uf5a2", "fa" };
        public static string[] FAMedalO = { "\uf5a2", "far" };
        public static string[] FAMedapps = { "\uf3c6", "fab" };
        public static string[] FAMedium = { "\uf23a", "fab" };
        public static string[] FAMediumM = { "\uf3c7", "fab" };
        public static string[] FAMedkit = { "\uf0fa", "fa" };
        public static string[] FAMedkitO = { "\uf0fa", "far" };
        public static string[] FAMedrt = { "\uf3c8", "fab" };
        public static string[] FAMeetup = { "\uf2e0", "fab" };
        public static string[] FAMegaphone = { "\uf675", "fa" };
        public static string[] FAMegaphoneO = { "\uf675", "far" };
        public static string[] FAMegaport = { "\uf5a3", "fab" };
        public static string[] FAMeh = { "\uf11a", "fa" };
        public static string[] FAMehO = { "\uf11a", "far" };
        public static string[] FAMehBlank = { "\uf5a4", "fa" };
        public static string[] FAMehBlankO = { "\uf5a4", "far" };
        public static string[] FAMehRollingEyes = { "\uf5a5", "fa" };
        public static string[] FAMehRollingEyesO = { "\uf5a5", "far" };
        public static string[] FAMemory = { "\uf538", "fa" };
        public static string[] FAMemoryO = { "\uf538", "far" };
        public static string[] FAMendeley = { "\uf7b3", "fab" };
        public static string[] FAMenorah = { "\uf676", "fa" };
        public static string[] FAMenorahO = { "\uf676", "far" };
        public static string[] FAMercury = { "\uf223", "fa" };
        public static string[] FAMercuryO = { "\uf223", "far" };
        public static string[] FAMeteor = { "\uf753", "fa" };
        public static string[] FAMeteorO = { "\uf753", "far" };
        public static string[] FAMicrochip = { "\uf2db", "fa" };
        public static string[] FAMicrochipO = { "\uf2db", "far" };
        public static string[] FAMicrophone = { "\uf130", "fa" };
        public static string[] FAMicrophoneO = { "\uf130", "far" };
        public static string[] FAMicrophoneAlt = { "\uf3c9", "fa" };
        public static string[] FAMicrophoneAltO = { "\uf3c9", "far" };
        public static string[] FAMicrophoneAltSlash = { "\uf539", "fa" };
        public static string[] FAMicrophoneAltSlashO = { "\uf539", "far" };
        public static string[] FAMicrophoneSlash = { "\uf131", "fa" };
        public static string[] FAMicrophoneSlashO = { "\uf131", "far" };
        public static string[] FAMicroscope = { "\uf610", "fa" };
        public static string[] FAMicroscopeO = { "\uf610", "far" };
        public static string[] FAMicrosoft = { "\uf3ca", "fab" };
        public static string[] FAMindShare = { "\uf677", "fa" };
        public static string[] FAMindShareO = { "\uf677", "far" };
        public static string[] FAMinus = { "\uf068", "fa" };
        public static string[] FAMinusO = { "\uf068", "far" };
        public static string[] FAMinusCircle = { "\uf056", "fa" };
        public static string[] FAMinusCircleO = { "\uf056", "far" };
        public static string[] FAMinusHexagon = { "\uf307", "fa" };
        public static string[] FAMinusHexagonO = { "\uf307", "far" };
        public static string[] FAMinusOctagon = { "\uf308", "fa" };
        public static string[] FAMinusOctagonO = { "\uf308", "far" };
        public static string[] FAMinusSquare = { "\uf146", "fa" };
        public static string[] FAMinusSquareO = { "\uf146", "far" };
        public static string[] FAMistletoe = { "\uf7b4", "fa" };
        public static string[] FAMistletoeO = { "\uf7b4", "far" };
        public static string[] FAMitten = { "\uf7b5", "fa" };
        public static string[] FAMittenO = { "\uf7b5", "far" };
        public static string[] FAMix = { "\uf3cb", "fab" };
        public static string[] FAMixcloud = { "\uf289", "fab" };
        public static string[] FAMizuni = { "\uf3cc", "fab" };
        public static string[] FAMobile = { "\uf10b", "fa" };
        public static string[] FAMobileO = { "\uf10b", "far" };
        public static string[] FAMobileAlt = { "\uf3cd", "fa" };
        public static string[] FAMobileAltO = { "\uf3cd", "far" };
        public static string[] FAMobileAndroid = { "\uf3ce", "fa" };
        public static string[] FAMobileAndroidO = { "\uf3ce", "far" };
        public static string[] FAMobileAndroidAlt = { "\uf3cf", "fa" };
        public static string[] FAMobileAndroidAltO = { "\uf3cf", "far" };
        public static string[] FAModx = { "\uf285", "fab" };
        public static string[] FAMonero = { "\uf3d0", "fab" };
        public static string[] FAMoneyBill = { "\uf0d6", "fa" };
        public static string[] FAMoneyBillO = { "\uf0d6", "far" };
        public static string[] FAMoneyBillAlt = { "\uf3d1", "fa" };
        public static string[] FAMoneyBillAltO = { "\uf3d1", "far" };
        public static string[] FAMoneyBillWave = { "\uf53a", "fa" };
        public static string[] FAMoneyBillWaveO = { "\uf53a", "far" };
        public static string[] FAMoneyBillWaveAlt = { "\uf53b", "fa" };
        public static string[] FAMoneyBillWaveAltO = { "\uf53b", "far" };
        public static string[] FAMoneyCheck = { "\uf53c", "fa" };
        public static string[] FAMoneyCheckO = { "\uf53c", "far" };
        public static string[] FAMoneyCheckAlt = { "\uf53d", "fa" };
        public static string[] FAMoneyCheckAltO = { "\uf53d", "far" };
        public static string[] FAMoneyCheckEdit = { "\uf872", "fa" };
        public static string[] FAMoneyCheckEditO = { "\uf872", "far" };
        public static string[] FAMoneyCheckEditAlt = { "\uf873", "fa" };
        public static string[] FAMoneyCheckEditAltO = { "\uf873", "far" };
        public static string[] FAMonitorHeartRate = { "\uf611", "fa" };
        public static string[] FAMonitorHeartRateO = { "\uf611", "far" };
        public static string[] FAMonkey = { "\uf6fb", "fa" };
        public static string[] FAMonkeyO = { "\uf6fb", "far" };
        public static string[] FAMonument = { "\uf5a6", "fa" };
        public static string[] FAMonumentO = { "\uf5a6", "far" };
        public static string[] FAMoon = { "\uf186", "fa" };
        public static string[] FAMoonO = { "\uf186", "far" };
        public static string[] FAMoonCloud = { "\uf754", "fa" };
        public static string[] FAMoonCloudO = { "\uf754", "far" };
        public static string[] FAMoonStars = { "\uf755", "fa" };
        public static string[] FAMoonStarsO = { "\uf755", "far" };
        public static string[] FAMortarPestle = { "\uf5a7", "fa" };
        public static string[] FAMortarPestleO = { "\uf5a7", "far" };
        public static string[] FAMosque = { "\uf678", "fa" };
        public static string[] FAMosqueO = { "\uf678", "far" };
        public static string[] FAMotorcycle = { "\uf21c", "fa" };
        public static string[] FAMotorcycleO = { "\uf21c", "far" };
        public static string[] FAMountain = { "\uf6fc", "fa" };
        public static string[] FAMountainO = { "\uf6fc", "far" };
        public static string[] FAMountains = { "\uf6fd", "fa" };
        public static string[] FAMountainsO = { "\uf6fd", "far" };
        public static string[] FAMousePointer = { "\uf245", "fa" };
        public static string[] FAMousePointerO = { "\uf245", "far" };
        public static string[] FAMug = { "\uf874", "fa" };
        public static string[] FAMugO = { "\uf874", "far" };
        public static string[] FAMugHot = { "\uf7b6", "fa" };
        public static string[] FAMugHotO = { "\uf7b6", "far" };
        public static string[] FAMugMarshmallows = { "\uf7b7", "fa" };
        public static string[] FAMugMarshmallowsO = { "\uf7b7", "far" };
        public static string[] FAMugTea = { "\uf875", "fa" };
        public static string[] FAMugTeaO = { "\uf875", "far" };
        public static string[] FAMusic = { "\uf001", "fa" };
        public static string[] FAMusicO = { "\uf001", "far" };
        public static string[] FANapster = { "\uf3d2", "fab" };
        public static string[] FANarwhal = { "\uf6fe", "fa" };
        public static string[] FANarwhalO = { "\uf6fe", "far" };
        public static string[] FANeos = { "\uf612", "fab" };
        public static string[] FANetworkWired = { "\uf6ff", "fa" };
        public static string[] FANetworkWiredO = { "\uf6ff", "far" };
        public static string[] FANeuter = { "\uf22c", "fa" };
        public static string[] FANeuterO = { "\uf22c", "far" };
        public static string[] FANewspaper = { "\uf1ea", "fa" };
        public static string[] FANewspaperO = { "\uf1ea", "far" };
        public static string[] FANimblr = { "\uf5a8", "fab" };
        public static string[] FANode = { "\uf419", "fab" };
        public static string[] FANodeJs = { "\uf3d3", "fab" };
        public static string[] FANotEqual = { "\uf53e", "fa" };
        public static string[] FANotEqualO = { "\uf53e", "far" };
        public static string[] FANotesMedical = { "\uf481", "fa" };
        public static string[] FANotesMedicalO = { "\uf481", "far" };
        public static string[] FANpm = { "\uf3d4", "fab" };
        public static string[] FANs8 = { "\uf3d5", "fab" };
        public static string[] FANutritionix = { "\uf3d6", "fab" };
        public static string[] FAObjectGroup = { "\uf247", "fa" };
        public static string[] FAObjectGroupO = { "\uf247", "far" };
        public static string[] FAObjectUngroup = { "\uf248", "fa" };
        public static string[] FAObjectUngroupO = { "\uf248", "far" };
        public static string[] FAOctagon = { "\uf306", "fa" };
        public static string[] FAOctagonO = { "\uf306", "far" };
        public static string[] FAOdnoklassniki = { "\uf263", "fab" };
        public static string[] FAOdnoklassnikiSquare = { "\uf264", "fab" };
        public static string[] FAOilCan = { "\uf613", "fa" };
        public static string[] FAOilCanO = { "\uf613", "far" };
        public static string[] FAOilTemp = { "\uf614", "fa" };
        public static string[] FAOilTempO = { "\uf614", "far" };
        public static string[] FAOldRepublic = { "\uf510", "fab" };
        public static string[] FAOm = { "\uf679", "fa" };
        public static string[] FAOmO = { "\uf679", "far" };
        public static string[] FAOmega = { "\uf67a", "fa" };
        public static string[] FAOmegaO = { "\uf67a", "far" };
        public static string[] FAOpencart = { "\uf23d", "fab" };
        public static string[] FAOpenid = { "\uf19b", "fab" };
        public static string[] FAOpera = { "\uf26a", "fab" };
        public static string[] FAOptinMonster = { "\uf23c", "fab" };
        public static string[] FAOrnament = { "\uf7b8", "fa" };
        public static string[] FAOrnamentO = { "\uf7b8", "far" };
        public static string[] FAOsi = { "\uf41a", "fab" };
        public static string[] FAOtter = { "\uf700", "fa" };
        public static string[] FAOtterO = { "\uf700", "far" };
        public static string[] FAOutdent = { "\uf03b", "fa" };
        public static string[] FAOutdentO = { "\uf03b", "far" };
        public static string[] FAOverline = { "\uf876", "fa" };
        public static string[] FAOverlineO = { "\uf876", "far" };
        public static string[] FAPageBreak = { "\uf877", "fa" };
        public static string[] FAPageBreakO = { "\uf877", "far" };
        public static string[] FAPage4 = { "\uf3d7", "fab" };
        public static string[] FAPagelines = { "\uf18c", "fab" };
        public static string[] FAPager = { "\uf815", "fa" };
        public static string[] FAPagerO = { "\uf815", "far" };
        public static string[] FAPaintBrush = { "\uf1fc", "fa" };
        public static string[] FAPaintBrushO = { "\uf1fc", "far" };
        public static string[] FAPaintBrushAlt = { "\uf5a9", "fa" };
        public static string[] FAPaintBrushAltO = { "\uf5a9", "far" };
        public static string[] FAPaintRoller = { "\uf5aa", "fa" };
        public static string[] FAPaintRollerO = { "\uf5aa", "far" };
        public static string[] FAPalette = { "\uf53f", "fa" };
        public static string[] FAPaletteO = { "\uf53f", "far" };
        public static string[] FAPalfed = { "\uf3d8", "fab" };
        public static string[] FAPallet = { "\uf482", "fa" };
        public static string[] FAPalletO = { "\uf482", "far" };
        public static string[] FAPalletAlt = { "\uf483", "fa" };
        public static string[] FAPalletAltO = { "\uf483", "far" };
        public static string[] FAPaperPlane = { "\uf1d8", "fa" };
        public static string[] FAPaperPlaneO = { "\uf1d8", "far" };
        public static string[] FAPaperclip = { "\uf0c6", "fa" };
        public static string[] FAPaperclipO = { "\uf0c6", "far" };
        public static string[] FAParachuteBox = { "\uf4cd", "fa" };
        public static string[] FAParachuteBoxO = { "\uf4cd", "far" };
        public static string[] FAParagraph = { "\uf1dd", "fa" };
        public static string[] FAParagraphO = { "\uf1dd", "far" };
        public static string[] FAParagraphRtl = { "\uf878", "fa" };
        public static string[] FAParagraphRtlO = { "\uf878", "far" };
        public static string[] FAParking = { "\uf540", "fa" };
        public static string[] FAParkingO = { "\uf540", "far" };
        public static string[] FAParkingCircle = { "\uf615", "fa" };
        public static string[] FAParkingCircleO = { "\uf615", "far" };
        public static string[] FAParkingCircleSlash = { "\uf616", "fa" };
        public static string[] FAParkingCircleSlashO = { "\uf616", "far" };
        public static string[] FAParkingSlash = { "\uf617", "fa" };
        public static string[] FAParkingSlashO = { "\uf617", "far" };
        public static string[] FAPassport = { "\uf5ab", "fa" };
        public static string[] FAPassportO = { "\uf5ab", "far" };
        public static string[] FAPastafarianism = { "\uf67b", "fa" };
        public static string[] FAPastafarianismO = { "\uf67b", "far" };
        public static string[] FAPaste = { "\uf0ea", "fa" };
        public static string[] FAPasteO = { "\uf0ea", "far" };
        public static string[] FAPatreon = { "\uf3d9", "fab" };
        public static string[] FAPause = { "\uf04c", "fa" };
        public static string[] FAPauseO = { "\uf04c", "far" };
        public static string[] FAPauseCircle = { "\uf28b", "fa" };
        public static string[] FAPauseCircleO = { "\uf28b", "far" };
        public static string[] FAPaw = { "\uf1b0", "fa" };
        public static string[] FAPawO = { "\uf1b0", "far" };
        public static string[] FAPawAlt = { "\uf701", "fa" };
        public static string[] FAPawAltO = { "\uf701", "far" };
        public static string[] FAPawClaws = { "\uf702", "fa" };
        public static string[] FAPawClawsO = { "\uf702", "far" };
        public static string[] FAPaypal = { "\uf1ed", "fab" };
        public static string[] FAPeace = { "\uf67c", "fa" };
        public static string[] FAPeaceO = { "\uf67c", "far" };
        public static string[] FAPegasus = { "\uf703", "fa" };
        public static string[] FAPegasusO = { "\uf703", "far" };
        public static string[] FAPen = { "\uf304", "fa" };
        public static string[] FAPenO = { "\uf304", "far" };
        public static string[] FAPenAlt = { "\uf305", "fa" };
        public static string[] FAPenAltO = { "\uf305", "far" };
        public static string[] FAPenFancy = { "\uf5ac", "fa" };
        public static string[] FAPenFancyO = { "\uf5ac", "far" };
        public static string[] FAPenNib = { "\uf5ad", "fa" };
        public static string[] FAPenNibO = { "\uf5ad", "far" };
        public static string[] FAPenSquare = { "\uf14b", "fa" };
        public static string[] FAPenSquareO = { "\uf14b", "far" };
        public static string[] FAPencil = { "\uf040", "fa" };
        public static string[] FAPencilO = { "\uf040", "far" };
        public static string[] FAPencilAlt = { "\uf303", "fa" };
        public static string[] FAPencilAltO = { "\uf303", "far" };
        public static string[] FAPencilPaintbrush = { "\uf618", "fa" };
        public static string[] FAPencilPaintbrushO = { "\uf618", "far" };
        public static string[] FAPencilRuler = { "\uf5ae", "fa" };
        public static string[] FAPencilRulerO = { "\uf5ae", "far" };
        public static string[] FAPennant = { "\uf456", "fa" };
        public static string[] FAPennantO = { "\uf456", "far" };
        public static string[] FAPennyArcade = { "\uf704", "fab" };
        public static string[] FAPeopleCarry = { "\uf4ce", "fa" };
        public static string[] FAPeopleCarryO = { "\uf4ce", "far" };
        public static string[] FAPepperHot = { "\uf816", "fa" };
        public static string[] FAPepperHotO = { "\uf816", "far" };
        public static string[] FAPercent = { "\uf295", "fa" };
        public static string[] FAPercentO = { "\uf295", "far" };
        public static string[] FAPercentage = { "\uf541", "fa" };
        public static string[] FAPercentageO = { "\uf541", "far" };
        public static string[] FAPeriscope = { "\uf3da", "fab" };
        public static string[] FAPersonBooth = { "\uf756", "fa" };
        public static string[] FAPersonBoothO = { "\uf756", "far" };
        public static string[] FAPersonCarry = { "\uf4cf", "fa" };
        public static string[] FAPersonCarryO = { "\uf4cf", "far" };
        public static string[] FAPersonDolly = { "\uf4d0", "fa" };
        public static string[] FAPersonDollyO = { "\uf4d0", "far" };
        public static string[] FAPersonDollyEmpty = { "\uf4d1", "fa" };
        public static string[] FAPersonDollyEmptyO = { "\uf4d1", "far" };
        public static string[] FAPersonSign = { "\uf757", "fa" };
        public static string[] FAPersonSignO = { "\uf757", "far" };
        public static string[] FAPhabricator = { "\uf3db", "fab" };
        public static string[] FAPhoenixFramework = { "\uf3dc", "fab" };
        public static string[] FAPhoenixSquadron = { "\uf511", "fab" };
        public static string[] FAPhone = { "\uf095", "fa" };
        public static string[] FAPhoneO = { "\uf095", "far" };
        public static string[] FAPhoneAlt = { "\uf879", "fa" };
        public static string[] FAPhoneAltO = { "\uf879", "far" };
        public static string[] FAPhoneLaptop = { "\uf87a", "fa" };
        public static string[] FAPhoneLaptopO = { "\uf87a", "far" };
        public static string[] FAPhoneOffice = { "\uf67d", "fa" };
        public static string[] FAPhoneOfficeO = { "\uf67d", "far" };
        public static string[] FAPhonePlus = { "\uf4d2", "fa" };
        public static string[] FAPhonePlusO = { "\uf4d2", "far" };
        public static string[] FAPhoneSlash = { "\uf3dd", "fa" };
        public static string[] FAPhoneSlashO = { "\uf3dd", "far" };
        public static string[] FAPhoneSquare = { "\uf098", "fa" };
        public static string[] FAPhoneSquareO = { "\uf098", "far" };
        public static string[] FAPhoneSquareAlt = { "\uf87b", "fa" };
        public static string[] FAPhoneSquareAltO = { "\uf87b", "far" };
        public static string[] FAPhoneVolume = { "\uf2a0", "fa" };
        public static string[] FAPhoneVolumeO = { "\uf2a0", "far" };
        public static string[] FAPhotoVideo = { "\uf87c", "fa" };
        public static string[] FAPhotoVideoO = { "\uf87c", "far" };
        public static string[] FAPhp = { "\uf457", "fab" };
        public static string[] FAPi = { "\uf67e", "fa" };
        public static string[] FAPiO = { "\uf67e", "far" };
        public static string[] FAPie = { "\uf705", "fa" };
        public static string[] FAPieO = { "\uf705", "far" };
        public static string[] FAPiedPiper = { "\uf2ae", "fab" };
        public static string[] FAPiedPiperAlt = { "\uf1a8", "fab" };
        public static string[] FAPiedPiperHat = { "\uf4e5", "fab" };
        public static string[] FAPiedPiperPp = { "\uf1a7", "fab" };
        public static string[] FAPig = { "\uf706", "fa" };
        public static string[] FAPigO = { "\uf706", "far" };
        public static string[] FAPiggyBank = { "\uf4d3", "fa" };
        public static string[] FAPiggyBankO = { "\uf4d3", "far" };
        public static string[] FAPills = { "\uf484", "fa" };
        public static string[] FAPillsO = { "\uf484", "far" };
        public static string[] FAPinterest = { "\uf0d2", "fab" };
        public static string[] FAPinterestP = { "\uf231", "fab" };
        public static string[] FAPinterestSquare = { "\uf0d3", "fab" };
        public static string[] FAPizza = { "\uf817", "fa" };
        public static string[] FAPizzaO = { "\uf817", "far" };
        public static string[] FAPizzaSlice = { "\uf818", "fa" };
        public static string[] FAPizzaSliceO = { "\uf818", "far" };
        public static string[] FAPlaceOfWorship = { "\uf67f", "fa" };
        public static string[] FAPlaceOfWorshipO = { "\uf67f", "far" };
        public static string[] FAPlane = { "\uf072", "fa" };
        public static string[] FAPlaneO = { "\uf072", "far" };
        public static string[] FAPlaneAlt = { "\uf3de", "fa" };
        public static string[] FAPlaneAltO = { "\uf3de", "far" };
        public static string[] FAPlaneArrival = { "\uf5af", "fa" };
        public static string[] FAPlaneArrivalO = { "\uf5af", "far" };
        public static string[] FAPlaneDeparture = { "\uf5b0", "fa" };
        public static string[] FAPlaneDepartureO = { "\uf5b0", "far" };
        public static string[] FAPlay = { "\uf04b", "fa" };
        public static string[] FAPlayO = { "\uf04b", "far" };
        public static string[] FAPlayCircle = { "\uf144", "fa" };
        public static string[] FAPlayCircleO = { "\uf144", "far" };
        public static string[] FAPlaystation = { "\uf3df", "fab" };
        public static string[] FAPlug = { "\uf1e6", "fa" };
        public static string[] FAPlugO = { "\uf1e6", "far" };
        public static string[] FAPlus = { "\uf067", "fa" };
        public static string[] FAPlusO = { "\uf067", "far" };
        public static string[] FAPlusCircle = { "\uf055", "fa" };
        public static string[] FAPlusCircleO = { "\uf055", "far" };
        public static string[] FAPlusHexagon = { "\uf300", "fa" };
        public static string[] FAPlusHexagonO = { "\uf300", "far" };
        public static string[] FAPlusOctagon = { "\uf301", "fa" };
        public static string[] FAPlusOctagonO = { "\uf301", "far" };
        public static string[] FAPlusSquare = { "\uf0fe", "fa" };
        public static string[] FAPlusSquareO = { "\uf0fe", "far" };
        public static string[] FAPodcast = { "\uf2ce", "fa" };
        public static string[] FAPodcastO = { "\uf2ce", "far" };
        public static string[] FAPodium = { "\uf680", "fa" };
        public static string[] FAPodiumO = { "\uf680", "far" };
        public static string[] FAPodiumStar = { "\uf758", "fa" };
        public static string[] FAPodiumStarO = { "\uf758", "far" };
        public static string[] FAPoll = { "\uf681", "fa" };
        public static string[] FAPollO = { "\uf681", "far" };
        public static string[] FAPollH = { "\uf682", "fa" };
        public static string[] FAPollHO = { "\uf682", "far" };
        public static string[] FAPollPeople = { "\uf759", "fa" };
        public static string[] FAPollPeopleO = { "\uf759", "far" };
        public static string[] FAPoo = { "\uf2fe", "fa" };
        public static string[] FAPooO = { "\uf2fe", "far" };
        public static string[] FAPooStorm = { "\uf75a", "fa" };
        public static string[] FAPooStormO = { "\uf75a", "far" };
        public static string[] FAPoop = { "\uf619", "fa" };
        public static string[] FAPoopO = { "\uf619", "far" };
        public static string[] FAPopcorn = { "\uf819", "fa" };
        public static string[] FAPopcornO = { "\uf819", "far" };
        public static string[] FAPortrait = { "\uf3e0", "fa" };
        public static string[] FAPortraitO = { "\uf3e0", "far" };
        public static string[] FAPoundSign = { "\uf154", "fa" };
        public static string[] FAPoundSignO = { "\uf154", "far" };
        public static string[] FAPowerOff = { "\uf011", "fa" };
        public static string[] FAPowerOffO = { "\uf011", "far" };
        public static string[] FAPray = { "\uf683", "fa" };
        public static string[] FAPrayO = { "\uf683", "far" };
        public static string[] FAPrayingHands = { "\uf684", "fa" };
        public static string[] FAPrayingHandsO = { "\uf684", "far" };
        public static string[] FAPrescription = { "\uf5b1", "fa" };
        public static string[] FAPrescriptionO = { "\uf5b1", "far" };
        public static string[] FAPrescriptionBottle = { "\uf485", "fa" };
        public static string[] FAPrescriptionBottleO = { "\uf485", "far" };
        public static string[] FAPrescriptionBottleAlt = { "\uf486", "fa" };
        public static string[] FAPrescriptionBottleAltO = { "\uf486", "far" };
        public static string[] FAPresentation = { "\uf685", "fa" };
        public static string[] FAPresentationO = { "\uf685", "far" };
        public static string[] FAPrint = { "\uf02f", "fa" };
        public static string[] FAPrintO = { "\uf02f", "far" };
        public static string[] FAPrintSearch = { "\uf81a", "fa" };
        public static string[] FAPrintSearchO = { "\uf81a", "far" };
        public static string[] FAPrintSlash = { "\uf686", "fa" };
        public static string[] FAPrintSlashO = { "\uf686", "far" };
        public static string[] FAProcedures = { "\uf487", "fa" };
        public static string[] FAProceduresO = { "\uf487", "far" };
        public static string[] FAProductHunt = { "\uf288", "fab" };
        public static string[] FAProjectDiagram = { "\uf542", "fa" };
        public static string[] FAProjectDiagramO = { "\uf542", "far" };
        public static string[] FAPumpkin = { "\uf707", "fa" };
        public static string[] FAPumpkinO = { "\uf707", "far" };
        public static string[] FAPushed = { "\uf3e1", "fab" };
        public static string[] FAPuzzlePiece = { "\uf12e", "fa" };
        public static string[] FAPuzzlePieceO = { "\uf12e", "far" };
        public static string[] FAPython = { "\uf3e2", "fab" };
        public static string[] FAQq = { "\uf1d6", "fab" };
        public static string[] FAQrcode = { "\uf029", "fa" };
        public static string[] FAQrcodeO = { "\uf029", "far" };
        public static string[] FAQuestion = { "\uf128", "fa" };
        public static string[] FAQuestionO = { "\uf128", "far" };
        public static string[] FAQuestionCircle = { "\uf059", "fa" };
        public static string[] FAQuestionCircleO = { "\uf059", "far" };
        public static string[] FAQuestionSquare = { "\uf2fd", "fa" };
        public static string[] FAQuestionSquareO = { "\uf2fd", "far" };
        public static string[] FAQuidditch = { "\uf458", "fa" };
        public static string[] FAQuidditchO = { "\uf458", "far" };
        public static string[] FAQuinscape = { "\uf459", "fab" };
        public static string[] FAQuora = { "\uf2c4", "fab" };
        public static string[] FAQuoteLeft = { "\uf10d", "fa" };
        public static string[] FAQuoteLeftO = { "\uf10d", "far" };
        public static string[] FAQuoteRight = { "\uf10e", "fa" };
        public static string[] FAQuoteRightO = { "\uf10e", "far" };
        public static string[] FAQuran = { "\uf687", "fa" };
        public static string[] FAQuranO = { "\uf687", "far" };
        public static string[] FARProject = { "\uf4f7", "fab" };
        public static string[] FARabbit = { "\uf708", "fa" };
        public static string[] FARabbitO = { "\uf708", "far" };
        public static string[] FARabbitFast = { "\uf709", "fa" };
        public static string[] FARabbitFastO = { "\uf709", "far" };
        public static string[] FARacquet = { "\uf45a", "fa" };
        public static string[] FARacquetO = { "\uf45a", "far" };
        public static string[] FARadiation = { "\uf7b9", "fa" };
        public static string[] FARadiationO = { "\uf7b9", "far" };
        public static string[] FARadiationAlt = { "\uf7ba", "fa" };
        public static string[] FARadiationAltO = { "\uf7ba", "far" };
        public static string[] FARainbow = { "\uf75b", "fa" };
        public static string[] FARainbowO = { "\uf75b", "far" };
        public static string[] FARaindrops = { "\uf75c", "fa" };
        public static string[] FARaindropsO = { "\uf75c", "far" };
        public static string[] FARam = { "\uf70a", "fa" };
        public static string[] FARamO = { "\uf70a", "far" };
        public static string[] FARampLoading = { "\uf4d4", "fa" };
        public static string[] FARampLoadingO = { "\uf4d4", "far" };
        public static string[] FARandom = { "\uf074", "fa" };
        public static string[] FARandomO = { "\uf074", "far" };
        public static string[] FARaspberryPi = { "\uf7bb", "fab" };
        public static string[] FARavelry = { "\uf2d9", "fab" };
        public static string[] FAReact = { "\uf41b", "fab" };
        public static string[] FAReacteurope = { "\uf75d", "fab" };
        public static string[] FAReadme = { "\uf4d5", "fab" };
        public static string[] FARebel = { "\uf1d0", "fab" };
        public static string[] FAReceipt = { "\uf543", "fa" };
        public static string[] FAReceiptO = { "\uf543", "far" };
        public static string[] FARectangleLandscape = { "\uf2fa", "fa" };
        public static string[] FARectangleLandscapeO = { "\uf2fa", "far" };
        public static string[] FARectanglePortrait = { "\uf2fb", "fa" };
        public static string[] FARectanglePortraitO = { "\uf2fb", "far" };
        public static string[] FARectangleWide = { "\uf2fc", "fa" };
        public static string[] FARectangleWideO = { "\uf2fc", "far" };
        public static string[] FARecycle = { "\uf1b8", "fa" };
        public static string[] FARecycleO = { "\uf1b8", "far" };
        public static string[] FARedRiver = { "\uf3e3", "fab" };
        public static string[] FAReddit = { "\uf1a1", "fab" };
        public static string[] FARedditAlien = { "\uf281", "fab" };
        public static string[] FARedditSquare = { "\uf1a2", "fab" };
        public static string[] FARedhat = { "\uf7bc", "fab" };
        public static string[] FARedo = { "\uf01e", "fa" };
        public static string[] FARedoO = { "\uf01e", "far" };
        public static string[] FARedoAlt = { "\uf2f9", "fa" };
        public static string[] FARedoAltO = { "\uf2f9", "far" };
        public static string[] FARegistered = { "\uf25d", "fa" };
        public static string[] FARegisteredO = { "\uf25d", "far" };
        public static string[] FARemoveFormat = { "\uf87d", "fa" };
        public static string[] FARemoveFormatO = { "\uf87d", "far" };
        public static string[] FARenren = { "\uf18b", "fab" };
        public static string[] FARepeat = { "\uf363", "fa" };
        public static string[] FARepeatO = { "\uf363", "far" };
        public static string[] FARepeat1 = { "\uf365", "fa" };
        public static string[] FARepeat1O = { "\uf365", "far" };
        public static string[] FARepeat1Alt = { "\uf366", "fa" };
        public static string[] FARepeat1AltO = { "\uf366", "far" };
        public static string[] FARepeatAlt = { "\uf364", "fa" };
        public static string[] FARepeatAltO = { "\uf364", "far" };
        public static string[] FAReply = { "\uf3e5", "fa" };
        public static string[] FAReplyO = { "\uf3e5", "far" };
        public static string[] FAReplyAll = { "\uf122", "fa" };
        public static string[] FAReplyAllO = { "\uf122", "far" };
        public static string[] FAReplyd = { "\uf3e6", "fab" };
        public static string[] FARepublican = { "\uf75e", "fa" };
        public static string[] FARepublicanO = { "\uf75e", "far" };
        public static string[] FAResearchgate = { "\uf4f8", "fab" };
        public static string[] FAResolving = { "\uf3e7", "fab" };
        public static string[] FARestroom = { "\uf7bd", "fa" };
        public static string[] FARestroomO = { "\uf7bd", "far" };
        public static string[] FARetweet = { "\uf079", "fa" };
        public static string[] FARetweetO = { "\uf079", "far" };
        public static string[] FARetweetAlt = { "\uf361", "fa" };
        public static string[] FARetweetAltO = { "\uf361", "far" };
        public static string[] FARev = { "\uf5b2", "fab" };
        public static string[] FARibbon = { "\uf4d6", "fa" };
        public static string[] FARibbonO = { "\uf4d6", "far" };
        public static string[] FARing = { "\uf70b", "fa" };
        public static string[] FARingO = { "\uf70b", "far" };
        public static string[] FARingsWedding = { "\uf81b", "fa" };
        public static string[] FARingsWeddingO = { "\uf81b", "far" };
        public static string[] FARoad = { "\uf018", "fa" };
        public static string[] FARoadO = { "\uf018", "far" };
        public static string[] FARobot = { "\uf544", "fa" };
        public static string[] FARobotO = { "\uf544", "far" };
        public static string[] FARocket = { "\uf135", "fa" };
        public static string[] FARocketO = { "\uf135", "far" };
        public static string[] FARocketchat = { "\uf3e8", "fab" };
        public static string[] FARockrms = { "\uf3e9", "fab" };
        public static string[] FARoute = { "\uf4d7", "fa" };
        public static string[] FARouteO = { "\uf4d7", "far" };
        public static string[] FARouteHighway = { "\uf61a", "fa" };
        public static string[] FARouteHighwayO = { "\uf61a", "far" };
        public static string[] FARouteInterstate = { "\uf61b", "fa" };
        public static string[] FARouteInterstateO = { "\uf61b", "far" };
        public static string[] FARss = { "\uf09e", "fa" };
        public static string[] FARssO = { "\uf09e", "far" };
        public static string[] FARssSquare = { "\uf143", "fa" };
        public static string[] FARssSquareO = { "\uf143", "far" };
        public static string[] FARubleSign = { "\uf158", "fa" };
        public static string[] FARubleSignO = { "\uf158", "far" };
        public static string[] FARuler = { "\uf545", "fa" };
        public static string[] FARulerO = { "\uf545", "far" };
        public static string[] FARulerCombined = { "\uf546", "fa" };
        public static string[] FARulerCombinedO = { "\uf546", "far" };
        public static string[] FARulerHorizontal = { "\uf547", "fa" };
        public static string[] FARulerHorizontalO = { "\uf547", "far" };
        public static string[] FARulerTriangle = { "\uf61c", "fa" };
        public static string[] FARulerTriangleO = { "\uf61c", "far" };
        public static string[] FARulerVertical = { "\uf548", "fa" };
        public static string[] FARulerVerticalO = { "\uf548", "far" };
        public static string[] FARunning = { "\uf70c", "fa" };
        public static string[] FARunningO = { "\uf70c", "far" };
        public static string[] FARupeeSign = { "\uf156", "fa" };
        public static string[] FARupeeSignO = { "\uf156", "far" };
        public static string[] FARv = { "\uf7be", "fa" };
        public static string[] FARvO = { "\uf7be", "far" };
        public static string[] FASack = { "\uf81c", "fa" };
        public static string[] FASackO = { "\uf81c", "far" };
        public static string[] FASackDollar = { "\uf81d", "fa" };
        public static string[] FASackDollarO = { "\uf81d", "far" };
        public static string[] FASadCry = { "\uf5b3", "fa" };
        public static string[] FASadCryO = { "\uf5b3", "far" };
        public static string[] FASadTear = { "\uf5b4", "fa" };
        public static string[] FASadTearO = { "\uf5b4", "far" };
        public static string[] FASafari = { "\uf267", "fab" };
        public static string[] FASalad = { "\uf81e", "fa" };
        public static string[] FASaladO = { "\uf81e", "far" };
        public static string[] FASalesforce = { "\uf83b", "fab" };
        public static string[] FASandwich = { "\uf81f", "fa" };
        public static string[] FASandwichO = { "\uf81f", "far" };
        public static string[] FASass = { "\uf41e", "fab" };
        public static string[] FASatellite = { "\uf7bf", "fa" };
        public static string[] FASatelliteO = { "\uf7bf", "far" };
        public static string[] FASatelliteDish = { "\uf7c0", "fa" };
        public static string[] FASatelliteDishO = { "\uf7c0", "far" };
        public static string[] FASausage = { "\uf820", "fa" };
        public static string[] FASausageO = { "\uf820", "far" };
        public static string[] FASave = { "\uf0c7", "fa" };
        public static string[] FASaveO = { "\uf0c7", "far" };
        public static string[] FAScalpel = { "\uf61d", "fa" };
        public static string[] FAScalpelO = { "\uf61d", "far" };
        public static string[] FAScalpelPath = { "\uf61e", "fa" };
        public static string[] FAScalpelPathO = { "\uf61e", "far" };
        public static string[] FAScanner = { "\uf488", "fa" };
        public static string[] FAScannerO = { "\uf488", "far" };
        public static string[] FAScannerKeyboard = { "\uf489", "fa" };
        public static string[] FAScannerKeyboardO = { "\uf489", "far" };
        public static string[] FAScannerTouchscreen = { "\uf48a", "fa" };
        public static string[] FAScannerTouchscreenO = { "\uf48a", "far" };
        public static string[] FAScarecrow = { "\uf70d", "fa" };
        public static string[] FAScarecrowO = { "\uf70d", "far" };
        public static string[] FAScarf = { "\uf7c1", "fa" };
        public static string[] FAScarfO = { "\uf7c1", "far" };
        public static string[] FASchlix = { "\uf3ea", "fab" };
        public static string[] FASchool = { "\uf549", "fa" };
        public static string[] FASchoolO = { "\uf549", "far" };
        public static string[] FAScrewdriver = { "\uf54a", "fa" };
        public static string[] FAScrewdriverO = { "\uf54a", "far" };
        public static string[] FAScribd = { "\uf28a", "fab" };
        public static string[] FAScroll = { "\uf70e", "fa" };
        public static string[] FAScrollO = { "\uf70e", "far" };
        public static string[] FAScrollOld = { "\uf70f", "fa" };
        public static string[] FAScrollOldO = { "\uf70f", "far" };
        public static string[] FAScrubber = { "\uf2f8", "fa" };
        public static string[] FAScrubberO = { "\uf2f8", "far" };
        public static string[] FAScythe = { "\uf710", "fa" };
        public static string[] FAScytheO = { "\uf710", "far" };
        public static string[] FASdCard = { "\uf7c2", "fa" };
        public static string[] FASdCardO = { "\uf7c2", "far" };
        public static string[] FASearch = { "\uf002", "fa" };
        public static string[] FASearchO = { "\uf002", "far" };
        public static string[] FASearchDollar = { "\uf688", "fa" };
        public static string[] FASearchDollarO = { "\uf688", "far" };
        public static string[] FASearchLocation = { "\uf689", "fa" };
        public static string[] FASearchLocationO = { "\uf689", "far" };
        public static string[] FASearchMinus = { "\uf010", "fa" };
        public static string[] FASearchMinusO = { "\uf010", "far" };
        public static string[] FASearchPlus = { "\uf00e", "fa" };
        public static string[] FASearchPlusO = { "\uf00e", "far" };
        public static string[] FASearchengin = { "\uf3eb", "fab" };
        public static string[] FASeedling = { "\uf4d8", "fa" };
        public static string[] FASeedlingO = { "\uf4d8", "far" };
        public static string[] FASellcast = { "\uf2da", "fab" };
        public static string[] FASellsy = { "\uf213", "fab" };
        public static string[] FASendBack = { "\uf87e", "fa" };
        public static string[] FASendBackO = { "\uf87e", "far" };
        public static string[] FASendBackward = { "\uf87f", "fa" };
        public static string[] FASendBackwardO = { "\uf87f", "far" };
        public static string[] FAServer = { "\uf233", "fa" };
        public static string[] FAServerO = { "\uf233", "far" };
        public static string[] FAServicestack = { "\uf3ec", "fab" };
        public static string[] FAShapes = { "\uf61f", "fa" };
        public static string[] FAShapesO = { "\uf61f", "far" };
        public static string[] FAShare = { "\uf064", "fa" };
        public static string[] FAShareO = { "\uf064", "far" };
        public static string[] FAShareAll = { "\uf367", "fa" };
        public static string[] FAShareAllO = { "\uf367", "far" };
        public static string[] FAShareAlt = { "\uf1e0", "fa" };
        public static string[] FAShareAltO = { "\uf1e0", "far" };
        public static string[] FAShareAltSquare = { "\uf1e1", "fa" };
        public static string[] FAShareAltSquareO = { "\uf1e1", "far" };
        public static string[] FAShareSquare = { "\uf14d", "fa" };
        public static string[] FAShareSquareO = { "\uf14d", "far" };
        public static string[] FASheep = { "\uf711", "fa" };
        public static string[] FASheepO = { "\uf711", "far" };
        public static string[] FAShekelSign = { "\uf20b", "fa" };
        public static string[] FAShekelSignO = { "\uf20b", "far" };
        public static string[] FAShield = { "\uf132", "fa" };
        public static string[] FAShieldO = { "\uf132", "far" };
        public static string[] FAShieldAlt = { "\uf3ed", "fa" };
        public static string[] FAShieldAltO = { "\uf3ed", "far" };
        public static string[] FAShieldCheck = { "\uf2f7", "fa" };
        public static string[] FAShieldCheckO = { "\uf2f7", "far" };
        public static string[] FAShieldCross = { "\uf712", "fa" };
        public static string[] FAShieldCrossO = { "\uf712", "far" };
        public static string[] FAShip = { "\uf21a", "fa" };
        public static string[] FAShipO = { "\uf21a", "far" };
        public static string[] FAShippingFast = { "\uf48b", "fa" };
        public static string[] FAShippingFastO = { "\uf48b", "far" };
        public static string[] FAShippingTimed = { "\uf48c", "fa" };
        public static string[] FAShippingTimedO = { "\uf48c", "far" };
        public static string[] FAShirtsinbulk = { "\uf214", "fab" };
        public static string[] FAShishKebab = { "\uf821", "fa" };
        public static string[] FAShishKebabO = { "\uf821", "far" };
        public static string[] FAShoePrints = { "\uf54b", "fa" };
        public static string[] FAShoePrintsO = { "\uf54b", "far" };
        public static string[] FAShoppingBag = { "\uf290", "fa" };
        public static string[] FAShoppingBagO = { "\uf290", "far" };
        public static string[] FAShoppingBasket = { "\uf291", "fa" };
        public static string[] FAShoppingBasketO = { "\uf291", "far" };
        public static string[] FAShoppingCart = { "\uf07a", "fa" };
        public static string[] FAShoppingCartO = { "\uf07a", "far" };
        public static string[] FAShopware = { "\uf5b5", "fab" };
        public static string[] FAShovel = { "\uf713", "fa" };
        public static string[] FAShovelO = { "\uf713", "far" };
        public static string[] FAShovelSnow = { "\uf7c3", "fa" };
        public static string[] FAShovelSnowO = { "\uf7c3", "far" };
        public static string[] FAShower = { "\uf2cc", "fa" };
        public static string[] FAShowerO = { "\uf2cc", "far" };
        public static string[] FAShredder = { "\uf68a", "fa" };
        public static string[] FAShredderO = { "\uf68a", "far" };
        public static string[] FAShuttleVan = { "\uf5b6", "fa" };
        public static string[] FAShuttleVanO = { "\uf5b6", "far" };
        public static string[] FAShuttlecock = { "\uf45b", "fa" };
        public static string[] FAShuttlecockO = { "\uf45b", "far" };
        public static string[] FASickle = { "\uf822", "fa" };
        public static string[] FASickleO = { "\uf822", "far" };
        public static string[] FASigma = { "\uf68b", "fa" };
        public static string[] FASigmaO = { "\uf68b", "far" };
        public static string[] FASign = { "\uf4d9", "fa" };
        public static string[] FASignO = { "\uf4d9", "far" };
        public static string[] FASignIn = { "\uf090", "fa" };
        public static string[] FASignInO = { "\uf090", "far" };
        public static string[] FASignInAlt = { "\uf2f6", "fa" };
        public static string[] FASignInAltO = { "\uf2f6", "far" };
        public static string[] FASignLanguage = { "\uf2a7", "fa" };
        public static string[] FASignLanguageO = { "\uf2a7", "far" };
        public static string[] FASignOut = { "\uf08b", "fa" };
        public static string[] FASignOutO = { "\uf08b", "far" };
        public static string[] FASignOutAlt = { "\uf2f5", "fa" };
        public static string[] FASignOutAltO = { "\uf2f5", "far" };
        public static string[] FASignal = { "\uf012", "fa" };
        public static string[] FASignalO = { "\uf012", "far" };
        public static string[] FASignal1 = { "\uf68c", "fa" };
        public static string[] FASignal1O = { "\uf68c", "far" };
        public static string[] FASignal2 = { "\uf68d", "fa" };
        public static string[] FASignal2O = { "\uf68d", "far" };
        public static string[] FASignal3 = { "\uf68e", "fa" };
        public static string[] FASignal3O = { "\uf68e", "far" };
        public static string[] FASignal4 = { "\uf68f", "fa" };
        public static string[] FASignal4O = { "\uf68f", "far" };
        public static string[] FASignalAlt = { "\uf690", "fa" };
        public static string[] FASignalAltO = { "\uf690", "far" };
        public static string[] FASignalAlt1 = { "\uf691", "fa" };
        public static string[] FASignalAlt1O = { "\uf691", "far" };
        public static string[] FASignalAlt2 = { "\uf692", "fa" };
        public static string[] FASignalAlt2O = { "\uf692", "far" };
        public static string[] FASignalAlt3 = { "\uf693", "fa" };
        public static string[] FASignalAlt3O = { "\uf693", "far" };
        public static string[] FASignalAltSlash = { "\uf694", "fa" };
        public static string[] FASignalAltSlashO = { "\uf694", "far" };
        public static string[] FASignalSlash = { "\uf695", "fa" };
        public static string[] FASignalSlashO = { "\uf695", "far" };
        public static string[] FASignature = { "\uf5b7", "fa" };
        public static string[] FASignatureO = { "\uf5b7", "far" };
        public static string[] FASimCard = { "\uf7c4", "fa" };
        public static string[] FASimCardO = { "\uf7c4", "far" };
        public static string[] FASimplybuilt = { "\uf215", "fab" };
        public static string[] FASistrix = { "\uf3ee", "fab" };
        public static string[] FASitemap = { "\uf0e8", "fa" };
        public static string[] FASitemapO = { "\uf0e8", "far" };
        public static string[] FASith = { "\uf512", "fab" };
        public static string[] FASkating = { "\uf7c5", "fa" };
        public static string[] FASkatingO = { "\uf7c5", "far" };
        public static string[] FASkeleton = { "\uf620", "fa" };
        public static string[] FASkeletonO = { "\uf620", "far" };
        public static string[] FASketch = { "\uf7c6", "fab" };
        public static string[] FASkiJump = { "\uf7c7", "fa" };
        public static string[] FASkiJumpO = { "\uf7c7", "far" };
        public static string[] FASkiLift = { "\uf7c8", "fa" };
        public static string[] FASkiLiftO = { "\uf7c8", "far" };
        public static string[] FASkiing = { "\uf7c9", "fa" };
        public static string[] FASkiingO = { "\uf7c9", "far" };
        public static string[] FASkiingNordic = { "\uf7ca", "fa" };
        public static string[] FASkiingNordicO = { "\uf7ca", "far" };
        public static string[] FASkull = { "\uf54c", "fa" };
        public static string[] FASkullO = { "\uf54c", "far" };
        public static string[] FASkullCrossbones = { "\uf714", "fa" };
        public static string[] FASkullCrossbonesO = { "\uf714", "far" };
        public static string[] FASkyatlas = { "\uf216", "fab" };
        public static string[] FASkype = { "\uf17e", "fab" };
        public static string[] FASlack = { "\uf198", "fab" };
        public static string[] FASlackHash = { "\uf3ef", "fab" };
        public static string[] FASlash = { "\uf715", "fa" };
        public static string[] FASlashO = { "\uf715", "far" };
        public static string[] FASledding = { "\uf7cb", "fa" };
        public static string[] FASleddingO = { "\uf7cb", "far" };
        public static string[] FASleigh = { "\uf7cc", "fa" };
        public static string[] FASleighO = { "\uf7cc", "far" };
        public static string[] FASlidersH = { "\uf1de", "fa" };
        public static string[] FASlidersHO = { "\uf1de", "far" };
        public static string[] FASlidersHSquare = { "\uf3f0", "fa" };
        public static string[] FASlidersHSquareO = { "\uf3f0", "far" };
        public static string[] FASlidersV = { "\uf3f1", "fa" };
        public static string[] FASlidersVO = { "\uf3f1", "far" };
        public static string[] FASlidersVSquare = { "\uf3f2", "fa" };
        public static string[] FASlidersVSquareO = { "\uf3f2", "far" };
        public static string[] FASlideshare = { "\uf1e7", "fab" };
        public static string[] FASmile = { "\uf118", "fa" };
        public static string[] FASmileO = { "\uf118", "far" };
        public static string[] FASmileBeam = { "\uf5b8", "fa" };
        public static string[] FASmileBeamO = { "\uf5b8", "far" };
        public static string[] FASmilePlus = { "\uf5b9", "fa" };
        public static string[] FASmilePlusO = { "\uf5b9", "far" };
        public static string[] FASmileWink = { "\uf4da", "fa" };
        public static string[] FASmileWinkO = { "\uf4da", "far" };
        public static string[] FASmog = { "\uf75f", "fa" };
        public static string[] FASmogO = { "\uf75f", "far" };
        public static string[] FASmoke = { "\uf760", "fa" };
        public static string[] FASmokeO = { "\uf760", "far" };
        public static string[] FASmoking = { "\uf48d", "fa" };
        public static string[] FASmokingO = { "\uf48d", "far" };
        public static string[] FASmokingBan = { "\uf54d", "fa" };
        public static string[] FASmokingBanO = { "\uf54d", "far" };
        public static string[] FASms = { "\uf7cd", "fa" };
        public static string[] FASmsO = { "\uf7cd", "far" };
        public static string[] FASnake = { "\uf716", "fa" };
        public static string[] FASnakeO = { "\uf716", "far" };
        public static string[] FASnapchat = { "\uf2ab", "fab" };
        public static string[] FASnapchatGhost = { "\uf2ac", "fab" };
        public static string[] FASnapchatSquare = { "\uf2ad", "fab" };
        public static string[] FASnooze = { "\uf880", "fa" };
        public static string[] FASnoozeO = { "\uf880", "far" };
        public static string[] FASnowBlowing = { "\uf761", "fa" };
        public static string[] FASnowBlowingO = { "\uf761", "far" };
        public static string[] FASnowboarding = { "\uf7ce", "fa" };
        public static string[] FASnowboardingO = { "\uf7ce", "far" };
        public static string[] FASnowflake = { "\uf2dc", "fa" };
        public static string[] FASnowflakeO = { "\uf2dc", "far" };
        public static string[] FASnowflakes = { "\uf7cf", "fa" };
        public static string[] FASnowflakesO = { "\uf7cf", "far" };
        public static string[] FASnowman = { "\uf7d0", "fa" };
        public static string[] FASnowmanO = { "\uf7d0", "far" };
        public static string[] FASnowmobile = { "\uf7d1", "fa" };
        public static string[] FASnowmobileO = { "\uf7d1", "far" };
        public static string[] FASnowplow = { "\uf7d2", "fa" };
        public static string[] FASnowplowO = { "\uf7d2", "far" };
        public static string[] FASocks = { "\uf696", "fa" };
        public static string[] FASocksO = { "\uf696", "far" };
        public static string[] FASolarPanel = { "\uf5ba", "fa" };
        public static string[] FASolarPanelO = { "\uf5ba", "far" };
        public static string[] FASort = { "\uf0dc", "fa" };
        public static string[] FASortO = { "\uf0dc", "far" };
        public static string[] FASortAlphaDown = { "\uf15d", "fa" };
        public static string[] FASortAlphaDownO = { "\uf15d", "far" };
        public static string[] FASortAlphaDownAlt = { "\uf881", "fa" };
        public static string[] FASortAlphaDownAltO = { "\uf881", "far" };
        public static string[] FASortAlphaUp = { "\uf15e", "fa" };
        public static string[] FASortAlphaUpO = { "\uf15e", "far" };
        public static string[] FASortAlphaUpAlt = { "\uf882", "fa" };
        public static string[] FASortAlphaUpAltO = { "\uf882", "far" };
        public static string[] FASortAlt = { "\uf883", "fa" };
        public static string[] FASortAltO = { "\uf883", "far" };
        public static string[] FASortAmountDown = { "\uf160", "fa" };
        public static string[] FASortAmountDownO = { "\uf160", "far" };
        public static string[] FASortAmountDownAlt = { "\uf884", "fa" };
        public static string[] FASortAmountDownAltO = { "\uf884", "far" };
        public static string[] FASortAmountUp = { "\uf161", "fa" };
        public static string[] FASortAmountUpO = { "\uf161", "far" };
        public static string[] FASortAmountUpAlt = { "\uf885", "fa" };
        public static string[] FASortAmountUpAltO = { "\uf885", "far" };
        public static string[] FASortDown = { "\uf0dd", "fa" };
        public static string[] FASortDownO = { "\uf0dd", "far" };
        public static string[] FASortNumericDown = { "\uf162", "fa" };
        public static string[] FASortNumericDownO = { "\uf162", "far" };
        public static string[] FASortNumericDownAlt = { "\uf886", "fa" };
        public static string[] FASortNumericDownAltO = { "\uf886", "far" };
        public static string[] FASortNumericUp = { "\uf163", "fa" };
        public static string[] FASortNumericUpO = { "\uf163", "far" };
        public static string[] FASortNumericUpAlt = { "\uf887", "fa" };
        public static string[] FASortNumericUpAltO = { "\uf887", "far" };
        public static string[] FASortShapesDown = { "\uf888", "fa" };
        public static string[] FASortShapesDownO = { "\uf888", "far" };
        public static string[] FASortShapesDownAlt = { "\uf889", "fa" };
        public static string[] FASortShapesDownAltO = { "\uf889", "far" };
        public static string[] FASortShapesUp = { "\uf88a", "fa" };
        public static string[] FASortShapesUpO = { "\uf88a", "far" };
        public static string[] FASortShapesUpAlt = { "\uf88b", "fa" };
        public static string[] FASortShapesUpAltO = { "\uf88b", "far" };
        public static string[] FASortSizeDown = { "\uf88c", "fa" };
        public static string[] FASortSizeDownO = { "\uf88c", "far" };
        public static string[] FASortSizeDownAlt = { "\uf88d", "fa" };
        public static string[] FASortSizeDownAltO = { "\uf88d", "far" };
        public static string[] FASortSizeUp = { "\uf88e", "fa" };
        public static string[] FASortSizeUpO = { "\uf88e", "far" };
        public static string[] FASortSizeUpAlt = { "\uf88f", "fa" };
        public static string[] FASortSizeUpAltO = { "\uf88f", "far" };
        public static string[] FASortUp = { "\uf0de", "fa" };
        public static string[] FASortUpO = { "\uf0de", "far" };
        public static string[] FASoundcloud = { "\uf1be", "fab" };
        public static string[] FASoup = { "\uf823", "fa" };
        public static string[] FASoupO = { "\uf823", "far" };
        public static string[] FASourcetree = { "\uf7d3", "fab" };
        public static string[] FASpa = { "\uf5bb", "fa" };
        public static string[] FASpaO = { "\uf5bb", "far" };
        public static string[] FASpaceShuttle = { "\uf197", "fa" };
        public static string[] FASpaceShuttleO = { "\uf197", "far" };
        public static string[] FASpade = { "\uf2f4", "fa" };
        public static string[] FASpadeO = { "\uf2f4", "far" };
        public static string[] FASparkles = { "\uf890", "fa" };
        public static string[] FASparklesO = { "\uf890", "far" };
        public static string[] FASpeakap = { "\uf3f3", "fab" };
        public static string[] FASpeakerDeck = { "\uf83c", "fab" };
        public static string[] FASpellCheck = { "\uf891", "fa" };
        public static string[] FASpellCheckO = { "\uf891", "far" };
        public static string[] FASpider = { "\uf717", "fa" };
        public static string[] FASpiderO = { "\uf717", "far" };
        public static string[] FASpiderBlackWidow = { "\uf718", "fa" };
        public static string[] FASpiderBlackWidowO = { "\uf718", "far" };
        public static string[] FASpiderWeb = { "\uf719", "fa" };
        public static string[] FASpiderWebO = { "\uf719", "far" };
        public static string[] FASpinner = { "\uf110", "fa" };
        public static string[] FASpinnerO = { "\uf110", "far" };
        public static string[] FASpinnerThird = { "\uf3f4", "fa" };
        public static string[] FASpinnerThirdO = { "\uf3f4", "far" };
        public static string[] FASplotch = { "\uf5bc", "fa" };
        public static string[] FASplotchO = { "\uf5bc", "far" };
        public static string[] FASpotify = { "\uf1bc", "fab" };
        public static string[] FASprayCan = { "\uf5bd", "fa" };
        public static string[] FASprayCanO = { "\uf5bd", "far" };
        public static string[] FASquare = { "\uf0c8", "fa" };
        public static string[] FASquareO = { "\uf0c8", "far" };
        public static string[] FASquareFull = { "\uf45c", "fa" };
        public static string[] FASquareFullO = { "\uf45c", "far" };
        public static string[] FASquareRoot = { "\uf697", "fa" };
        public static string[] FASquareRootO = { "\uf697", "far" };
        public static string[] FASquareRootAlt = { "\uf698", "fa" };
        public static string[] FASquareRootAltO = { "\uf698", "far" };
        public static string[] FASquarespace = { "\uf5be", "fab" };
        public static string[] FASquirrel = { "\uf71a", "fa" };
        public static string[] FASquirrelO = { "\uf71a", "far" };
        public static string[] FAStackExchange = { "\uf18d", "fab" };
        public static string[] FAStackOverflow = { "\uf16c", "fab" };
        public static string[] FAStackpath = { "\uf842", "fab" };
        public static string[] FAStaff = { "\uf71b", "fa" };
        public static string[] FAStaffO = { "\uf71b", "far" };
        public static string[] FAStamp = { "\uf5bf", "fa" };
        public static string[] FAStampO = { "\uf5bf", "far" };
        public static string[] FAStar = { "\uf005", "fa" };
        public static string[] FAStarO = { "\uf005", "far" };
        public static string[] FAStarAndCrescent = { "\uf699", "fa" };
        public static string[] FAStarAndCrescentO = { "\uf699", "far" };
        public static string[] FAStarChristmas = { "\uf7d4", "fa" };
        public static string[] FAStarChristmasO = { "\uf7d4", "far" };
        public static string[] FAStarExclamation = { "\uf2f3", "fa" };
        public static string[] FAStarExclamationO = { "\uf2f3", "far" };
        public static string[] FAStarHalf = { "\uf089", "fa" };
        public static string[] FAStarHalfO = { "\uf089", "far" };
        public static string[] FAStarHalfAlt = { "\uf5c0", "fa" };
        public static string[] FAStarHalfAltO = { "\uf5c0", "far" };
        public static string[] FAStarOfDavid = { "\uf69a", "fa" };
        public static string[] FAStarOfDavidO = { "\uf69a", "far" };
        public static string[] FAStarOfLife = { "\uf621", "fa" };
        public static string[] FAStarOfLifeO = { "\uf621", "far" };
        public static string[] FAStars = { "\uf762", "fa" };
        public static string[] FAStarsO = { "\uf762", "far" };
        public static string[] FAStaylinked = { "\uf3f5", "fab" };
        public static string[] FASteak = { "\uf824", "fa" };
        public static string[] FASteakO = { "\uf824", "far" };
        public static string[] FASteam = { "\uf1b6", "fab" };
        public static string[] FASteamSquare = { "\uf1b7", "fab" };
        public static string[] FASteamSymbol = { "\uf3f6", "fab" };
        public static string[] FASteeringWheel = { "\uf622", "fa" };
        public static string[] FASteeringWheelO = { "\uf622", "far" };
        public static string[] FAStepBackward = { "\uf048", "fa" };
        public static string[] FAStepBackwardO = { "\uf048", "far" };
        public static string[] FAStepForward = { "\uf051", "fa" };
        public static string[] FAStepForwardO = { "\uf051", "far" };
        public static string[] FAStethoscope = { "\uf0f1", "fa" };
        public static string[] FAStethoscopeO = { "\uf0f1", "far" };
        public static string[] FAStickerMule = { "\uf3f7", "fab" };
        public static string[] FAStickyNote = { "\uf249", "fa" };
        public static string[] FAStickyNoteO = { "\uf249", "far" };
        public static string[] FAStocking = { "\uf7d5", "fa" };
        public static string[] FAStockingO = { "\uf7d5", "far" };
        public static string[] FAStomach = { "\uf623", "fa" };
        public static string[] FAStomachO = { "\uf623", "far" };
        public static string[] FAStop = { "\uf04d", "fa" };
        public static string[] FAStopO = { "\uf04d", "far" };
        public static string[] FAStopCircle = { "\uf28d", "fa" };
        public static string[] FAStopCircleO = { "\uf28d", "far" };
        public static string[] FAStopwatch = { "\uf2f2", "fa" };
        public static string[] FAStopwatchO = { "\uf2f2", "far" };
        public static string[] FAStore = { "\uf54e", "fa" };
        public static string[] FAStoreO = { "\uf54e", "far" };
        public static string[] FAStoreAlt = { "\uf54f", "fa" };
        public static string[] FAStoreAltO = { "\uf54f", "far" };
        public static string[] FAStrava = { "\uf428", "fab" };
        public static string[] FAStream = { "\uf550", "fa" };
        public static string[] FAStreamO = { "\uf550", "far" };
        public static string[] FAStreetView = { "\uf21d", "fa" };
        public static string[] FAStreetViewO = { "\uf21d", "far" };
        public static string[] FAStretcher = { "\uf825", "fa" };
        public static string[] FAStretcherO = { "\uf825", "far" };
        public static string[] FAStrikethrough = { "\uf0cc", "fa" };
        public static string[] FAStrikethroughO = { "\uf0cc", "far" };
        public static string[] FAStripe = { "\uf429", "fab" };
        public static string[] FAStripeS = { "\uf42a", "fab" };
        public static string[] FAStroopwafel = { "\uf551", "fa" };
        public static string[] FAStroopwafelO = { "\uf551", "far" };
        public static string[] FAStudiovinari = { "\uf3f8", "fab" };
        public static string[] FAStumbleupon = { "\uf1a4", "fab" };
        public static string[] FAStumbleuponCircle = { "\uf1a3", "fab" };
        public static string[] FASubscript = { "\uf12c", "fa" };
        public static string[] FASubscriptO = { "\uf12c", "far" };
        public static string[] FASubway = { "\uf239", "fa" };
        public static string[] FASubwayO = { "\uf239", "far" };
        public static string[] FASuitcase = { "\uf0f2", "fa" };
        public static string[] FASuitcaseO = { "\uf0f2", "far" };
        public static string[] FASuitcaseRolling = { "\uf5c1", "fa" };
        public static string[] FASuitcaseRollingO = { "\uf5c1", "far" };
        public static string[] FASun = { "\uf185", "fa" };
        public static string[] FASunO = { "\uf185", "far" };
        public static string[] FASunCloud = { "\uf763", "fa" };
        public static string[] FASunCloudO = { "\uf763", "far" };
        public static string[] FASunDust = { "\uf764", "fa" };
        public static string[] FASunDustO = { "\uf764", "far" };
        public static string[] FASunHaze = { "\uf765", "fa" };
        public static string[] FASunHazeO = { "\uf765", "far" };
        public static string[] FASunglasses = { "\uf892", "fa" };
        public static string[] FASunglassesO = { "\uf892", "far" };
        public static string[] FASunrise = { "\uf766", "fa" };
        public static string[] FASunriseO = { "\uf766", "far" };
        public static string[] FASunset = { "\uf767", "fa" };
        public static string[] FASunsetO = { "\uf767", "far" };
        public static string[] FASuperpowers = { "\uf2dd", "fab" };
        public static string[] FASuperscript = { "\uf12b", "fa" };
        public static string[] FASuperscriptO = { "\uf12b", "far" };
        public static string[] FASupple = { "\uf3f9", "fab" };
        public static string[] FASurprise = { "\uf5c2", "fa" };
        public static string[] FASurpriseO = { "\uf5c2", "far" };
        public static string[] FASuse = { "\uf7d6", "fab" };
        public static string[] FASwatchbook = { "\uf5c3", "fa" };
        public static string[] FASwatchbookO = { "\uf5c3", "far" };
        public static string[] FASwimmer = { "\uf5c4", "fa" };
        public static string[] FASwimmerO = { "\uf5c4", "far" };
        public static string[] FASwimmingPool = { "\uf5c5", "fa" };
        public static string[] FASwimmingPoolO = { "\uf5c5", "far" };
        public static string[] FASword = { "\uf71c", "fa" };
        public static string[] FASwordO = { "\uf71c", "far" };
        public static string[] FASwords = { "\uf71d", "fa" };
        public static string[] FASwordsO = { "\uf71d", "far" };
        public static string[] FASymfony = { "\uf83d", "fab" };
        public static string[] FASynagogue = { "\uf69b", "fa" };
        public static string[] FASynagogueO = { "\uf69b", "far" };
        public static string[] FASync = { "\uf021", "fa" };
        public static string[] FASyncO = { "\uf021", "far" };
        public static string[] FASyncAlt = { "\uf2f1", "fa" };
        public static string[] FASyncAltO = { "\uf2f1", "far" };
        public static string[] FASyringe = { "\uf48e", "fa" };
        public static string[] FASyringeO = { "\uf48e", "far" };
        public static string[] FATable = { "\uf0ce", "fa" };
        public static string[] FATableO = { "\uf0ce", "far" };
        public static string[] FATableTennis = { "\uf45d", "fa" };
        public static string[] FATableTennisO = { "\uf45d", "far" };
        public static string[] FATablet = { "\uf10a", "fa" };
        public static string[] FATabletO = { "\uf10a", "far" };
        public static string[] FATabletAlt = { "\uf3fa", "fa" };
        public static string[] FATabletAltO = { "\uf3fa", "far" };
        public static string[] FATabletAndroid = { "\uf3fb", "fa" };
        public static string[] FATabletAndroidO = { "\uf3fb", "far" };
        public static string[] FATabletAndroidAlt = { "\uf3fc", "fa" };
        public static string[] FATabletAndroidAltO = { "\uf3fc", "far" };
        public static string[] FATabletRugged = { "\uf48f", "fa" };
        public static string[] FATabletRuggedO = { "\uf48f", "far" };
        public static string[] FATablets = { "\uf490", "fa" };
        public static string[] FATabletsO = { "\uf490", "far" };
        public static string[] FATachometer = { "\uf0e4", "fa" };
        public static string[] FATachometerO = { "\uf0e4", "far" };
        public static string[] FATachometerAlt = { "\uf3fd", "fa" };
        public static string[] FATachometerAltO = { "\uf3fd", "far" };
        public static string[] FATachometerAltAverage = { "\uf624", "fa" };
        public static string[] FATachometerAltAverageO = { "\uf624", "far" };
        public static string[] FATachometerAltFast = { "\uf625", "fa" };
        public static string[] FATachometerAltFastO = { "\uf625", "far" };
        public static string[] FATachometerAltFastest = { "\uf626", "fa" };
        public static string[] FATachometerAltFastestO = { "\uf626", "far" };
        public static string[] FATachometerAltSlow = { "\uf627", "fa" };
        public static string[] FATachometerAltSlowO = { "\uf627", "far" };
        public static string[] FATachometerAltSlowest = { "\uf628", "fa" };
        public static string[] FATachometerAltSlowestO = { "\uf628", "far" };
        public static string[] FATachometerAverage = { "\uf629", "fa" };
        public static string[] FATachometerAverageO = { "\uf629", "far" };
        public static string[] FATachometerFast = { "\uf62a", "fa" };
        public static string[] FATachometerFastO = { "\uf62a", "far" };
        public static string[] FATachometerFastest = { "\uf62b", "fa" };
        public static string[] FATachometerFastestO = { "\uf62b", "far" };
        public static string[] FATachometerSlow = { "\uf62c", "fa" };
        public static string[] FATachometerSlowO = { "\uf62c", "far" };
        public static string[] FATachometerSlowest = { "\uf62d", "fa" };
        public static string[] FATachometerSlowestO = { "\uf62d", "far" };
        public static string[] FATaco = { "\uf826", "fa" };
        public static string[] FATacoO = { "\uf826", "far" };
        public static string[] FATag = { "\uf02b", "fa" };
        public static string[] FATagO = { "\uf02b", "far" };
        public static string[] FATags = { "\uf02c", "fa" };
        public static string[] FATagsO = { "\uf02c", "far" };
        public static string[] FATally = { "\uf69c", "fa" };
        public static string[] FATallyO = { "\uf69c", "far" };
        public static string[] FATanakh = { "\uf827", "fa" };
        public static string[] FATanakhO = { "\uf827", "far" };
        public static string[] FATape = { "\uf4db", "fa" };
        public static string[] FATapeO = { "\uf4db", "far" };
        public static string[] FATasks = { "\uf0ae", "fa" };
        public static string[] FATasksO = { "\uf0ae", "far" };
        public static string[] FATasksAlt = { "\uf828", "fa" };
        public static string[] FATasksAltO = { "\uf828", "far" };
        public static string[] FATaxi = { "\uf1ba", "fa" };
        public static string[] FATaxiO = { "\uf1ba", "far" };
        public static string[] FATeamspeak = { "\uf4f9", "fab" };
        public static string[] FATeeth = { "\uf62e", "fa" };
        public static string[] FATeethO = { "\uf62e", "far" };
        public static string[] FATeethOpen = { "\uf62f", "fa" };
        public static string[] FATeethOpenO = { "\uf62f", "far" };
        public static string[] FATelegram = { "\uf2c6", "fab" };
        public static string[] FATelegramPlane = { "\uf3fe", "fab" };
        public static string[] FATemperatureFrigid = { "\uf768", "fa" };
        public static string[] FATemperatureFrigidO = { "\uf768", "far" };
        public static string[] FATemperatureHigh = { "\uf769", "fa" };
        public static string[] FATemperatureHighO = { "\uf769", "far" };
        public static string[] FATemperatureHot = { "\uf76a", "fa" };
        public static string[] FATemperatureHotO = { "\uf76a", "far" };
        public static string[] FATemperatureLow = { "\uf76b", "fa" };
        public static string[] FATemperatureLowO = { "\uf76b", "far" };
        public static string[] FATencentWeibo = { "\uf1d5", "fab" };
        public static string[] FATenge = { "\uf7d7", "fa" };
        public static string[] FATengeO = { "\uf7d7", "far" };
        public static string[] FATennisBall = { "\uf45e", "fa" };
        public static string[] FATennisBallO = { "\uf45e", "far" };
        public static string[] FATerminal = { "\uf120", "fa" };
        public static string[] FATerminalO = { "\uf120", "far" };
        public static string[] FAText = { "\uf893", "fa" };
        public static string[] FATextO = { "\uf893", "far" };
        public static string[] FATextHeight = { "\uf034", "fa" };
        public static string[] FATextHeightO = { "\uf034", "far" };
        public static string[] FATextSize = { "\uf894", "fa" };
        public static string[] FATextSizeO = { "\uf894", "far" };
        public static string[] FATextWidth = { "\uf035", "fa" };
        public static string[] FATextWidthO = { "\uf035", "far" };
        public static string[] FATh = { "\uf00a", "fa" };
        public static string[] FAThO = { "\uf00a", "far" };
        public static string[] FAThLarge = { "\uf009", "fa" };
        public static string[] FAThLargeO = { "\uf009", "far" };
        public static string[] FAThList = { "\uf00b", "fa" };
        public static string[] FAThListO = { "\uf00b", "far" };
        public static string[] FATheRedYeti = { "\uf69d", "fab" };
        public static string[] FATheaterMasks = { "\uf630", "fa" };
        public static string[] FATheaterMasksO = { "\uf630", "far" };
        public static string[] FAThemeco = { "\uf5c6", "fab" };
        public static string[] FAThemeisle = { "\uf2b2", "fab" };
        public static string[] FAThermometer = { "\uf491", "fa" };
        public static string[] FAThermometerO = { "\uf491", "far" };
        public static string[] FAThermometerEmpty = { "\uf2cb", "fa" };
        public static string[] FAThermometerEmptyO = { "\uf2cb", "far" };
        public static string[] FAThermometerFull = { "\uf2c7", "fa" };
        public static string[] FAThermometerFullO = { "\uf2c7", "far" };
        public static string[] FAThermometerHalf = { "\uf2c9", "fa" };
        public static string[] FAThermometerHalfO = { "\uf2c9", "far" };
        public static string[] FAThermometerQuarter = { "\uf2ca", "fa" };
        public static string[] FAThermometerQuarterO = { "\uf2ca", "far" };
        public static string[] FAThermometerThreeQuarters = { "\uf2c8", "fa" };
        public static string[] FAThermometerThreeQuartersO = { "\uf2c8", "far" };
        public static string[] FATheta = { "\uf69e", "fa" };
        public static string[] FAThetaO = { "\uf69e", "far" };
        public static string[] FAThinkPeaks = { "\uf731", "fab" };
        public static string[] FAThumbsDown = { "\uf165", "fa" };
        public static string[] FAThumbsDownO = { "\uf165", "far" };
        public static string[] FAThumbsUp = { "\uf164", "fa" };
        public static string[] FAThumbsUpO = { "\uf164", "far" };
        public static string[] FAThumbtack = { "\uf08d", "fa" };
        public static string[] FAThumbtackO = { "\uf08d", "far" };
        public static string[] FAThunderstorm = { "\uf76c", "fa" };
        public static string[] FAThunderstormO = { "\uf76c", "far" };
        public static string[] FAThunderstormMoon = { "\uf76d", "fa" };
        public static string[] FAThunderstormMoonO = { "\uf76d", "far" };
        public static string[] FAThunderstormSun = { "\uf76e", "fa" };
        public static string[] FAThunderstormSunO = { "\uf76e", "far" };
        public static string[] FATicket = { "\uf145", "fa" };
        public static string[] FATicketO = { "\uf145", "far" };
        public static string[] FATicketAlt = { "\uf3ff", "fa" };
        public static string[] FATicketAltO = { "\uf3ff", "far" };
        public static string[] FATilde = { "\uf69f", "fa" };
        public static string[] FATildeO = { "\uf69f", "far" };
        public static string[] FATimes = { "\uf00d", "fa" };
        public static string[] FATimesO = { "\uf00d", "far" };
        public static string[] FATimesCircle = { "\uf057", "fa" };
        public static string[] FATimesCircleO = { "\uf057", "far" };
        public static string[] FATimesHexagon = { "\uf2ee", "fa" };
        public static string[] FATimesHexagonO = { "\uf2ee", "far" };
        public static string[] FATimesOctagon = { "\uf2f0", "fa" };
        public static string[] FATimesOctagonO = { "\uf2f0", "far" };
        public static string[] FATimesSquare = { "\uf2d3", "fa" };
        public static string[] FATimesSquareO = { "\uf2d3", "far" };
        public static string[] FATint = { "\uf043", "fa" };
        public static string[] FATintO = { "\uf043", "far" };
        public static string[] FATintSlash = { "\uf5c7", "fa" };
        public static string[] FATintSlashO = { "\uf5c7", "far" };
        public static string[] FATire = { "\uf631", "fa" };
        public static string[] FATireO = { "\uf631", "far" };
        public static string[] FATireFlat = { "\uf632", "fa" };
        public static string[] FATireFlatO = { "\uf632", "far" };
        public static string[] FATirePressureWarning = { "\uf633", "fa" };
        public static string[] FATirePressureWarningO = { "\uf633", "far" };
        public static string[] FATireRugged = { "\uf634", "fa" };
        public static string[] FATireRuggedO = { "\uf634", "far" };
        public static string[] FATired = { "\uf5c8", "fa" };
        public static string[] FATiredO = { "\uf5c8", "far" };
        public static string[] FAToggleOff = { "\uf204", "fa" };
        public static string[] FAToggleOffO = { "\uf204", "far" };
        public static string[] FAToggleOn = { "\uf205", "fa" };
        public static string[] FAToggleOnO = { "\uf205", "far" };
        public static string[] FAToilet = { "\uf7d8", "fa" };
        public static string[] FAToiletO = { "\uf7d8", "far" };
        public static string[] FAToiletPaper = { "\uf71e", "fa" };
        public static string[] FAToiletPaperO = { "\uf71e", "far" };
        public static string[] FAToiletPaperAlt = { "\uf71f", "fa" };
        public static string[] FAToiletPaperAltO = { "\uf71f", "far" };
        public static string[] FATombstone = { "\uf720", "fa" };
        public static string[] FATombstoneO = { "\uf720", "far" };
        public static string[] FATombstoneAlt = { "\uf721", "fa" };
        public static string[] FATombstoneAltO = { "\uf721", "far" };
        public static string[] FAToolbox = { "\uf552", "fa" };
        public static string[] FAToolboxO = { "\uf552", "far" };
        public static string[] FATools = { "\uf7d9", "fa" };
        public static string[] FAToolsO = { "\uf7d9", "far" };
        public static string[] FATooth = { "\uf5c9", "fa" };
        public static string[] FAToothO = { "\uf5c9", "far" };
        public static string[] FAToothbrush = { "\uf635", "fa" };
        public static string[] FAToothbrushO = { "\uf635", "far" };
        public static string[] FATorah = { "\uf6a0", "fa" };
        public static string[] FATorahO = { "\uf6a0", "far" };
        public static string[] FAToriiGate = { "\uf6a1", "fa" };
        public static string[] FAToriiGateO = { "\uf6a1", "far" };
        public static string[] FATornado = { "\uf76f", "fa" };
        public static string[] FATornadoO = { "\uf76f", "far" };
        public static string[] FATractor = { "\uf722", "fa" };
        public static string[] FATractorO = { "\uf722", "far" };
        public static string[] FATradeFederation = { "\uf513", "fab" };
        public static string[] FATrademark = { "\uf25c", "fa" };
        public static string[] FATrademarkO = { "\uf25c", "far" };
        public static string[] FATrafficCone = { "\uf636", "fa" };
        public static string[] FATrafficConeO = { "\uf636", "far" };
        public static string[] FATrafficLight = { "\uf637", "fa" };
        public static string[] FATrafficLightO = { "\uf637", "far" };
        public static string[] FATrafficLightGo = { "\uf638", "fa" };
        public static string[] FATrafficLightGoO = { "\uf638", "far" };
        public static string[] FATrafficLightSlow = { "\uf639", "fa" };
        public static string[] FATrafficLightSlowO = { "\uf639", "far" };
        public static string[] FATrafficLightStop = { "\uf63a", "fa" };
        public static string[] FATrafficLightStopO = { "\uf63a", "far" };
        public static string[] FATrain = { "\uf238", "fa" };
        public static string[] FATrainO = { "\uf238", "far" };
        public static string[] FATram = { "\uf7da", "fa" };
        public static string[] FATramO = { "\uf7da", "far" };
        public static string[] FATransgender = { "\uf224", "fa" };
        public static string[] FATransgenderO = { "\uf224", "far" };
        public static string[] FATransgenderAlt = { "\uf225", "fa" };
        public static string[] FATransgenderAltO = { "\uf225", "far" };
        public static string[] FATrash = { "\uf1f8", "fa" };
        public static string[] FATrashO = { "\uf1f8", "far" };
        public static string[] FATrashAlt = { "\uf2ed", "fa" };
        public static string[] FATrashAltO = { "\uf2ed", "far" };
        public static string[] FATrashRestore = { "\uf829", "fa" };
        public static string[] FATrashRestoreO = { "\uf829", "far" };
        public static string[] FATrashRestoreAlt = { "\uf82a", "fa" };
        public static string[] FATrashRestoreAltO = { "\uf82a", "far" };
        public static string[] FATrashUndo = { "\uf895", "fa" };
        public static string[] FATrashUndoO = { "\uf895", "far" };
        public static string[] FATrashUndoAlt = { "\uf896", "fa" };
        public static string[] FATrashUndoAltO = { "\uf896", "far" };
        public static string[] FATreasureChest = { "\uf723", "fa" };
        public static string[] FATreasureChestO = { "\uf723", "far" };
        public static string[] FATree = { "\uf1bb", "fa" };
        public static string[] FATreeO = { "\uf1bb", "far" };
        public static string[] FATreeAlt = { "\uf400", "fa" };
        public static string[] FATreeAltO = { "\uf400", "far" };
        public static string[] FATreeChristmas = { "\uf7db", "fa" };
        public static string[] FATreeChristmasO = { "\uf7db", "far" };
        public static string[] FATreeDecorated = { "\uf7dc", "fa" };
        public static string[] FATreeDecoratedO = { "\uf7dc", "far" };
        public static string[] FATreeLarge = { "\uf7dd", "fa" };
        public static string[] FATreeLargeO = { "\uf7dd", "far" };
        public static string[] FATreePalm = { "\uf82b", "fa" };
        public static string[] FATreePalmO = { "\uf82b", "far" };
        public static string[] FATrees = { "\uf724", "fa" };
        public static string[] FATreesO = { "\uf724", "far" };
        public static string[] FATrello = { "\uf181", "fab" };
        public static string[] FATriangle = { "\uf2ec", "fa" };
        public static string[] FATriangleO = { "\uf2ec", "far" };
        public static string[] FATripadvisor = { "\uf262", "fab" };
        public static string[] FATrophy = { "\uf091", "fa" };
        public static string[] FATrophyO = { "\uf091", "far" };
        public static string[] FATrophyAlt = { "\uf2eb", "fa" };
        public static string[] FATrophyAltO = { "\uf2eb", "far" };
        public static string[] FATruck = { "\uf0d1", "fa" };
        public static string[] FATruckO = { "\uf0d1", "far" };
        public static string[] FATruckContainer = { "\uf4dc", "fa" };
        public static string[] FATruckContainerO = { "\uf4dc", "far" };
        public static string[] FATruckCouch = { "\uf4dd", "fa" };
        public static string[] FATruckCouchO = { "\uf4dd", "far" };
        public static string[] FATruckLoading = { "\uf4de", "fa" };
        public static string[] FATruckLoadingO = { "\uf4de", "far" };
        public static string[] FATruckMonster = { "\uf63b", "fa" };
        public static string[] FATruckMonsterO = { "\uf63b", "far" };
        public static string[] FATruckMoving = { "\uf4df", "fa" };
        public static string[] FATruckMovingO = { "\uf4df", "far" };
        public static string[] FATruckPickup = { "\uf63c", "fa" };
        public static string[] FATruckPickupO = { "\uf63c", "far" };
        public static string[] FATruckPlow = { "\uf7de", "fa" };
        public static string[] FATruckPlowO = { "\uf7de", "far" };
        public static string[] FATruckRamp = { "\uf4e0", "fa" };
        public static string[] FATruckRampO = { "\uf4e0", "far" };
        public static string[] FATshirt = { "\uf553", "fa" };
        public static string[] FATshirtO = { "\uf553", "far" };
        public static string[] FATty = { "\uf1e4", "fa" };
        public static string[] FATtyO = { "\uf1e4", "far" };
        public static string[] FATumblr = { "\uf173", "fab" };
        public static string[] FATumblrSquare = { "\uf174", "fab" };
        public static string[] FATurkey = { "\uf725", "fa" };
        public static string[] FATurkeyO = { "\uf725", "far" };
        public static string[] FATurtle = { "\uf726", "fa" };
        public static string[] FATurtleO = { "\uf726", "far" };
        public static string[] FATv = { "\uf26c", "fa" };
        public static string[] FATvO = { "\uf26c", "far" };
        public static string[] FATvRetro = { "\uf401", "fa" };
        public static string[] FATvRetroO = { "\uf401", "far" };
        public static string[] FATwitch = { "\uf1e8", "fab" };
        public static string[] FATwitter = { "\uf099", "fab" };
        public static string[] FATwitterSquare = { "\uf081", "fab" };
        public static string[] FATypo3 = { "\uf42b", "fab" };
        public static string[] FAUber = { "\uf402", "fab" };
        public static string[] FAUbuntu = { "\uf7df", "fab" };
        public static string[] FAUikit = { "\uf403", "fab" };
        public static string[] FAUmbrella = { "\uf0e9", "fa" };
        public static string[] FAUmbrellaO = { "\uf0e9", "far" };
        public static string[] FAUmbrellaBeach = { "\uf5ca", "fa" };
        public static string[] FAUmbrellaBeachO = { "\uf5ca", "far" };
        public static string[] FAUnderline = { "\uf0cd", "fa" };
        public static string[] FAUnderlineO = { "\uf0cd", "far" };
        public static string[] FAUndo = { "\uf0e2", "fa" };
        public static string[] FAUndoO = { "\uf0e2", "far" };
        public static string[] FAUndoAlt = { "\uf2ea", "fa" };
        public static string[] FAUndoAltO = { "\uf2ea", "far" };
        public static string[] FAUnicorn = { "\uf727", "fa" };
        public static string[] FAUnicornO = { "\uf727", "far" };
        public static string[] FAUnion = { "\uf6a2", "fa" };
        public static string[] FAUnionO = { "\uf6a2", "far" };
        public static string[] FAUniregistry = { "\uf404", "fab" };
        public static string[] FAUniversalAccess = { "\uf29a", "fa" };
        public static string[] FAUniversalAccessO = { "\uf29a", "far" };
        public static string[] FAUniversity = { "\uf19c", "fa" };
        public static string[] FAUniversityO = { "\uf19c", "far" };
        public static string[] FAUnlink = { "\uf127", "fa" };
        public static string[] FAUnlinkO = { "\uf127", "far" };
        public static string[] FAUnlock = { "\uf09c", "fa" };
        public static string[] FAUnlockO = { "\uf09c", "far" };
        public static string[] FAUnlockAlt = { "\uf13e", "fa" };
        public static string[] FAUnlockAltO = { "\uf13e", "far" };
        public static string[] FAUntappd = { "\uf405", "fab" };
        public static string[] FAUpload = { "\uf093", "fa" };
        public static string[] FAUploadO = { "\uf093", "far" };
        public static string[] FAUps = { "\uf7e0", "fab" };
        public static string[] FAUsb = { "\uf287", "fab" };
        public static string[] FAUsdCircle = { "\uf2e8", "fa" };
        public static string[] FAUsdCircleO = { "\uf2e8", "far" };
        public static string[] FAUsdSquare = { "\uf2e9", "fa" };
        public static string[] FAUsdSquareO = { "\uf2e9", "far" };
        public static string[] FAUser = { "\uf007", "fa" };
        public static string[] FAUserO = { "\uf007", "far" };
        public static string[] FAUserAlt = { "\uf406", "fa" };
        public static string[] FAUserAltO = { "\uf406", "far" };
        public static string[] FAUserAltSlash = { "\uf4fa", "fa" };
        public static string[] FAUserAltSlashO = { "\uf4fa", "far" };
        public static string[] FAUserAstronaut = { "\uf4fb", "fa" };
        public static string[] FAUserAstronautO = { "\uf4fb", "far" };
        public static string[] FAUserChart = { "\uf6a3", "fa" };
        public static string[] FAUserChartO = { "\uf6a3", "far" };
        public static string[] FAUserCheck = { "\uf4fc", "fa" };
        public static string[] FAUserCheckO = { "\uf4fc", "far" };
        public static string[] FAUserCircle = { "\uf2bd", "fa" };
        public static string[] FAUserCircleO = { "\uf2bd", "far" };
        public static string[] FAUserClock = { "\uf4fd", "fa" };
        public static string[] FAUserClockO = { "\uf4fd", "far" };
        public static string[] FAUserCog = { "\uf4fe", "fa" };
        public static string[] FAUserCogO = { "\uf4fe", "far" };
        public static string[] FAUserCrown = { "\uf6a4", "fa" };
        public static string[] FAUserCrownO = { "\uf6a4", "far" };
        public static string[] FAUserEdit = { "\uf4ff", "fa" };
        public static string[] FAUserEditO = { "\uf4ff", "far" };
        public static string[] FAUserFriends = { "\uf500", "fa" };
        public static string[] FAUserFriendsO = { "\uf500", "far" };
        public static string[] FAUserGraduate = { "\uf501", "fa" };
        public static string[] FAUserGraduateO = { "\uf501", "far" };
        public static string[] FAUserHardHat = { "\uf82c", "fa" };
        public static string[] FAUserHardHatO = { "\uf82c", "far" };
        public static string[] FAUserHeadset = { "\uf82d", "fa" };
        public static string[] FAUserHeadsetO = { "\uf82d", "far" };
        public static string[] FAUserInjured = { "\uf728", "fa" };
        public static string[] FAUserInjuredO = { "\uf728", "far" };
        public static string[] FAUserLock = { "\uf502", "fa" };
        public static string[] FAUserLockO = { "\uf502", "far" };
        public static string[] FAUserMd = { "\uf0f0", "fa" };
        public static string[] FAUserMdO = { "\uf0f0", "far" };
        public static string[] FAUserMdChat = { "\uf82e", "fa" };
        public static string[] FAUserMdChatO = { "\uf82e", "far" };
        public static string[] FAUserMinus = { "\uf503", "fa" };
        public static string[] FAUserMinusO = { "\uf503", "far" };
        public static string[] FAUserNinja = { "\uf504", "fa" };
        public static string[] FAUserNinjaO = { "\uf504", "far" };
        public static string[] FAUserNurse = { "\uf82f", "fa" };
        public static string[] FAUserNurseO = { "\uf82f", "far" };
        public static string[] FAUserPlus = { "\uf234", "fa" };
        public static string[] FAUserPlusO = { "\uf234", "far" };
        public static string[] FAUserSecret = { "\uf21b", "fa" };
        public static string[] FAUserSecretO = { "\uf21b", "far" };
        public static string[] FAUserShield = { "\uf505", "fa" };
        public static string[] FAUserShieldO = { "\uf505", "far" };
        public static string[] FAUserSlash = { "\uf506", "fa" };
        public static string[] FAUserSlashO = { "\uf506", "far" };
        public static string[] FAUserTag = { "\uf507", "fa" };
        public static string[] FAUserTagO = { "\uf507", "far" };
        public static string[] FAUserTie = { "\uf508", "fa" };
        public static string[] FAUserTieO = { "\uf508", "far" };
        public static string[] FAUserTimes = { "\uf235", "fa" };
        public static string[] FAUserTimesO = { "\uf235", "far" };
        public static string[] FAUsers = { "\uf0c0", "fa" };
        public static string[] FAUsersO = { "\uf0c0", "far" };
        public static string[] FAUsersClass = { "\uf63d", "fa" };
        public static string[] FAUsersClassO = { "\uf63d", "far" };
        public static string[] FAUsersCog = { "\uf509", "fa" };
        public static string[] FAUsersCogO = { "\uf509", "far" };
        public static string[] FAUsersCrown = { "\uf6a5", "fa" };
        public static string[] FAUsersCrownO = { "\uf6a5", "far" };
        public static string[] FAUsersMedical = { "\uf830", "fa" };
        public static string[] FAUsersMedicalO = { "\uf830", "far" };
        public static string[] FAUsps = { "\uf7e1", "fab" };
        public static string[] FAUssunnah = { "\uf407", "fab" };
        public static string[] FAUtensilFork = { "\uf2e3", "fa" };
        public static string[] FAUtensilForkO = { "\uf2e3", "far" };
        public static string[] FAUtensilKnife = { "\uf2e4", "fa" };
        public static string[] FAUtensilKnifeO = { "\uf2e4", "far" };
        public static string[] FAUtensilSpoon = { "\uf2e5", "fa" };
        public static string[] FAUtensilSpoonO = { "\uf2e5", "far" };
        public static string[] FAUtensils = { "\uf2e7", "fa" };
        public static string[] FAUtensilsO = { "\uf2e7", "far" };
        public static string[] FAUtensilsAlt = { "\uf2e6", "fa" };
        public static string[] FAUtensilsAltO = { "\uf2e6", "far" };
        public static string[] FAVaadin = { "\uf408", "fab" };
        public static string[] FAValueAbsolute = { "\uf6a6", "fa" };
        public static string[] FAValueAbsoluteO = { "\uf6a6", "far" };
        public static string[] FAVectorSquare = { "\uf5cb", "fa" };
        public static string[] FAVectorSquareO = { "\uf5cb", "far" };
        public static string[] FAVenus = { "\uf221", "fa" };
        public static string[] FAVenusO = { "\uf221", "far" };
        public static string[] FAVenusDouble = { "\uf226", "fa" };
        public static string[] FAVenusDoubleO = { "\uf226", "far" };
        public static string[] FAVenusMars = { "\uf228", "fa" };
        public static string[] FAVenusMarsO = { "\uf228", "far" };
        public static string[] FAViacoin = { "\uf237", "fab" };
        public static string[] FAViadeo = { "\uf2a9", "fab" };
        public static string[] FAViadeoSquare = { "\uf2aa", "fab" };
        public static string[] FAVial = { "\uf492", "fa" };
        public static string[] FAVialO = { "\uf492", "far" };
        public static string[] FAVials = { "\uf493", "fa" };
        public static string[] FAVialsO = { "\uf493", "far" };
        public static string[] FAViber = { "\uf409", "fab" };
        public static string[] FAVideo = { "\uf03d", "fa" };
        public static string[] FAVideoO = { "\uf03d", "far" };
        public static string[] FAVideoPlus = { "\uf4e1", "fa" };
        public static string[] FAVideoPlusO = { "\uf4e1", "far" };
        public static string[] FAVideoSlash = { "\uf4e2", "fa" };
        public static string[] FAVideoSlashO = { "\uf4e2", "far" };
        public static string[] FAVihara = { "\uf6a7", "fa" };
        public static string[] FAViharaO = { "\uf6a7", "far" };
        public static string[] FAVimeo = { "\uf40a", "fab" };
        public static string[] FAVimeoSquare = { "\uf194", "fab" };
        public static string[] FAVimeoV = { "\uf27d", "fab" };
        public static string[] FAVine = { "\uf1ca", "fab" };
        public static string[] FAVk = { "\uf189", "fab" };
        public static string[] FAVnv = { "\uf40b", "fab" };
        public static string[] FAVoicemail = { "\uf897", "fa" };
        public static string[] FAVoicemailO = { "\uf897", "far" };
        public static string[] FAVolcano = { "\uf770", "fa" };
        public static string[] FAVolcanoO = { "\uf770", "far" };
        public static string[] FAVolleyballBall = { "\uf45f", "fa" };
        public static string[] FAVolleyballBallO = { "\uf45f", "far" };
        public static string[] FAVolume = { "\uf6a8", "fa" };
        public static string[] FAVolumeO = { "\uf6a8", "far" };
        public static string[] FAVolumeDown = { "\uf027", "fa" };
        public static string[] FAVolumeDownO = { "\uf027", "far" };
        public static string[] FAVolumeMute = { "\uf6a9", "fa" };
        public static string[] FAVolumeMuteO = { "\uf6a9", "far" };
        public static string[] FAVolumeOff = { "\uf026", "fa" };
        public static string[] FAVolumeOffO = { "\uf026", "far" };
        public static string[] FAVolumeSlash = { "\uf2e2", "fa" };
        public static string[] FAVolumeSlashO = { "\uf2e2", "far" };
        public static string[] FAVolumeUp = { "\uf028", "fa" };
        public static string[] FAVolumeUpO = { "\uf028", "far" };
        public static string[] FAVoteNay = { "\uf771", "fa" };
        public static string[] FAVoteNayO = { "\uf771", "far" };
        public static string[] FAVoteYea = { "\uf772", "fa" };
        public static string[] FAVoteYeaO = { "\uf772", "far" };
        public static string[] FAVrCardboard = { "\uf729", "fa" };
        public static string[] FAVrCardboardO = { "\uf729", "far" };
        public static string[] FAVuejs = { "\uf41f", "fab" };
        public static string[] FAWalker = { "\uf831", "fa" };
        public static string[] FAWalkerO = { "\uf831", "far" };
        public static string[] FAWalking = { "\uf554", "fa" };
        public static string[] FAWalkingO = { "\uf554", "far" };
        public static string[] FAWallet = { "\uf555", "fa" };
        public static string[] FAWalletO = { "\uf555", "far" };
        public static string[] FAWand = { "\uf72a", "fa" };
        public static string[] FAWandO = { "\uf72a", "far" };
        public static string[] FAWandMagic = { "\uf72b", "fa" };
        public static string[] FAWandMagicO = { "\uf72b", "far" };
        public static string[] FAWarehouse = { "\uf494", "fa" };
        public static string[] FAWarehouseO = { "\uf494", "far" };
        public static string[] FAWarehouseAlt = { "\uf495", "fa" };
        public static string[] FAWarehouseAltO = { "\uf495", "far" };
        public static string[] FAWasher = { "\uf898", "fa" };
        public static string[] FAWasherO = { "\uf898", "far" };
        public static string[] FAWatch = { "\uf2e1", "fa" };
        public static string[] FAWatchO = { "\uf2e1", "far" };
        public static string[] FAWatchFitness = { "\uf63e", "fa" };
        public static string[] FAWatchFitnessO = { "\uf63e", "far" };
        public static string[] FAWater = { "\uf773", "fa" };
        public static string[] FAWaterO = { "\uf773", "far" };
        public static string[] FAWaterLower = { "\uf774", "fa" };
        public static string[] FAWaterLowerO = { "\uf774", "far" };
        public static string[] FAWaterRise = { "\uf775", "fa" };
        public static string[] FAWaterRiseO = { "\uf775", "far" };
        public static string[] FAWaveSine = { "\uf899", "fa" };
        public static string[] FAWaveSineO = { "\uf899", "far" };
        public static string[] FAWaveSquare = { "\uf83e", "fa" };
        public static string[] FAWaveSquareO = { "\uf83e", "far" };
        public static string[] FAWaveTriangle = { "\uf89a", "fa" };
        public static string[] FAWaveTriangleO = { "\uf89a", "far" };
        public static string[] FAWaze = { "\uf83f", "fab" };
        public static string[] FAWebcam = { "\uf832", "fa" };
        public static string[] FAWebcamO = { "\uf832", "far" };
        public static string[] FAWebcamSlash = { "\uf833", "fa" };
        public static string[] FAWebcamSlashO = { "\uf833", "far" };
        public static string[] FAWeebly = { "\uf5cc", "fab" };
        public static string[] FAWeibo = { "\uf18a", "fab" };
        public static string[] FAWeight = { "\uf496", "fa" };
        public static string[] FAWeightO = { "\uf496", "far" };
        public static string[] FAWeightHanging = { "\uf5cd", "fa" };
        public static string[] FAWeightHangingO = { "\uf5cd", "far" };
        public static string[] FAWeixin = { "\uf1d7", "fab" };
        public static string[] FAWhale = { "\uf72c", "fa" };
        public static string[] FAWhaleO = { "\uf72c", "far" };
        public static string[] FAWhatsapp = { "\uf232", "fab" };
        public static string[] FAWhatsappSquare = { "\uf40c", "fab" };
        public static string[] FAWheat = { "\uf72d", "fa" };
        public static string[] FAWheatO = { "\uf72d", "far" };
        public static string[] FAWheelchair = { "\uf193", "fa" };
        public static string[] FAWheelchairO = { "\uf193", "far" };
        public static string[] FAWhistle = { "\uf460", "fa" };
        public static string[] FAWhistleO = { "\uf460", "far" };
        public static string[] FAWhmcs = { "\uf40d", "fab" };
        public static string[] FAWifi = { "\uf1eb", "fa" };
        public static string[] FAWifiO = { "\uf1eb", "far" };
        public static string[] FAWifi1 = { "\uf6aa", "fa" };
        public static string[] FAWifi1O = { "\uf6aa", "far" };
        public static string[] FAWifi2 = { "\uf6ab", "fa" };
        public static string[] FAWifi2O = { "\uf6ab", "far" };
        public static string[] FAWifiSlash = { "\uf6ac", "fa" };
        public static string[] FAWifiSlashO = { "\uf6ac", "far" };
        public static string[] FAWikipediaW = { "\uf266", "fab" };
        public static string[] FAWind = { "\uf72e", "fa" };
        public static string[] FAWindO = { "\uf72e", "far" };
        public static string[] FAWindTurbine = { "\uf89b", "fa" };
        public static string[] FAWindTurbineO = { "\uf89b", "far" };
        public static string[] FAWindWarning = { "\uf776", "fa" };
        public static string[] FAWindWarningO = { "\uf776", "far" };
        public static string[] FAWindow = { "\uf40e", "fa" };
        public static string[] FAWindowO = { "\uf40e", "far" };
        public static string[] FAWindowAlt = { "\uf40f", "fa" };
        public static string[] FAWindowAltO = { "\uf40f", "far" };
        public static string[] FAWindowClose = { "\uf410", "fa" };
        public static string[] FAWindowCloseO = { "\uf410", "far" };
        public static string[] FAWindowMaximize = { "\uf2d0", "fa" };
        public static string[] FAWindowMaximizeO = { "\uf2d0", "far" };
        public static string[] FAWindowMinimize = { "\uf2d1", "fa" };
        public static string[] FAWindowMinimizeO = { "\uf2d1", "far" };
        public static string[] FAWindowRestore = { "\uf2d2", "fa" };
        public static string[] FAWindowRestoreO = { "\uf2d2", "far" };
        public static string[] FAWindows = { "\uf17a", "fab" };
        public static string[] FAWindsock = { "\uf777", "fa" };
        public static string[] FAWindsockO = { "\uf777", "far" };
        public static string[] FAWineBottle = { "\uf72f", "fa" };
        public static string[] FAWineBottleO = { "\uf72f", "far" };
        public static string[] FAWineGlass = { "\uf4e3", "fa" };
        public static string[] FAWineGlassO = { "\uf4e3", "far" };
        public static string[] FAWineGlassAlt = { "\uf5ce", "fa" };
        public static string[] FAWineGlassAltO = { "\uf5ce", "far" };
        public static string[] FAWix = { "\uf5cf", "fab" };
        public static string[] FAWizardsOfTheCoast = { "\uf730", "fab" };
        public static string[] FAWolfPackBattalion = { "\uf514", "fab" };
        public static string[] FAWonSign = { "\uf159", "fa" };
        public static string[] FAWonSignO = { "\uf159", "far" };
        public static string[] FAWordpress = { "\uf19a", "fab" };
        public static string[] FAWordpressSimple = { "\uf411", "fab" };
        public static string[] FAWpbeginner = { "\uf297", "fab" };
        public static string[] FAWpexplorer = { "\uf2de", "fab" };
        public static string[] FAWpforms = { "\uf298", "fab" };
        public static string[] FAWpressr = { "\uf3e4", "fab" };
        public static string[] FAWreath = { "\uf7e2", "fa" };
        public static string[] FAWreathO = { "\uf7e2", "far" };
        public static string[] FAWrench = { "\uf0ad", "fa" };
        public static string[] FAWrenchO = { "\uf0ad", "far" };
        public static string[] FAXRay = { "\uf497", "fa" };
        public static string[] FAXRayO = { "\uf497", "far" };
        public static string[] FAXbox = { "\uf412", "fab" };
        public static string[] FAXing = { "\uf168", "fab" };
        public static string[] FAXingSquare = { "\uf169", "fab" };
        public static string[] FAYCombinator = { "\uf23b", "fab" };
        public static string[] FAYahoo = { "\uf19e", "fab" };
        public static string[] FAYammer = { "\uf840", "fab" };
        public static string[] FAYandex = { "\uf413", "fab" };
        public static string[] FAYandexInternational = { "\uf414", "fab" };
        public static string[] FAYarn = { "\uf7e3", "fab" };
        public static string[] FAYelp = { "\uf1e9", "fab" };
        public static string[] FAYenSign = { "\uf157", "fa" };
        public static string[] FAYenSignO = { "\uf157", "far" };
        public static string[] FAYinYang = { "\uf6ad", "fa" };
        public static string[] FAYinYangO = { "\uf6ad", "far" };
        public static string[] FAYoast = { "\uf2b1", "fab" };
        public static string[] FAYoutube = { "\uf167", "fab" };
        public static string[] FAYoutubeSquare = { "\uf431", "fab" };
        public static string[] FAZhihu = { "\uf63f", "fab" };

        public static string[] MAFolderMapMarker = { "\ue000", "ma" };
        public static string[] MAViledaTrolleyDamage = { "\ue001", "ma" };
        public static string[] MAViledaCheckCondition = { "\ue002", "ma" };
        public static string[] MAViledaCheckEquipment = { "\ue003", "ma" };
        public static string[] MAViledaTrolleyPrepare = { "\ue004", "ma" };
        public static string[] MAViledaTrolleyRegister = { "\ue005", "ma" };
        public static string[] MAViledaTrolleyCheck = { "\ue006", "ma" };
        public static string[] MABorrow = { "\ue008", "ma" };
        public static string[] MAReturn = { "\ue009", "ma" };
        public static string[] MABackspace = { "\ue00a", "ma" };
        public static string[] MATowel = { "\ue00b", "ma" };
        public static string[] MAToiletroll = { "\ue00c", "ma" };
        public static string[] MARfidscanner = { "\ue00d", "ma" };
        public static string[] MAShirt = { "\ue00e", "ma" };
        public static string[] MABeacon = { "\ue00f", "ma" };
        public static string[] MAMop = { "\ue010", "ma" };
        public static string[] MAFolderCompany = { "\ue011", "ma" };
        public static string[] MAFolderElement = { "\ue012", "ma" };
        public static string[] MAFolderUser = { "\ue013", "ma" };
        public static string[] MAEnvelopeSlash = { "\ue014", "ma" };
        public static string[] MAFolderDepartment = { "\ue015", "ma" };
        public static string[] MAMapMarkerCircle = { "\ue016", "ma" };
        public static string[] MAMapMarkerSquare = { "\ue017", "ma" };
        public static string[] MABoltSquareSlash = { "\ue018", "ma" };
        public static string[] MABoltSquare = { "\ue019", "ma" };
        public static string[] MALockCircle = { "\ue01a", "ma" };
        public static string[] MASignInCircle = { "\ue01c", "ma" };
        public static string[] MASignOutCircle = { "\ue01b", "ma" };
        public static string[] MAKeyCircle = { "\ue01d", "ma" };
        public static string[] MAOphardtBottles01 = { "\ue01e", "ma" };
        public static string[] MAOphardtBucket01 = { "\ue01f", "ma" };
        public static string[] MAOphardtBucket02 = { "\ue020", "ma" };
        public static string[] MAOphardtBucket03 = { "\ue021", "ma" };
        public static string[] MAOphardtCheckList01 = { "\ue022", "ma" };
        public static string[] MAOphardtDisinfectantFillLevel01 = { "\ue023", "ma" };
        public static string[] MAOphardtDisinfectantFillLevel02 = { "\ue024", "ma" };
        public static string[] MAOphardtDisinfectantFillLevel03 = { "\ue025", "ma" };
        public static string[] MAOphardtDisinfectantFillLevel04 = { "\ue026", "ma" };
        public static string[] MAOphardtFeet01 = { "\ue027", "ma" };
        public static string[] MAOphardtFemale01 = { "\ue028", "ma" };
        public static string[] MAOphardtMale01 = { "\ue029", "ma" };
        public static string[] MAOphardtNaviCancel01 = { "\ue02a", "ma" };
        public static string[] MAOphardtNaviDown01 = { "\ue02b", "ma" };
        public static string[] MAOphardtNaviGo01 = { "\ue02c", "ma" };
        public static string[] MAOphardtNaviHelp = { "\ue02d", "ma" };
        public static string[] MAOphardtNaviLeft01 = { "\ue02e", "ma" };
        public static string[] MAOphardtNaviOk01 = { "\ue02f", "ma" };
        public static string[] MAOphardtNaviOk02 = { "\ue030", "ma" };
        public static string[] MAOphardtNaviRefresh01 = { "\ue031", "ma" };
        public static string[] MAOphardtNaviRight01 = { "\ue032", "ma" };
        public static string[] MAOphardtNaviUp01 = { "\ue033", "ma" };
        public static string[] MAOphardtPaperTowelDispenser01 = { "\ue034", "ma" };
        public static string[] MAOphardtPaperTowels01 = { "\ue035", "ma" };
        public static string[] MAOphardtPaperTowels02 = { "\ue036", "ma" };
        public static string[] MAOphardSoap01 = { "\ue037", "ma" };
        public static string[] MAOphardtSoapFillLevel01 = { "\ue038", "ma" };
        public static string[] MAOphardtSoapFillLevel02 = { "\ue039", "ma" };
        public static string[] MAOphardtSoapFillLevel03 = { "\ue03a", "ma" };
        public static string[] MAOphardtSoapFillLevel04 = { "\ue03b", "ma" };
        public static string[] MAOphardtStatus01 = { "\ue03c", "ma" };
        public static string[] MAOphardtStatus02 = { "\ue03d", "ma" };
        public static string[] MAOphardtStatus03 = { "\ue03e", "ma" };
        public static string[] MAOphardtStatus04 = { "\ue03f", "ma" };
        public static string[] MAOphardtToiletPaper01 = { "\ue040", "ma" };
        public static string[] MAOphardtToiletPaperDispenser01 = { "\ue041", "ma" };
        public static string[] MAOphardtToiletPaperDispenser02 = { "\ue042", "ma" };
        public static string[] MAOphardtVisitor01 = { "\ue043", "ma" };
        public static string[] MAOphardtVisitor02 = { "\ue044", "ma" };
        public static string[] MAOphardtVisitor03 = { "\ue045", "ma" };
        public static string[] MAOphardtWasteBin01 = { "\ue046", "ma" };
        public static string[] MAOphardtWasteBin02 = { "\ue047", "ma" };
        public static string[] MAOphardtWasteBin03 = { "\ue048", "ma" };
        public static string[] MAOphardtWasteBinFillLevel01 = { "\ue049", "ma" };
        public static string[] MAOphardtWasteBinFillLevel02 = { "\ue04a", "ma" };
        public static string[] MAOphardtWasteBinFillLevel03 = { "\ue04b", "ma" };
        public static string[] MAOphardtWasteBinFillLevel04 = { "\ue04c", "ma" };

        // old names that still may be used in the database; db values are
        // mapped with FieldName function; for example ma-vileda-prepare-trolley
        // is mapped to MAViledaPrepareTrolley
        public static string[] MATrolley = { "\ue006", "ma" };
        public static string[] MAViledaReportDamage = { "\ue001", "ma" };
        public static string[] MAViledaPrepareTrolley = { "\ue004", "ma" };
        public static string[] MAViledaRegisterNewTrolley = { "\ue005", "ma" };
        public static string[] MAToiletRoll = { "\ue00c", "ma" };
        public static string[] MARFIDScanner = { "\ue00d", "ma" };
        public static string[] MAMapCircle = { "\ue016", "ma" };
        public static string[] MABoltSlash = { "\ue018", "ma" };
        public static string[] MABolt = { "\ue019", "ma" };

        public static Dictionary<string, string> constantToCSS = new Dictionary<string, string> {
            { "\uf26e", "fa-500px" },
            { "\uf640", "fa-abacus" },
            { "\uf368", "fa-accessible-icon" },
            { "\uf369", "fa-accusoft" },
            { "\uf6ae", "fa-acorn" },
            { "\uf6af", "fa-acquisitions-incorporated" },
            { "\uf641", "fa-ad" },
            { "\uf2b9", "fa-address-book" },
            { "\uf2bb", "fa-address-card" },
            { "\uf042", "fa-adjust" },
            { "\uf170", "fa-adn" },
            { "\uf778", "fa-adobe" },
            { "\uf36a", "fa-adversal" },
            { "\uf36b", "fa-affiliatetheme" },
            { "\uf5d0", "fa-air-freshener" },
            { "\uf834", "fa-airbnb" },
            { "\uf34e", "fa-alarm-clock" },
            { "\uf843", "fa-alarm-exclamation" },
            { "\uf844", "fa-alarm-plus" },
            { "\uf845", "fa-alarm-snooze" },
            { "\uf36c", "fa-algolia" },
            { "\uf6b0", "fa-alicorn" },
            { "\uf037", "fa-align-center" },
            { "\uf039", "fa-align-justify" },
            { "\uf036", "fa-align-left" },
            { "\uf038", "fa-align-right" },
            { "\uf846", "fa-align-slash" },
            { "\uf642", "fa-alipay" },
            { "\uf461", "fa-allergies" },
            { "\uf270", "fa-amazon" },
            { "\uf42c", "fa-amazon-pay" },
            { "\uf0f9", "fa-ambulance" },
            { "\uf2a3", "fa-american-sign-language-interpreting" },
            { "\uf36d", "fa-amilia" },
            { "\uf643", "fa-analytics" },
            { "\uf13d", "fa-anchor" },
            { "\uf17b", "fa-android" },
            { "\uf779", "fa-angel" },
            { "\uf209", "fa-angellist" },
            { "\uf103", "fa-angle-double-down" },
            { "\uf100", "fa-angle-double-left" },
            { "\uf101", "fa-angle-double-right" },
            { "\uf102", "fa-angle-double-up" },
            { "\uf107", "fa-angle-down" },
            { "\uf104", "fa-angle-left" },
            { "\uf105", "fa-angle-right" },
            { "\uf106", "fa-angle-up" },
            { "\uf556", "fa-angry" },
            { "\uf36e", "fa-angrycreative" },
            { "\uf420", "fa-angular" },
            { "\uf644", "fa-ankh" },
            { "\uf36f", "fa-app-store" },
            { "\uf370", "fa-app-store-ios" },
            { "\uf371", "fa-apper" },
            { "\uf179", "fa-apple" },
            { "\uf5d1", "fa-apple-alt" },
            { "\uf6b1", "fa-apple-crate" },
            { "\uf415", "fa-apple-pay" },
            { "\uf187", "fa-archive" },
            { "\uf557", "fa-archway" },
            { "\uf358", "fa-arrow-alt-circle-down" },
            { "\uf359", "fa-arrow-alt-circle-left" },
            { "\uf35a", "fa-arrow-alt-circle-right" },
            { "\uf35b", "fa-arrow-alt-circle-up" },
            { "\uf354", "fa-arrow-alt-down" },
            { "\uf346", "fa-arrow-alt-from-bottom" },
            { "\uf347", "fa-arrow-alt-from-left" },
            { "\uf348", "fa-arrow-alt-from-right" },
            { "\uf349", "fa-arrow-alt-from-top" },
            { "\uf355", "fa-arrow-alt-left" },
            { "\uf356", "fa-arrow-alt-right" },
            { "\uf350", "fa-arrow-alt-square-down" },
            { "\uf351", "fa-arrow-alt-square-left" },
            { "\uf352", "fa-arrow-alt-square-right" },
            { "\uf353", "fa-arrow-alt-square-up" },
            { "\uf34a", "fa-arrow-alt-to-bottom" },
            { "\uf34b", "fa-arrow-alt-to-left" },
            { "\uf34c", "fa-arrow-alt-to-right" },
            { "\uf34d", "fa-arrow-alt-to-top" },
            { "\uf357", "fa-arrow-alt-up" },
            { "\uf0ab", "fa-arrow-circle-down" },
            { "\uf0a8", "fa-arrow-circle-left" },
            { "\uf0a9", "fa-arrow-circle-right" },
            { "\uf0aa", "fa-arrow-circle-up" },
            { "\uf063", "fa-arrow-down" },
            { "\uf342", "fa-arrow-from-bottom" },
            { "\uf343", "fa-arrow-from-left" },
            { "\uf344", "fa-arrow-from-right" },
            { "\uf345", "fa-arrow-from-top" },
            { "\uf060", "fa-arrow-left" },
            { "\uf061", "fa-arrow-right" },
            { "\uf339", "fa-arrow-square-down" },
            { "\uf33a", "fa-arrow-square-left" },
            { "\uf33b", "fa-arrow-square-right" },
            { "\uf33c", "fa-arrow-square-up" },
            { "\uf33d", "fa-arrow-to-bottom" },
            { "\uf33e", "fa-arrow-to-left" },
            { "\uf340", "fa-arrow-to-right" },
            { "\uf341", "fa-arrow-to-top" },
            { "\uf062", "fa-arrow-up" },
            { "\uf047", "fa-arrows" },
            { "\uf0b2", "fa-arrows-alt" },
            { "\uf337", "fa-arrows-alt-h" },
            { "\uf338", "fa-arrows-alt-v" },
            { "\uf07e", "fa-arrows-h" },
            { "\uf07d", "fa-arrows-v" },
            { "\uf77a", "fa-artstation" },
            { "\uf2a2", "fa-assistive-listening-systems" },
            { "\uf069", "fa-asterisk" },
            { "\uf372", "fa-asymmetrik" },
            { "\uf1fa", "fa-at" },
            { "\uf558", "fa-atlas" },
            { "\uf77b", "fa-atlassian" },
            { "\uf5d2", "fa-atom" },
            { "\uf5d3", "fa-atom-alt" },
            { "\uf373", "fa-audible" },
            { "\uf29e", "fa-audio-description" },
            { "\uf41c", "fa-autoprefixer" },
            { "\uf374", "fa-avianex" },
            { "\uf421", "fa-aviato" },
            { "\uf559", "fa-award" },
            { "\uf375", "fa-aws" },
            { "\uf6b2", "fa-axe" },
            { "\uf6b3", "fa-axe-battle" },
            { "\uf77c", "fa-baby" },
            { "\uf77d", "fa-baby-carriage" },
            { "\uf5d4", "fa-backpack" },
            { "\uf55a", "fa-backspace" },
            { "\uf04a", "fa-backward" },
            { "\uf7e5", "fa-bacon" },
            { "\uf335", "fa-badge" },
            { "\uf336", "fa-badge-check" },
            { "\uf645", "fa-badge-dollar" },
            { "\uf646", "fa-badge-percent" },
            { "\uf6b4", "fa-badger-honey" },
            { "\uf847", "fa-bags-shopping" },
            { "\uf24e", "fa-balance-scale" },
            { "\uf515", "fa-balance-scale-left" },
            { "\uf516", "fa-balance-scale-right" },
            { "\uf77e", "fa-ball-pile" },
            { "\uf732", "fa-ballot" },
            { "\uf733", "fa-ballot-check" },
            { "\uf05e", "fa-ban" },
            { "\uf462", "fa-band-aid" },
            { "\uf2d5", "fa-bandcamp" },
            { "\uf02a", "fa-barcode" },
            { "\uf463", "fa-barcode-alt" },
            { "\uf464", "fa-barcode-read" },
            { "\uf465", "fa-barcode-scan" },
            { "\uf0c9", "fa-bars" },
            { "\uf432", "fa-baseball" },
            { "\uf433", "fa-baseball-ball" },
            { "\uf434", "fa-basketball-ball" },
            { "\uf435", "fa-basketball-hoop" },
            { "\uf6b5", "fa-bat" },
            { "\uf2cd", "fa-bath" },
            { "\uf376", "fa-battery-bolt" },
            { "\uf244", "fa-battery-empty" },
            { "\uf240", "fa-battery-full" },
            { "\uf242", "fa-battery-half" },
            { "\uf243", "fa-battery-quarter" },
            { "\uf377", "fa-battery-slash" },
            { "\uf241", "fa-battery-three-quarters" },
            { "\uf835", "fa-battle-net" },
            { "\uf236", "fa-bed" },
            { "\uf0fc", "fa-beer" },
            { "\uf1b4", "fa-behance" },
            { "\uf1b5", "fa-behance-square" },
            { "\uf0f3", "fa-bell" },
            { "\uf848", "fa-bell-exclamation" },
            { "\uf849", "fa-bell-plus" },
            { "\uf5d5", "fa-bell-school" },
            { "\uf5d6", "fa-bell-school-slash" },
            { "\uf1f6", "fa-bell-slash" },
            { "\uf77f", "fa-bells" },
            { "\uf55b", "fa-bezier-curve" },
            { "\uf647", "fa-bible" },
            { "\uf206", "fa-bicycle" },
            { "\uf84a", "fa-biking" },
            { "\uf84b", "fa-biking-mountain" },
            { "\uf378", "fa-bimobject" },
            { "\uf1e5", "fa-binoculars" },
            { "\uf780", "fa-biohazard" },
            { "\uf1fd", "fa-birthday-cake" },
            { "\uf171", "fa-bitbucket" },
            { "\uf379", "fa-bitcoin" },
            { "\uf37a", "fa-bity" },
            { "\uf27e", "fa-black-tie" },
            { "\uf37b", "fa-blackberry" },
            { "\uf498", "fa-blanket" },
            { "\uf517", "fa-blender" },
            { "\uf6b6", "fa-blender-phone" },
            { "\uf29d", "fa-blind" },
            { "\uf781", "fa-blog" },
            { "\uf37c", "fa-blogger" },
            { "\uf37d", "fa-blogger-b" },
            { "\uf293", "fa-bluetooth" },
            { "\uf294", "fa-bluetooth-b" },
            { "\uf032", "fa-bold" },
            { "\uf0e7", "fa-bolt" },
            { "\uf1e2", "fa-bomb" },
            { "\uf5d7", "fa-bone" },
            { "\uf5d8", "fa-bone-break" },
            { "\uf55c", "fa-bong" },
            { "\uf02d", "fa-book" },
            { "\uf5d9", "fa-book-alt" },
            { "\uf6b7", "fa-book-dead" },
            { "\uf499", "fa-book-heart" },
            { "\uf7e6", "fa-book-medical" },
            { "\uf518", "fa-book-open" },
            { "\uf5da", "fa-book-reader" },
            { "\uf6b8", "fa-book-spells" },
            { "\uf7e7", "fa-book-user" },
            { "\uf02e", "fa-bookmark" },
            { "\uf5db", "fa-books" },
            { "\uf7e8", "fa-books-medical" },
            { "\uf782", "fa-boot" },
            { "\uf734", "fa-booth-curtain" },
            { "\uf836", "fa-bootstrap" },
            { "\uf84c", "fa-border-all" },
            { "\uf84d", "fa-border-bottom" },
            { "\uf84e", "fa-border-inner" },
            { "\uf84f", "fa-border-left" },
            { "\uf850", "fa-border-none" },
            { "\uf851", "fa-border-outer" },
            { "\uf852", "fa-border-right" },
            { "\uf853", "fa-border-style" },
            { "\uf854", "fa-border-style-alt" },
            { "\uf855", "fa-border-top" },
            { "\uf6b9", "fa-bow-arrow" },
            { "\uf436", "fa-bowling-ball" },
            { "\uf437", "fa-bowling-pins" },
            { "\uf466", "fa-box" },
            { "\uf49a", "fa-box-alt" },
            { "\uf735", "fa-box-ballot" },
            { "\uf467", "fa-box-check" },
            { "\uf49b", "fa-box-fragile" },
            { "\uf49c", "fa-box-full" },
            { "\uf49d", "fa-box-heart" },
            { "\uf49e", "fa-box-open" },
            { "\uf49f", "fa-box-up" },
            { "\uf4a0", "fa-box-usd" },
            { "\uf468", "fa-boxes" },
            { "\uf4a1", "fa-boxes-alt" },
            { "\uf438", "fa-boxing-glove" },
            { "\uf7e9", "fa-brackets" },
            { "\uf7ea", "fa-brackets-curly" },
            { "\uf2a1", "fa-braille" },
            { "\uf5dc", "fa-brain" },
            { "\uf7eb", "fa-bread-loaf" },
            { "\uf7ec", "fa-bread-slice" },
            { "\uf0b1", "fa-briefcase" },
            { "\uf469", "fa-briefcase-medical" },
            { "\uf856", "fa-bring-forward" },
            { "\uf857", "fa-bring-front" },
            { "\uf519", "fa-broadcast-tower" },
            { "\uf51a", "fa-broom" },
            { "\uf37e", "fa-browser" },
            { "\uf55d", "fa-brush" },
            { "\uf15a", "fa-btc" },
            { "\uf837", "fa-buffer" },
            { "\uf188", "fa-bug" },
            { "\uf1ad", "fa-building" },
            { "\uf0a1", "fa-bullhorn" },
            { "\uf140", "fa-bullseye" },
            { "\uf648", "fa-bullseye-arrow" },
            { "\uf649", "fa-bullseye-pointer" },
            { "\uf858", "fa-burger-soda" },
            { "\uf46a", "fa-burn" },
            { "\uf37f", "fa-buromobelexperte" },
            { "\uf7ed", "fa-burrito" },
            { "\uf207", "fa-bus" },
            { "\uf55e", "fa-bus-alt" },
            { "\uf5dd", "fa-bus-school" },
            { "\uf64a", "fa-business-time" },
            { "\uf20d", "fa-buysellads" },
            { "\uf64b", "fa-cabinet-filing" },
            { "\uf1ec", "fa-calculator" },
            { "\uf64c", "fa-calculator-alt" },
            { "\uf133", "fa-calendar" },
            { "\uf073", "fa-calendar-alt" },
            { "\uf274", "fa-calendar-check" },
            { "\uf783", "fa-calendar-day" },
            { "\uf333", "fa-calendar-edit" },
            { "\uf334", "fa-calendar-exclamation" },
            { "\uf272", "fa-calendar-minus" },
            { "\uf271", "fa-calendar-plus" },
            { "\uf736", "fa-calendar-star" },
            { "\uf273", "fa-calendar-times" },
            { "\uf784", "fa-calendar-week" },
            { "\uf030", "fa-camera" },
            { "\uf332", "fa-camera-alt" },
            { "\uf083", "fa-camera-retro" },
            { "\uf6ba", "fa-campfire" },
            { "\uf6bb", "fa-campground" },
            { "\uf785", "fa-canadian-maple-leaf" },
            { "\uf6bc", "fa-candle-holder" },
            { "\uf786", "fa-candy-cane" },
            { "\uf6bd", "fa-candy-corn" },
            { "\uf55f", "fa-cannabis" },
            { "\uf46b", "fa-capsules" },
            { "\uf1b9", "fa-car" },
            { "\uf5de", "fa-car-alt" },
            { "\uf5df", "fa-car-battery" },
            { "\uf859", "fa-car-building" },
            { "\uf5e0", "fa-car-bump" },
            { "\uf85a", "fa-car-bus" },
            { "\uf5e1", "fa-car-crash" },
            { "\uf5e2", "fa-car-garage" },
            { "\uf5e3", "fa-car-mechanic" },
            { "\uf5e4", "fa-car-side" },
            { "\uf5e5", "fa-car-tilt" },
            { "\uf5e6", "fa-car-wash" },
            { "\uf32d", "fa-caret-circle-down" },
            { "\uf32e", "fa-caret-circle-left" },
            { "\uf330", "fa-caret-circle-right" },
            { "\uf331", "fa-caret-circle-up" },
            { "\uf0d7", "fa-caret-down" },
            { "\uf0d9", "fa-caret-left" },
            { "\uf0da", "fa-caret-right" },
            { "\uf150", "fa-caret-square-down" },
            { "\uf191", "fa-caret-square-left" },
            { "\uf152", "fa-caret-square-right" },
            { "\uf151", "fa-caret-square-up" },
            { "\uf0d8", "fa-caret-up" },
            { "\uf787", "fa-carrot" },
            { "\uf85b", "fa-cars" },
            { "\uf218", "fa-cart-arrow-down" },
            { "\uf217", "fa-cart-plus" },
            { "\uf788", "fa-cash-register" },
            { "\uf6be", "fa-cat" },
            { "\uf6bf", "fa-cauldron" },
            { "\uf42d", "fa-cc-amazon-pay" },
            { "\uf1f3", "fa-cc-amex" },
            { "\uf416", "fa-cc-apple-pay" },
            { "\uf24c", "fa-cc-diners-club" },
            { "\uf1f2", "fa-cc-discover" },
            { "\uf24b", "fa-cc-jcb" },
            { "\uf1f1", "fa-cc-mastercard" },
            { "\uf1f4", "fa-cc-paypal" },
            { "\uf1f5", "fa-cc-stripe" },
            { "\uf1f0", "fa-cc-visa" },
            { "\uf380", "fa-centercode" },
            { "\uf789", "fa-centos" },
            { "\uf0a3", "fa-certificate" },
            { "\uf6c0", "fa-chair" },
            { "\uf6c1", "fa-chair-office" },
            { "\uf51b", "fa-chalkboard" },
            { "\uf51c", "fa-chalkboard-teacher" },
            { "\uf5e7", "fa-charging-station" },
            { "\uf1fe", "fa-chart-area" },
            { "\uf080", "fa-chart-bar" },
            { "\uf201", "fa-chart-line" },
            { "\uf64d", "fa-chart-line-down" },
            { "\uf78a", "fa-chart-network" },
            { "\uf200", "fa-chart-pie" },
            { "\uf64e", "fa-chart-pie-alt" },
            { "\uf7ee", "fa-chart-scatter" },
            { "\uf00c", "fa-check" },
            { "\uf058", "fa-check-circle" },
            { "\uf560", "fa-check-double" },
            { "\uf14a", "fa-check-square" },
            { "\uf7ef", "fa-cheese" },
            { "\uf7f0", "fa-cheese-swiss" },
            { "\uf7f1", "fa-cheeseburger" },
            { "\uf439", "fa-chess" },
            { "\uf43a", "fa-chess-bishop" },
            { "\uf43b", "fa-chess-bishop-alt" },
            { "\uf43c", "fa-chess-board" },
            { "\uf43d", "fa-chess-clock" },
            { "\uf43e", "fa-chess-clock-alt" },
            { "\uf43f", "fa-chess-king" },
            { "\uf440", "fa-chess-king-alt" },
            { "\uf441", "fa-chess-knight" },
            { "\uf442", "fa-chess-knight-alt" },
            { "\uf443", "fa-chess-pawn" },
            { "\uf444", "fa-chess-pawn-alt" },
            { "\uf445", "fa-chess-queen" },
            { "\uf446", "fa-chess-queen-alt" },
            { "\uf447", "fa-chess-rook" },
            { "\uf448", "fa-chess-rook-alt" },
            { "\uf13a", "fa-chevron-circle-down" },
            { "\uf137", "fa-chevron-circle-left" },
            { "\uf138", "fa-chevron-circle-right" },
            { "\uf139", "fa-chevron-circle-up" },
            { "\uf322", "fa-chevron-double-down" },
            { "\uf323", "fa-chevron-double-left" },
            { "\uf324", "fa-chevron-double-right" },
            { "\uf325", "fa-chevron-double-up" },
            { "\uf078", "fa-chevron-down" },
            { "\uf053", "fa-chevron-left" },
            { "\uf054", "fa-chevron-right" },
            { "\uf329", "fa-chevron-square-down" },
            { "\uf32a", "fa-chevron-square-left" },
            { "\uf32b", "fa-chevron-square-right" },
            { "\uf32c", "fa-chevron-square-up" },
            { "\uf077", "fa-chevron-up" },
            { "\uf1ae", "fa-child" },
            { "\uf78b", "fa-chimney" },
            { "\uf268", "fa-chrome" },
            { "\uf838", "fa-chromecast" },
            { "\uf51d", "fa-church" },
            { "\uf111", "fa-circle" },
            { "\uf1ce", "fa-circle-notch" },
            { "\uf64f", "fa-city" },
            { "\uf6c2", "fa-claw-marks" },
            { "\uf7f2", "fa-clinic-medical" },
            { "\uf328", "fa-clipboard" },
            { "\uf46c", "fa-clipboard-check" },
            { "\uf46d", "fa-clipboard-list" },
            { "\uf737", "fa-clipboard-list-check" },
            { "\uf5e8", "fa-clipboard-prescription" },
            { "\uf7f3", "fa-clipboard-user" },
            { "\uf017", "fa-clock" },
            { "\uf24d", "fa-clone" },
            { "\uf20a", "fa-closed-captioning" },
            { "\uf0c2", "fa-cloud" },
            { "\uf0ed", "fa-cloud-download" },
            { "\uf381", "fa-cloud-download-alt" },
            { "\uf738", "fa-cloud-drizzle" },
            { "\uf739", "fa-cloud-hail" },
            { "\uf73a", "fa-cloud-hail-mixed" },
            { "\uf73b", "fa-cloud-meatball" },
            { "\uf6c3", "fa-cloud-moon" },
            { "\uf73c", "fa-cloud-moon-rain" },
            { "\uf73d", "fa-cloud-rain" },
            { "\uf73e", "fa-cloud-rainbow" },
            { "\uf73f", "fa-cloud-showers" },
            { "\uf740", "fa-cloud-showers-heavy" },
            { "\uf741", "fa-cloud-sleet" },
            { "\uf742", "fa-cloud-snow" },
            { "\uf6c4", "fa-cloud-sun" },
            { "\uf743", "fa-cloud-sun-rain" },
            { "\uf0ee", "fa-cloud-upload" },
            { "\uf382", "fa-cloud-upload-alt" },
            { "\uf744", "fa-clouds" },
            { "\uf745", "fa-clouds-moon" },
            { "\uf746", "fa-clouds-sun" },
            { "\uf383", "fa-cloudscale" },
            { "\uf384", "fa-cloudsmith" },
            { "\uf385", "fa-cloudversify" },
            { "\uf327", "fa-club" },
            { "\uf561", "fa-cocktail" },
            { "\uf121", "fa-code" },
            { "\uf126", "fa-code-branch" },
            { "\uf386", "fa-code-commit" },
            { "\uf387", "fa-code-merge" },
            { "\uf1cb", "fa-codepen" },
            { "\uf284", "fa-codiepie" },
            { "\uf0f4", "fa-coffee" },
            { "\uf6c5", "fa-coffee-togo" },
            { "\uf6c6", "fa-coffin" },
            { "\uf013", "fa-cog" },
            { "\uf085", "fa-cogs" },
            { "\uf85c", "fa-coin" },
            { "\uf51e", "fa-coins" },
            { "\uf0db", "fa-columns" },
            { "\uf075", "fa-comment" },
            { "\uf27a", "fa-comment-alt" },
            { "\uf4a2", "fa-comment-alt-check" },
            { "\uf650", "fa-comment-alt-dollar" },
            { "\uf4a3", "fa-comment-alt-dots" },
            { "\uf4a4", "fa-comment-alt-edit" },
            { "\uf4a5", "fa-comment-alt-exclamation" },
            { "\uf4a6", "fa-comment-alt-lines" },
            { "\uf7f4", "fa-comment-alt-medical" },
            { "\uf4a7", "fa-comment-alt-minus" },
            { "\uf4a8", "fa-comment-alt-plus" },
            { "\uf4a9", "fa-comment-alt-slash" },
            { "\uf4aa", "fa-comment-alt-smile" },
            { "\uf4ab", "fa-comment-alt-times" },
            { "\uf4ac", "fa-comment-check" },
            { "\uf651", "fa-comment-dollar" },
            { "\uf4ad", "fa-comment-dots" },
            { "\uf4ae", "fa-comment-edit" },
            { "\uf4af", "fa-comment-exclamation" },
            { "\uf4b0", "fa-comment-lines" },
            { "\uf7f5", "fa-comment-medical" },
            { "\uf4b1", "fa-comment-minus" },
            { "\uf4b2", "fa-comment-plus" },
            { "\uf4b3", "fa-comment-slash" },
            { "\uf4b4", "fa-comment-smile" },
            { "\uf4b5", "fa-comment-times" },
            { "\uf086", "fa-comments" },
            { "\uf4b6", "fa-comments-alt" },
            { "\uf652", "fa-comments-alt-dollar" },
            { "\uf653", "fa-comments-dollar" },
            { "\uf51f", "fa-compact-disc" },
            { "\uf14e", "fa-compass" },
            { "\uf5e9", "fa-compass-slash" },
            { "\uf066", "fa-compress" },
            { "\uf422", "fa-compress-alt" },
            { "\uf78c", "fa-compress-arrows-alt" },
            { "\uf326", "fa-compress-wide" },
            { "\uf562", "fa-concierge-bell" },
            { "\uf78d", "fa-confluence" },
            { "\uf20e", "fa-connectdevelop" },
            { "\uf85d", "fa-construction" },
            { "\uf4b7", "fa-container-storage" },
            { "\uf26d", "fa-contao" },
            { "\uf46e", "fa-conveyor-belt" },
            { "\uf46f", "fa-conveyor-belt-alt" },
            { "\uf563", "fa-cookie" },
            { "\uf564", "fa-cookie-bite" },
            { "\uf0c5", "fa-copy" },
            { "\uf1f9", "fa-copyright" },
            { "\uf6c7", "fa-corn" },
            { "\uf4b8", "fa-couch" },
            { "\uf6c8", "fa-cow" },
            { "\uf388", "fa-cpanel" },
            { "\uf25e", "fa-creative-commons" },
            { "\uf4e7", "fa-creative-commons-by" },
            { "\uf4e8", "fa-creative-commons-nc" },
            { "\uf4e9", "fa-creative-commons-nc-eu" },
            { "\uf4ea", "fa-creative-commons-nc-jp" },
            { "\uf4eb", "fa-creative-commons-nd" },
            { "\uf4ec", "fa-creative-commons-pd" },
            { "\uf4ed", "fa-creative-commons-pd-alt" },
            { "\uf4ee", "fa-creative-commons-remix" },
            { "\uf4ef", "fa-creative-commons-sa" },
            { "\uf4f0", "fa-creative-commons-sampling" },
            { "\uf4f1", "fa-creative-commons-sampling-plus" },
            { "\uf4f2", "fa-creative-commons-share" },
            { "\uf4f3", "fa-creative-commons-zero" },
            { "\uf09d", "fa-credit-card" },
            { "\uf389", "fa-credit-card-blank" },
            { "\uf38a", "fa-credit-card-front" },
            { "\uf449", "fa-cricket" },
            { "\uf6c9", "fa-critical-role" },
            { "\uf7f6", "fa-croissant" },
            { "\uf125", "fa-crop" },
            { "\uf565", "fa-crop-alt" },
            { "\uf654", "fa-cross" },
            { "\uf05b", "fa-crosshairs" },
            { "\uf520", "fa-crow" },
            { "\uf521", "fa-crown" },
            { "\uf7f7", "fa-crutch" },
            { "\uf7f8", "fa-crutches" },
            { "\uf13c", "fa-css3" },
            { "\uf38b", "fa-css3-alt" },
            { "\uf1b2", "fa-cube" },
            { "\uf1b3", "fa-cubes" },
            { "\uf44a", "fa-curling" },
            { "\uf0c4", "fa-cut" },
            { "\uf38c", "fa-cuttlefish" },
            { "\uf38d", "fa-d-and-d" },
            { "\uf6ca", "fa-d-and-d-beyond" },
            { "\uf6cb", "fa-dagger" },
            { "\uf210", "fa-dashcube" },
            { "\uf1c0", "fa-database" },
            { "\uf2a4", "fa-deaf" },
            { "\uf7f9", "fa-debug" },
            { "\uf78e", "fa-deer" },
            { "\uf78f", "fa-deer-rudolph" },
            { "\uf1a5", "fa-delicious" },
            { "\uf747", "fa-democrat" },
            { "\uf38e", "fa-deploydog" },
            { "\uf38f", "fa-deskpro" },
            { "\uf108", "fa-desktop" },
            { "\uf390", "fa-desktop-alt" },
            { "\uf6cc", "fa-dev" },
            { "\uf1bd", "fa-deviantart" },
            { "\uf748", "fa-dewpoint" },
            { "\uf655", "fa-dharmachakra" },
            { "\uf790", "fa-dhl" },
            { "\uf470", "fa-diagnoses" },
            { "\uf219", "fa-diamond" },
            { "\uf791", "fa-diaspora" },
            { "\uf522", "fa-dice" },
            { "\uf6cd", "fa-dice-d10" },
            { "\uf6ce", "fa-dice-d12" },
            { "\uf6cf", "fa-dice-d20" },
            { "\uf6d0", "fa-dice-d4" },
            { "\uf6d1", "fa-dice-d6" },
            { "\uf6d2", "fa-dice-d8" },
            { "\uf523", "fa-dice-five" },
            { "\uf524", "fa-dice-four" },
            { "\uf525", "fa-dice-one" },
            { "\uf526", "fa-dice-six" },
            { "\uf527", "fa-dice-three" },
            { "\uf528", "fa-dice-two" },
            { "\uf1a6", "fa-digg" },
            { "\uf85e", "fa-digging" },
            { "\uf391", "fa-digital-ocean" },
            { "\uf566", "fa-digital-tachograph" },
            { "\uf5ea", "fa-diploma" },
            { "\uf5eb", "fa-directions" },
            { "\uf392", "fa-discord" },
            { "\uf393", "fa-discourse" },
            { "\uf7fa", "fa-disease" },
            { "\uf529", "fa-divide" },
            { "\uf567", "fa-dizzy" },
            { "\uf471", "fa-dna" },
            { "\uf5ec", "fa-do-not-enter" },
            { "\uf394", "fa-dochub" },
            { "\uf395", "fa-docker" },
            { "\uf6d3", "fa-dog" },
            { "\uf6d4", "fa-dog-leashed" },
            { "\uf155", "fa-dollar-sign" },
            { "\uf472", "fa-dolly" },
            { "\uf473", "fa-dolly-empty" },
            { "\uf474", "fa-dolly-flatbed" },
            { "\uf475", "fa-dolly-flatbed-alt" },
            { "\uf476", "fa-dolly-flatbed-empty" },
            { "\uf4b9", "fa-donate" },
            { "\uf52a", "fa-door-closed" },
            { "\uf52b", "fa-door-open" },
            { "\uf192", "fa-dot-circle" },
            { "\uf4ba", "fa-dove" },
            { "\uf019", "fa-download" },
            { "\uf396", "fa-draft2digital" },
            { "\uf568", "fa-drafting-compass" },
            { "\uf6d5", "fa-dragon" },
            { "\uf5ed", "fa-draw-circle" },
            { "\uf5ee", "fa-draw-polygon" },
            { "\uf5ef", "fa-draw-square" },
            { "\uf792", "fa-dreidel" },
            { "\uf17d", "fa-dribbble" },
            { "\uf397", "fa-dribbble-square" },
            { "\uf85f", "fa-drone" },
            { "\uf860", "fa-drone-alt" },
            { "\uf16b", "fa-dropbox" },
            { "\uf569", "fa-drum" },
            { "\uf56a", "fa-drum-steelpan" },
            { "\uf6d6", "fa-drumstick" },
            { "\uf6d7", "fa-drumstick-bite" },
            { "\uf1a9", "fa-drupal" },
            { "\uf861", "fa-dryer" },
            { "\uf862", "fa-dryer-alt" },
            { "\uf6d8", "fa-duck" },
            { "\uf44b", "fa-dumbbell" },
            { "\uf793", "fa-dumpster" },
            { "\uf794", "fa-dumpster-fire" },
            { "\uf6d9", "fa-dungeon" },
            { "\uf399", "fa-dyalog" },
            { "\uf5f0", "fa-ear" },
            { "\uf795", "fa-ear-muffs" },
            { "\uf39a", "fa-earlybirds" },
            { "\uf4f4", "fa-ebay" },
            { "\uf749", "fa-eclipse" },
            { "\uf74a", "fa-eclipse-alt" },
            { "\uf282", "fa-edge" },
            { "\uf044", "fa-edit" },
            { "\uf7fb", "fa-egg" },
            { "\uf7fc", "fa-egg-fried" },
            { "\uf052", "fa-eject" },
            { "\uf430", "fa-elementor" },
            { "\uf6da", "fa-elephant" },
            { "\uf141", "fa-ellipsis-h" },
            { "\uf39b", "fa-ellipsis-h-alt" },
            { "\uf142", "fa-ellipsis-v" },
            { "\uf39c", "fa-ellipsis-v-alt" },
            { "\uf5f1", "fa-ello" },
            { "\uf423", "fa-ember" },
            { "\uf1d1", "fa-empire" },
            { "\uf656", "fa-empty-set" },
            { "\uf5f2", "fa-engine-warning" },
            { "\uf0e0", "fa-envelope" },
            { "\uf2b6", "fa-envelope-open" },
            { "\uf657", "fa-envelope-open-dollar" },
            { "\uf658", "fa-envelope-open-text" },
            { "\uf199", "fa-envelope-square" },
            { "\uf299", "fa-envira" },
            { "\uf52c", "fa-equals" },
            { "\uf12d", "fa-eraser" },
            { "\uf39d", "fa-erlang" },
            { "\uf42e", "fa-ethereum" },
            { "\uf796", "fa-ethernet" },
            { "\uf2d7", "fa-etsy" },
            { "\uf153", "fa-euro-sign" },
            { "\uf839", "fa-evernote" },
            { "\uf0ec", "fa-exchange" },
            { "\uf362", "fa-exchange-alt" },
            { "\uf12a", "fa-exclamation" },
            { "\uf06a", "fa-exclamation-circle" },
            { "\uf321", "fa-exclamation-square" },
            { "\uf071", "fa-exclamation-triangle" },
            { "\uf065", "fa-expand" },
            { "\uf424", "fa-expand-alt" },
            { "\uf31d", "fa-expand-arrows" },
            { "\uf31e", "fa-expand-arrows-alt" },
            { "\uf320", "fa-expand-wide" },
            { "\uf23e", "fa-expeditedssl" },
            { "\uf08e", "fa-external-link" },
            { "\uf35d", "fa-external-link-alt" },
            { "\uf14c", "fa-external-link-square" },
            { "\uf360", "fa-external-link-square-alt" },
            { "\uf06e", "fa-eye" },
            { "\uf1fb", "fa-eye-dropper" },
            { "\uf6db", "fa-eye-evil" },
            { "\uf070", "fa-eye-slash" },
            { "\uf09a", "fa-facebook" },
            { "\uf39e", "fa-facebook-f" },
            { "\uf39f", "fa-facebook-messenger" },
            { "\uf082", "fa-facebook-square" },
            { "\uf863", "fa-fan" },
            { "\uf6dc", "fa-fantasy-flight-games" },
            { "\uf864", "fa-farm" },
            { "\uf049", "fa-fast-backward" },
            { "\uf050", "fa-fast-forward" },
            { "\uf1ac", "fa-fax" },
            { "\uf52d", "fa-feather" },
            { "\uf56b", "fa-feather-alt" },
            { "\uf797", "fa-fedex" },
            { "\uf798", "fa-fedora" },
            { "\uf182", "fa-female" },
            { "\uf44c", "fa-field-hockey" },
            { "\uf0fb", "fa-fighter-jet" },
            { "\uf799", "fa-figma" },
            { "\uf15b", "fa-file" },
            { "\uf15c", "fa-file-alt" },
            { "\uf1c6", "fa-file-archive" },
            { "\uf1c7", "fa-file-audio" },
            { "\uf5f3", "fa-file-certificate" },
            { "\uf659", "fa-file-chart-line" },
            { "\uf65a", "fa-file-chart-pie" },
            { "\uf316", "fa-file-check" },
            { "\uf1c9", "fa-file-code" },
            { "\uf56c", "fa-file-contract" },
            { "\uf6dd", "fa-file-csv" },
            { "\uf56d", "fa-file-download" },
            { "\uf31c", "fa-file-edit" },
            { "\uf1c3", "fa-file-excel" },
            { "\uf31a", "fa-file-exclamation" },
            { "\uf56e", "fa-file-export" },
            { "\uf1c5", "fa-file-image" },
            { "\uf56f", "fa-file-import" },
            { "\uf570", "fa-file-invoice" },
            { "\uf571", "fa-file-invoice-dollar" },
            { "\uf477", "fa-file-medical" },
            { "\uf478", "fa-file-medical-alt" },
            { "\uf318", "fa-file-minus" },
            { "\uf1c1", "fa-file-pdf" },
            { "\uf319", "fa-file-plus" },
            { "\uf1c4", "fa-file-powerpoint" },
            { "\uf572", "fa-file-prescription" },
            { "\uf865", "fa-file-search" },
            { "\uf573", "fa-file-signature" },
            { "\uf65b", "fa-file-spreadsheet" },
            { "\uf317", "fa-file-times" },
            { "\uf574", "fa-file-upload" },
            { "\uf65c", "fa-file-user" },
            { "\uf1c8", "fa-file-video" },
            { "\uf1c2", "fa-file-word" },
            { "\uf7fd", "fa-files-medical" },
            { "\uf575", "fa-fill" },
            { "\uf576", "fa-fill-drip" },
            { "\uf008", "fa-film" },
            { "\uf3a0", "fa-film-alt" },
            { "\uf0b0", "fa-filter" },
            { "\uf577", "fa-fingerprint" },
            { "\uf06d", "fa-fire" },
            { "\uf7e4", "fa-fire-alt" },
            { "\uf134", "fa-fire-extinguisher" },
            { "\uf74b", "fa-fire-smoke" },
            { "\uf269", "fa-firefox" },
            { "\uf79a", "fa-fireplace" },
            { "\uf479", "fa-first-aid" },
            { "\uf2b0", "fa-first-order" },
            { "\uf50a", "fa-first-order-alt" },
            { "\uf3a1", "fa-firstdraft" },
            { "\uf578", "fa-fish" },
            { "\uf7fe", "fa-fish-cooked" },
            { "\uf6de", "fa-fist-raised" },
            { "\uf024", "fa-flag" },
            { "\uf74c", "fa-flag-alt" },
            { "\uf11e", "fa-flag-checkered" },
            { "\uf74d", "fa-flag-usa" },
            { "\uf6df", "fa-flame" },
            { "\uf0c3", "fa-flask" },
            { "\uf6e0", "fa-flask-poison" },
            { "\uf6e1", "fa-flask-potion" },
            { "\uf16e", "fa-flickr" },
            { "\uf44d", "fa-flipboard" },
            { "\uf7ff", "fa-flower" },
            { "\uf800", "fa-flower-daffodil" },
            { "\uf801", "fa-flower-tulip" },
            { "\uf579", "fa-flushed" },
            { "\uf417", "fa-fly" },
            { "\uf74e", "fa-fog" },
            { "\uf07b", "fa-folder" },
            { "\uf65d", "fa-folder-minus" },
            { "\uf07c", "fa-folder-open" },
            { "\uf65e", "fa-folder-plus" },
            { "\uf65f", "fa-folder-times" },
            { "\uf802", "fa-folder-tree" },
            { "\uf660", "fa-folders" },
            { "\uf031", "fa-font" },
            { "\uf2b4", "fa-font-awesome" },
            { "\uf35c", "fa-font-awesome-alt" },
            { "\uf425", "fa-font-awesome-flag" },
            { "\uf4e6", "fa-font-awesome-logo-full" },
            { "\uf866", "fa-font-case" },
            { "\uf280", "fa-fonticons" },
            { "\uf3a2", "fa-fonticons-fi" },
            { "\uf44e", "fa-football-ball" },
            { "\uf44f", "fa-football-helmet" },
            { "\uf47a", "fa-forklift" },
            { "\uf286", "fa-fort-awesome" },
            { "\uf3a3", "fa-fort-awesome-alt" },
            { "\uf211", "fa-forumbee" },
            { "\uf04e", "fa-forward" },
            { "\uf180", "fa-foursquare" },
            { "\uf4bb", "fa-fragile" },
            { "\uf2c5", "fa-free-code-camp" },
            { "\uf3a4", "fa-freebsd" },
            { "\uf803", "fa-french-fries" },
            { "\uf52e", "fa-frog" },
            { "\uf79b", "fa-frosty-head" },
            { "\uf119", "fa-frown" },
            { "\uf57a", "fa-frown-open" },
            { "\uf50b", "fa-fulcrum" },
            { "\uf661", "fa-function" },
            { "\uf662", "fa-funnel-dollar" },
            { "\uf1e3", "fa-futbol" },
            { "\uf50c", "fa-galactic-republic" },
            { "\uf50d", "fa-galactic-senate" },
            { "\uf867", "fa-game-board" },
            { "\uf868", "fa-game-board-alt" },
            { "\uf11b", "fa-gamepad" },
            { "\uf52f", "fa-gas-pump" },
            { "\uf5f4", "fa-gas-pump-slash" },
            { "\uf0e3", "fa-gavel" },
            { "\uf3a5", "fa-gem" },
            { "\uf22d", "fa-genderless" },
            { "\uf265", "fa-get-pocket" },
            { "\uf260", "fa-gg" },
            { "\uf261", "fa-gg-circle" },
            { "\uf6e2", "fa-ghost" },
            { "\uf06b", "fa-gift" },
            { "\uf663", "fa-gift-card" },
            { "\uf79c", "fa-gifts" },
            { "\uf79d", "fa-gingerbread-man" },
            { "\uf1d3", "fa-git" },
            { "\uf841", "fa-git-alt" },
            { "\uf1d2", "fa-git-square" },
            { "\uf09b", "fa-github" },
            { "\uf113", "fa-github-alt" },
            { "\uf092", "fa-github-square" },
            { "\uf3a6", "fa-gitkraken" },
            { "\uf296", "fa-gitlab" },
            { "\uf426", "fa-gitter" },
            { "\uf804", "fa-glass" },
            { "\uf79e", "fa-glass-champagne" },
            { "\uf79f", "fa-glass-cheers" },
            { "\uf869", "fa-glass-citrus" },
            { "\uf000", "fa-glass-martini" },
            { "\uf57b", "fa-glass-martini-alt" },
            { "\uf7a0", "fa-glass-whiskey" },
            { "\uf7a1", "fa-glass-whiskey-rocks" },
            { "\uf530", "fa-glasses" },
            { "\uf5f5", "fa-glasses-alt" },
            { "\uf2a5", "fa-glide" },
            { "\uf2a6", "fa-glide-g" },
            { "\uf0ac", "fa-globe" },
            { "\uf57c", "fa-globe-africa" },
            { "\uf57d", "fa-globe-americas" },
            { "\uf57e", "fa-globe-asia" },
            { "\uf7a2", "fa-globe-europe" },
            { "\uf7a3", "fa-globe-snow" },
            { "\uf5f6", "fa-globe-stand" },
            { "\uf3a7", "fa-gofore" },
            { "\uf450", "fa-golf-ball" },
            { "\uf451", "fa-golf-club" },
            { "\uf3a8", "fa-goodreads" },
            { "\uf3a9", "fa-goodreads-g" },
            { "\uf1a0", "fa-google" },
            { "\uf3aa", "fa-google-drive" },
            { "\uf3ab", "fa-google-play" },
            { "\uf2b3", "fa-google-plus" },
            { "\uf0d5", "fa-google-plus-g" },
            { "\uf0d4", "fa-google-plus-square" },
            { "\uf1ee", "fa-google-wallet" },
            { "\uf664", "fa-gopuram" },
            { "\uf19d", "fa-graduation-cap" },
            { "\uf184", "fa-gratipay" },
            { "\uf2d6", "fa-grav" },
            { "\uf531", "fa-greater-than" },
            { "\uf532", "fa-greater-than-equal" },
            { "\uf57f", "fa-grimace" },
            { "\uf580", "fa-grin" },
            { "\uf581", "fa-grin-alt" },
            { "\uf582", "fa-grin-beam" },
            { "\uf583", "fa-grin-beam-sweat" },
            { "\uf584", "fa-grin-hearts" },
            { "\uf585", "fa-grin-squint" },
            { "\uf586", "fa-grin-squint-tears" },
            { "\uf587", "fa-grin-stars" },
            { "\uf588", "fa-grin-tears" },
            { "\uf589", "fa-grin-tongue" },
            { "\uf58a", "fa-grin-tongue-squint" },
            { "\uf58b", "fa-grin-tongue-wink" },
            { "\uf58c", "fa-grin-wink" },
            { "\uf58d", "fa-grip-horizontal" },
            { "\uf7a4", "fa-grip-lines" },
            { "\uf7a5", "fa-grip-lines-vertical" },
            { "\uf58e", "fa-grip-vertical" },
            { "\uf3ac", "fa-gripfire" },
            { "\uf3ad", "fa-grunt" },
            { "\uf7a6", "fa-guitar" },
            { "\uf3ae", "fa-gulp" },
            { "\uf0fd", "fa-h-square" },
            { "\uf313", "fa-h1" },
            { "\uf314", "fa-h2" },
            { "\uf315", "fa-h3" },
            { "\uf86a", "fa-h4" },
            { "\uf1d4", "fa-hacker-news" },
            { "\uf3af", "fa-hacker-news-square" },
            { "\uf5f7", "fa-hackerrank" },
            { "\uf805", "fa-hamburger" },
            { "\uf6e3", "fa-hammer" },
            { "\uf6e4", "fa-hammer-war" },
            { "\uf665", "fa-hamsa" },
            { "\uf4bc", "fa-hand-heart" },
            { "\uf4bd", "fa-hand-holding" },
            { "\uf47b", "fa-hand-holding-box" },
            { "\uf4be", "fa-hand-holding-heart" },
            { "\uf6e5", "fa-hand-holding-magic" },
            { "\uf4bf", "fa-hand-holding-seedling" },
            { "\uf4c0", "fa-hand-holding-usd" },
            { "\uf4c1", "fa-hand-holding-water" },
            { "\uf258", "fa-hand-lizard" },
            { "\uf806", "fa-hand-middle-finger" },
            { "\uf256", "fa-hand-paper" },
            { "\uf25b", "fa-hand-peace" },
            { "\uf0a7", "fa-hand-point-down" },
            { "\uf0a5", "fa-hand-point-left" },
            { "\uf0a4", "fa-hand-point-right" },
            { "\uf0a6", "fa-hand-point-up" },
            { "\uf25a", "fa-hand-pointer" },
            { "\uf47c", "fa-hand-receiving" },
            { "\uf255", "fa-hand-rock" },
            { "\uf257", "fa-hand-scissors" },
            { "\uf259", "fa-hand-spock" },
            { "\uf4c2", "fa-hands" },
            { "\uf4c3", "fa-hands-heart" },
            { "\uf4c4", "fa-hands-helping" },
            { "\uf4c5", "fa-hands-usd" },
            { "\uf2b5", "fa-handshake" },
            { "\uf4c6", "fa-handshake-alt" },
            { "\uf6e6", "fa-hanukiah" },
            { "\uf807", "fa-hard-hat" },
            { "\uf292", "fa-hashtag" },
            { "\uf86b", "fa-hat-chef" },
            { "\uf7a7", "fa-hat-santa" },
            { "\uf7a8", "fa-hat-winter" },
            { "\uf6e7", "fa-hat-witch" },
            { "\uf6e8", "fa-hat-wizard" },
            { "\uf666", "fa-haykal" },
            { "\uf0a0", "fa-hdd" },
            { "\uf6e9", "fa-head-side" },
            { "\uf808", "fa-head-side-brain" },
            { "\uf809", "fa-head-side-medical" },
            { "\uf6ea", "fa-head-vr" },
            { "\uf1dc", "fa-heading" },
            { "\uf025", "fa-headphones" },
            { "\uf58f", "fa-headphones-alt" },
            { "\uf590", "fa-headset" },
            { "\uf004", "fa-heart" },
            { "\uf7a9", "fa-heart-broken" },
            { "\uf4c7", "fa-heart-circle" },
            { "\uf5f8", "fa-heart-rate" },
            { "\uf4c8", "fa-heart-square" },
            { "\uf21e", "fa-heartbeat" },
            { "\uf533", "fa-helicopter" },
            { "\uf6eb", "fa-helmet-battle" },
            { "\uf312", "fa-hexagon" },
            { "\uf591", "fa-highlighter" },
            { "\uf6ec", "fa-hiking" },
            { "\uf6ed", "fa-hippo" },
            { "\uf452", "fa-hips" },
            { "\uf3b0", "fa-hire-a-helper" },
            { "\uf1da", "fa-history" },
            { "\uf6ee", "fa-hockey-mask" },
            { "\uf453", "fa-hockey-puck" },
            { "\uf454", "fa-hockey-sticks" },
            { "\uf7aa", "fa-holly-berry" },
            { "\uf015", "fa-home" },
            { "\uf80a", "fa-home-alt" },
            { "\uf4c9", "fa-home-heart" },
            { "\uf80b", "fa-home-lg" },
            { "\uf80c", "fa-home-lg-alt" },
            { "\uf6ef", "fa-hood-cloak" },
            { "\uf427", "fa-hooli" },
            { "\uf86c", "fa-horizontal-rule" },
            { "\uf592", "fa-hornbill" },
            { "\uf6f0", "fa-horse" },
            { "\uf7ab", "fa-horse-head" },
            { "\uf0f8", "fa-hospital" },
            { "\uf47d", "fa-hospital-alt" },
            { "\uf47e", "fa-hospital-symbol" },
            { "\uf80d", "fa-hospital-user" },
            { "\uf80e", "fa-hospitals" },
            { "\uf593", "fa-hot-tub" },
            { "\uf80f", "fa-hotdog" },
            { "\uf594", "fa-hotel" },
            { "\uf3b1", "fa-hotjar" },
            { "\uf254", "fa-hourglass" },
            { "\uf253", "fa-hourglass-end" },
            { "\uf252", "fa-hourglass-half" },
            { "\uf251", "fa-hourglass-start" },
            { "\uf6f1", "fa-house-damage" },
            { "\uf74f", "fa-house-flood" },
            { "\uf27c", "fa-houzz" },
            { "\uf6f2", "fa-hryvnia" },
            { "\uf13b", "fa-html5" },
            { "\uf3b2", "fa-hubspot" },
            { "\uf750", "fa-humidity" },
            { "\uf751", "fa-hurricane" },
            { "\uf246", "fa-i-cursor" },
            { "\uf810", "fa-ice-cream" },
            { "\uf7ac", "fa-ice-skate" },
            { "\uf7ad", "fa-icicles" },
            { "\uf86d", "fa-icons" },
            { "\uf86e", "fa-icons-alt" },
            { "\uf2c1", "fa-id-badge" },
            { "\uf2c2", "fa-id-card" },
            { "\uf47f", "fa-id-card-alt" },
            { "\uf7ae", "fa-igloo" },
            { "\uf03e", "fa-image" },
            { "\uf302", "fa-images" },
            { "\uf2d8", "fa-imdb" },
            { "\uf01c", "fa-inbox" },
            { "\uf310", "fa-inbox-in" },
            { "\uf311", "fa-inbox-out" },
            { "\uf03c", "fa-indent" },
            { "\uf275", "fa-industry" },
            { "\uf3b3", "fa-industry-alt" },
            { "\uf534", "fa-infinity" },
            { "\uf129", "fa-info" },
            { "\uf05a", "fa-info-circle" },
            { "\uf30f", "fa-info-square" },
            { "\uf5f9", "fa-inhaler" },
            { "\uf16d", "fa-instagram" },
            { "\uf667", "fa-integral" },
            { "\uf7af", "fa-intercom" },
            { "\uf26b", "fa-internet-explorer" },
            { "\uf668", "fa-intersection" },
            { "\uf480", "fa-inventory" },
            { "\uf7b0", "fa-invision" },
            { "\uf208", "fa-ioxhost" },
            { "\uf811", "fa-island-tropical" },
            { "\uf033", "fa-italic" },
            { "\uf83a", "fa-itch-io" },
            { "\uf3b4", "fa-itunes" },
            { "\uf3b5", "fa-itunes-note" },
            { "\uf30e", "fa-jack-o-lantern" },
            { "\uf4e4", "fa-java" },
            { "\uf669", "fa-jedi" },
            { "\uf50e", "fa-jedi-order" },
            { "\uf3b6", "fa-jenkins" },
            { "\uf7b1", "fa-jira" },
            { "\uf3b7", "fa-joget" },
            { "\uf595", "fa-joint" },
            { "\uf1aa", "fa-joomla" },
            { "\uf66a", "fa-journal-whills" },
            { "\uf3b8", "fa-js" },
            { "\uf3b9", "fa-js-square" },
            { "\uf1cc", "fa-jsfiddle" },
            { "\uf66b", "fa-kaaba" },
            { "\uf5fa", "fa-kaggle" },
            { "\uf86f", "fa-kerning" },
            { "\uf084", "fa-key" },
            { "\uf6f3", "fa-key-skeleton" },
            { "\uf4f5", "fa-keybase" },
            { "\uf11c", "fa-keyboard" },
            { "\uf3ba", "fa-keycdn" },
            { "\uf66c", "fa-keynote" },
            { "\uf66d", "fa-khanda" },
            { "\uf3bb", "fa-kickstarter" },
            { "\uf3bc", "fa-kickstarter-k" },
            { "\uf5fb", "fa-kidneys" },
            { "\uf596", "fa-kiss" },
            { "\uf597", "fa-kiss-beam" },
            { "\uf598", "fa-kiss-wink-heart" },
            { "\uf6f4", "fa-kite" },
            { "\uf535", "fa-kiwi-bird" },
            { "\uf6f5", "fa-knife-kitchen" },
            { "\uf42f", "fa-korvue" },
            { "\uf66e", "fa-lambda" },
            { "\uf4ca", "fa-lamp" },
            { "\uf66f", "fa-landmark" },
            { "\uf752", "fa-landmark-alt" },
            { "\uf1ab", "fa-language" },
            { "\uf109", "fa-laptop" },
            { "\uf5fc", "fa-laptop-code" },
            { "\uf812", "fa-laptop-medical" },
            { "\uf3bd", "fa-laravel" },
            { "\uf202", "fa-lastfm" },
            { "\uf203", "fa-lastfm-square" },
            { "\uf599", "fa-laugh" },
            { "\uf59a", "fa-laugh-beam" },
            { "\uf59b", "fa-laugh-squint" },
            { "\uf59c", "fa-laugh-wink" },
            { "\uf5fd", "fa-layer-group" },
            { "\uf5fe", "fa-layer-minus" },
            { "\uf5ff", "fa-layer-plus" },
            { "\uf06c", "fa-leaf" },
            { "\uf4cb", "fa-leaf-heart" },
            { "\uf6f6", "fa-leaf-maple" },
            { "\uf6f7", "fa-leaf-oak" },
            { "\uf212", "fa-leanpub" },
            { "\uf094", "fa-lemon" },
            { "\uf41d", "fa-less" },
            { "\uf536", "fa-less-than" },
            { "\uf537", "fa-less-than-equal" },
            { "\uf149", "fa-level-down" },
            { "\uf3be", "fa-level-down-alt" },
            { "\uf148", "fa-level-up" },
            { "\uf3bf", "fa-level-up-alt" },
            { "\uf1cd", "fa-life-ring" },
            { "\uf0eb", "fa-lightbulb" },
            { "\uf670", "fa-lightbulb-dollar" },
            { "\uf671", "fa-lightbulb-exclamation" },
            { "\uf672", "fa-lightbulb-on" },
            { "\uf673", "fa-lightbulb-slash" },
            { "\uf7b2", "fa-lights-holiday" },
            { "\uf3c0", "fa-line" },
            { "\uf870", "fa-line-columns" },
            { "\uf871", "fa-line-height" },
            { "\uf0c1", "fa-link" },
            { "\uf08c", "fa-linkedin" },
            { "\uf0e1", "fa-linkedin-in" },
            { "\uf2b8", "fa-linode" },
            { "\uf17c", "fa-linux" },
            { "\uf600", "fa-lips" },
            { "\uf195", "fa-lira-sign" },
            { "\uf03a", "fa-list" },
            { "\uf022", "fa-list-alt" },
            { "\uf0cb", "fa-list-ol" },
            { "\uf0ca", "fa-list-ul" },
            { "\uf601", "fa-location" },
            { "\uf124", "fa-location-arrow" },
            { "\uf602", "fa-location-circle" },
            { "\uf603", "fa-location-slash" },
            { "\uf023", "fa-lock" },
            { "\uf30d", "fa-lock-alt" },
            { "\uf3c1", "fa-lock-open" },
            { "\uf3c2", "fa-lock-open-alt" },
            { "\uf309", "fa-long-arrow-alt-down" },
            { "\uf30a", "fa-long-arrow-alt-left" },
            { "\uf30b", "fa-long-arrow-alt-right" },
            { "\uf30c", "fa-long-arrow-alt-up" },
            { "\uf175", "fa-long-arrow-down" },
            { "\uf177", "fa-long-arrow-left" },
            { "\uf178", "fa-long-arrow-right" },
            { "\uf176", "fa-long-arrow-up" },
            { "\uf4cc", "fa-loveseat" },
            { "\uf2a8", "fa-low-vision" },
            { "\uf455", "fa-luchador" },
            { "\uf59d", "fa-luggage-cart" },
            { "\uf604", "fa-lungs" },
            { "\uf3c3", "fa-lyft" },
            { "\uf6f8", "fa-mace" },
            { "\uf3c4", "fa-magento" },
            { "\uf0d0", "fa-magic" },
            { "\uf076", "fa-magnet" },
            { "\uf674", "fa-mail-bulk" },
            { "\uf813", "fa-mailbox" },
            { "\uf59e", "fa-mailchimp" },
            { "\uf183", "fa-male" },
            { "\uf50f", "fa-mandalorian" },
            { "\uf6f9", "fa-mandolin" },
            { "\uf279", "fa-map" },
            { "\uf59f", "fa-map-marked" },
            { "\uf5a0", "fa-map-marked-alt" },
            { "\uf041", "fa-map-marker" },
            { "\uf3c5", "fa-map-marker-alt" },
            { "\uf605", "fa-map-marker-alt-slash" },
            { "\uf606", "fa-map-marker-check" },
            { "\uf607", "fa-map-marker-edit" },
            { "\uf608", "fa-map-marker-exclamation" },
            { "\uf609", "fa-map-marker-minus" },
            { "\uf60a", "fa-map-marker-plus" },
            { "\uf60b", "fa-map-marker-question" },
            { "\uf60c", "fa-map-marker-slash" },
            { "\uf60d", "fa-map-marker-smile" },
            { "\uf60e", "fa-map-marker-times" },
            { "\uf276", "fa-map-pin" },
            { "\uf277", "fa-map-signs" },
            { "\uf60f", "fa-markdown" },
            { "\uf5a1", "fa-marker" },
            { "\uf222", "fa-mars" },
            { "\uf227", "fa-mars-double" },
            { "\uf229", "fa-mars-stroke" },
            { "\uf22b", "fa-mars-stroke-h" },
            { "\uf22a", "fa-mars-stroke-v" },
            { "\uf6fa", "fa-mask" },
            { "\uf4f6", "fa-mastodon" },
            { "\uf136", "fa-maxcdn" },
            { "\uf814", "fa-meat" },
            { "\uf5a2", "fa-medal" },
            { "\uf3c6", "fa-medapps" },
            { "\uf23a", "fa-medium" },
            { "\uf3c7", "fa-medium-m" },
            { "\uf0fa", "fa-medkit" },
            { "\uf3c8", "fa-medrt" },
            { "\uf2e0", "fa-meetup" },
            { "\uf675", "fa-megaphone" },
            { "\uf5a3", "fa-megaport" },
            { "\uf11a", "fa-meh" },
            { "\uf5a4", "fa-meh-blank" },
            { "\uf5a5", "fa-meh-rolling-eyes" },
            { "\uf538", "fa-memory" },
            { "\uf7b3", "fa-mendeley" },
            { "\uf676", "fa-menorah" },
            { "\uf223", "fa-mercury" },
            { "\uf753", "fa-meteor" },
            { "\uf2db", "fa-microchip" },
            { "\uf130", "fa-microphone" },
            { "\uf3c9", "fa-microphone-alt" },
            { "\uf539", "fa-microphone-alt-slash" },
            { "\uf131", "fa-microphone-slash" },
            { "\uf610", "fa-microscope" },
            { "\uf3ca", "fa-microsoft" },
            { "\uf677", "fa-mind-share" },
            { "\uf068", "fa-minus" },
            { "\uf056", "fa-minus-circle" },
            { "\uf307", "fa-minus-hexagon" },
            { "\uf308", "fa-minus-octagon" },
            { "\uf146", "fa-minus-square" },
            { "\uf7b4", "fa-mistletoe" },
            { "\uf7b5", "fa-mitten" },
            { "\uf3cb", "fa-mix" },
            { "\uf289", "fa-mixcloud" },
            { "\uf3cc", "fa-mizuni" },
            { "\uf10b", "fa-mobile" },
            { "\uf3cd", "fa-mobile-alt" },
            { "\uf3ce", "fa-mobile-android" },
            { "\uf3cf", "fa-mobile-android-alt" },
            { "\uf285", "fa-modx" },
            { "\uf3d0", "fa-monero" },
            { "\uf0d6", "fa-money-bill" },
            { "\uf3d1", "fa-money-bill-alt" },
            { "\uf53a", "fa-money-bill-wave" },
            { "\uf53b", "fa-money-bill-wave-alt" },
            { "\uf53c", "fa-money-check" },
            { "\uf53d", "fa-money-check-alt" },
            { "\uf872", "fa-money-check-edit" },
            { "\uf873", "fa-money-check-edit-alt" },
            { "\uf611", "fa-monitor-heart-rate" },
            { "\uf6fb", "fa-monkey" },
            { "\uf5a6", "fa-monument" },
            { "\uf186", "fa-moon" },
            { "\uf754", "fa-moon-cloud" },
            { "\uf755", "fa-moon-stars" },
            { "\uf5a7", "fa-mortar-pestle" },
            { "\uf678", "fa-mosque" },
            { "\uf21c", "fa-motorcycle" },
            { "\uf6fc", "fa-mountain" },
            { "\uf6fd", "fa-mountains" },
            { "\uf245", "fa-mouse-pointer" },
            { "\uf874", "fa-mug" },
            { "\uf7b6", "fa-mug-hot" },
            { "\uf7b7", "fa-mug-marshmallows" },
            { "\uf875", "fa-mug-tea" },
            { "\uf001", "fa-music" },
            { "\uf3d2", "fa-napster" },
            { "\uf6fe", "fa-narwhal" },
            { "\uf612", "fa-neos" },
            { "\uf6ff", "fa-network-wired" },
            { "\uf22c", "fa-neuter" },
            { "\uf1ea", "fa-newspaper" },
            { "\uf5a8", "fa-nimblr" },
            { "\uf419", "fa-node" },
            { "\uf3d3", "fa-node-js" },
            { "\uf53e", "fa-not-equal" },
            { "\uf481", "fa-notes-medical" },
            { "\uf3d4", "fa-npm" },
            { "\uf3d5", "fa-ns8" },
            { "\uf3d6", "fa-nutritionix" },
            { "\uf247", "fa-object-group" },
            { "\uf248", "fa-object-ungroup" },
            { "\uf306", "fa-octagon" },
            { "\uf263", "fa-odnoklassniki" },
            { "\uf264", "fa-odnoklassniki-square" },
            { "\uf613", "fa-oil-can" },
            { "\uf614", "fa-oil-temp" },
            { "\uf510", "fa-old-republic" },
            { "\uf679", "fa-om" },
            { "\uf67a", "fa-omega" },
            { "\uf23d", "fa-opencart" },
            { "\uf19b", "fa-openid" },
            { "\uf26a", "fa-opera" },
            { "\uf23c", "fa-optin-monster" },
            { "\uf7b8", "fa-ornament" },
            { "\uf41a", "fa-osi" },
            { "\uf700", "fa-otter" },
            { "\uf03b", "fa-outdent" },
            { "\uf876", "fa-overline" },
            { "\uf877", "fa-page-break" },
            { "\uf3d7", "fa-page4" },
            { "\uf18c", "fa-pagelines" },
            { "\uf815", "fa-pager" },
            { "\uf1fc", "fa-paint-brush" },
            { "\uf5a9", "fa-paint-brush-alt" },
            { "\uf5aa", "fa-paint-roller" },
            { "\uf53f", "fa-palette" },
            { "\uf3d8", "fa-palfed" },
            { "\uf482", "fa-pallet" },
            { "\uf483", "fa-pallet-alt" },
            { "\uf1d8", "fa-paper-plane" },
            { "\uf0c6", "fa-paperclip" },
            { "\uf4cd", "fa-parachute-box" },
            { "\uf1dd", "fa-paragraph" },
            { "\uf878", "fa-paragraph-rtl" },
            { "\uf540", "fa-parking" },
            { "\uf615", "fa-parking-circle" },
            { "\uf616", "fa-parking-circle-slash" },
            { "\uf617", "fa-parking-slash" },
            { "\uf5ab", "fa-passport" },
            { "\uf67b", "fa-pastafarianism" },
            { "\uf0ea", "fa-paste" },
            { "\uf3d9", "fa-patreon" },
            { "\uf04c", "fa-pause" },
            { "\uf28b", "fa-pause-circle" },
            { "\uf1b0", "fa-paw" },
            { "\uf701", "fa-paw-alt" },
            { "\uf702", "fa-paw-claws" },
            { "\uf1ed", "fa-paypal" },
            { "\uf67c", "fa-peace" },
            { "\uf703", "fa-pegasus" },
            { "\uf304", "fa-pen" },
            { "\uf305", "fa-pen-alt" },
            { "\uf5ac", "fa-pen-fancy" },
            { "\uf5ad", "fa-pen-nib" },
            { "\uf14b", "fa-pen-square" },
            { "\uf040", "fa-pencil" },
            { "\uf303", "fa-pencil-alt" },
            { "\uf618", "fa-pencil-paintbrush" },
            { "\uf5ae", "fa-pencil-ruler" },
            { "\uf456", "fa-pennant" },
            { "\uf704", "fa-penny-arcade" },
            { "\uf4ce", "fa-people-carry" },
            { "\uf816", "fa-pepper-hot" },
            { "\uf295", "fa-percent" },
            { "\uf541", "fa-percentage" },
            { "\uf3da", "fa-periscope" },
            { "\uf756", "fa-person-booth" },
            { "\uf4cf", "fa-person-carry" },
            { "\uf4d0", "fa-person-dolly" },
            { "\uf4d1", "fa-person-dolly-empty" },
            { "\uf757", "fa-person-sign" },
            { "\uf3db", "fa-phabricator" },
            { "\uf3dc", "fa-phoenix-framework" },
            { "\uf511", "fa-phoenix-squadron" },
            { "\uf095", "fa-phone" },
            { "\uf879", "fa-phone-alt" },
            { "\uf87a", "fa-phone-laptop" },
            { "\uf67d", "fa-phone-office" },
            { "\uf4d2", "fa-phone-plus" },
            { "\uf3dd", "fa-phone-slash" },
            { "\uf098", "fa-phone-square" },
            { "\uf87b", "fa-phone-square-alt" },
            { "\uf2a0", "fa-phone-volume" },
            { "\uf87c", "fa-photo-video" },
            { "\uf457", "fa-php" },
            { "\uf67e", "fa-pi" },
            { "\uf705", "fa-pie" },
            { "\uf2ae", "fa-pied-piper" },
            { "\uf1a8", "fa-pied-piper-alt" },
            { "\uf4e5", "fa-pied-piper-hat" },
            { "\uf1a7", "fa-pied-piper-pp" },
            { "\uf706", "fa-pig" },
            { "\uf4d3", "fa-piggy-bank" },
            { "\uf484", "fa-pills" },
            { "\uf0d2", "fa-pinterest" },
            { "\uf231", "fa-pinterest-p" },
            { "\uf0d3", "fa-pinterest-square" },
            { "\uf817", "fa-pizza" },
            { "\uf818", "fa-pizza-slice" },
            { "\uf67f", "fa-place-of-worship" },
            { "\uf072", "fa-plane" },
            { "\uf3de", "fa-plane-alt" },
            { "\uf5af", "fa-plane-arrival" },
            { "\uf5b0", "fa-plane-departure" },
            { "\uf04b", "fa-play" },
            { "\uf144", "fa-play-circle" },
            { "\uf3df", "fa-playstation" },
            { "\uf1e6", "fa-plug" },
            { "\uf067", "fa-plus" },
            { "\uf055", "fa-plus-circle" },
            { "\uf300", "fa-plus-hexagon" },
            { "\uf301", "fa-plus-octagon" },
            { "\uf0fe", "fa-plus-square" },
            { "\uf2ce", "fa-podcast" },
            { "\uf680", "fa-podium" },
            { "\uf758", "fa-podium-star" },
            { "\uf681", "fa-poll" },
            { "\uf682", "fa-poll-h" },
            { "\uf759", "fa-poll-people" },
            { "\uf2fe", "fa-poo" },
            { "\uf75a", "fa-poo-storm" },
            { "\uf619", "fa-poop" },
            { "\uf819", "fa-popcorn" },
            { "\uf3e0", "fa-portrait" },
            { "\uf154", "fa-pound-sign" },
            { "\uf011", "fa-power-off" },
            { "\uf683", "fa-pray" },
            { "\uf684", "fa-praying-hands" },
            { "\uf5b1", "fa-prescription" },
            { "\uf485", "fa-prescription-bottle" },
            { "\uf486", "fa-prescription-bottle-alt" },
            { "\uf685", "fa-presentation" },
            { "\uf02f", "fa-print" },
            { "\uf81a", "fa-print-search" },
            { "\uf686", "fa-print-slash" },
            { "\uf487", "fa-procedures" },
            { "\uf288", "fa-product-hunt" },
            { "\uf542", "fa-project-diagram" },
            { "\uf707", "fa-pumpkin" },
            { "\uf3e1", "fa-pushed" },
            { "\uf12e", "fa-puzzle-piece" },
            { "\uf3e2", "fa-python" },
            { "\uf1d6", "fa-qq" },
            { "\uf029", "fa-qrcode" },
            { "\uf128", "fa-question" },
            { "\uf059", "fa-question-circle" },
            { "\uf2fd", "fa-question-square" },
            { "\uf458", "fa-quidditch" },
            { "\uf459", "fa-quinscape" },
            { "\uf2c4", "fa-quora" },
            { "\uf10d", "fa-quote-left" },
            { "\uf10e", "fa-quote-right" },
            { "\uf687", "fa-quran" },
            { "\uf4f7", "fa-r-project" },
            { "\uf708", "fa-rabbit" },
            { "\uf709", "fa-rabbit-fast" },
            { "\uf45a", "fa-racquet" },
            { "\uf7b9", "fa-radiation" },
            { "\uf7ba", "fa-radiation-alt" },
            { "\uf75b", "fa-rainbow" },
            { "\uf75c", "fa-raindrops" },
            { "\uf70a", "fa-ram" },
            { "\uf4d4", "fa-ramp-loading" },
            { "\uf074", "fa-random" },
            { "\uf7bb", "fa-raspberry-pi" },
            { "\uf2d9", "fa-ravelry" },
            { "\uf41b", "fa-react" },
            { "\uf75d", "fa-reacteurope" },
            { "\uf4d5", "fa-readme" },
            { "\uf1d0", "fa-rebel" },
            { "\uf543", "fa-receipt" },
            { "\uf2fa", "fa-rectangle-landscape" },
            { "\uf2fb", "fa-rectangle-portrait" },
            { "\uf2fc", "fa-rectangle-wide" },
            { "\uf1b8", "fa-recycle" },
            { "\uf3e3", "fa-red-river" },
            { "\uf1a1", "fa-reddit" },
            { "\uf281", "fa-reddit-alien" },
            { "\uf1a2", "fa-reddit-square" },
            { "\uf7bc", "fa-redhat" },
            { "\uf01e", "fa-redo" },
            { "\uf2f9", "fa-redo-alt" },
            { "\uf25d", "fa-registered" },
            { "\uf87d", "fa-remove-format" },
            { "\uf18b", "fa-renren" },
            { "\uf363", "fa-repeat" },
            { "\uf365", "fa-repeat-1" },
            { "\uf366", "fa-repeat-1-alt" },
            { "\uf364", "fa-repeat-alt" },
            { "\uf3e5", "fa-reply" },
            { "\uf122", "fa-reply-all" },
            { "\uf3e6", "fa-replyd" },
            { "\uf75e", "fa-republican" },
            { "\uf4f8", "fa-researchgate" },
            { "\uf3e7", "fa-resolving" },
            { "\uf7bd", "fa-restroom" },
            { "\uf079", "fa-retweet" },
            { "\uf361", "fa-retweet-alt" },
            { "\uf5b2", "fa-rev" },
            { "\uf4d6", "fa-ribbon" },
            { "\uf70b", "fa-ring" },
            { "\uf81b", "fa-rings-wedding" },
            { "\uf018", "fa-road" },
            { "\uf544", "fa-robot" },
            { "\uf135", "fa-rocket" },
            { "\uf3e8", "fa-rocketchat" },
            { "\uf3e9", "fa-rockrms" },
            { "\uf4d7", "fa-route" },
            { "\uf61a", "fa-route-highway" },
            { "\uf61b", "fa-route-interstate" },
            { "\uf09e", "fa-rss" },
            { "\uf143", "fa-rss-square" },
            { "\uf158", "fa-ruble-sign" },
            { "\uf545", "fa-ruler" },
            { "\uf546", "fa-ruler-combined" },
            { "\uf547", "fa-ruler-horizontal" },
            { "\uf61c", "fa-ruler-triangle" },
            { "\uf548", "fa-ruler-vertical" },
            { "\uf70c", "fa-running" },
            { "\uf156", "fa-rupee-sign" },
            { "\uf7be", "fa-rv" },
            { "\uf81c", "fa-sack" },
            { "\uf81d", "fa-sack-dollar" },
            { "\uf5b3", "fa-sad-cry" },
            { "\uf5b4", "fa-sad-tear" },
            { "\uf267", "fa-safari" },
            { "\uf81e", "fa-salad" },
            { "\uf83b", "fa-salesforce" },
            { "\uf81f", "fa-sandwich" },
            { "\uf41e", "fa-sass" },
            { "\uf7bf", "fa-satellite" },
            { "\uf7c0", "fa-satellite-dish" },
            { "\uf820", "fa-sausage" },
            { "\uf0c7", "fa-save" },
            { "\uf61d", "fa-scalpel" },
            { "\uf61e", "fa-scalpel-path" },
            { "\uf488", "fa-scanner" },
            { "\uf489", "fa-scanner-keyboard" },
            { "\uf48a", "fa-scanner-touchscreen" },
            { "\uf70d", "fa-scarecrow" },
            { "\uf7c1", "fa-scarf" },
            { "\uf3ea", "fa-schlix" },
            { "\uf549", "fa-school" },
            { "\uf54a", "fa-screwdriver" },
            { "\uf28a", "fa-scribd" },
            { "\uf70e", "fa-scroll" },
            { "\uf70f", "fa-scroll-old" },
            { "\uf2f8", "fa-scrubber" },
            { "\uf710", "fa-scythe" },
            { "\uf7c2", "fa-sd-card" },
            { "\uf002", "fa-search" },
            { "\uf688", "fa-search-dollar" },
            { "\uf689", "fa-search-location" },
            { "\uf010", "fa-search-minus" },
            { "\uf00e", "fa-search-plus" },
            { "\uf3eb", "fa-searchengin" },
            { "\uf4d8", "fa-seedling" },
            { "\uf2da", "fa-sellcast" },
            { "\uf213", "fa-sellsy" },
            { "\uf87e", "fa-send-back" },
            { "\uf87f", "fa-send-backward" },
            { "\uf233", "fa-server" },
            { "\uf3ec", "fa-servicestack" },
            { "\uf61f", "fa-shapes" },
            { "\uf064", "fa-share" },
            { "\uf367", "fa-share-all" },
            { "\uf1e0", "fa-share-alt" },
            { "\uf1e1", "fa-share-alt-square" },
            { "\uf14d", "fa-share-square" },
            { "\uf711", "fa-sheep" },
            { "\uf20b", "fa-shekel-sign" },
            { "\uf132", "fa-shield" },
            { "\uf3ed", "fa-shield-alt" },
            { "\uf2f7", "fa-shield-check" },
            { "\uf712", "fa-shield-cross" },
            { "\uf21a", "fa-ship" },
            { "\uf48b", "fa-shipping-fast" },
            { "\uf48c", "fa-shipping-timed" },
            { "\uf214", "fa-shirtsinbulk" },
            { "\uf821", "fa-shish-kebab" },
            { "\uf54b", "fa-shoe-prints" },
            { "\uf290", "fa-shopping-bag" },
            { "\uf291", "fa-shopping-basket" },
            { "\uf07a", "fa-shopping-cart" },
            { "\uf5b5", "fa-shopware" },
            { "\uf713", "fa-shovel" },
            { "\uf7c3", "fa-shovel-snow" },
            { "\uf2cc", "fa-shower" },
            { "\uf68a", "fa-shredder" },
            { "\uf5b6", "fa-shuttle-van" },
            { "\uf45b", "fa-shuttlecock" },
            { "\uf822", "fa-sickle" },
            { "\uf68b", "fa-sigma" },
            { "\uf4d9", "fa-sign" },
            { "\uf090", "fa-sign-in" },
            { "\uf2f6", "fa-sign-in-alt" },
            { "\uf2a7", "fa-sign-language" },
            { "\uf08b", "fa-sign-out" },
            { "\uf2f5", "fa-sign-out-alt" },
            { "\uf012", "fa-signal" },
            { "\uf68c", "fa-signal-1" },
            { "\uf68d", "fa-signal-2" },
            { "\uf68e", "fa-signal-3" },
            { "\uf68f", "fa-signal-4" },
            { "\uf690", "fa-signal-alt" },
            { "\uf691", "fa-signal-alt-1" },
            { "\uf692", "fa-signal-alt-2" },
            { "\uf693", "fa-signal-alt-3" },
            { "\uf694", "fa-signal-alt-slash" },
            { "\uf695", "fa-signal-slash" },
            { "\uf5b7", "fa-signature" },
            { "\uf7c4", "fa-sim-card" },
            { "\uf215", "fa-simplybuilt" },
            { "\uf3ee", "fa-sistrix" },
            { "\uf0e8", "fa-sitemap" },
            { "\uf512", "fa-sith" },
            { "\uf7c5", "fa-skating" },
            { "\uf620", "fa-skeleton" },
            { "\uf7c6", "fa-sketch" },
            { "\uf7c7", "fa-ski-jump" },
            { "\uf7c8", "fa-ski-lift" },
            { "\uf7c9", "fa-skiing" },
            { "\uf7ca", "fa-skiing-nordic" },
            { "\uf54c", "fa-skull" },
            { "\uf714", "fa-skull-crossbones" },
            { "\uf216", "fa-skyatlas" },
            { "\uf17e", "fa-skype" },
            { "\uf198", "fa-slack" },
            { "\uf3ef", "fa-slack-hash" },
            { "\uf715", "fa-slash" },
            { "\uf7cb", "fa-sledding" },
            { "\uf7cc", "fa-sleigh" },
            { "\uf1de", "fa-sliders-h" },
            { "\uf3f0", "fa-sliders-h-square" },
            { "\uf3f1", "fa-sliders-v" },
            { "\uf3f2", "fa-sliders-v-square" },
            { "\uf1e7", "fa-slideshare" },
            { "\uf118", "fa-smile" },
            { "\uf5b8", "fa-smile-beam" },
            { "\uf5b9", "fa-smile-plus" },
            { "\uf4da", "fa-smile-wink" },
            { "\uf75f", "fa-smog" },
            { "\uf760", "fa-smoke" },
            { "\uf48d", "fa-smoking" },
            { "\uf54d", "fa-smoking-ban" },
            { "\uf7cd", "fa-sms" },
            { "\uf716", "fa-snake" },
            { "\uf2ab", "fa-snapchat" },
            { "\uf2ac", "fa-snapchat-ghost" },
            { "\uf2ad", "fa-snapchat-square" },
            { "\uf880", "fa-snooze" },
            { "\uf761", "fa-snow-blowing" },
            { "\uf7ce", "fa-snowboarding" },
            { "\uf2dc", "fa-snowflake" },
            { "\uf7cf", "fa-snowflakes" },
            { "\uf7d0", "fa-snowman" },
            { "\uf7d1", "fa-snowmobile" },
            { "\uf7d2", "fa-snowplow" },
            { "\uf696", "fa-socks" },
            { "\uf5ba", "fa-solar-panel" },
            { "\uf0dc", "fa-sort" },
            { "\uf15d", "fa-sort-alpha-down" },
            { "\uf881", "fa-sort-alpha-down-alt" },
            { "\uf15e", "fa-sort-alpha-up" },
            { "\uf882", "fa-sort-alpha-up-alt" },
            { "\uf883", "fa-sort-alt" },
            { "\uf160", "fa-sort-amount-down" },
            { "\uf884", "fa-sort-amount-down-alt" },
            { "\uf161", "fa-sort-amount-up" },
            { "\uf885", "fa-sort-amount-up-alt" },
            { "\uf0dd", "fa-sort-down" },
            { "\uf162", "fa-sort-numeric-down" },
            { "\uf886", "fa-sort-numeric-down-alt" },
            { "\uf163", "fa-sort-numeric-up" },
            { "\uf887", "fa-sort-numeric-up-alt" },
            { "\uf888", "fa-sort-shapes-down" },
            { "\uf889", "fa-sort-shapes-down-alt" },
            { "\uf88a", "fa-sort-shapes-up" },
            { "\uf88b", "fa-sort-shapes-up-alt" },
            { "\uf88c", "fa-sort-size-down" },
            { "\uf88d", "fa-sort-size-down-alt" },
            { "\uf88e", "fa-sort-size-up" },
            { "\uf88f", "fa-sort-size-up-alt" },
            { "\uf0de", "fa-sort-up" },
            { "\uf1be", "fa-soundcloud" },
            { "\uf823", "fa-soup" },
            { "\uf7d3", "fa-sourcetree" },
            { "\uf5bb", "fa-spa" },
            { "\uf197", "fa-space-shuttle" },
            { "\uf2f4", "fa-spade" },
            { "\uf890", "fa-sparkles" },
            { "\uf3f3", "fa-speakap" },
            { "\uf83c", "fa-speaker-deck" },
            { "\uf891", "fa-spell-check" },
            { "\uf717", "fa-spider" },
            { "\uf718", "fa-spider-black-widow" },
            { "\uf719", "fa-spider-web" },
            { "\uf110", "fa-spinner" },
            { "\uf3f4", "fa-spinner-third" },
            { "\uf5bc", "fa-splotch" },
            { "\uf1bc", "fa-spotify" },
            { "\uf5bd", "fa-spray-can" },
            { "\uf0c8", "fa-square" },
            { "\uf45c", "fa-square-full" },
            { "\uf697", "fa-square-root" },
            { "\uf698", "fa-square-root-alt" },
            { "\uf5be", "fa-squarespace" },
            { "\uf71a", "fa-squirrel" },
            { "\uf18d", "fa-stack-exchange" },
            { "\uf16c", "fa-stack-overflow" },
            { "\uf842", "fa-stackpath" },
            { "\uf71b", "fa-staff" },
            { "\uf5bf", "fa-stamp" },
            { "\uf005", "fa-star" },
            { "\uf699", "fa-star-and-crescent" },
            { "\uf7d4", "fa-star-christmas" },
            { "\uf2f3", "fa-star-exclamation" },
            { "\uf089", "fa-star-half" },
            { "\uf5c0", "fa-star-half-alt" },
            { "\uf69a", "fa-star-of-david" },
            { "\uf621", "fa-star-of-life" },
            { "\uf762", "fa-stars" },
            { "\uf3f5", "fa-staylinked" },
            { "\uf824", "fa-steak" },
            { "\uf1b6", "fa-steam" },
            { "\uf1b7", "fa-steam-square" },
            { "\uf3f6", "fa-steam-symbol" },
            { "\uf622", "fa-steering-wheel" },
            { "\uf048", "fa-step-backward" },
            { "\uf051", "fa-step-forward" },
            { "\uf0f1", "fa-stethoscope" },
            { "\uf3f7", "fa-sticker-mule" },
            { "\uf249", "fa-sticky-note" },
            { "\uf7d5", "fa-stocking" },
            { "\uf623", "fa-stomach" },
            { "\uf04d", "fa-stop" },
            { "\uf28d", "fa-stop-circle" },
            { "\uf2f2", "fa-stopwatch" },
            { "\uf54e", "fa-store" },
            { "\uf54f", "fa-store-alt" },
            { "\uf428", "fa-strava" },
            { "\uf550", "fa-stream" },
            { "\uf21d", "fa-street-view" },
            { "\uf825", "fa-stretcher" },
            { "\uf0cc", "fa-strikethrough" },
            { "\uf429", "fa-stripe" },
            { "\uf42a", "fa-stripe-s" },
            { "\uf551", "fa-stroopwafel" },
            { "\uf3f8", "fa-studiovinari" },
            { "\uf1a4", "fa-stumbleupon" },
            { "\uf1a3", "fa-stumbleupon-circle" },
            { "\uf12c", "fa-subscript" },
            { "\uf239", "fa-subway" },
            { "\uf0f2", "fa-suitcase" },
            { "\uf5c1", "fa-suitcase-rolling" },
            { "\uf185", "fa-sun" },
            { "\uf763", "fa-sun-cloud" },
            { "\uf764", "fa-sun-dust" },
            { "\uf765", "fa-sun-haze" },
            { "\uf892", "fa-sunglasses" },
            { "\uf766", "fa-sunrise" },
            { "\uf767", "fa-sunset" },
            { "\uf2dd", "fa-superpowers" },
            { "\uf12b", "fa-superscript" },
            { "\uf3f9", "fa-supple" },
            { "\uf5c2", "fa-surprise" },
            { "\uf7d6", "fa-suse" },
            { "\uf5c3", "fa-swatchbook" },
            { "\uf5c4", "fa-swimmer" },
            { "\uf5c5", "fa-swimming-pool" },
            { "\uf71c", "fa-sword" },
            { "\uf71d", "fa-swords" },
            { "\uf83d", "fa-symfony" },
            { "\uf69b", "fa-synagogue" },
            { "\uf021", "fa-sync" },
            { "\uf2f1", "fa-sync-alt" },
            { "\uf48e", "fa-syringe" },
            { "\uf0ce", "fa-table" },
            { "\uf45d", "fa-table-tennis" },
            { "\uf10a", "fa-tablet" },
            { "\uf3fa", "fa-tablet-alt" },
            { "\uf3fb", "fa-tablet-android" },
            { "\uf3fc", "fa-tablet-android-alt" },
            { "\uf48f", "fa-tablet-rugged" },
            { "\uf490", "fa-tablets" },
            { "\uf0e4", "fa-tachometer" },
            { "\uf3fd", "fa-tachometer-alt" },
            { "\uf624", "fa-tachometer-alt-average" },
            { "\uf625", "fa-tachometer-alt-fast" },
            { "\uf626", "fa-tachometer-alt-fastest" },
            { "\uf627", "fa-tachometer-alt-slow" },
            { "\uf628", "fa-tachometer-alt-slowest" },
            { "\uf629", "fa-tachometer-average" },
            { "\uf62a", "fa-tachometer-fast" },
            { "\uf62b", "fa-tachometer-fastest" },
            { "\uf62c", "fa-tachometer-slow" },
            { "\uf62d", "fa-tachometer-slowest" },
            { "\uf826", "fa-taco" },
            { "\uf02b", "fa-tag" },
            { "\uf02c", "fa-tags" },
            { "\uf69c", "fa-tally" },
            { "\uf827", "fa-tanakh" },
            { "\uf4db", "fa-tape" },
            { "\uf0ae", "fa-tasks" },
            { "\uf828", "fa-tasks-alt" },
            { "\uf1ba", "fa-taxi" },
            { "\uf4f9", "fa-teamspeak" },
            { "\uf62e", "fa-teeth" },
            { "\uf62f", "fa-teeth-open" },
            { "\uf2c6", "fa-telegram" },
            { "\uf3fe", "fa-telegram-plane" },
            { "\uf768", "fa-temperature-frigid" },
            { "\uf769", "fa-temperature-high" },
            { "\uf76a", "fa-temperature-hot" },
            { "\uf76b", "fa-temperature-low" },
            { "\uf1d5", "fa-tencent-weibo" },
            { "\uf7d7", "fa-tenge" },
            { "\uf45e", "fa-tennis-ball" },
            { "\uf120", "fa-terminal" },
            { "\uf893", "fa-text" },
            { "\uf034", "fa-text-height" },
            { "\uf894", "fa-text-size" },
            { "\uf035", "fa-text-width" },
            { "\uf00a", "fa-th" },
            { "\uf009", "fa-th-large" },
            { "\uf00b", "fa-th-list" },
            { "\uf69d", "fa-the-red-yeti" },
            { "\uf630", "fa-theater-masks" },
            { "\uf5c6", "fa-themeco" },
            { "\uf2b2", "fa-themeisle" },
            { "\uf491", "fa-thermometer" },
            { "\uf2cb", "fa-thermometer-empty" },
            { "\uf2c7", "fa-thermometer-full" },
            { "\uf2c9", "fa-thermometer-half" },
            { "\uf2ca", "fa-thermometer-quarter" },
            { "\uf2c8", "fa-thermometer-three-quarters" },
            { "\uf69e", "fa-theta" },
            { "\uf731", "fa-think-peaks" },
            { "\uf165", "fa-thumbs-down" },
            { "\uf164", "fa-thumbs-up" },
            { "\uf08d", "fa-thumbtack" },
            { "\uf76c", "fa-thunderstorm" },
            { "\uf76d", "fa-thunderstorm-moon" },
            { "\uf76e", "fa-thunderstorm-sun" },
            { "\uf145", "fa-ticket" },
            { "\uf3ff", "fa-ticket-alt" },
            { "\uf69f", "fa-tilde" },
            { "\uf00d", "fa-times" },
            { "\uf057", "fa-times-circle" },
            { "\uf2ee", "fa-times-hexagon" },
            { "\uf2f0", "fa-times-octagon" },
            { "\uf2d3", "fa-times-square" },
            { "\uf043", "fa-tint" },
            { "\uf5c7", "fa-tint-slash" },
            { "\uf631", "fa-tire" },
            { "\uf632", "fa-tire-flat" },
            { "\uf633", "fa-tire-pressure-warning" },
            { "\uf634", "fa-tire-rugged" },
            { "\uf5c8", "fa-tired" },
            { "\uf204", "fa-toggle-off" },
            { "\uf205", "fa-toggle-on" },
            { "\uf7d8", "fa-toilet" },
            { "\uf71e", "fa-toilet-paper" },
            { "\uf71f", "fa-toilet-paper-alt" },
            { "\uf720", "fa-tombstone" },
            { "\uf721", "fa-tombstone-alt" },
            { "\uf552", "fa-toolbox" },
            { "\uf7d9", "fa-tools" },
            { "\uf5c9", "fa-tooth" },
            { "\uf635", "fa-toothbrush" },
            { "\uf6a0", "fa-torah" },
            { "\uf6a1", "fa-torii-gate" },
            { "\uf76f", "fa-tornado" },
            { "\uf722", "fa-tractor" },
            { "\uf513", "fa-trade-federation" },
            { "\uf25c", "fa-trademark" },
            { "\uf636", "fa-traffic-cone" },
            { "\uf637", "fa-traffic-light" },
            { "\uf638", "fa-traffic-light-go" },
            { "\uf639", "fa-traffic-light-slow" },
            { "\uf63a", "fa-traffic-light-stop" },
            { "\uf238", "fa-train" },
            { "\uf7da", "fa-tram" },
            { "\uf224", "fa-transgender" },
            { "\uf225", "fa-transgender-alt" },
            { "\uf1f8", "fa-trash" },
            { "\uf2ed", "fa-trash-alt" },
            { "\uf829", "fa-trash-restore" },
            { "\uf82a", "fa-trash-restore-alt" },
            { "\uf895", "fa-trash-undo" },
            { "\uf896", "fa-trash-undo-alt" },
            { "\uf723", "fa-treasure-chest" },
            { "\uf1bb", "fa-tree" },
            { "\uf400", "fa-tree-alt" },
            { "\uf7db", "fa-tree-christmas" },
            { "\uf7dc", "fa-tree-decorated" },
            { "\uf7dd", "fa-tree-large" },
            { "\uf82b", "fa-tree-palm" },
            { "\uf724", "fa-trees" },
            { "\uf181", "fa-trello" },
            { "\uf2ec", "fa-triangle" },
            { "\uf262", "fa-tripadvisor" },
            { "\uf091", "fa-trophy" },
            { "\uf2eb", "fa-trophy-alt" },
            { "\uf0d1", "fa-truck" },
            { "\uf4dc", "fa-truck-container" },
            { "\uf4dd", "fa-truck-couch" },
            { "\uf4de", "fa-truck-loading" },
            { "\uf63b", "fa-truck-monster" },
            { "\uf4df", "fa-truck-moving" },
            { "\uf63c", "fa-truck-pickup" },
            { "\uf7de", "fa-truck-plow" },
            { "\uf4e0", "fa-truck-ramp" },
            { "\uf553", "fa-tshirt" },
            { "\uf1e4", "fa-tty" },
            { "\uf173", "fa-tumblr" },
            { "\uf174", "fa-tumblr-square" },
            { "\uf725", "fa-turkey" },
            { "\uf726", "fa-turtle" },
            { "\uf26c", "fa-tv" },
            { "\uf401", "fa-tv-retro" },
            { "\uf1e8", "fa-twitch" },
            { "\uf099", "fa-twitter" },
            { "\uf081", "fa-twitter-square" },
            { "\uf42b", "fa-typo3" },
            { "\uf402", "fa-uber" },
            { "\uf7df", "fa-ubuntu" },
            { "\uf403", "fa-uikit" },
            { "\uf0e9", "fa-umbrella" },
            { "\uf5ca", "fa-umbrella-beach" },
            { "\uf0cd", "fa-underline" },
            { "\uf0e2", "fa-undo" },
            { "\uf2ea", "fa-undo-alt" },
            { "\uf727", "fa-unicorn" },
            { "\uf6a2", "fa-union" },
            { "\uf404", "fa-uniregistry" },
            { "\uf29a", "fa-universal-access" },
            { "\uf19c", "fa-university" },
            { "\uf127", "fa-unlink" },
            { "\uf09c", "fa-unlock" },
            { "\uf13e", "fa-unlock-alt" },
            { "\uf405", "fa-untappd" },
            { "\uf093", "fa-upload" },
            { "\uf7e0", "fa-ups" },
            { "\uf287", "fa-usb" },
            { "\uf2e8", "fa-usd-circle" },
            { "\uf2e9", "fa-usd-square" },
            { "\uf007", "fa-user" },
            { "\uf406", "fa-user-alt" },
            { "\uf4fa", "fa-user-alt-slash" },
            { "\uf4fb", "fa-user-astronaut" },
            { "\uf6a3", "fa-user-chart" },
            { "\uf4fc", "fa-user-check" },
            { "\uf2bd", "fa-user-circle" },
            { "\uf4fd", "fa-user-clock" },
            { "\uf4fe", "fa-user-cog" },
            { "\uf6a4", "fa-user-crown" },
            { "\uf4ff", "fa-user-edit" },
            { "\uf500", "fa-user-friends" },
            { "\uf501", "fa-user-graduate" },
            { "\uf82c", "fa-user-hard-hat" },
            { "\uf82d", "fa-user-headset" },
            { "\uf728", "fa-user-injured" },
            { "\uf502", "fa-user-lock" },
            { "\uf0f0", "fa-user-md" },
            { "\uf82e", "fa-user-md-chat" },
            { "\uf503", "fa-user-minus" },
            { "\uf504", "fa-user-ninja" },
            { "\uf82f", "fa-user-nurse" },
            { "\uf234", "fa-user-plus" },
            { "\uf21b", "fa-user-secret" },
            { "\uf505", "fa-user-shield" },
            { "\uf506", "fa-user-slash" },
            { "\uf507", "fa-user-tag" },
            { "\uf508", "fa-user-tie" },
            { "\uf235", "fa-user-times" },
            { "\uf0c0", "fa-users" },
            { "\uf63d", "fa-users-class" },
            { "\uf509", "fa-users-cog" },
            { "\uf6a5", "fa-users-crown" },
            { "\uf830", "fa-users-medical" },
            { "\uf7e1", "fa-usps" },
            { "\uf407", "fa-ussunnah" },
            { "\uf2e3", "fa-utensil-fork" },
            { "\uf2e4", "fa-utensil-knife" },
            { "\uf2e5", "fa-utensil-spoon" },
            { "\uf2e7", "fa-utensils" },
            { "\uf2e6", "fa-utensils-alt" },
            { "\uf408", "fa-vaadin" },
            { "\uf6a6", "fa-value-absolute" },
            { "\uf5cb", "fa-vector-square" },
            { "\uf221", "fa-venus" },
            { "\uf226", "fa-venus-double" },
            { "\uf228", "fa-venus-mars" },
            { "\uf237", "fa-viacoin" },
            { "\uf2a9", "fa-viadeo" },
            { "\uf2aa", "fa-viadeo-square" },
            { "\uf492", "fa-vial" },
            { "\uf493", "fa-vials" },
            { "\uf409", "fa-viber" },
            { "\uf03d", "fa-video" },
            { "\uf4e1", "fa-video-plus" },
            { "\uf4e2", "fa-video-slash" },
            { "\uf6a7", "fa-vihara" },
            { "\uf40a", "fa-vimeo" },
            { "\uf194", "fa-vimeo-square" },
            { "\uf27d", "fa-vimeo-v" },
            { "\uf1ca", "fa-vine" },
            { "\uf189", "fa-vk" },
            { "\uf40b", "fa-vnv" },
            { "\uf897", "fa-voicemail" },
            { "\uf770", "fa-volcano" },
            { "\uf45f", "fa-volleyball-ball" },
            { "\uf6a8", "fa-volume" },
            { "\uf027", "fa-volume-down" },
            { "\uf6a9", "fa-volume-mute" },
            { "\uf026", "fa-volume-off" },
            { "\uf2e2", "fa-volume-slash" },
            { "\uf028", "fa-volume-up" },
            { "\uf771", "fa-vote-nay" },
            { "\uf772", "fa-vote-yea" },
            { "\uf729", "fa-vr-cardboard" },
            { "\uf41f", "fa-vuejs" },
            { "\uf831", "fa-walker" },
            { "\uf554", "fa-walking" },
            { "\uf555", "fa-wallet" },
            { "\uf72a", "fa-wand" },
            { "\uf72b", "fa-wand-magic" },
            { "\uf494", "fa-warehouse" },
            { "\uf495", "fa-warehouse-alt" },
            { "\uf898", "fa-washer" },
            { "\uf2e1", "fa-watch" },
            { "\uf63e", "fa-watch-fitness" },
            { "\uf773", "fa-water" },
            { "\uf774", "fa-water-lower" },
            { "\uf775", "fa-water-rise" },
            { "\uf899", "fa-wave-sine" },
            { "\uf83e", "fa-wave-square" },
            { "\uf89a", "fa-wave-triangle" },
            { "\uf83f", "fa-waze" },
            { "\uf832", "fa-webcam" },
            { "\uf833", "fa-webcam-slash" },
            { "\uf5cc", "fa-weebly" },
            { "\uf18a", "fa-weibo" },
            { "\uf496", "fa-weight" },
            { "\uf5cd", "fa-weight-hanging" },
            { "\uf1d7", "fa-weixin" },
            { "\uf72c", "fa-whale" },
            { "\uf232", "fa-whatsapp" },
            { "\uf40c", "fa-whatsapp-square" },
            { "\uf72d", "fa-wheat" },
            { "\uf193", "fa-wheelchair" },
            { "\uf460", "fa-whistle" },
            { "\uf40d", "fa-whmcs" },
            { "\uf1eb", "fa-wifi" },
            { "\uf6aa", "fa-wifi-1" },
            { "\uf6ab", "fa-wifi-2" },
            { "\uf6ac", "fa-wifi-slash" },
            { "\uf266", "fa-wikipedia-w" },
            { "\uf72e", "fa-wind" },
            { "\uf89b", "fa-wind-turbine" },
            { "\uf776", "fa-wind-warning" },
            { "\uf40e", "fa-window" },
            { "\uf40f", "fa-window-alt" },
            { "\uf410", "fa-window-close" },
            { "\uf2d0", "fa-window-maximize" },
            { "\uf2d1", "fa-window-minimize" },
            { "\uf2d2", "fa-window-restore" },
            { "\uf17a", "fa-windows" },
            { "\uf777", "fa-windsock" },
            { "\uf72f", "fa-wine-bottle" },
            { "\uf4e3", "fa-wine-glass" },
            { "\uf5ce", "fa-wine-glass-alt" },
            { "\uf5cf", "fa-wix" },
            { "\uf730", "fa-wizards-of-the-coast" },
            { "\uf514", "fa-wolf-pack-battalion" },
            { "\uf159", "fa-won-sign" },
            { "\uf19a", "fa-wordpress" },
            { "\uf411", "fa-wordpress-simple" },
            { "\uf297", "fa-wpbeginner" },
            { "\uf2de", "fa-wpexplorer" },
            { "\uf298", "fa-wpforms" },
            { "\uf3e4", "fa-wpressr" },
            { "\uf7e2", "fa-wreath" },
            { "\uf0ad", "fa-wrench" },
            { "\uf497", "fa-x-ray" },
            { "\uf412", "fa-xbox" },
            { "\uf168", "fa-xing" },
            { "\uf169", "fa-xing-square" },
            { "\uf23b", "fa-y-combinator" },
            { "\uf19e", "fa-yahoo" },
            { "\uf840", "fa-yammer" },
            { "\uf413", "fa-yandex" },
            { "\uf414", "fa-yandex-international" },
            { "\uf7e3", "fa-yarn" },
            { "\uf1e9", "fa-yelp" },
            { "\uf157", "fa-yen-sign" },
            { "\uf6ad", "fa-yin-yang" },
            { "\uf2b1", "fa-yoast" },
            { "\uf167", "fa-youtube" },
            { "\uf431", "fa-youtube-square" },
            { "\uf63f", "fa-zhihu" },

            { "\ue000", "ma-folder-map-marker" },
            { "\ue001", "ma-vileda-trolley-damage" },
            { "\ue002", "ma-vileda-check-condition" },
            { "\ue003", "ma-vileda-check-equipment" },
            { "\ue004", "ma-vileda-trolley-prepare" },
            { "\ue005", "ma-vileda-trolley-register" },
            { "\ue006", "ma-vileda-trolley-check" },
            { "\ue008", "ma-borrow" },
            { "\ue009", "ma-return" },
            { "\ue00a", "ma-backspace" },
            { "\ue00b", "ma-towel" },
            { "\ue00c", "ma-toiletroll" },
            { "\ue00d", "ma-rfidscanner" },
            { "\ue00e", "ma-shirt" },
            { "\ue00f", "ma-beacon" },
            { "\ue010", "ma-mop" },
            { "\ue011", "ma-folder-company" },
            { "\ue012", "ma-folder-element" },
            { "\ue013", "ma-folder-user" },
            { "\ue014", "ma-envelope-slash" },
            { "\ue015", "ma-folder-department" },
            { "\ue016", "ma-map-marker-circle" },
            { "\ue017", "ma-map-marker-square" },
            { "\ue018", "ma-bolt-square-slash" },
            { "\ue019", "ma-bolt-square" },
            { "\ue01a", "ma-lock-circle" },
            { "\ue01c", "ma-sign-in-circle" },
            { "\ue01b", "ma-sign-out-circle" },
            { "\ue01d", "ma-key-circle" },
            { "\ue01e", "ma-ophardt-bottles_01" },
            { "\ue01f", "ma-ophardt-bucket_01" },
            { "\ue020", "ma-ophardt-bucket_02" },
            { "\ue021", "ma-ophardt-bucket_03" },
            { "\ue022", "ma-ophardt-check-list-01" },
            { "\ue023", "ma-ophardt-disinfectant_fill-level_01" },
            { "\ue024", "ma-ophardt-disinfectant_fill-level_02" },
            { "\ue025", "ma-ophardt-disinfectant_fill-level_03" },
            { "\ue026", "ma-ophardt-disinfectant_fill-level_04" },
            { "\ue027", "ma-ophardt-feet-01" },
            { "\ue028", "ma-ophardt-female-01" },
            { "\ue029", "ma-ophardt-male-01" },
            { "\ue02a", "ma-ophardt-navi_cancel-01" },
            { "\ue02b", "ma-ophardt-navi_down-01" },
            { "\ue02c", "ma-ophardt-navi_go-01" },
            { "\ue02d", "ma-ophardt-navi_help" },
            { "\ue02e", "ma-ophardt-navi_left-01" },
            { "\ue02f", "ma-ophardt-navi_ok-01" },
            { "\ue030", "ma-ophardt-navi_ok-02" },
            { "\ue031", "ma-ophardt-navi_refresh-01" },
            { "\ue032", "ma-ophardt-navi_right-01" },
            { "\ue033", "ma-ophardt-navi_up-01" },
            { "\ue034", "ma-ophardt-paper-towel-dispenser-01" },
            { "\ue035", "ma-ophardt-paper-towels-01" },
            { "\ue036", "ma-ophardt-paper-towels-02" },
            { "\ue037", "ma-ophard-soap_01" },
            { "\ue038", "ma-ophardt-soap_fill-level_01" },
            { "\ue039", "ma-ophardt-soap_fill-level_02" },
            { "\ue03a", "ma-ophardt-soap_fill-level_03" },
            { "\ue03b", "ma-ophardt-soap_fill-level_04" },
            { "\ue03c", "ma-ophardt-status_01" },
            { "\ue03d", "ma-ophardt-status_02" },
            { "\ue03e", "ma-ophardt-status_03" },
            { "\ue03f", "ma-ophardt-status_04" },
            { "\ue040", "ma-ophardt-toilet-paper_01" },
            { "\ue041", "ma-ophardt-toilet-paper-dispenser_01" },
            { "\ue042", "ma-ophardt-toilet-paper-dispenser_02" },
            { "\ue043", "ma-ophardt-visitor_01" },
            { "\ue044", "ma-ophardt-visitor_02" },
            { "\ue045", "ma-ophardt-visitor_03" },
            { "\ue046", "ma-ophardt-waste-bin_01" },
            { "\ue047", "ma-ophardt-waste-bin_02" },
            { "\ue048", "ma-ophardt-waste-bin_03" },
            { "\ue049", "ma-ophardt-waste-bin_fill-level-01" },
            { "\ue04a", "ma-ophardt-waste-bin_fill-level-02" },
            { "\ue04b", "ma-ophardt-waste-bin_fill-level-03" },
            { "\ue04c", "ma-ophardt-waste-bin_fill-level-04" }
        };
        #endregion

        public string _Tag;
        public String Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }

        private string[] _hybridText;
        public string[] HybridText
        {
            get { return _hybridText; }
            set
            {
                if (value != null)
                {
                    // to list available fonts in iOS, run the following in the iOS project:
                    //foreach (var familyNames in UIFont.FamilyNames.OrderBy(c => c).ToList())
                    //{
                    //    Console.WriteLine(" * " + familyNames);
                    //    foreach (var familyName in UIFont.FontNamesForFamilyName(familyNames).OrderBy(c => c).ToList())
                    //    {
                    //        Console.WriteLine(" *-- " + familyName);
                    //    }
                    //}

                    switch (value[1])
                    {
                        case "ma":
                            FontFamily = "MaxAwesome.ttf#MaxAwesome";
                            break;

                        default:
                        case "fa":
                            FontFamily = "FontAwesomeSolid.ttf#FontAwesome5ProSolid";
                            break;

                        case "fab":
                            FontFamily = "FontAwesomeBrands.ttf#FontAwesome5BrandsRegular";
                            break;

                        case "far":
                            FontFamily = "FontAwesomeRegular.ttf#FontAwesome5ProRegular";
                            break;

                        case "fal":
                            FontFamily = "FontAwesomeLight.ttf#FontAwesome5ProLight";
                            break;
                    }

                    Text = value[0];
                } else {
                    Text = "";
                }

                _hybridText = value;
            }
        }

        public static readonly BindableProperty HybridTextProperty =
            BindableProperty.Create("HybridText", typeof(string[]), typeof(FontAwesomeIcon), null, propertyChanged: OnHybridTextChanged);

        // override old Text property
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string[]), typeof(FontAwesomeIcon), null, propertyChanged: OnTextChanged);

        static void OnHybridTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((FontAwesomeIcon)bindable).HybridText = (string[])newValue;
        }

        static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((FontAwesomeIcon)bindable).HybridText = (string[])newValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FontAwesomeIcon"/> class.
        /// </summary>
        public FontAwesomeIcon()
        {
#if ANDROID 
            FontFamily = "FontAwesomeSolid.ttf#FontAwesome5ProSolid";
#elif IOS
            FontFamily = "FontAwesome5Pro-Solid";
#else
            FontFamily = "FontAwesomeSolid.ttf#FontAwesome5ProSolid";
#endif
            FontSize = 18;
            Padding = 0;
        }

        public static Size GetSize(string[] icon, double fontSize = 18)
        {
            TextMeter meter = new TextMeter();

            switch (icon[1]) {
                case "ma":
                    return meter.MeasureTextSize(icon[0], 1000000, fontSize, "MaxAwesome.ttf#MaxAwesome");

                default:
                case "fa":
                    return meter.MeasureTextSize(icon[0], 1000000, fontSize, "FontAwesomeSolid.ttf#FontAwesome5ProSolid");

                case "fab":
                    return meter.MeasureTextSize(icon[0], 1000000, fontSize, "FontAwesomeBrands.ttf#FontAwesome5BrandsRegular");

                case "far":
                    return meter.MeasureTextSize(icon[0], 1000000, fontSize, "FontAwesomeRegular.ttf#FontAwesome5ProRegular");

                case "fal":
                    return meter.MeasureTextSize(icon[0], 1000000, fontSize, "FontAwesomeLight.ttf#FontAwesome5ProLight");
            }
        }
    }
}