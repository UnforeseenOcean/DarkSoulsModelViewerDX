﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsModelViewerDX.DbgMenus
{
    public class DbgMenuItemSpawnObj : DbgMenuItem
    {
        private readonly int[] possibleObjIDs = new int[]
        {
            0020,
            0100,
            0101,
            0105,
            0106,
            0110,
            0150,
            0200,
            0201,
            0300,
            0500,
            0502,
            0503,
            0504,
            1000,
            1001,
            1002,
            1010,
            1011,
            1020,
            1030,
            1031,
            1040,
            1041,
            1042,
            1048,
            1049,
            1050,
            1051,
            1052,
            1055,
            1056,
            1057,
            1058,
            1060,
            1061,
            1062,
            1063,
            1064,
            1065,
            1066,
            1067,
            1068,
            1069,
            1070,
            1071,
            1072,
            1073,
            1074,
            1075,
            1076,
            1077,
            1078,
            1079,
            1080,
            1100,
            1110,
            1111,
            1112,
            1120,
            1121,
            1122,
            1125,
            1126,
            1129,
            1130,
            1131,
            1132,
            1133,
            1134,
            1135,
            1136,
            1140,
            1145,
            1146,
            1150,
            1151,
            1152,
            1153,
            1154,
            1155,
            1156,
            1160,
            1162,
            1163,
            1170,
            1172,
            1173,
            1175,
            1176,
            1190,
            1200,
            1201,
            1202,
            1205,
            1206,
            1207,
            1208,
            1209,
            1210,
            1211,
            1212,
            1213,
            1214,
            1215,
            1216,
            1217,
            1218,
            1219,
            1220,
            1223,
            1224,
            1230,
            1231,
            1232,
            1233,
            1240,
            1241,
            1242,
            1243,
            1244,
            1250,
            1251,
            1252,
            1270,
            1271,
            1290,
            1300,
            1301,
            1302,
            1303,
            1305,
            1306,
            1308,
            1309,
            1310,
            1311,
            1312,
            1313,
            1314,
            1315,
            1316,
            1317,
            1318,
            1319,
            1320,
            1321,
            1322,
            1323,
            1330,
            1340,
            1350,
            1351,
            1357,
            1358,
            1400,
            1401,
            1402,
            1403,
            1404,
            1405,
            1406,
            1407,
            1408,
            1409,
            1410,
            1411,
            1412,
            1413,
            1414,
            1415,
            1416,
            1417,
            1418,
            1419,
            1420,
            1421,
            1450,
            1460,
            1465,
            1470,
            1475,
            1480,
            1481,
            1490,
            1495,
            1496,
            1497,
            1500,
            1510,
            1511,
            1512,
            1513,
            1520,
            1521,
            1530,
            1540,
            1550,
            1560,
            1570,
            1571,
            1580,
            1600,
            1601,
            1602,
            1603,
            1604,
            1605,
            1610,
            1700,
            1701,
            1702,
            1703,
            1710,
            1711,
            1712,
            1713,
            1800,
            1801,
            1802,
            1900,
            1910,
            1915,
            1916,
            1920,
            1930,
            1940,
            1945,
            1946,
            1950,
            1960,
            1965,
            1966,
            1967,
            2000,
            2100,
            2110,
            2111,
            2120,
            2130,
            2131,
            2200,
            2201,
            2202,
            2203,
            2250,
            2251,
            2252,
            2253,
            2300,
            2400,
            2401,
            2402,
            2403,
            2450,
            2600,
            2601,
            2610,
            2611,
            2612,
            2613,
            2620,
            2621,
            2630,
            2700,
            2701,
            2710,
            2720,
            2730,
            2731,
            2732,
            2740,
            2750,
            2760,
            2765,
            2770,
            2780,
            2785,
            2790,
            2791,
            2795,
            2800,
            2801,
            2900,
            2901,
            2902,
            2903,
            2904,
            2905,
            2906,
            2907,
            2908,
            2909,
            2910,
            2911,
            2912,
            2913,
            2914,
            2915,
            2916,
            2917,
            2918,
            2919,
            2920,
            3000,
            3001,
            3010,
            3011,
            3020,
            3021,
            3030,
            3031,
            3032,
            3033,
            3034,
            3035,
            3036,
            3040,
            3041,
            3042,
            3043,
            3044,
            3045,
            3046,
            3047,
            3048,
            3050,
            3051,
            3052,
            3053,
            3060,
            3100,
            3101,
            3102,
            3140,
            3141,
            3142,
            3143,
            3144,
            3240,
            3241,
            3242,
            3243,
            3300,
            3301,
            3302,
            3310,
            3311,
            3312,
            3320,
            3321,
            3350,
            3400,
            3450,
            3451,
            3452,
            3500,
            3501,
            3600,
            3610,
            3611,
            3612,
            3650,
            3651,
            3652,
            3653,
            3654,
            3660,
            3661,
            3870,
            3871,
            3872,
            3873,
            3880,
            3881,
            3890,
            3900,
            3901,
            3902,
            3910,
            3950,
            3951,
            3952,
            3953,
            3954,
            3955,
            3960,
            3961,
            3962,
            3963,
            3964,
            3965,
            3970,
            3971,
            3972,
            3973,
            4000,
            4001,
            4002,
            4003,
            4050,
            4100,
            4101,
            4102,
            4103,
            4104,
            4105,
            4106,
            4107,
            4108,
            4109,
            4110,
            4111,
            4112,
            4113,
            4114,
            4115,
            4116,
            4117,
            4118,
            4119,
            4120,
            4121,
            4122,
            4123,
            4124,
            4125,
            4200,
            4201,
            4202,
            4215,
            4300,
            4301,
            4302,
            4303,
            4304,
            4305,
            4350,
            4351,
            4352,
            4353,
            4360,
            4361,
            4362,
            4370,
            4400,
            4401,
            4402,
            4404,
            4405,
            4406,
            4407,
            4408,
            4409,
            4410,
            4411,
            4450,
            4451,
            4460,
            4461,
            4500,
            4510,
            4550,
            4560,
            4570,
            4600,
            4610,
            4611,
            4620,
            4621,
            4622,
            4623,
            4624,
            4625,
            4626,
            4627,
            4628,
            4629,
            4630,
            4631,
            4632,
            4633,
            4634,
            4635,
            4636,
            4637,
            4700,
            4701,
            4800,
            4810,
            4820,
            4830,
            4840,
            4850,
            4900,
            4901,
            4950,
            4951,
            4952,
            4953,
            4954,
            4955,
            4956,
            4957,
            4958,
            4960,
            4961,
            4962,
            4963,
            4964,
            4965,
            4966,
            4967,
            4968,
            4969,
            4970,
            4971,
            4972,
            4973,
            5000,
            5010,
            5040,
            5100,
            5110,
            5120,
            5130,
            5140,
            5150,
            5151,
            5152,
            5153,
            5154,
            5155,
            5200,
            5210,
            5220,
            5250,
            5300,
            5301,
            5310,
            5400,
            5401,
            5402,
            5403,
            5404,
            5410,
            5500,
            5501,
            5510,
            5520,
            5550,
            5551,
            5552,
            5560,
            5561,
            5570,
            5580,
            5590,
            5600,
            5610,
            5611,
            5612,
            5620,
            5630,
            5650,
            5651,
            5652,
            5653,
            5654,
            5655,
            5700,
            5710,
            5720,
            5730,
            5740,
            5750,
            5760,
            5800,
            5801,
            5810,
            5850,
            5860,
            5861,
            5862,
            5863,
            5864,
            5865,
            5866,
            5867,
            5868,
            5869,
            5870,
            5871,
            5900,
            5905,
            5906,
            5910,
            5911,
            5920,
            5930,
            5940,
            5950,
            5951,
            5952,
            5960,
            5965,
            5966,
            5967,
            5968,
            5969,
            5970,
            5971,
            5972,
            5980,
            5981,
            5982,
            5983,
            5990,
            5998,
            5999,
            6000,
            6010,
            6100,
            6110,
            6200,
            6400,
            6401,
            6410,
            6450,
            6451,
            6452,
            6455,
            6456,
            6457,
            6500,
            6600,
            6601,
            6602,
            6603,
            6604,
            6605,
            6606,
            6607,
            6700,
            7100,
            7199,
            7200,
            7201,
            7202,
            7210,
            7220,
            7230,
            7231,
            7240,
            7241,
            7250,
            7251,
            7300,
            7301,
            7302,
            7303,
            7400,
            7401,
            7402,
            7403,
            7404,
            7500,
            7501,
            7510,
            7600,
            7601,
            7610,
            7620,
            7621,
            7630,
            7640,
            7641,
            7650,
            7670,
            7680,
            7690,
            7700,
            7900,
            7901,
            7902,
            7906,
            7907,
            7908,
            8000,
            8050,
            8051,
            8100,
            8150,
            8200,
            8300,
            8310,
            8311,
            8312,
            8320,
            8400,
            8401,
            8402,
            8403,
            8404,
            8410,
            8411,
            8420,
            8421,
            8422,
            8425,
            8430,
            8500,
            8501,
            8510,
            8511,
            8520,
            8521,
            8530,
            8531,
            8540,
            8541,
            8542,
            8543,
            8544,
            8549,
            8550,
            8600,
            8601,
            8610,
            8700,
            8701,
            8702,
            8950,
            8951,
            8952,
            8953,
            8999,
            9000,
            9001,
            9002,
            9003,
            9100,
            9200,
            9800,
            9990,
            9991,
            9992,
            9993,
            9994,
            9995,
            9998,
            9999,
        };

        public int ChrIdIndex = 0;


        public DbgMenuItemSpawnObj()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            Text = $"Click to Spawn OBJ [ID: <o{possibleObjIDs[ChrIdIndex]:D4}>]";
        }

        public override void OnIncrease(bool isRepeat, int incrementAmount)
        {
            int prevIndex = ChrIdIndex;
            ChrIdIndex += incrementAmount;

            //If upper bound reached
            if (ChrIdIndex >= possibleObjIDs.Length)
            {
                //If already at end and just tapped button
                if (prevIndex == possibleObjIDs.Length - 1 && !isRepeat)
                    ChrIdIndex = 0; //Wrap Around
                else
                    ChrIdIndex = possibleObjIDs.Length - 1; //Stop
            }

            UpdateText();
        }

        public override void OnDecrease(bool isRepeat, int incrementAmount)
        {
            int prevIndex = ChrIdIndex;
            ChrIdIndex -= incrementAmount;

            //If upper bound reached
            if (ChrIdIndex < 0)
            {
                //If already at end and just tapped button
                if (prevIndex == 0 && !isRepeat)
                    ChrIdIndex = possibleObjIDs.Length - 1; //Wrap Around
                else
                    ChrIdIndex = 0; //Stop
            }

            UpdateText();
        }

        public override void OnResetDefault()
        {
            ChrIdIndex = 0;
            UpdateText();
        }

        public override void OnClick()
        {
            GFX.ModelDrawer.AddObj(possibleObjIDs[ChrIdIndex], Transform.Zero);
        }
    }
}
