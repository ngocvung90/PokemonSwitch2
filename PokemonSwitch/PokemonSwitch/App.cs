using PokemonSwitch.DB;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PokemonSwitch
{
    public class App : Application
    {
        public static SQliteDBHelper _dbHelper = null;
        Dictionary<int, List<MapSaver>> dicStepToMap = new Dictionary<int, List<MapSaver>>();
        MapSaver mapServer = new MapSaver();
        public App()
        {
            //string strMapFull = DependencyService.Get<ISaveAndLoad>().LoadText("map.txt");
            //string strAnswerFull = DependencyService.Get<ISaveAndLoad>().LoadText("answer.txt");
            //BuidMap(strMapFull);
            Map map = new Map();
            //map.SetMap(dicStepToMap, 2);
            // The root page of your application
            MainPage = map;
        }

        public App(string dbPath, ISQLitePlatform sqlitePlatform)
        {
            _dbHelper = new SQliteDBHelper(sqlitePlatform, dbPath);
            List<Gate> listGate = _dbHelper.GetGates();
            //string strMapFull = DependencyService.Get<ISaveAndLoad>().LoadText("map.txt");
            //string strAnswerFull = DependencyService.Get<ISaveAndLoad>().LoadText("answer.txt");
            //BuidMap(strMapFull);
            BuildMap(listGate);
            Map map = new Map();
            Setting setting = _dbHelper.GetSetting();
            if (setting == null)
                map.SetMap(dicStepToMap, 2);
            else
                map.SetMap(dicStepToMap, setting.LevelID, setting.GateIndex, setting.PairImageName);
            // The root page of your application
            MainPage = map;
        }

        private void BuildMap(List<Gate> listGate)
        {
            foreach(Gate gate in listGate)
            {
                int key = gate.LevelID;
                bool[] arrStyle = stringToArrayBool(gate.Map);
                MapSaver map = new MapSaver(key, arrStyle, null);
                if(dicStepToMap.ContainsKey(key))
                    dicStepToMap[key].Add(map);
                else
                {
                    dicStepToMap.Add(key, new List<MapSaver>());
                    dicStepToMap[key].Add(map);
                }
            }
        }
        private bool[] stringToArrayBool(string str)
        {
            bool[] arr = new bool[16];
            string[] arrMapLevel = str.Split(new String[] { "\r\n" }, StringSplitOptions.None);
            for(int i = 0; i < arrMapLevel.Length; i++)
            {
                string row = arrMapLevel[i];
                string[] arrRow = row.Split(' ');
                for(int j = 0; j < arrRow.Length; j ++)
                {
                    if(arrRow[j].Trim() != "")
                    {
                        arr[i * 4 + j] = Boolean.Parse(arrRow[j]);
                    }
                }
            }
            return arr;
        }
        private void BuidMap(string strMapFull)
        {
            string[] arrMapLevel = strMapFull.Split(new String[] { "\r\n" }, StringSplitOptions.None);
            string[] arrAnswer = strMapFull.Split(new String[] { "\r\n" }, StringSplitOptions.None);
            int nCountStep = -1;
            int nMap = 0;
            for (int i = 0; i < arrMapLevel.Length; i++)
            {
                int tmpCount = -1;
                if (arrMapLevel[i] == "") { nCountStep = -1; continue; }
                else if (Int32.TryParse(arrMapLevel[i], out tmpCount))
                {
                    nCountStep = tmpCount;
                    dicStepToMap.Add(nCountStep, new List<MapSaver>());
                }
                else
                {
                    mapServer = new MapSaver();
                    mapServer.nSolvedStep = nCountStep;
                    mapServer.listResult = GetListNodeAnswer(arrAnswer[nMap]);
                    mapServer.arrStyle = new bool[16];
                    for(int j = 0; j < 4; j ++)
                    {
                        string row = arrMapLevel[j + i];
                        if (MakeEachRow(row, j) == false) break;
                    }
                    i += 4;
                    dicStepToMap[nCountStep].Add(mapServer);
                    nMap++;
                }
            }
        }

        private List<Node> GetListNodeAnswer(string strListNode)
        {
            List<Node> listNode = new List<Node>();
            string[] arrNodeIndex = strListNode.Split(' ');
            for(int i = 0; i < arrNodeIndex.Length; i ++)
            {
                if(arrNodeIndex[i] != "")
                {
                    Node node = new Node();
                    Int32.TryParse(arrNodeIndex[i], out node.index);
                    node.x = node.index / 4; node.y = node.index % 4;
                    listNode.Add(node);
                }
            }
            return listNode;
        }

        bool MakeEachRow(string row, int rowIndex)
        {
            string[] arrRow = row.Split(' ');
            if (arrRow.Length < 4) return false;
            for(int i = 0; i < 4; i ++)
            {
                if (arrRow[i] != "")
                    mapServer.arrStyle[i + rowIndex * 4] = Boolean.Parse(arrRow[i]);
            }
            return true;
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
