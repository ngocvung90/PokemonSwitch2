using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Interop;

namespace PokemonSwitch.DB
{

    public class SQliteDBHelper
    {
        SQLiteConnection conn = null;
        public SQliteDBHelper(ISQLitePlatform platform, string dbPath)
        {
            if(conn == null)
            {
                conn = new SQLiteConnection(platform, dbPath);
                conn.CreateTable<PairImage>();
                conn.CreateTable<Level>();
                conn.CreateTable<Gate>();
                conn.CreateTable<Setting>();
            }
        }

        #region PairImage access
        public List<PairImage> GetPairImages()
        {
            return conn.Table<PairImage>().ToList();
        }
        #endregion
        #region Level Access
        public List<Level> GetLevels()
        {
            return conn.Table<Level>().ToList();
        }
        public Level GetLevel(int solveStep)
        {
            return conn.Get<Level>(solveStep);
        }
        #endregion
        #region Gate Access
        public List<Gate> GetGates()
        {
            return conn.Table<Gate>().ToList();
        }
        public List<Gate> GetGatesFromLevel(int LevelID)
        {
            string query = String.Format("select * from Gate where LevelID = ?");
            List<Gate> listGate = conn.Query<Gate>(query, new object[] { LevelID }).ToList();
            return listGate;
        }

        public Gate GetGate(int levelID, int GateIndex)
        {
            string query = String.Format("select * from Gate where LevelID = ? AND GateIndex = ?");
            List<Gate> listGate = conn.Query<Gate>(query, new object[]{ levelID, GateIndex }).ToList();
            if (listGate.Count > 0) return listGate[0];
            return null;
        }
        public void UpdateGate(Gate gate)
        {
            string query = String.Format("update Gate set Star = ? where gateIndex = ? And LevelID = ?");
            conn.Query<Gate>(query, new object[] { gate.Star, gate.GateIndex, gate.LevelID});
            //conn.Update(gate);
        }
        #endregion
        #region Setting access
        public Setting GetSetting()
        {
            List<Setting> listSetting = conn.Table<Setting>().ToList();
            if (listSetting.Count > 0) return listSetting[0];
            return null;
        }
        public void UpdateSetting(Setting currentSetting)
        {
            conn.Update(currentSetting);
        }
        #endregion
    }
}
