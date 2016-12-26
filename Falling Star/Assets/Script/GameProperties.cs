using System;
using UnityEngine;

namespace Assets.Script
{
    static class GameProperties
    {

        public const string AD_ENABLE = "adenable";
        public const string AD_INTERSTITIAL_GAME_SIZE = "interstitialGameSize";
        public const string AD_REWARD_GAME_SIZE = "rewardSize";
        public const string AD_REWARD_EARN_POINT = "rewardPoint";
        public const string GAME_PLAY_COUNT = "gameplaycount";
        

        static public bool StatusAD
        {
            get
            {
                return Convert.ToBoolean(PlayerPrefs.GetInt(AD_ENABLE, 1));
            }
        }

        static public int RewardGameSize
        {
            get
            {
                return PlayerPrefs.GetInt(AD_REWARD_GAME_SIZE, 15);
            }
        }
        static public int InterstitialGameSize
        {
            get
            {
                return PlayerPrefs.GetInt(AD_INTERSTITIAL_GAME_SIZE, 7);
            }
        }

        static public uint GamePlayCount
        {
            get
            {
                return Convert.ToUInt32(PlayerPrefs.GetInt(GAME_PLAY_COUNT, 0));
            }
        }

        static public void IncGamePlayCount()
        {
            uint count = GamePlayCount;
            count++;
            PlayerPrefs.SetInt(GAME_PLAY_COUNT, Convert.ToInt32(count));
        }
    }
}
